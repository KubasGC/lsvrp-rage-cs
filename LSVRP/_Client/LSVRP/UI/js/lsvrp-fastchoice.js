function showVehicles() {
    mp.trigger("fc.vehicles");
    fastChoiceToggle(false);
}

function showGroups() {
    mp.trigger("fc.groups");
    fastChoiceToggle(false);
}

function showPhoneFC() {
    mp.trigger("fc.phone");
    fastChoiceToggle(false);
}

function showStats() {
    mp.trigger("fc.stats");
    fastChoiceToggle(false);
}

function showClothes() {
    mp.trigger("fc.clothes");
    fastChoiceToggle(false);
}

function showDescriptions() {
    mp.trigger("fc.desc");
    fastChoiceToggle(false);
}

function fastChoiceToggle(state) {
    if (!creatorEnabled && !paintEnabled) {
        if (state) {
            mp.trigger("fc.showmouse");
            document.getElementById("fastChoice").style.display = "block";
        } else {
            mp.trigger("fc.hidemouse");
            document.getElementById("fastChoice").style.display = "none";
        }
    }
}