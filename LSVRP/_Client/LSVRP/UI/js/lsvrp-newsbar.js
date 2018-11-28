var state = false;


function showRadio() {
    if (!state) {
        var radio = document.getElementById("newsbar");
        radio.classList.remove('radioAnimHide');
        radio.classList.add('radioAnimShow');
        var radio2 = document.getElementById("newsbar-highlight");
        radio2.classList.remove('radioAnimHide2');
        radio2.classList.add('radioAnimShow2');
        state = true;
        blink(false);
    } else {
        var radio = document.getElementById("newsbar");
        radio.classList.remove('radioAnimShow');
        radio.classList.add('radioAnimHide');
        var radio2 = document.getElementById("newsbar-highlight");
        radio2.classList.remove('radioAnimShow2');
        radio2.classList.add('radioAnimHide2');
        state = false;
    }
}

function setMessage(name, type, content, show) {
    var nameDiv = document.getElementById("ns-author");
    var titleDiv = document.getElementById("ns-title");
    var contentDiv = document.getElementById("ns-content");
    var msg = content.replace(/<(?:.|\n)*?>/gm, '');
    nameDiv.innerHTML = name;
    titleDiv.innerHTML = type;
    contentDiv.innerHTML = msg;
    blink(true);
    if (show) {
        var radio = document.getElementById("newsbar");
        radio.classList.remove('radioAnimHide');
        radio.classList.add('radioAnimShow');
        var radio2 = document.getElementById("newsbar-highlight");
        radio2.classList.remove('radioAnimHide2');
        radio2.classList.add('radioAnimShow2');
        state = true;
        blink(false);
    }
}

function blink(st) {
    if (st && !state) {
        var blink = document.getElementById("newsbar-highlight");
        blink.classList.add('blinkAnim');
    } else {
        var blink = document.getElementById("newsbar-highlight");
        blink.classList.remove('blinkAnim');
    }
}