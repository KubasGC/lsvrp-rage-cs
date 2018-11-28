jQuery(function($) {
    $("#loginButton").click(function() {
        var Username = $("#username").val();
        var Password = $("#password").val();
        if (Username.length > 3 && Password.length > 3) {
            toggleLoginButton(true);
            resourceCall("tryLogIn", Username, Password);
        }
    });

    // POSTACIE
    $('.postacie-li').on("click",
        function() {
            $('.postacie-li').removeClass("selected");
            $(this).addClass("selected");
        });
});

function ChooseChar(Elem) {
    var CharID = Number($(Elem).val());
    if (Number.isInteger(CharID)) {
        resourceCall("ChooseChar", Number(CharID));
    }
}

function HideWindow() {
    $("#content").fadeOut(1000,
        function() {
            resourceCall("DestroyBrowser");
        });
}

function toggleLoginButton(state) {
    if (state) {
        $("#ButtonID").hide();
        $("#ProgressID").show();
    } else {
        $("#ButtonID").show();
        $("#ProgressID").hide();
    }
}

function ShowCharacters(Characters) {
    Characters = JSON.parse(Characters);
    $("#LoginContent").fadeOut(1000,
        function() {
            $("#CharactersContent").fadeIn(1000);
        });
    for (i = 0; i < Characters.length; i++) {
        $("#tbodyChar").append('<tr><td style="width: 10%;">' +
            Characters[i][0] +
            '</td><td style="width: 30%">' +
            Characters[i][1] +
            '</td> <td style="width: 10%">' +
            Characters[i][2] +
            ' lat</td><td style="width: 15%;">' +
            Characters[i][3] +
            '</td><td style="width: 25%;">0h 0min</td><td style="width: 10%;"><button name="Char" onclick="ChooseChar(this)" value="' +
            Characters[i][0] +
            '" class="btn btn-small waves-effect waves-light"> <i class="material-icons">input</i></button></td></tr>');
    }
}