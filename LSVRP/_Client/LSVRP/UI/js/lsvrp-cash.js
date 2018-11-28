function setMoney(value) {
    document.getElementById("playerCash").innerHTML = "$" + value;
}

function moneyToggle(state) {
    if (state) {
        document.getElementById("playerCash").style.display = "block";
    } else {
        document.getElementById("playerCash").style.display = "none";
    }
}