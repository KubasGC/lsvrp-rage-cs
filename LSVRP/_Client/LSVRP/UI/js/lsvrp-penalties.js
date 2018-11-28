function penaltiesToggle(state) {
    if (state) {
        document.getElementById("penalties").style.display = "block";
    } else {
        document.getElementById("penalties").style.display = "none";
    }
}


/*
    KICK = 1,
    BLOCKCHAR,
    WARN,
    BAN,
    AJ,
    CK,
    BLOCKVEH,
    BLOCKOOC,
    VPOINTS
*/

function updatePenalty(type, target, admin, reason, time) {
    switch (type) {
    case 1:
        document.getElementById("penalties-title").innerHTML = `<font color="red">Kick</font>`;
        break;

    case 2:
        document.getElementById("penalties-title").innerHTML = `<font color="red">Blokada postaci</font>`;
        break;

    case 3:
        document.getElementById("penalties-title").innerHTML = `<font color="red">Ostrzeżenie</font>`;
        break;

    case 4:
        document.getElementById("penalties-title").innerHTML = `<font color="red">Ban</font>`;
        break;

    case 5:
        document.getElementById("penalties-title").innerHTML = `<font color="red">Admin Jail (${time} min.)</font>`;
        break;

    case 6:
        document.getElementById("penalties-title").innerHTML = `<font color="red">Character Kill</font>`;
        break;

    case 7:
        document.getElementById("penalties-title").innerHTML =
            `<font color="red">Blokada prowadzenia pojazdów (${time} dni)</font>`;
        break;

    case 8:
        document.getElementById("penalties-title").innerHTML =
            `<font color="red">Blokada czatu OOC (${time} dni)</font>`;
        break;

    case 9:
        document.getElementById("penalties-title").innerHTML = `<font color="lightgreen">vPoints (+${time})</font>`;
        break;

    case 10:
        document.getElementById("penalties-title").innerHTML =
            `<font color="red">Blokada prędkości (${time} dni)</font>`;
        break;
    }
    document.getElementById("penalties-player").innerHTML = target;
    document.getElementById("penalties-admin").innerHTML = admin;
    document.getElementById("penalties-reason").innerHTML = reason;
}