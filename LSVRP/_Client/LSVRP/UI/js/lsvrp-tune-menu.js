var spoiler = -1;
var fBumper = -1;
var rBumper = -1;
var sSkirt = -1;
var exhaust = -1;
var frame = -1;
var grille = -1;
var hood = -1;
var fender = -1;
var rFender = -1;
var roof = -1;
var engine = -1;
var brakes = -1;
var transmission = -1;
var suspension = -1;
var turbo = -1;
var xenon = -1;
var wheels = -1;
var windows = -1;
/*COS TAM*/
let choosedSpoiler = -1;
let choosedFBumper = -1;
let choosedRBumper = -1;
let choosedSSkirt = -1;
let choosedExhaust = -1;
let choosedFrame = -1;
let choosedGrille = -1;
let choosedHood = -1;
let choosedFender = -1;
let choosedRFender = -1;
let choosedRoof = -1;
let choosedEngine = -1;
let choosedBrakes = -1;
let choosedTransmission = -1;
let choosedSuspension = -1;
let choosedTurbo = -1;
let choosedXenon = -1;
let choosedWheels = -1;
let choosedWindows = -1;


function tuneMenuLoad(data) {
    data = JSON.parse(decodeURIComponent(data));
    for (let i = 0; i < data.length; i++) {
        if (data[i].data == `spoiler`) {
            spoiler = data[i].value;
        } else if (data[i].data == `fBumper`) {
            fBumper = data[i].value;
        } else if (data[i].data == `rBumper`) {
            rBumper = data[i].value;
        } else if (data[i].data == `sSkirt`) {
            sSkirt = data[i].value;
        } else if (data[i].data == `exhaust`) {
            exhaust = data[i].value;
        } else if (data[i].data == `frame`) {
            frame = data[i].value;
        } else if (data[i].data == `grille`) {
            grille = data[i].value;
        } else if (data[i].data == `hood`) {
            hood = data[i].value;
        } else if (data[i].data == `fender`) {
            fender = data[i].value;
        } else if (data[i].data == `rFender`) {
            rFender = data[i].value;
        } else if (data[i].data == `roof`) {
            roof = data[i].value;
        } else if (data[i].data == `engine`) {
            engine = data[i].value;
        } else if (data[i].data == `brakes`) {
            brakes = data[i].value;
        } else if (data[i].data == `transmission`) {
            transmission = data[i].value;
        } else if (data[i].data == `suspension`) {
            suspension = data[i].value;
        } else if (data[i].data == `turbo`) {
            turbo = data[i].value;
        } else if (data[i].data == `xenon`) {
            xenon = data[i].value;
        } else if (data[i].data == `wheels`) {
            wheels = data[i].value;
        } else if (data[i].data == `windows`) {
            windows = data[i].value;
        }
    }
}

function tuneMenuToggle(state) {
    if (state) {
        $("#tune-menu").show();
    } else {
        $("#tune-menu").hide();
    }
}

function changeSpoiler(up) {
    if (up) {
        choosedSpoiler++;
        if (choosedSpoiler > (spoiler - 1)) {
            choosedSpoiler = -1;
        }
    } else {
        choosedSpoiler--;
        if (choosedSpoiler < -1) {
            choosedSpoiler = -1;
        }
    }
    $("#tune-menu-spoiler").html(`Typ ${choosedSpoiler}`);
    if (choosedSpoiler == -1) {
        $("#tune-menu-spoiler").html(`Fabryczny`);
    }
    updateVehicle();
}

function changeFBumper(up) {
    if (up) {
        choosedFBumper++;
        if (choosedFBumper > (fBumper - 1)) {
            choosedFBumper = -1;
        }
    } else {
        choosedFBumper--;
        if (choosedFBumper < -1) {
            choosedFBumper = -1;
        }
    }
    $("#tune-menu-bumper").html(`Typ ${choosedFBumper}`);
    if (choosedFBumper == -1) {
        $("#tune-menu-bumper").html(`Fabryczny`);
    }
    updateVehicle();
}

function changeRBumper(up) {
    if (up) {
        choosedRBumper++;
        if (choosedRBumper > (rBumper - 1)) {
            choosedRBumper = -1;
        }
    } else {
        choosedRBumper--;
        if (choosedRBumper < -1) {
            choosedRBumper = -1;
        }
    }
    $("#tune-menu-bumper2").html(`Typ ${choosedRBumper}`);
    if (choosedRBumper == -1) {
        $("#tune-menu-bumper2").html(`Fabryczny`);
    }
    updateVehicle();
}

