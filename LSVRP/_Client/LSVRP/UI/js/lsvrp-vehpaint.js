let selectedFieldPaint = 0;

let paintEnabled = false;

// KREATOR SKINÓW
let listColors = [
    { id: 0, name: "Metallic black" },
    { id: 1, name: "Metallic graphite black" },
    { id: 2, name: "Metallic black steal" },
    { id: 3, name: "Metallic dark silver" },
    { id: 4, name: "Metallic silver" },
    { id: 5, name: "Metallic blue silver" },
    { id: 6, name: "Metallic steel gray" },
    { id: 7, name: "Metallic shadow gray" },
    { id: 8, name: "Metallic stone silver" },
    { id: 9, name: "Metallic midnight silver" },
    { id: 10, name: "Metallic gun metal" },
    { id: 11, name: "Metallic anthracite grey" },
    { id: 12, name: "Matte black" },
    { id: 13, name: "Matte gray" },
    { id: 14, name: "Matte light grey" },
    { id: 15, name: "Util black" },
    { id: 16, name: "Util black poly" },
    { id: 17, name: "Util dark silver" },
    { id: 18, name: "Util silver" },
    { id: 19, name: "Util gun metal" },
    { id: 20, name: "Util shadow silver" },
    { id: 21, name: "Worn black" },
    { id: 22, name: "Worn graphite" },
    { id: 23, name: "Worn silver grey" },
    { id: 24, name: "Worn silver" },
    { id: 25, name: "Worn blue silver" },
    { id: 26, name: "Worn shadow silver" },
    { id: 27, name: "Metallic red" },
    { id: 28, name: "Metallic torino red" },
    { id: 29, name: "Metallic formula red" },
    { id: 30, name: "Metallic blaze red" },
    { id: 31, name: "Metallic graceful red" },
    { id: 32, name: "Metallic garnet red" },
    { id: 33, name: "Metallic desert red" },
    { id: 34, name: "Metallic cabernet red" },
    { id: 35, name: "Metallic candy red" },
    { id: 36, name: "Metallic sunrise orange" },
    { id: 37, name: "Metallic classic gold" },
    { id: 38, name: "Metallic orange" },
    { id: 39, name: "Matte red" },
    { id: 40, name: "Matte dark red" },
    { id: 41, name: "Matte orange" },
    { id: 42, name: "Matte yellow" },
    { id: 43, name: "Util red" },
    { id: 44, name: "Util bright red" },
    { id: 45, name: "Util garnet red" },
    { id: 46, name: "Worn red" },
    { id: 47, name: "Worn golden red" },
    { id: 48, name: "Worn dark red" },
    { id: 49, name: "Metallic dark green" },
    { id: 50, name: "Metallic racing green" },
    { id: 51, name: "Metallic sea green" },
    { id: 52, name: "Metallic olive green" },
    { id: 53, name: "Metallic green" },
    { id: 54, name: "Metallic gasoline blue green" },
    { id: 55, name: "Matte lime green" },
    { id: 56, name: "Util dark green" },
    { id: 57, name: "Util green" },
    { id: 58, name: "Worn dark green" },
    { id: 59, name: "Worn green" },
    { id: 60, name: "Worn sea wash" },
    { id: 61, name: "Metallic midnight blue" },
    { id: 62, name: "Metallic dark blue" },
    { id: 63, name: "Metallic saxony blue" },
    { id: 64, name: "Metallic blue" },
    { id: 65, name: "Metallic mariner blue" },
    { id: 66, name: "Metallic harbor blue" },
    { id: 67, name: "Metallic diamond blue" },
    { id: 68, name: "Metallic surf blue" },
    { id: 69, name: "Metallic nautical blue" },
    { id: 70, name: "Metallic bright blue" },
    { id: 71, name: "Metallic purple blue" },
    { id: 72, name: "Metallic spinnaker blue" },
    { id: 73, name: "Metallic ultra blue" },
    { id: 74, name: "Metallic bright blue" },
    { id: 75, name: "Util dark blue" },
    { id: 76, name: "Util midnight blue" },
    { id: 77, name: "Util blue" },
    { id: 78, name: "Util sea foam blue" },
    { id: 79, name: "Util lightning blue" },
    { id: 80, name: "Util maui blue poly" },
    { id: 81, name: "Util bright blue" },
    { id: 82, name: "Matte dark blue" },
    { id: 83, name: "Matte blue" },
    { id: 84, name: "Matte midnight blue" },
    { id: 85, name: "Worn dark blue" },
    { id: 86, name: "Worn blue" },
    { id: 87, name: "Worn light blue" },
    { id: 88, name: "Metallic taxi yellow" },
    { id: 89, name: "Metallic race yellow" },
    { id: 90, name: "Metallic bronze" },
    { id: 91, name: "Metallic yellow bird" },
    { id: 92, name: "Metallic lime" },
    { id: 93, name: "Metallic champagne" },
    { id: 94, name: "Metallic pueblo beige" },
    { id: 95, name: "Metallic dark ivory" },
    { id: 96, name: "Metallic choco brown" },
    { id: 97, name: "Metallic golden brown" },
    { id: 98, name: "Metallic light brown" },
    { id: 99, name: "Metallic straw beige" },
    { id: 100, name: "Metallic moss brown" },
    { id: 101, name: "Metallic biston brown" },
    { id: 102, name: "Metallic beechwood" },
    { id: 103, name: "Metallic dark beechwood" },
    { id: 104, name: "Metallic choco orange" },
    { id: 105, name: "Metallic beach sand" },
    { id: 106, name: "Metallic sun bleeched sand" },
    { id: 107, name: "Brushed gold" },
    { id: 108, name: "Util brown" },
    { id: 109, name: "Util medium brown" },
    { id: 110, name: "Util light brown" },
    { id: 111, name: "Metallic white" },
    { id: 112, name: "Metallic frost white" },
    { id: 113, name: "Worn honey beige" },
    { id: 114, name: "Worn brown" },
    { id: 115, name: "Worn dark brown" },
    { id: 116, name: "Worn straw beige" },
    { id: 117, name: "Brushed steel" },
    { id: 118, name: "Brushed Black steel" },
    { id: 119, name: "Brushed Aluminium" },
    { id: 120, name: "Chrome" },
    { id: 121, name: "Worn off white" },
    { id: 122, name: "Util off white" },
    { id: 123, name: "Worn orange" },
    { id: 124, name: "Worn light orange" },
    { id: 125, name: "Metallic securicor green" },
    { id: 126, name: "Worn taxi yellow" },
    { id: 127, name: "Police car blue " },
    { id: 128, name: "Matte green" },
    { id: 129, name: "Matte brown" },
    { id: 130, name: "Worn orange" },
    { id: 131, name: "Matte white" },
    { id: 132, name: "Worn white" },
    { id: 133, name: "Worn olive army green" },
    { id: 134, name: "Pure white" },
    { id: 135, name: "Hot pink" },
    { id: 136, name: "Salmon pink" },
    { id: 137, name: "Metallic vermillion pink" },
    { id: 138, name: "Orange" },
    { id: 139, name: "Green" },
    { id: 140, name: "Blue" },
    { id: 141, name: "Mettalic black blue" },
    { id: 142, name: "Metallic black purple" },
    { id: 143, name: "Metallic black red" },
    { id: 144, name: "Hunter green" },
    { id: 145, name: "Metallic purple" },
    { id: 146, name: "Metaillic v dark blue" },
    { id: 147, name: "Modshop black1" },
    { id: 148, name: "Matte purple" },
    { id: 149, name: "Matte dark purple" },
    { id: 150, name: "Metallic lava red" },
    { id: 151, name: "Matte forest green" },
    { id: 152, name: "Matte olive drab" },
    { id: 153, name: "Matte desert brown" },
    { id: 154, name: "Matte desert tan" },
    { id: 155, name: "Matte foilage green" },
    { id: 156, name: "Default alloy color " },
    { id: 157, name: "Epsilon blue" },
    { id: 158, name: "Pure gold" },
    { id: 159, name: "Brushed gold" }
];

