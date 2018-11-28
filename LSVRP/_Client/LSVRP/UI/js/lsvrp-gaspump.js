var fuel = 0.00;
var cash = 0.00;
var btn = false;
var maxfuel = 0;


function fuel_go() {
    if (btn) {
        fuel += 0.1;
        cash = fuel * 2.5;
        if (fuel >= maxfuel) {
            cash = maxfuel * 2.5;
            fuel = maxfuel;
        }
        document.getElementById("cash").value = Math.round(cash).toFixed(2);
        document.getElementById("fuel").value = Math.round(fuel).toFixed(2);
        setTimeout(function() {
                document.getElementById("pDown").addEventListener("mousedown", fuel_go());
            },
            25);
    }
}

function pump_cancel() {
    mp.trigger("client.gasstations.hide");
    resetPump();
}

function pump_pay() {
    mp.trigger("client.gasstations.pay", Math.round(fuel).toFixed(2), Math.round(cash).toFixed(2));
    resetPump();
}

function resetPump() {
    fuel = 0.00;
    cash = 0.00;
    btn = false;
    maxfuel = 0;
    document.getElementById("cash").value = 0.00;
    document.getElementById("fuel").value = 0.00;
}

function gasSetMaxValue(val) {
    maxfuel = Number(val);
}

function pump_down() {
    btn = true;
    fuel_go();
}

function pump_up() {
    btn = false;
}

function gasPumpToggle(state) {
    if (state) {
        $("#gaspump").show();
    } else {
        $("#gaspump").hide();
    }
}