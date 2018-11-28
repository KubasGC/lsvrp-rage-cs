let chat =
{
    size: 0,
    container: null,
    input: null,
    enabled: false,
    active: true,
    previous: "",
};


let isChatBlocked = false;

function blockChat(state) {
    isChatBlocked = state;
}

function enableChatInput(enable) {
    if (chat.active === false && enable === true)
        return;

    if (isChatBlocked)
        return;

    if (enable != (chat.input != null)) {
        mp.invoke("focus", enable);

        if (enable) {
            chat.input = $("#chat").append('<div><input id="chat_msg" type="text" spellcheck="false"/></div>')
                .children(":last");
            chat.input.children("input").focus();
            document.getElementById('scrollbar_style').innerHTML = '::-webkit-scrollbar{width: 5px; height: 5px;}';
            mp.trigger("cef.chat.focusChat", true);
        } else {
            chat.input.fadeOut('fast',
                function() {
                    chat.input.remove();
                    chat.input = null;
                    mp.trigger("cef.chat.focusChat", false);
                });
            document.getElementById('scrollbar_style').innerHTML = '::-webkit-scrollbar{width: 0px; height: 5px;}';
        }
    }
}

var chatAPI =
{
    push: (text) => {
        chat.container.append("<li>" + text + "</li>");
        $('#chat_messages').scrollTop($('#chat_messages')[0].scrollHeight);
        chat.size++;

        if (chat.size >= 50) {
            chat.container.children(":first").remove();
        }
    },

    clear: () => {
        chat.container.html("");
    },

    activate: (toggle) => {
        if (toggle == false && (chat.input != null))
            enableChatInput(false);

        chat.active = toggle;
    },

    show: (toggle) => {
        if (toggle)
            $("#chat").show();
        else
            $("#chat").hide();

        chat.active = toggle;
    }
};


$(document).ready(function() {
    chat.container = $("#chat ul#chat_messages");

    $(".ui_element").show();
    chatAPI.push("Uruchomiono czat LSVRP...");

    $("body").keydown(function(event) {
        if (event.which === 84 && chat.input == null && chat.active === true) {
            enableChatInput(true);
            event.preventDefault();
        } else if (event.which === 13 && chat.input != null) {
            let value = chat.input.children("input").val();
            if (value.length > 0) {
                chat.previous = value;
                if (value[0] === "/") {
                    value = value.substr(1);

                    if (value.length > 0)
                        mp.invoke("command", value);
                } else {
                    mp.invoke("chatMessage", value);
                }
            }

            enableChatInput(false);
        } else if (event.which === 38) //strzałka w górę
        {
            chat.input.children("input").val(chat.previous);
        }
    });

});