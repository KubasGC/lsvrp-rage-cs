function playersListToggle(state) {
    if (state) {
        document.getElementById("scoretab").style.display = "block";
    } else {
        document.getElementById("scoretab").style.display = "none";
    }
}

function loadPlayersList(data) {
    players = JSON.parse(data);
    var list = "";
    var num = 1;
    for (i = 0; i < players.length; i++) {
        if (num == 1) {
            list = list +
                `<tr>
            <td width="50px;">${players[i].Id}</td>
            <td width="300px;">${players[i].Name} (${players[i].Ping}ms)</td> 
            <td width="300px;">${players[i].GamePoints}</td>
            </tr>`;

        } else {
            list = list +
                `<tr class="tr2">
            <td width="50px;">${players[i].Id}</td>
            <td width="300px;">${players[i].Name} (${players[i].Ping}ms)</td> 
            <td width="300px;">${players[i].GamePoints}</td>
            </tr>`;
        }
        num++;

    }
    document.getElementById("pTbody").innerHTML = list;
    document.getElementById("playersCount").innerHTML = `Gracze online: ${players.length}`;
}