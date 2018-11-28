let segSpeed;
let segMileage;
let segGear;
let kmhGauge;
let rpmGauge;
let fuelGauge;

function vehicleToggle(state) {
    if (state) {
        $("#speedometer").show();
    } else {
        $("#speedometer").hide();
    }
}

function vehEngineToggle(state) {
    if (state) {
        document.getElementById("engine").src = "img/engineon.png";
    } else {
        document.getElementById("engine").src = "img/engine.png";
    }
}

function vehDoorsToggle(state) {
    if (state) {
        document.getElementById("doors").src = "img/doorson.png";
    } else {
        document.getElementById("doors").src = "img/doors.png";
    }
}

function vehFuelToggle(state) {
    if (state) {
        document.getElementById("fueli").src = "img/fuelon.png";
    } else {
        document.getElementById("fueli").src = "img/fuel.png";
    }
}

function vehLeftToggle(state) {
    if (state) {
        document.getElementById("left").src = "img/lefton.png";
    } else {
        document.getElementById("left").src = "img/left.png";
    }
}

function vehRightToggle(state) {
    if (state) {
        document.getElementById("right").src = "img/righton.png";
    } else {
        document.getElementById("right").src = "img/right.png";
    }
}

function vehFuelChange(value) {
    document.getElementById("fuelbar").value = value;
}

function vehSpeedUpdate(value) {
    kmhGauge.value(value);
    segSpeed.value(value);
}

function vehDistanceUpdate(value) {
    segMileage.value(value);
}

function vehRpmUpdate(rpm) {
    rpmGauge.value(rpm);
}

function vehGearUpdate(gear) {
    segGear.value(gear);
}

function vehFuelUpdate(fuel) {
    fuelGauge.value(fuel);
}

document.addEventListener("DOMContentLoaded", function (event) {

    function drawInd(g, r) {
        g.append("path").attr("d", "M0 " + 0.25 * r + " L 0 " + -0.95 * r + "");
        g.append("circle").attr("r", 0.03 * r);
    }

    // fuel gauge config

    var fuelSvg = d3.select("#fuel")
        .append("svg:svg")
        .attr("width", 400)
        .attr("height", 400);

    fuelGauge = iopctrl.arcslider()
        .radius(120)
        .events(false)
        .indicator(iopctrl.defaultGaugeIndicator);

    fuelGauge.axis().orient("in")
        .normalize(true)
        .ticks(12)
        .tickSubdivide(3)
        .tickSize(10, 8, 10)
        .tickPadding(5)
        .scale(d3.scale.linear()
            .domain([0, 240])
            .range([-3 * Math.PI / 4, 3 * Math.PI / 4]));

    // end fuel gauge config

    var svg = d3.select("#speedometer")
        .append("svg:svg")
        .attr("width", 500)
        .attr("height", 400);

    kmhGauge = iopctrl.arcslider()
        .radius(120)
        .bands([{
            domain: [200, 240],
            span: [0.9, 1],
            class: 'fault'
        }])
        .events(false)
        .indicator(drawInd);

    kmhGauge.axis().orient("out")
        .normalize(false)
        .ticks(10)
        .tickSubdivide(1)
        .tickSize(-12, -8, 10)
        .tickPadding(8)
        .scale(d3.scale.linear()
            .domain([0, 240])
            .range([-3 * Math.PI / 4, 3 * Math.PI / 4])
        );

    svg.append("g")
        .attr("class", "gauge big")
        .call(kmhGauge);

    var mphGauge = iopctrl.arcslider()
        .radius(60)
        .bands([{
            domain: [120, 150],
            span: [0.90, 1],
            class: 'fault'
        }])
        .events(false);

    mphGauge.axis().orient("out")
        .normalize(false)
        .ticks(6)
        .tickSubdivide(1)
        .tickSize(-10, -6, 10)
        .tickPadding(8)
        .scale(d3.scale.linear()
            .domain([0, 150])
            .range([-3 * Math.PI / 4, 3 * Math.PI / 4])
        );

    svg.append("g")
        .attr("class", "gauge small")
        .attr("transform", "translate(60, 60)")
        .call(mphGauge);

    rpmGauge = iopctrl.arcslider()
        .radius(70)
        .bands([{
            domain: [5, 7],
            span: [0.90, 1],
            class: 'fault'
        }])
        .events(false)
        .indicator(drawInd);

    rpmGauge.axis().orient("out")
        .normalize(false)
        .ticks(6)
        .tickSubdivide(1)
        .tickSize(-10, -6, 10)
        .tickPadding(8)
        .scale(d3.scale.linear()
            .domain([1, 7])
            .range([Math.PI + Math.PI / 6, -1 * Math.PI / 8])
        );

    svg.append("g")
        .attr("class", "gauge small")
        .attr("transform", "translate(250, 80)")
        .call(rpmGauge);

    var fuelGaugeLabel = iopctrl.arcslider()
        .radius(25)
        .events(false);

    fuelGaugeLabel.axis().orient("out")
        .normalize(true)
        .ticks(3)
        .tickSubdivide(1)
        .tickSize(-4, -2, 10)
        .tickPadding(6)
        .scale(d3.scale.ordinal()
            .domain(['L', 'F'])
            .range([3 * Math.PI / 5, -1 * Math.PI / 4])
        );

    svg.append("g")
        .attr("class", "gauge fuel-label")
        .attr("transform", "translate(265 165)")
        .call(fuelGaugeLabel);

    fuelGauge = iopctrl.arcslider()
        .radius(25)
        .events(false)
        .bands([{
            domain: [0, 20],
            span: [0.8, 1],
            class: 'fault'
        }])
        .indicator(drawInd);

    fuelGauge.axis().orient("out")
        .normalize(true)
        .ticks(1)
        .tickSubdivide(1)
        .tickSize(-4, -2, 10)
        .tickPadding(8)
        .scale(d3.scale.linear()
            .domain([0, 100])
            .range([3 * Math.PI / 5, -1 * Math.PI / 4])
        );

    svg.append("g")
        .attr("class", "gauge fuel")
        .attr("transform", "translate(265, 165)")
        .call(fuelGauge);

    segSpeed = iopctrl.segdisplay()
        .width(50)
        .digitCount(3)
        .negative(false)
        .decimals(0);

    svg.append("g")
        .attr("class", "segdisplay")
        .attr("transform", "translate(145, 200)")
        .call(segSpeed);

    segGear = iopctrl.segdisplay()
        .width(20)
        .digitCount(1)
        .negative(false)
        .decimals(0);

    svg.append("g")
        .attr("class", "segdisplay")
        .attr("transform", "translate(350, 160)")
        .call(segGear);

    segMileage = iopctrl.segdisplay()
        .width(100)
        .digitCount(8)
        .negative(false)
        .decimals(1);

    svg.append("g")
        .attr("class", "segdisplay")
        .attr("transform", "translate(120, 240)")
        .call(segMileage);
});