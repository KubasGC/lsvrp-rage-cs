function setDuty(value) {
    var dutyMinutes = Math.floor(value / 60);
    var dutySeconds = Math.floor(value - (dutyMinutes * 60));
    document.getElementById("playerDuty").innerHTML = `SŁUŻBA<br>${dutyMinutes}m ${dutySeconds}s`;
}

function dutyToggle(state) {
    if (state) {
        document.getElementById("playerDuty").style.display = "block";
    } else {
        document.getElementById("playerDuty").style.display = "none";
    }
}