// WYBRANE OPCJE
let choosedColorOne = 0;
let choosedColorTwo = 0;

function changePaintOneColor(up) {
    if (up) {
        choosedColorOne++;
        if (choosedColorOne > (listColors.length - 1)) {
            choosedColorOne = listColors.length - 1;
        }
    } else {
        choosedColorOne--;
        if (choosedColorOne < 0) {
            choosedColorOne = 0;
        }
    }
    $("#veh-paint-c1").html(`${listColors[choosedColorOne].name}`);
    updateGameVeh();
}

function changePaintTwoColor(up) {
    if (up) {
        choosedColorTwo++;
        if (choosedColorTwo > (listColors.length - 1)) {
            choosedColorTwo = listColors.length - 1;
        }
    } else {
        choosedColorTwo--;
        if (choosedColorTwo < 0) {
            choosedColorTwo = 0;
        }
    }
    $("#veh-paint-c2").html(`${listColors[choosedColorTwo].name}`);
    updateGameVeh();
}

function updateGameVeh() {

    mp.trigger("updateVehPaint", choosedColorOne, choosedColorTwo);

}


// LAKIEROWANIE


function toggleVehPainting(state) {
    if (state) {
        choosedColorOne = 0;
        choosedColorTwo = 0;

        $("#veh-paint").show();
        paintEnabled = true;
        selectedFieldPaint = 0;
    } else {
        $("#veh-paint").hide();
        paintEnabled = 1;
        selectedFieldPaint = false;
    }
}

