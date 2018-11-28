var helpWindow = false;

function changeTab(evt, category) {
    var i, x, tablinks;
    x = document.getElementsByClassName("help-tab");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablink");
    for (i = 0; i < x.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" selected", "");
    }
    document.getElementById(category).style.display = "block";
    evt.currentTarget.className += " selected";
}

function toggleHelp() {
    if (helpWindow) {
        document.getElementById("help-container-main").style.display = "none";
        mp.trigger("fc.hidemouse");
        helpWindow = false;
    } else {
        document.getElementById("help-container-main").style.display = "block";
        mp.trigger("fc.showmouse");
        helpWindow = true;
    }
}