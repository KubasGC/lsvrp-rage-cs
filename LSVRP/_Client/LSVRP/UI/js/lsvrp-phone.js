
var viewingContact = 0;

function playButtonSound() {
    let audioSound = new Audio("sounds/phone/buttons/2.ogg");
    audioSound.volume = 0.3;
    audioSound.play();
}

function changeWallpaper(num) {
    document.getElementById("phone-wallpaper").style.backgroundImage = `url('../ui/img/phone/wallpapers/${num}.png')`;
    playButtonSound();
}

function showSettings(state) {
    playButtonSound();
    if (state) {
        document.getElementById("phone-clock-main").style.display = "none";
        document.getElementById("phone-icons").style.display = "none";
        document.getElementById("phone-app-bg").style.display = "block";
        document.getElementById("phone-app-settings").style.display = "block";
    } else {
        document.getElementById("phone-clock-main").style.display = "block";
        document.getElementById("phone-icons").style.display = "block";
        document.getElementById("phone-app-bg").style.display = "none";
        document.getElementById("phone-app-settings").style.display = "none";
    }
}

function showPhone(state) {
    playButtonSound();
    if (state) {
        document.getElementById("phone-clock-main").style.display = "none";
        document.getElementById("phone-icons").style.display = "none";
        document.getElementById("phone-app-bg").style.display = "block";
        document.getElementById("phone-app-phone").style.display = "block";
    } else {
        document.getElementById("phone-clock-main").style.display = "block";
        document.getElementById("phone-icons").style.display = "block";
        document.getElementById("phone-app-bg").style.display = "none";
        document.getElementById("phone-app-phone").style.display = "none";
    }
}

function showSettingsWallpaper(state) {
    playButtonSound();
    if (state) {
        document.getElementById("phone-app-settings").style.display = "block";
        document.getElementById("phone-app-settings-wallpaper").style.display = "block";
    } else {
        document.getElementById("phone-app-settings").style.display = "block";
        document.getElementById("phone-app-settings-wallpaper").style.display = "none";
    }
}

function showSettingsWallpaperPremium(state) {
    playButtonSound();
    if (state) {
        document.getElementById("phone-app-settings").style.display = "block";
        document.getElementById("phone-app-settings-wallpaper-premium").style.display = "block";
    } else {
        document.getElementById("phone-app-settings").style.display = "block";
        document.getElementById("phone-app-settings-wallpaper-premium").style.display = "none";
    }
}

function showContacts(state) {
    playButtonSound();
    if (state) {
        document.getElementById("phone-clock-main").style.display = "none";
        document.getElementById("phone-icons").style.display = "none";
        document.getElementById("phone-app-bg").style.display = "block";
        document.getElementById("phone-app-contacts").style.display = "block";
    } else {
        document.getElementById("phone-app-contacts").style.display = "none";
        showHome();
    }
}

function prepareContactInfo(contactId) {
    mp.trigger("client.phone.prepareContactInfo", contactId);
}

function showContactInfo(contactName, contactNumber) {
    playButtonSound();
    if (contactName != "") {
        document.getElementById("contactDetailNameHeader").innerHTML = contactName;
        document.getElementById("contactDetailAvatar").innerHTML = contactName.charAt(0);
        document.getElementById("contactDetailName").value = contactName;
        document.getElementById("contactDetailNumber").value = contactNumber;
        document.getElementById("phone-app-contacts-show").style.display = "block";
    } else {
        document.getElementById("phone-app-contacts-show").style.display = "none";
    }
}

function prepareConversations() {
    mp.trigger("client.phone.prepareConversations");
}

function showConversations($state) {
    playButtonSound();
    if ($state) {
        document.getElementById("phone-clock-main").style.display = "none";
        document.getElementById("phone-icons").style.display = "none";
        document.getElementById("phone-app-bg").style.display = "block";
        document.getElementById("phone-app-messages").style.display = "block";
    } else {
        document.getElementById("phone-app-messages").style.display = "none";
        showHome();
    }
}

function showIncommingCall($state) {
    if ($state) {
        document.getElementById("phone-clock-main").style.display = "none";
        document.getElementById("phone-icons").style.display = "none";
        document.getElementById("phone-app-bg").style.display = "block";
        document.getElementById("phone-app-incomming-call").style.display = "block";
    } else {
        document.getElementById("phone-app-incomming-call").style.display = "none";
        showHome();
    }
}

function prepareMessages($convId, $conName) {
    mp.trigger("client.phone.prepareMessages", $convId, $conName);
}

function showAllMessages($state) {
    playButtonSound();
    if (!$state) {
        document.getElementById("phone-app-messages-show").style.display = "none";
    } else {
        document.getElementById("phone-app-messages-show").style.display = "block";
    }
}

function resetValues() {
    document.getElementById("phone-app-phone-number-input").value = "";
    document.getElementById("phone-app-wallpaper-premium-link").value = "";
}