/*function RefreshClothesCreatorUI() {
    $("#char-clothes-torso-name").html(`Typ ${choosedTorso + 1}`);
    $("#char-clothes-legs-name").html(`Typ ${choosedLegs + 1}`);

    mp.trigger("updatePlayerClothes", JSON.stringify(jsonData));
}*/

function SavePaint() {
    toggleVehPainting(false);
    mp.trigger("client.vehPaint.save", choosedColorOne, choosedColorTwo);
}

document.addEventListener('keydown',
    (event) => {
        const keyName = event.key;
        if (paintEnabled) {
            if (keyName == 'ArrowDown') {
                rowSelect2(false);
            } else if (keyName == 'ArrowUp') {
                rowSelect2(true);
            } else if (keyName == 'ArrowLeft') {
                if (selectedFieldPaint == 0) {
                    changePaintOneColor(false);
                } else if (selectedFieldPaint == 1) {
                    changePaintTwoColor(false);
                }
            } else if (keyName == 'ArrowRight') {
                if (selectedFieldPaint == 0) {
                    changePaintOneColor(true);
                } else if (selectedFieldPaint == 1) {
                    changePaintTwoColor(true);
                }
            }
        }
    });

function rowSelect2(state) {
    if (state) {
        var row = "vp";
        row = "vp" + selectedFieldPaint;

        document.getElementById(row).style.backgroundColor = "transparent";
        document.getElementById(row).style.color = "white";
        if (selectedFieldPaint != 0) {
            selectedFieldPaint --;
        }

        row = "vp" + selectedFieldPaint;

        document.getElementById(row).style.backgroundColor = "white";
        document.getElementById(row).style.color = "black";
    } else {
        var row = "vp";
        row = "vp" + selectedFieldPaint;

        document.getElementById(row).style.backgroundColor = "transparent";
        document.getElementById(row).style.color = "white";
        if (selectedFieldPaint != 1) {
            selectedFieldPaint ++;
        }

        row = "vp" + selectedFieldPaint;

        document.getElementById(row).style.backgroundColor = "white";
        document.getElementById(row).style.color = "black";
    }
}