function changeSSkirt(up) {
    if (up) {
        choosedSSkirt ++;
        if (choosedSSkirt > (sSkirt - 1)) {
            choosedSSkirt = -1;
        }
    } else {
        choosedSSkirt --;
        if (choosedSSkirt < 0) {
            choosedSSkirt = -1;
        }
    }
    $("#tune-menu-sideskirt").html(`Typ ${choosedSSkirt}`);
    if (choosedSSkirt == -1) {
        $("#tune-menu-sideskirt").html(`Fabryczne`);
    }
    updateVehicle();
}

function changeExhaust(up) {
    if (up) {
        choosedExhaust ++;
        if (choosedExhaust > (exhaust - 1)) {
            choosedExhaust = -1;
        }
    } else {
        choosedExhaust --;
        if (choosedExhaust < 0) {
            choosedExhaust = -1;
        }
    }
    $("#tune-menu-exhaust").html(`Typ ${choosedExhaust}`);
    if (choosedExhaust == -1) {
        $("#tune-menu-exhaust").html(`Fabryczny`);
    }
    updateVehicle();
}

function changeFrame(up) {
    if (up) {
        choosedFrame ++;
        if (choosedFrame > (frame - 1)) {
            choosedFrame = -1;
        }
    } else {
        choosedFrame --;
        if (choosedFrame < 0) {
            choosedFrame = -1;
        }
    }
    $("#tune-menu-frame").html(`Typ ${choosedFrame}`);
    if (choosedFrame == -1) {
        $("#tune-menu-frame").html(`Fabryczna`);
    }
    updateVehicle();
}

function changeGrille(up) {
    if (up) {
        choosedGrille ++;
        if (choosedGrille > (grille - 1)) {
            choosedGrille = -1;
        }
    } else {
        choosedGrille --;
        if (choosedGrille < 0) {
            choosedGrille = -1;
        }
    }
    $("#tune-menu-grill").html(`Typ ${choosedGrille}`);
    if (choosedGrille == -1) {
        $("#tune-menu-grill").html(`Fabryczny`);
    }
    updateVehicle();
}

function changeHood(up) {
    if (up) {
        choosedHood ++;
        if (choosedHood > (hood - 1)) {
            choosedHood = -1;
        }
    } else {
        choosedHood --;
        if (choosedHood < 0) {
            choosedHood = -1;
        }
    }
    $("#tune-menu-hood").html(`Typ ${choosedHood}`);
    if (choosedHood == -1) {
        $("#tune-menu-hood").html(`Fabryczna`);
    }
    updateVehicle();
}

function changeFender(up) {
    if (up) {
        choosedFender ++;
        if (choosedFender > (fender - 1)) {
            choosedFender = -1;
        }
    } else {
        choosedFender --;
        if (choosedFender < 0) {
            choosedFender = -1;
        }
    }
    $("#tune-menu-fender").html(`Typ ${choosedFender}`);
    if (choosedFender == -1) {
        $("#tune-menu-fender").html(`Fabryczne`);
    }
    updateVehicle();
}

function changeRFender(up) {
    if (up) {
        choosedRFender ++;
        if (choosedRFender > (rFender - 1)) {
            choosedRFender = -1;
        }
    } else {
        choosedRFender --;
        if (choosedRFender < 0) {
            choosedRFender = -1;
        }
    }
    $("#tune-menu-rightfender").html(`Typ ${choosedRFender}`);
    if (choosedRFender == -1) {
        $("#tune-menu-rightfender").html(`Fabryczne`);
    }
    updateVehicle();
}

function changeRoof(up) {
    if (up) {
        choosedRoof ++;
        if (choosedRoof > (roof - 1)) {
            choosedRoof = -1;
        }
    } else {
        choosedRoof --;
        if (choosedRoof < 0) {
            choosedRoof = -1;
        }
    }
    $("#tune-menu-roof").html(`Typ ${choosedRoof}`);
    if (choosedRoof == -1) {
        $("#tune-menu-roof").html(`Fabryczny`);
    }
    updateVehicle();
}

function changeEngine(up) {
    if (up) {
        choosedEngine ++;
        if (choosedEngine > (engine - 1)) {
            choosedEngine = -1;
        }
    } else {
        choosedEngine --;
        if (choosedEngine < 0) {
            choosedEngine = -1;
        }
    }
    $("#tune-menu-engine").html(`Typ ${choosedEngine}`);
    if (choosedEngine == -1) {
        $("#tune-menu-engine").html(`Fabryczny`);
    }
    updateVehicle();
}

