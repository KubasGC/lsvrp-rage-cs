function bwSetTime(seconds) {
    let bwTime = $("#bw-timer .time");
    let minutes = `${Math.floor(seconds / 60)}`;
    seconds = `${Math.floor(seconds - (minutes * 60))}`;

    bwTime.html(`${("0" + minutes).slice(-2)}:${("0" + seconds).slice(-2)}`);
}

function bwToggle(state) {
    let bwTime = $("#bw-timer");
    if (state) {
        bwTime.fadeIn(500);
    } else {
        bwTime.fadeOut(500);
    }
}