function showHome() {
    playButtonSound();
    document.getElementById("phone-clock-main").style.display = "block";
    document.getElementById("phone-icons").style.display = "block";
    document.getElementById("phone-app-bg").style.display = "none";
    document.getElementById("phone-app-settings").style.display = "none";
    document.getElementById("phone-app-settings-wallpaper").style.display = "none";
    document.getElementById("phone-app-settings-wallpaper-premium").style.display = "none";
    document.getElementById("phone-app-phone").style.display = "none";
    document.getElementById("phone-app-contacts").style.display = "none";
    document.getElementById("phone-app-messages").style.display = "none";

    resetValues();
}

function savePremiumWallpaper() {
    playButtonSound();
    var link = document.getElementById("phone-app-wallpaper-premium-link").value;
    document.getElementById("phone-wallpaper").style.backgroundImage = `url('${link}')`;
    document.getElementById("phone-app-wallpaper-premium-link").value = "";
    mp.trigger("client.phone.savePremiumWallpaper", link);
    showHome();
}

function saveStandardWallpaper(wallpaperId) {
    mp.trigger("client.phone.saveStandardWallpaper", wallpaperId);
}

function setPremiumWallpaper(link) {
    document.getElementById("phone-wallpaper").style.backgroundImage = `url('${link}')`;
}

function phoneCallInsert($symbol) {
    playButtonSound();
    document.getElementById("phone-app-phone-number-input").value =
        document.getElementById("phone-app-phone-number-input").value + $symbol;
}

function phoneCallRemove() {
    playButtonSound();
    var text = document.getElementById("phone-app-phone-number-input");
    text.value = text.value.substring(0, text.value.length - 1);
}

function phoneSetGsmName(name) {
    document.getElementById("phone-notification-bar").innerHTML = `&#128225;${name}`;
}

function phoneToggle($state) {
    if ($state) {
        document.getElementById("phone-main").style.display = "block";
        document.getElementById("phone-wallpaper").style.display = "block";
        document.getElementById("phone-notification-bar").style.display = "block";
    } else {
        showHome();
        document.getElementById("phone-main").style.display = "none";
        document.getElementById("phone-wallpaper").style.display = "none";
        document.getElementById("phone-notification-bar").style.display = "none";
    }
}

window.onload = function() {
    setInterval(function() {
            var d = new Date();
            var h = d.getHours();
            var m = d.getMinutes();

            document.getElementById("phone-clock-main").innerHTML = `${zeroFill(h)}:${zeroFill(m)}`;
        },
        5000);
};

function zeroFill(i) {
    return (i < 10 ? '0' : '') + i;
}

function LoadContacts(data) {
    listContent = JSON.parse(data);
    var output = "";
    for (var i = 0; i < listContent.length; i++) {
        output =
            `${output}<div class="phone-app-list-item" onclick="prepareContactInfo(${listContent[i].data
            });"><div class="phone-app-contacts-avatar">${listContent[i].text.charAt(0)}</div>${listContent[i].text
            }</div>`;
    }
    document.getElementById("phoneContactsList").innerHTML = output;
}

function loadConversations(data) {
    listContent = JSON.parse(data);
    var output = "";
    for (var i = 0; i < listContent.length; i++) {
        //output = `${output}<div class="phone-app-list-item" onclick="prepareContactInfo(${listContent[i].data});"><div class="phone-app-contacts-avatar">${listContent[i].text.charAt(0)}</div>${listContent[i].text}</div>`;\
        var unix = Math.round(+new Date() / 1000);
        var d = new Date(listContent[i].timestamp * 1000);
        output =
            `${output}<div class="phone-app-list-item messages-list" onclick="prepareMessages(${listContent[i].id},'${
            listContent[i].name}');"><div class="phone-app-contacts-avatar">${listContent[i].name.charAt(0)
            }</div><div class="phone-app-messages-name">${listContent[i].name
            }</div><div class="phone-app-messages-date">${d.getHours()}:${d.getMinutes()}</div></div>`;
    }
    document.getElementById("conversationsList").innerHTML = output;
    showConversations(true);
}

function loadMessages(data) {
    listContent = JSON.parse(data);
    var output = "";
    var name = "";
    for (var i = 0; i < listContent.length; i++) {
        //output = `${output}<div class="phone-app-list-item" onclick="prepareContactInfo(${listContent[i].data});"><div class="phone-app-contacts-avatar">${listContent[i].text.charAt(0)}</div>${listContent[i].text}</div>`;\
        var unix = Math.round(+new Date() / 1000);
        var d = new Date(listContent[i].timestamp * 1000);
        if (listContent[i].received) {
            output =
                `${output}<div class="phone-message-sender">${listContent[i].message
                }<div class="phone-message-author">${listContent[i].name} | ${d.getHours()}:${d.getMinutes()
                }</div></div>`;
        } else {
            output =
                `${output}<div class="phone-message-own">${listContent[i].message
                }<div class="phone-message-author">Ja | ${d.getHours()}:${d.getMinutes()}</div></div>`;
        }
        name = listContent[i].name;
    }
    document.getElementById("convMessagesList").innerHTML = output;
    document.getElementById("messName").innerHTML = name;
    showAllMessages(true);
}

function sendMessage() {
    var mess = document.getElementById("phone-messages-input");
    if (mess.value != "") {
        mp.trigger("client.phone.sendMessage", [mess.value]);
        mess.value = "";
        playButtonSound();
    }
}