function changeBrakes(up) {
    if (up) {
        choosedBrakes ++;
        if (choosedBrakes > (brakes - 1)) {
            choosedBrakes = -1;
        }
    } else {
        choosedBrakes --;
        if (choosedBrakes < 0) {
            choosedBrakes = -1;
        }
    }
    $("#tune-menu-brakes").html(`Typ ${choosedBrakes}`);
    if (choosedBrakes == -1) {
        $("#tune-menu-brakes").html(`Fabryczne`);
    }
    updateVehicle();
}

function changeTransmission(up) {
    if (up) {
        choosedTransmission ++;
        if (choosedTransmission > (transmission - 1)) {
            choosedTransmission = -1;
        }
    } else {
        choosedTransmission --;
        if (choosedTransmission < 0) {
            choosedTransmission = -1;
        }
    }
    $("#tune-menu-transmission").html(`Typ ${choosedTransmission}`);
    if (choosedTransmission == -1) {
        $("#tune-menu-transmission").html(`Fabryczna`);
    }
    updateVehicle();
}

function changeSuspension(up) {
    if (up) {
        choosedSuspension ++;
        if (choosedSuspension > (suspension - 1)) {
            choosedSuspension = -1;
        }
    } else {
        choosedSuspension --;
        if (choosedSuspension < 0) {
            choosedSuspension = -1;
        }
    }
    $("#tune-menu-suspension").html(`Typ ${choosedSuspension}`);
    if (choosedSuspension == -1) {
        $("#tune-menu-suspension").html(`Fabryczne`);
    }
    updateVehicle();
}

function changeTurbo(up) {
    if (up) {
        choosedTurbo ++;
        if (choosedTurbo > (turbo)) {
            choosedTurbo = -1;
        }
    } else {
        choosedTurbo --;
        if (choosedTurbo < 0) {
            choosedTurbo = -1;
        }
    }
    $("#tune-menu-turbo").html(`Tak`);
    if (choosedTurbo == -1) {
        $("#tune-menu-turbo").html(`Nie`);
    }
    updateVehicle();
}

function changeXenon(up) {
    if (up) {
        choosedXenon ++;
        if (choosedXenon > (xenon)) {
            choosedXenon = -1;
        }
    } else {
        choosedXenon --;
        if (choosedXenon < 0) {
            choosedXenon = -1;
        }
    }
    //$("#tune-menu-xenon").html(`Typ ${choosedXenon }`);
    if (choosedXenon == -1) {
        $("#tune-menu-xenon").html(`Nie`);
    } else {
        $("#tune-menu-xenon").html(`Tak`);
    }
    updateVehicle();
}

function changeWheels(up) {
    if (up) {
        choosedWheels ++;
        if (choosedWheels > (wheels - 1)) {
            choosedWheels = -1;
        }
    } else {
        choosedWheels --;
        if (choosedWheels < 0) {
            choosedWheels = -1;
        }
    }
    $("#tune-menu-wheels").html(`Typ ${choosedWheels}`);
    if (choosedWheels == -1) {
        $("#tune-menu-wheels").html(`Fabryczne`);
    }
    updateVehicle();
}

function changeWindows(up) {
    if (up) {
        choosedWindows ++;
        if (choosedWindows > (windows - 1)) {
            choosedWindows = -1;
        }
    } else {
        choosedWindows --;
        if (choosedWindows < 0) {
            choosedWindows = -1;
        }
    }
    $("#tune-menu-windows").html(`Typ ${choosedWindows}`);
    if (choosedFBumper == -1) {
        $("#tune-menu-bumper").html(`Fabryczny`);
    }
    updateVehicle();
}

function SaveTune() {
    tuneMenuToggle(false);
    choosedSpoiler = -1;
    choosedFBumper = -1;
    choosedRBumper = -1;
    choosedSSkirt = -1;
    choosedExhaust = -1;
    choosedFrame = -1;
    choosedGrille = -1;
    choosedHood = -1;
    choosedFender = -1;
    choosedRFender = -1;
    choosedRoof = -1;
    choosedEngine = -1;
    choosedBrakes = -1;
    choosedTransmission = -1;
    choosedSuspension = -1;
    choosedTurbo = -1;
    choosedXenon = -1;
    choosedWheels = -1;
    choosedWindows = -1;
}


function updateVehicle() {
    mp.trigger("client.workshop.tune.update",
        choosedSpoiler,
        choosedFBumper,
        choosedRBumper,
        choosedSSkirt,
        choosedExhaust,
        choosedFrame,
        choosedGrille,
        choosedHood,
        choosedFender,
        choosedRFender,
        choosedRoof,
        choosedEngine,
        choosedBrakes,
        choosedTransmission,
        choosedSuspension,
        choosedTurbo,
        choosedXenon,
        choosedWheels,
        choosedWindows);
}