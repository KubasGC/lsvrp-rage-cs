var charCreatorSkinMixSlider = null;
var charCreatorSkinColorMixSlider = null;

var charCreatorNoseWidthSlider = null;
var charCreatorNoseHeightSlider = null;
var charCreatorNoseLengthSlider = null;
var charCreatorNoseBridgeSlider = null;
var charCreatorNoseTipSlider = null;
var charCreatorNoseBridgeShiftSlider = null;

let isClothesCreatorLoading = false;

let isFemale = false;

let selectedField = 0;

let creatorEnabled = false;
let creatorStep = 1;
// KREATOR SKINÓW
let menSkins = [
    { id: 0, name: "James" },
    { id: 1, name: "David" },
    { id: 2, name: "Martin" },
    { id: 3, name: "Michael" },
    { id: 4, name: "Kenneth" },
    { id: 5, name: "Jesse" },
    { id: 6, name: "Fredrick" },
    { id: 7, name: "Ronald" },
    { id: 8, name: "Carl" },
    { id: 9, name: "Randolph" },
    { id: 10, name: "Jason" },
    { id: 11, name: "Shawn" },
    { id: 12, name: "William" },
    { id: 13, name: "Thomas" },
    { id: 14, name: "Jerry" },
    { id: 15, name: "Lewis" },
    { id: 16, name: "Gustavo" },
    { id: 17, name: "Oscar" },
    { id: 18, name: "Mark" },
    { id: 19, name: "Harold" },
    { id: 20, name: "Juan" },
    { id: 42, name: "Randall" },
    { id: 43, name: "Billy" },
    { id: 44, name: "Mike" }
];
let womenSkins = [
    { id: 21, name: "Emma" },
    { id: 22, name: "Towanda" },
    { id: 23, name: "Florene" },
    { id: 24, name: "Carol" },
    { id: 25, name: "Kristine" },
    { id: 26, name: "Cheryl" },
    { id: 27, name: "Caitlin" },
    { id: 28, name: "Patricia" },
    { id: 29, name: "Myrtle" },
    { id: 30, name: "Jane" },
    { id: 31, name: "Linda" },
    { id: 32, name: "Jamie" },
    { id: 33, name: "Lucille" },
    { id: 34, name: "Erica" },
    { id: 35, name: "Anita" },
    { id: 36, name: "Ella" },
    { id: 37, name: "Susanne" },
    { id: 38, name: "Pamela" },
    { id: 39, name: "Laurene" },
    { id: 40, name: "Agnes" },
    { id: 41, name: "Eleanor" },
    { id: 42, name: "Brianna" }
];
let menHairs = [
    { id: 0, name: "Łysina" },
    { id: 1, name: "Krótkie kręcone" },
    { id: 2, name: "Przód dłuższy boki krótsze" },
    { id: 3, name: "Wygolone boki" },
    { id: 4, name: "Wycieniowane i zaczesane do tyłu" },
    { id: 5, name: "Krótko ścięty" },
    { id: 6, name: "Pasek włosów" },
    { id: 7, name: "Mocno zaczesae do tyłu" },
    { id: 8, name: "Warkoczyki" },
    { id: 9, name: "Zaczesana góra z niesfornym tyłem" },
    { id: 10, name: "Podniesiona grzywka" },
    { id: 11, name: "Boki krótsze z lekkim irokezem" },
    { id: 12, name: "Włosy zaczesane do przodu" },
    { id: 13, name: "Długa grzywka" },
    { id: 14, name: "Dredy" },
    { id: 15, name: "Proste z przedziałkiem na środku" },
    { id: 16, name: "Niesforne loki" },
    { id: 17, name: "Proste z podkręconą grzywką" },
    { id: 18, name: "Zaczesana grzywka" },
    { id: 19, name: "Zaczeska" },
    { id: 20, name: "Cieniowane uczesane na bok" },
    { id: 21, name: "Boki łyse góra zaczesana" },
    { id: 22, name: "Lata 80-te" },
    { id: 24, name: "Warkoczyki style 1" },
    { id: 25, name: "Warkoczyki style 2" },
    { id: 26, name: "Warkoczyki style 3" },
    { id: 27, name: "Warkoczyki style 4" },
    { id: 28, name: "Warkoczyki style 5" },
    { id: 29, name: "Warkoczyki style 6" },
    { id: 30, name: "Wystylizowane afro" },
    { id: 31, name: "Długie zaczesane do tyłu" },
    { id: 32, name: "Boki lekki odrost długa gróra" },
    { id: 33, name: "Boki lekki odrost góra zaczesana" },
    { id: 34, name: "Punk Rock" },
    { id: 35, name: "Niesforne" },
    { id: 36, name: "Proste z krótsza grzywka" }
];
let womenHairs = [
    { id: 0, name: "Łysina" },
    { id: 1, name: "Bowl cut" },
    { id: 2, name: "Pixi" },
    { id: 3, name: "Warkoczyki" },
    { id: 4, name: "Kita z grzywką" },
    { id: 5, name: "Fala z warkoczami" },
    { id: 6, name: "Kitka z warkoczy" },
    { id: 7, name: "Shortbob" },
    { id: 8, name: "Irokez" },
    { id: 9, name: "Kok banan" },
    { id: 10, name: "Bob" },
    { id: 11, name: "Niski kok" },
    { id: 12, name: "Chop-Chop" },
    { id: 13, name: "Undercut" },
    { id: 14, name: "Niesforny kok" },
    { id: 15, name: "Falowany bob" },
    { id: 16, name: "Pin up" },
    { id: 17, name: "Kok z grzywą" },
    { id: 18, name: "Lata dwudzieste" },
    { id: 19, name: "Kucyk z węzłem" },
    { id: 20, name: "Afro" },
    { id: 21, name: "Krótkie loczki" },
    { id: 22, name: "Warkoczykowy kok" },
    { id: 23, name: "Lata 80-te" },
    { id: 25, name: "Warkocze francuskie 1" },
    { id: 26, name: " Warkocze francuskie 2" },
    { id: 27, name: "Warkocze francuskie 3" },
    { id: 28, name: "Warkoczyki z grzywką" },
    { id: 29, name: "Wzburzone morze" },
    { id: 30, name: "Upadły wąż" },
    { id: 31, name: "Banan z kitą" },
    { id: 32, name: "Zaczeska" },
    { id: 33, name: "Undercut 2" },
    { id: 34, name: "Undercut 3" },
    { id: 35, name: "Irokez z wygolonymi bokami" },
    { id: 36, name: "Warkoczyki bokserskie" },
    { id: 37, name: "Sama grzywa" },
    { id: 38, name: "Paź" }
];
let hairColors = [
    { id: 0, name: "Czarny" },
    { id: 1, name: "Pieprz" },
    { id: 2, name: "Gorzka czekolada" },
    { id: 3, name: "Brąz" },
    { id: 4, name: "Mleczna czekolada" },
    { id: 5, name: "Miedziany" },
    { id: 6, name: "Miodowy" },
    { id: 7, name: "Topaz" },
    { id: 8, name: "Popielaty blond" },
    { id: 9, name: "Jasny popielaty blond" },
    { id: 10, name: "Platyna" },
    { id: 11, name: "Szampan" },
    { id: 12, name: "Jasny blond" },
    { id: 13, name: "Blond" },
    { id: 14, name: "Słoneczny blond" },
    { id: 15, name: "Słomiany" },
    { id: 16, name: "Złocisty blond" },
    { id: 17, name: "Cynamon" },
    { id: 18, name: "Miedziany blond" },
    { id: 19, name: "Pikantna papryczka" },
    { id: 20, name: "Papryka" },
    { id: 21, name: "Kora" },
    { id: 22, name: "Marchewkowy" },
    { id: 23, name: "Pomarańczka" },
    { id: 24, name: "Whisky" },
    { id: 25, name: "Tycjanowska czerwień" },
    { id: 26, name: "Szarość" },
    { id: 27, name: "Siwy" },
    { id: 28, name: "Rozjaśniony popiel" },
    { id: 29, name: "Biała szarość" },
    { id: 30, name: "Fiolet" },
    { id: 31, name: "Wyprany fiolet" },
    { id: 32, name: "Śliwkowy" },
    { id: 33, name: "Neonowy róż" },
    { id: 34, name: "Matowy róż" },
    { id: 35, name: "Pudrowy róż" },
    { id: 36, name: "Seledynowy" },
    { id: 37, name: "Morski błękit" },
    { id: 38, name: "Granat" },
    { id: 39, name: "Zieleń" },
    { id: 40, name: "Trawa" },
    { id: 41, name: "Głębia morska" },
    { id: 42, name: "Neonowa zieleń" },
    { id: 43, name: "Matowa zieleń" },
    { id: 44, name: "Zieleń z refleksami" },
    { id: 45, name: "Jajeczny blond" },
    { id: 46, name: "Cytrynowy blond" },
    { id: 47, name: "Pigwa" },
    { id: 48, name: "Pomarańczowa miedź" },
    { id: 49, name: "Czerwień z refleksami" },
    { id: 50, name: "Płomienny rudy" },
    { id: 51, name: "Złota pomarańczka" },
    { id: 52, name: "Płomienny pomarańczowy" },
    { id: 53, name: "Jasna czerwień" },
    { id: 54, name: "Krwista czerwień" },
    { id: 55, name: "Brunet" },
    { id: 56, name: "Brąz 1" },
    { id: 57, name: "Brąz 2" },
    { id: 58, name: "Brąz 3" },
    { id: 59, name: "Brąz 4" },
    { id: 60, name: "Szatynowe" },
    { id: 61, name: "Głęboka czerń" },
    { id: 62, name: "Blond z odrostami" },
    { id: 63, name: "Jasny blond" }
];
let listBlemishes = [
    { id: 255, name: "Brak" },
    { id: 0, name: "Typ 1" },
    { id: 1, name: "Typ 2" },
    { id: 2, name: "Typ 3" },
    { id: 3, name: "Typ 4" },
    { id: 4, name: "Typ 5" },
    { id: 5, name: "Typ 6" },
    { id: 6, name: "Typ 7" },
    { id: 7, name: "Typ 8" },
    { id: 8, name: "Typ 9" },
    { id: 9, name: "Typ 10" },
    { id: 10, name: "Typ 11" },
    { id: 11, name: "Typ 12" },
    { id: 12, name: "Typ 13" },
    { id: 13, name: "Typ 14" },
    { id: 14, name: "Typ 15" },
    { id: 15, name: "Typ 16" },
    { id: 16, name: "Typ 17" },
    { id: 17, name: "Typ 18" },
    { id: 18, name: "Typ 19" },
    { id: 19, name: "Typ 20" },
    { id: 20, name: "Typ 21" },
    { id: 21, name: "Typ 22" },
    { id: 22, name: "Typ 23" },
    { id: 23, name: "Typ 24" }
];
let listFacialHair = [
    { id: 255, name: "Brak" },
    { id: 0, name: "Typ 1" },
    { id: 1, name: "Typ 2" },
    { id: 2, name: "Typ 3" },
    { id: 3, name: "Typ 4" },
    { id: 4, name: "Typ 5" },
    { id: 5, name: "Typ 6" },
    { id: 6, name: "Typ 7" },
    { id: 7, name: "Typ 8" },
    { id: 8, name: "Typ 9" },
    { id: 9, name: "Typ 10" },
    { id: 10, name: "Typ 11" },
    { id: 11, name: "Typ 12" },
    { id: 12, name: "Typ 13" },
    { id: 13, name: "Typ 14" },
    { id: 14, name: "Typ 15" },
    { id: 15, name: "Typ 16" },
    { id: 16, name: "Typ 17" },
    { id: 17, name: "Typ 18" },
    { id: 18, name: "Typ 19" },
    { id: 19, name: "Typ 20" },
    { id: 20, name: "Typ 21" },
    { id: 21, name: "Typ 22" },
    { id: 22, name: "Typ 23" },
    { id: 23, name: "Typ 24" },
    { id: 24, name: "Typ 25" },
    { id: 25, name: "Typ 26" },
    { id: 26, name: "Typ 27" },
    { id: 27, name: "Typ 28" },
    { id: 28, name: "Typ 29" }
];
let listFacialHairColor = [
    { id: 0, name: "Typ 1" },
    { id: 1, name: "Typ 2" },
    { id: 2, name: "Typ 3" },
    { id: 3, name: "Typ 4" },
    { id: 4, name: "Typ 5" },
    { id: 5, name: "Typ 6" },
    { id: 6, name: "Typ 7" },
    { id: 7, name: "Typ 8" },
    { id: 8, name: "Typ 9" },
    { id: 9, name: "Typ 10" },
    { id: 10, name: "Typ 11" },
    { id: 11, name: "Typ 12" },
    { id: 12, name: "Typ 13" },
    { id: 13, name: "Typ 14" },
    { id: 14, name: "Typ 15" },
    { id: 15, name: "Typ 16" },
    { id: 16, name: "Typ 17" },
    { id: 17, name: "Typ 18" },
    { id: 18, name: "Typ 19" },
    { id: 19, name: "Typ 20" },
    { id: 20, name: "Typ 21" },
    { id: 21, name: "Typ 22" },
    { id: 22, name: "Typ 23" },
    { id: 23, name: "Typ 24" },
    { id: 24, name: "Typ 25" },
    { id: 25, name: "Typ 26" },
    { id: 26, name: "Typ 27" },
    { id: 27, name: "Typ 28" },
    { id: 28, name: "Typ 29" },
    { id: 29, name: "Typ 30" },
    { id: 30, name: "Typ 31" },
    { id: 31, name: "Typ 32" },
    { id: 32, name: "Typ 33" },
    { id: 33, name: "Typ 34" },
    { id: 34, name: "Typ 35" },
    { id: 35, name: "Typ 36" },
    { id: 36, name: "Typ 37" },
    { id: 37, name: "Typ 38" },
    { id: 38, name: "Typ 39" },
    { id: 39, name: "Typ 40" },
    { id: 40, name: "Typ 41" },
    { id: 41, name: "Typ 42" },
    { id: 42, name: "Typ 43" },
    { id: 43, name: "Typ 44" },
    { id: 44, name: "Typ 45" },
    { id: 45, name: "Typ 46" },
    { id: 46, name: "Typ 47" },
    { id: 47, name: "Typ 48" },
    { id: 48, name: "Typ 49" },
    { id: 49, name: "Typ 50" },
    { id: 50, name: "Typ 51" },
    { id: 51, name: "Typ 52" },
    { id: 52, name: "Typ 53" },
    { id: 53, name: "Typ 54" },
    { id: 54, name: "Typ 55" },
    { id: 55, name: "Typ 56" },
    { id: 56, name: "Typ 57" },
    { id: 57, name: "Typ 58" },
    { id: 58, name: "Typ 59" },
    { id: 59, name: "Typ 60" },
    { id: 60, name: "Typ 61" },
    { id: 61, name: "Typ 62" },
    { id: 62, name: "Typ 63" },
    { id: 63, name: "Typ 64" }
];
let listEyeBrows = [
    { id: 255, name: "Brak" },
    { id: 0, name: "Typ 1" },
    { id: 1, name: "Typ 2" },
    { id: 2, name: "Typ 3" },
    { id: 3, name: "Typ 4" },
    { id: 4, name: "Typ 5" },
    { id: 5, name: "Typ 6" },
    { id: 6, name: "Typ 7" },
    { id: 7, name: "Typ 8" },
    { id: 8, name: "Typ 9" },
    { id: 9, name: "Typ 10" },
    { id: 10, name: "Typ 11" },
    { id: 11, name: "Typ 12" },
    { id: 12, name: "Typ 13" },
    { id: 13, name: "Typ 14" },
    { id: 14, name: "Typ 15" },
    { id: 15, name: "Typ 16" },
    { id: 16, name: "Typ 17" },
    { id: 17, name: "Typ 18" },
    { id: 18, name: "Typ 19" },
    { id: 19, name: "Typ 20" },
    { id: 20, name: "Typ 21" },
    { id: 21, name: "Typ 22" },
    { id: 22, name: "Typ 23" },
    { id: 23, name: "Typ 24" },
    { id: 24, name: "Typ 25" },
    { id: 25, name: "Typ 26" },
    { id: 26, name: "Typ 27" },
    { id: 27, name: "Typ 28" },
    { id: 28, name: "Typ 29" },
    { id: 29, name: "Typ 30" },
    { id: 30, name: "Typ 31" },
    { id: 31, name: "Typ 32" },
    { id: 32, name: "Typ 33" },
    { id: 33, name: "Typ 34" }
];

// UBRANIA


// WYBRANE OPCJE
let choosedMenSkin = 0;
let choosedWomenSkin = 0;
let choosedHair = 0;
let choosedHairColor = 0;

let maxDrawableData =
{
    3: 112,
    4: 99,
    5: 70,
    6: 74,
    7: 129,
    8: 132,
    11: 254,

    100: 0,
    101: 0,
    102: 0
};

let maxTextureData = {
    4: 0,
    5: 0,
    6: 0,
    7: 0,
    8: 0,
    11: 0,

    100: 0,
    101: 0,
    102: 0
};

let choosedBlemishes = 0;
let choosedFacialHair = 0;
let choosedFacialHairColor = 0;
let choosedEyeBrows = 0;


function changeMenSkin(up) {
    if (up) {
        choosedMenSkin++;
        if (choosedMenSkin > (menSkins.length - 1)) {
            choosedMenSkin = menSkins.length - 1;
        }
    } else {
        choosedMenSkin--;
        if (choosedMenSkin < 0) {
            choosedMenSkin = 0;
        }
    }
    $("#char-creator-father-name").html(`${menSkins[choosedMenSkin].name} (${menSkins[choosedMenSkin].id})`);
    updateGameSkin();
}

function changeWomenSkin(up) {
    if (up) {
        choosedWomenSkin++;
        if (choosedWomenSkin > (womenSkins.length - 1)) {
            choosedWomenSkin = womenSkins.length - 1;
        }
    } else {
        choosedWomenSkin--;
        if (choosedWomenSkin < 0) {
            choosedWomenSkin = 0;
        }
    }
    $("#char-creator-mother-name").html(`${womenSkins[choosedWomenSkin].name} (${womenSkins[choosedWomenSkin].id})`);
    updateGameSkin();
}

function changeHair(up) {
    if (up) {
        choosedHair++;
        if (choosedHair > ((isFemale ? womenHairs.length : menHairs.length) - 1)) {
            choosedHair = (isFemale ? womenHairs.length : menHairs.length) - 1;
        }
    } else {
        choosedHair--;
        if (choosedHair < 0) {
            choosedHair = 0;
        }
    }
    $("#char-creator-hair-name").html(`${isFemale ? womenHairs[choosedHair].name : menHairs[choosedHair].name}`);
    updateGameSkin();
}

function changeHairColor(up) {
    if (up) {
        choosedHairColor++;
        if (choosedHairColor > (hairColors.length - 1)) {
            choosedHairColor = hairColors.length - 1;
        }
    } else {
        choosedHairColor--;
        if (choosedHairColor < 0) {
            choosedHairColor = 0;
        }
    }
    $("#char-creator-haircolor-name").html(`${hairColors[choosedHairColor].name}`);
    updateGameSkin();
}

function changeBlemishes(up) {
    if (up) {
        choosedBlemishes++;
        if (choosedBlemishes > (listBlemishes.length - 1)) {
            choosedBlemishes = listBlemishes.length - 1;
        }
    } else {
        choosedBlemishes--;
        if (choosedBlemishes < 0) {
            choosedBlemishes = 0;
        }
    }
    $("#char-creator-blemishes-name").html(`${listBlemishes[choosedBlemishes].name}`);
    updateGameSkin();
}

function changeFacialHair(up) {
    if (up) {
        choosedFacialHair++;
        if (choosedFacialHair > (listFacialHair.length - 1)) {
            choosedFacialHair = listFacialHair.length - 1;
        }
    } else {
        choosedFacialHair--;
        if (choosedFacialHair < 0) {
            choosedFacialHair = 0;
        }
    }
    $("#char-creator-facialhair-name").html(`${listFacialHair[choosedFacialHair].name}`);
    updateGameSkin();
}

function changeFacialHairColor(up) {
    if (up) {
        choosedFacialHairColor++;
        if (choosedFacialHairColor > (listFacialHairColor.length - 1)) {
            choosedFacialHairColor = listFacialHairColor.length - 1;
        }
    } else {
        choosedFacialHairColor--;
        if (choosedFacialHairColor < 0) {
            choosedFacialHairColor = 0;
        }
    }
    $("#char-creator-facialhaircolor-name").html(`${listFacialHairColor[choosedFacialHairColor].name}`);
    updateGameSkin();
}

function changeEyeBrows(up) {
    if (up) {
        choosedEyeBrows++;
        if (choosedEyeBrows > (listEyeBrows.length - 1)) {
            choosedEyeBrows = listEyeBrows.length - 1;
        }
    } else {
        choosedEyeBrows--;
        if (choosedEyeBrows < 0) {
            choosedEyeBrows = 0;
        }
    }
    $("#char-creator-eyebrows-name").html(`${listEyeBrows[choosedEyeBrows].name}`);
    updateGameSkin();
}

function updateGameSkin() {
    let shapeMix = charCreatorSkinMixSlider.noUiSlider.get();
    let skinMix = charCreatorSkinColorMixSlider.noUiSlider.get();

    let noseWidth = charCreatorNoseWidthSlider.noUiSlider.get();
    var noseHeight = charCreatorNoseHeightSlider.noUiSlider.get();
    var noseLength = charCreatorNoseLengthSlider.noUiSlider.get();
    var noseBridge = charCreatorNoseBridgeSlider.noUiSlider.get();
    var noseTip = charCreatorNoseTipSlider.noUiSlider.get();
    var noseBridgeShift = charCreatorNoseBridgeShiftSlider.noUiSlider.get();

    let noseData =
    {
        width: parseFloat(noseWidth),
        height: parseFloat(noseHeight),
        length: parseFloat(noseLength),
        bridge: parseFloat(noseBridge),
        tip: parseFloat(noseTip),
        bridgeShift: parseFloat(noseBridgeShift)
    };


    mp.trigger("updatePlayer",
        womenSkins[choosedWomenSkin].id,
        menSkins[choosedMenSkin].id,
        menHairs[choosedHair].id,
        hairColors[choosedHairColor].id,
        parseFloat(shapeMix),
        parseFloat(skinMix),
        listBlemishes[choosedBlemishes].id,
        listFacialHair[choosedFacialHair].id,
        listFacialHairColor[choosedFacialHairColor].id,
        listEyeBrows[choosedEyeBrows].id,
        JSON.stringify(noseData));

}

function SaveSkin() {
    let shapeMix = charCreatorSkinMixSlider.noUiSlider.get();
    let skinMix = charCreatorSkinColorMixSlider.noUiSlider.get();

    let noseWidth = charCreatorNoseWidthSlider.noUiSlider.get();
    var noseHeight = charCreatorNoseHeightSlider.noUiSlider.get();
    var noseLength = charCreatorNoseLengthSlider.noUiSlider.get();
    var noseBridge = charCreatorNoseBridgeSlider.noUiSlider.get();
    var noseTip = charCreatorNoseTipSlider.noUiSlider.get();
    var noseBridgeShift = charCreatorNoseBridgeShiftSlider.noUiSlider.get();

    let noseData =
    {
        width: parseFloat(noseWidth),
        height: parseFloat(noseHeight),
        length: parseFloat(noseLength),
        bridge: parseFloat(noseBridge),
        tip: parseFloat(noseTip),
        bridgeShift: parseFloat(noseBridgeShift)
    };

    let skinData =
    {
        motherId: womenSkins[choosedWomenSkin].id,
        fatherId: menSkins[choosedMenSkin].id,
        hairId: isFemale ? womenHairs[choosedHair].id : menHairs[choosedHair].id,
        hairColor: hairColors[choosedHairColor].id,
        shapeMix: parseFloat(shapeMix),
        skinMix: parseFloat(skinMix),
        blemishes: listBlemishes[choosedBlemishes].id,
        facialHair: listFacialHair[choosedFacialHair].id,
        overlayColor: listFacialHairColor[choosedFacialHairColor].id,
        eyeBrows: listEyeBrows[choosedEyeBrows].id
    };

    mp.trigger("savePlayerSkin", JSON.stringify(skinData), JSON.stringify(noseData));
}

function toggleCharCreator(state, female = false) {
    if (state) {
        $("#char-creator").show();
        isFemale = female;
        creatorEnabled = true;
        creatorStep = 1;
    } else {
        $("#char-creator").hide();
        creatorEnabled = false;
    }
}


// KREATOR UBRAŃ
let choosedTorso = 0;
let choosedLegs = 0;
let choosedLegsTexture = 0;
let choosedBag = 0;
let choosedBagTexture = 0;
let choosedBoots = 0;
let choosedBootsTexture = 0;
let choosedAccessories = 0;
let choosedAccessoriesTexture = 0;
let choosedUndershirt = 0;
let choosedUndershirtTexture = 0;
let choosedTops = 0;
let choosedTopsTexture = 0;
let choosedGlasses = 0;
let choosedGlassesTexture = 0;
let choosedHat = 0;
let choosedHatTexture = 0;
let choosedEars = 0;
let choosedEarsTexture = 0;

function toggleClothesCreator(state) {
    if (state) {
        mp.trigger("cef.char-creator.triggerMaxDrawableData");

        choosedTorso = 0;
        choosedLegs = 0;
        choosedLegsTexture = 0;
        choosedBag = 0;
        choosedBagTexture = 0;
        choosedBoots = 0;
        choosedBootsTexture = 0;
        choosedAccessories = 0;
        choosedAccessoriesTexture = 0;
        choosedUndershirt = 0;
        choosedUndershirtTexture = 0;
        choosedTops = 0;
        choosedTopsTexture = 0;
        choosedGlasses = 0;
        choosedGlassesTexture = 0;
        choosedHat = 0;
        choosedHatTexture = 0;
        choosedEars = 0;
        choosedEarsTexture = 0;

        $("#char-clothes").show();
        creatorStep = 2;
        creatorEnabled = true;
        selectedField = 0;
    } else {
        $("#char-clothes").hide();
        creatorStep = 1;
        creatorEnabled = false;
    }
}

function ChooseCreator(index, state) {
    switch (index) {
    case 1: // torso
        if (state) {
            choosedTorso++;
            if (choosedTorso > (maxDrawableData[3] - 1)) {
                choosedTorso = maxDrawableData[3] - 1;
            }
        } else {
            choosedTorso--;
            if (choosedTorso < 0) {
                choosedTorso = 0;
            }
        }
        break;
    case 2: // Legs
        if (state) {
            choosedLegs++;
            if (choosedLegs > (maxDrawableData[4] - 1)) {
                choosedLegs = maxDrawableData[4] - 1;
            }
        } else {
            choosedLegs--;
            if (choosedLegs < 0) {
                choosedLegs = 0;
            }
        }
        choosedLegsTexture = 0;
        mp.trigger("cef.char-creator.triggerMaxTextureData", 4, choosedLegs);
        break;
    case 3: // Legs texture
        if (state) {
            choosedLegsTexture++;
            if (choosedLegsTexture > maxTextureData[4] - 1) {
                choosedLegsTexture = maxTextureData[4] - 1;
            }
        } else {
            choosedLegsTexture--;
            if (choosedLegsTexture < 0) {
                choosedLegsTexture = 0;
            }
        }
        break;
    case 4: // Bag
        if (state) {
            choosedBag++;
            if (choosedBag > (maxDrawableData[5] - 1)) {
                choosedBag = maxDrawableData[5] - 1;
            }
        } else {
            choosedBag--;
            if (choosedBag < 0) {
                choosedBag = 0;
            }
        }
        choosedBagTexture = 0;
        mp.trigger("cef.char-creator.triggerMaxTextureData", 5, choosedBag);
        break;
    case 5: // Bag texture
        if (state) {
            choosedBagTexture++;
            if (choosedBagTexture > maxTextureData[5] - 1) {
                choosedBagTexture = maxTextureData[5] - 1;
            }
        } else {
            choosedBagTexture--;
            if (choosedBagTexture < 0) {
                choosedBagTexture = 0;
            }
        }
        break;
    case 6: // Boots
        if (state) {
            choosedBoots++;
            if (choosedBoots > (maxDrawableData[6] - 1)) {
                choosedBoots = maxDrawableData[6] - 1;
            }
        } else {
            choosedBoots--;
            if (choosedBoots < 0) {
                choosedBoots = 0;
            }
        }
        choosedBootsTexture = 0;
        mp.trigger("cef.char-creator.triggerMaxTextureData", 6, choosedBoots);
        break;
    case 7: // Boots texture
        if (state) {
            choosedBootsTexture++;
            if (choosedBootsTexture > maxTextureData[6] - 1) {
                choosedBootsTexture = maxTextureData[6] - 1;
            }
        } else {
            choosedBootsTexture--;
            if (choosedBootsTexture < 0) {
                choosedBootsTexture = 0;
            }
        }
        break;
    case 8: // Accessories
        if (state) {
            choosedAccessories++;
            if (choosedAccessories > (maxDrawableData[7] - 1)) {
                choosedAccessories = maxDrawableData[7] - 1;
            }
        } else {
            choosedAccessories--;
            if (choosedAccessories < 0) {
                choosedAccessories = 0;
            }
        }
        choosedAccessoriesTexture = 0;
        mp.trigger("cef.char-creator.triggerMaxTextureData", 7, choosedAccessories);
        break;
    case 9: // Accessories texture
        if (state) {
            choosedAccessoriesTexture++;
            if (choosedAccessoriesTexture > maxTextureData[7] - 1) {
                choosedAccessoriesTexture = maxTextureData[7] - 1;
            }
        } else {
            choosedAccessoriesTexture--;
            if (choosedAccessoriesTexture < 0) {
                choosedAccessoriesTexture = 0;
            }
        }
        break;
    case 10: // Undershirt
        if (state) {
            choosedUndershirt++;
            if (choosedUndershirt > (maxDrawableData[8] - 1)) {
                choosedUndershirt = maxDrawableData[8] - 1;
            }
        } else {
            choosedUndershirt--;
            if (choosedUndershirt < 0) {
                choosedUndershirt = 0;
            }
        }
        choosedUndershirtTexture = 0;
        mp.trigger("cef.char-creator.triggerMaxTextureData", 8, choosedUndershirt);
        break;
    case 11: // Undershirt texture
        if (state) {
            choosedUndershirtTexture++;
            if (choosedUndershirtTexture > maxTextureData[8] - 1) {
                choosedUndershirtTexture = maxTextureData[8] - 1;
            }
        } else {
            choosedUndershirtTexture--;
            if (choosedUndershirtTexture < 0) {
                choosedUndershirtTexture = 0;
            }
        }
        break;
    case 12: // Tops
        if (state) {
            choosedTops++;
            if (choosedTops > (maxDrawableData[11] - 1)) {
                choosedTops = maxDrawableData[11] - 1;
            }
        } else {
            choosedTops--;
            if (choosedTops < 0) {
                choosedTops = 0;
            }
        }
        choosedTopsTexture = 0;
        mp.trigger("cef.char-creator.triggerMaxTextureData", 11, choosedTops);
        break;
    case 13: // Tops texture
        if (state) {
            choosedTopsTexture++;
            if (choosedTopsTexture > maxTextureData[11] - 1) {
                choosedTopsTexture = maxTextureData[11] - 1;
            }
        } else {
            choosedTopsTexture--;
            if (choosedTopsTexture < 0) {
                choosedTopsTexture = 0;
            }
        }
        break;

    case 14: // Glasses
        if (state) {
            choosedGlasses++;
            if (choosedGlasses > (maxDrawableData[101] - 1)) {
                choosedGlasses = maxDrawableData[101] - 1;
            }
        } else {
            choosedGlasses--;
            if (choosedGlasses < 0) {
                choosedGlasses = 0;
            }
        }
        choosedGlassesTexture = 0;
        mp.trigger("cef.char-creator.triggerMaxTextureDataProp", 1, choosedGlasses);
        break;
    case 15: // Glasses texture
        if (state) {
            choosedGlassesTexture++;
            if (choosedGlassesTexture > maxTextureData[101] - 1) {
                choosedGlassesTexture = maxTextureData[101] - 1;
            }
        } else {
            choosedGlassesTexture--;
            if (choosedGlassesTexture < 0) {
                choosedGlassesTexture = 0;
            }
        }
        break;
    case 16: // Hats
        if (state) {
            choosedHat++;
            if (choosedHat > (maxDrawableData[100] - 1)) {
                choosedHat = maxDrawableData[100] - 1;
            }
        } else {
            choosedHat--;
            if (choosedHat < 0) {
                choosedHat = 0;
            }
        }
        choosedHatTexture = 0;
        mp.trigger("cef.char-creator.triggerMaxTextureDataProp", 0, choosedHat);
        break;
    case 17: // Hats texture
        if (state) {
            choosedHatTexture++;
            if (choosedHatTexture > maxTextureData[100] - 1) {
                choosedHatTexture = maxTextureData[100] - 1;
            }
        } else {
            choosedHatTexture--;
            if (choosedHatTexture < 0) {
                choosedHatTexture = 0;
            }
        }
        break;
    case 18: // Ears
        if (state) {
            choosedEars++;
            if (choosedEars > (maxDrawableData[102] - 1)) {
                choosedEars = maxDrawableData[102] - 1;
            }
        } else {
            choosedEars--;
            if (choosedEars < 0) {
                choosedEars = 0;
            }
        }
        choosedEarsTexture = 0;
        mp.trigger("cef.char-creator.triggerMaxTextureDataProp", 2, choosedEars);
        break;
    case 19: // Ears texture
        if (state) {
            choosedEarsTexture++;
            if (choosedEarsTexture > maxTextureData[102] - 1) {
                choosedEarsTexture = maxTextureData[102] - 1;
            }
        } else {
            choosedEarsTexture--;
            if (choosedEarsTexture < 0) {
                choosedEarsTexture = 0;
            }
        }
        break;
    }
    RefreshClothesCreatorUI();
}

function LoadMaxData(drawableData) {
    let parsedDrawableData = JSON.parse(decodeURIComponent(drawableData));
    maxDrawableData = parsedDrawableData;
}

function LoadMaxTextureData(componentId, textureData) {
    maxTextureData[parseInt(componentId)] = parseInt(textureData);
}

function RefreshClothesCreatorUI() {
    $("#char-clothes-torso-name").html(`Typ ${choosedTorso + 1}`);
    $("#char-clothes-legs-name").html(`Typ ${choosedLegs + 1}`);
    $("#char-clothes-legst-name").html(`Typ ${choosedLegsTexture + 1}`);
    $("#char-clothes-bag-name").html(`Typ ${choosedBag + 1}`);
    $("#char-clothes-bagt-name").html(`Typ ${choosedBagTexture + 1}`);
    $("#char-clothes-boots-name").html(`Typ ${choosedBoots + 1}`);
    $("#char-clothes-bootst-name").html(`Typ ${choosedBootsTexture + 1}`);
    $("#char-clothes-accessories-name").html(`Typ ${choosedAccessories + 1}`);
    $("#char-clothes-accessoriest-name").html(`Typ ${choosedAccessoriesTexture + 1}`);
    $("#char-clothes-undershirt-name").html(`Typ ${choosedUndershirt + 1}`);
    $("#char-clothes-undershirtt-name").html(`Typ ${choosedUndershirtTexture + 1}`);
    $("#char-clothes-tops-name").html(`Typ ${choosedTops + 1}`);
    $("#char-clothes-topst-name").html(`Typ ${choosedTopsTexture + 1}`);
    $("#char-clothes-glasses-name").html(`Typ ${choosedGlasses + 1}`);
    $("#char-clothes-glassest-name").html(`Typ ${choosedGlassesTexture + 1}`);
    $("#char-clothes-hats-name").html(`Typ ${choosedHat + 1}`);
    $("#char-clothes-hatst-name").html(`Typ ${choosedHatTexture + 1}`);
    $("#char-clothes-ears-name").html(`Typ ${choosedEars + 1}`);
    $("#char-clothes-earst-name").html(`Typ ${choosedEarsTexture + 1}`);

    let jsonData =
    {
        torso: choosedTorso,
        legs: choosedLegs,
        legsTexture: choosedLegsTexture,
        bag: choosedBag,
        bagTexture: choosedBagTexture,
        boots: choosedBoots,
        bootsTexture: choosedBootsTexture,
        accessories: choosedAccessories,
        accessoriesTexture: choosedAccessoriesTexture,
        undershirt: choosedUndershirt,
        undershirtTexture: choosedUndershirtTexture,
        top: choosedTops,
        topTexture: choosedTopsTexture,
        glasses: choosedGlasses,
        glassesTexture: choosedGlassesTexture,
        hat: choosedHat,
        hatTexture: choosedHatTexture,
        ears: choosedEars,
        earsTexture: choosedEarsTexture
    };
    mp.trigger("updatePlayerClothes", JSON.stringify(jsonData));
}

function SaveClothes() {
    let jsonData =
    {
        torso: choosedTorso,
        legs: choosedLegs,
        legsTexture: choosedLegsTexture,
        bag: choosedBag,
        bagTexture: choosedBagTexture,
        boots: choosedBoots,
        bootsTexture: choosedBootsTexture,
        accessories: choosedAccessories,
        accessoriesTexture: choosedAccessoriesTexture,
        undershirt: choosedUndershirt,
        undershirtTexture: choosedUndershirtTexture,
        top: choosedTops,
        topTexture: choosedTopsTexture,
        glasses: choosedGlasses,
        glassesTexture: choosedGlassesTexture,
        hat: choosedHat,
        hatTexture: choosedHatTexture,
        ears: choosedEars,
        earsTexture: choosedEarsTexture
    };
    mp.trigger("cef.char-creator.saveClothes", JSON.stringify(jsonData));
}

document.addEventListener('keydown',
    (event) => {
        const keyName = event.key;
        if (creatorEnabled) {
            if (keyName == 'ArrowDown') {
                rowSelect(false);
            } else if (keyName == 'ArrowUp') {
                rowSelect(true);
            } else if (keyName == 'ArrowLeft') {
                if (creatorStep == 1 && creatorEnabled) {
                    if (selectedField == 0) {
                        changeMenSkin(false);
                    } else if (selectedField == 1) {
                        changeWomenSkin(false);
                    } else if (selectedField == 2) {
                        setSkinMix(false);
                    } else if (selectedField == 3) {
                        setSkinColorMix(false);
                    } else if (selectedField == 4) {
                        changeHair(false);
                    } else if (selectedField == 5) {
                        changeHairColor(false);
                    } else if (selectedField == 6) {
                        changeBlemishes(false);
                    } else if (selectedField == 7) {
                        changeFacialHair(false);
                    } else if (selectedField == 8) {
                        changeFacialHairColor(false);
                    } else if (selectedField == 9) {
                        changeEyeBrows(false);
                    } else if (selectedField == 10) {
                        setNoseWidth(false);
                    } else if (selectedField == 11) {
                        setNoseHeight(false);
                    } else if (selectedField == 12) {
                        setNoseLength(false);
                    } else if (selectedField == 13) {
                        setNoseBridge(false);
                    } else if (selectedField == 14) {
                        setNoseTip(false);
                    } else if (selectedField == 15) {
                        setNoseBridgeShift(false);
                    }
                } else {
                    if (selectedField == 0) {
                        ChooseCreator(1, false);
                    } else if (selectedField == 1) {
                        ChooseCreator(2, false);
                    } else if (selectedField == 2) {
                        ChooseCreator(3, false);
                    } else if (selectedField == 3) {
                        ChooseCreator(4, false);
                    } else if (selectedField == 4) {
                        ChooseCreator(5, false);
                    } else if (selectedField == 5) {
                        ChooseCreator(6, false);
                    } else if (selectedField == 6) {
                        ChooseCreator(7, false);
                    } else if (selectedField == 7) {
                        ChooseCreator(8, false);
                    } else if (selectedField == 8) {
                        ChooseCreator(9, false);
                    } else if (selectedField == 9) {
                        ChooseCreator(10, false);
                    } else if (selectedField == 10) {
                        ChooseCreator(11, false);
                    } else if (selectedField == 11) {
                        ChooseCreator(12, false);
                    } else if (selectedField == 12) {
                        ChooseCreator(13, false);
                    } else if (selectedField == 13) {
                        ChooseCreator(14, false);
                    } else if (selectedField == 14) {
                        ChooseCreator(15, false);
                    } else if (selectedField == 15) {
                        ChooseCreator(16, false);
                    } else if (selectedField == 16) {
                        ChooseCreator(17, false);
                    } else if (selectedField == 17) {
                        ChooseCreator(18, false);
                    } else if (selectedField == 18) {
                        ChooseCreator(19, false);
                    }
                }
            } else if (keyName == 'ArrowRight') {
                if (creatorStep == 1) {
                    if (selectedField == 0) {
                        changeMenSkin(true);
                    } else if (selectedField == 1) {
                        changeWomenSkin(true);
                    } else if (selectedField == 2) {
                        setSkinMix(true);
                    } else if (selectedField == 3) {
                        setSkinColorMix(true);
                    } else if (selectedField == 4) {
                        changeHair(true);
                    } else if (selectedField == 5) {
                        changeHairColor(true);
                    } else if (selectedField == 6) {
                        changeBlemishes(true);
                    } else if (selectedField == 7) {
                        changeFacialHair(true);
                    } else if (selectedField == 8) {
                        changeFacialHairColor(true);
                    } else if (selectedField == 9) {
                        changeEyeBrows(true);
                    } else if (selectedField == 10) {
                        setNoseWidth(true);
                    } else if (selectedField == 11) {
                        setNoseHeight(true);
                    } else if (selectedField == 12) {
                        setNoseLength(true);
                    } else if (selectedField == 13) {
                        setNoseBridge(true);
                    } else if (selectedField == 14) {
                        setNoseTip(true);
                    } else if (selectedField == 15) {
                        setNoseBridgeShift(true);
                    }
                } else {
                    if (selectedField == 0) {
                        ChooseCreator(1, true);
                    } else if (selectedField == 1) {
                        ChooseCreator(2, true);
                    } else if (selectedField == 2) {
                        ChooseCreator(3, true);
                    } else if (selectedField == 3) {
                        ChooseCreator(4, true);
                    } else if (selectedField == 4) {
                        ChooseCreator(5, true);
                    } else if (selectedField == 5) {
                        ChooseCreator(6, true);
                    } else if (selectedField == 6) {
                        ChooseCreator(7, true);
                    } else if (selectedField == 7) {
                        ChooseCreator(8, true);
                    } else if (selectedField == 8) {
                        ChooseCreator(9, true);
                    } else if (selectedField == 9) {
                        ChooseCreator(10, true);
                    } else if (selectedField == 10) {
                        ChooseCreator(11, true);
                    } else if (selectedField == 11) {
                        ChooseCreator(12, true);
                    } else if (selectedField == 12) {
                        ChooseCreator(13, true);
                    } else if (selectedField == 12) {
                        ChooseCreator(13, true);
                    } else if (selectedField == 13) {
                        ChooseCreator(14, true);
                    } else if (selectedField == 14) {
                        ChooseCreator(15, true);
                    } else if (selectedField == 15) {
                        ChooseCreator(16, true);
                    } else if (selectedField == 16) {
                        ChooseCreator(17, true);
                    } else if (selectedField == 17) {
                        ChooseCreator(18, true);
                    } else if (selectedField == 18) {
                        ChooseCreator(19, true);
                    }
                }
            }
        }
    });

var defValue = 0.5;

function setSkinMix(state) {
    if (!state) {
        if (defValue > 0.0) {
            defValue -= 0.05;
            charCreatorSkinMixSlider.noUiSlider.set(defValue);
        }
    } else {
        if (defValue < 1.0) {
            defValue += 0.05;
            charCreatorSkinMixSlider.noUiSlider.set(defValue);
        }
    }
}

var defValue2 = 0.5;

function setSkinColorMix(state) {
    if (!state) {
        if (defValue2 > 0.0) {
            defValue2 -= 0.05;
            charCreatorSkinColorMixSlider.noUiSlider.set(defValue2);
        }

    } else {
        if (defValue2 < 1.0) {
            defValue2 += 0.05;
            charCreatorSkinColorMixSlider.noUiSlider.set(defValue2);
        }
    }
}

var defValue3 = 0.0;

function setNoseWidth(state) {
    if (!state) {
        if (defValue3 > -1.0) {
            defValue3 -= 0.05;
            charCreatorNoseWidthSlider.noUiSlider.set(defValue3);
        }
    } else {
        if (defValue3 < 1.0) {
            defValue3 += 0.05;
            charCreatorNoseWidthSlider.noUiSlider.set(defValue3);
        }
    }
}

var defValue4 = 0.0;

function setNoseHeight(state) {
    if (!state) {
        if (defValue4 > -1.0) {
            defValue4 -= 0.05;
            charCreatorNoseHeightSlider.noUiSlider.set(defValue4);
        }
    } else {
        if (defValue4 < 1.0) {
            defValue4 += 0.05;
            charCreatorNoseHeightSlider.noUiSlider.set(defValue4);
        }
    }
}

var defValue5 = 0.0;

function setNoseBridge(state) {
    if (!state) {
        if (defValue5 > -1.0) {
            defValue5 -= 0.05;
            charCreatorNoseBridgeSlider.noUiSlider.set(defValue5);
        }
    } else {
        if (defValue5 < 1.0) {
            defValue5 += 0.05;
            charCreatorNoseBridgeSlider.noUiSlider.set(defValue5);
        }
    }
}

var defValue6 = 0.0;

function setNoseTip(state) {
    if (!state) {
        if (defValue6 > -1.0) {
            defValue6 -= 0.05;
            charCreatorNoseTipSlider.noUiSlider.set(defValue6);
        }
    } else {
        if (defValue6 < 1.0) {
            defValue6 += 0.05;
            charCreatorNoseTipSlider.noUiSlider.set(defValue6);
        }
    }
}

var defValue7 = 0.0;

function setNoseBridgeShift(state) {
    if (!state) {
        if (defValue7 > -1.0) {
            defValue7 -= 0.05;
            charCreatorNoseBridgeShiftSlider.noUiSlider.set(defValue7);
        }
    } else {
        if (defValue7 < -1.0) {
            defValue7 += 0.05;
            charCreatorNoseBridgeShiftSlider.noUiSlider.set(defValue7);
        }
    }
}

var defValue8 = 0.0;

function setNoseLength(state) {
    if (!state) {
        if (defValue8 > -1.0) {
            defValue8 -= 0.05;
            charCreatorNoseLengthSlider.noUiSlider.set(defValue8);
        }
    } else {
        if (defValue8 < 1.0) {
            defValue8 += 0.05;
            charCreatorNoseLengthSlider.noUiSlider.set(defValue8);
        }
    }
}


function rowSelect(state) {
    if (state) {
        var row = "cc";
        if (creatorStep == 1) {
            row = "cc" + selectedField;
        } else if (creatorStep == 2) {
            row = "clc" + selectedField;
        }
        document.getElementById(row).style.backgroundColor = "transparent";
        document.getElementById(row).style.color = "white";
        if (creatorStep == 1 && selectedField != 0) {
            selectedField --;
        } else if (creatorStep == 2 && selectedField != 0) {
            selectedField --;
        }
        if (creatorStep == 1) {
            row = "cc" + selectedField;
        } else if (creatorStep == 2) {
            row = "clc" + selectedField;
        }
        document.getElementById(row).style.backgroundColor = "white";
        document.getElementById(row).style.color = "black";
    } else {
        var row = "cc";
        if (creatorStep == 1) {
            row = "cc" + selectedField;
        } else if (creatorStep == 2) {
            row = "clc" + selectedField;
        }
        document.getElementById(row).style.backgroundColor = "transparent";
        document.getElementById(row).style.color = "white";
        if (creatorStep == 1 && selectedField != 15) {
            selectedField ++;
        } else if (creatorStep == 2 && selectedField != 18) {
            selectedField ++;
        }
        if (creatorStep == 1) {
            row = "cc" + selectedField;
        } else if (creatorStep == 2) {
            row = "clc" + selectedField;
        }
        document.getElementById(row).style.backgroundColor = "white";
        document.getElementById(row).style.color = "black";
    }
}

$(document).ready(function() {

    charCreatorSkinMixSlider = document.getElementById('char-creator-skin-mix');
    charCreatorSkinColorMixSlider = document.getElementById('char-creator-skin-color-mix');

    charCreatorNoseWidthSlider = document.getElementById('char-creator-nose-width');
    charCreatorNoseHeightSlider = document.getElementById('char-creator-nose-height');
    charCreatorNoseLengthSlider = document.getElementById('char-creator-nose-length');
    charCreatorNoseBridgeSlider = document.getElementById('char-creator-nose-bridge');
    charCreatorNoseTipSlider = document.getElementById('char-creator-nose-tip');
    charCreatorNoseBridgeShiftSlider = document.getElementById('char-creator-nose-bridgeshift');


    noUiSlider.create(charCreatorSkinMixSlider,
        {
            start: [0.5],
            step: 0.01,
            range: {
                'min': [0.0],
                'max': [1.0]
            }
        });
    noUiSlider.create(charCreatorSkinColorMixSlider,
        {
            start: [0.5],
            step: 0.01,
            range: {
                'min': [0.0],
                'max': [1.0]
            }
        });

    noUiSlider.create(charCreatorNoseWidthSlider,
        {
            start: [0.0],
            step: 0.01,
            range: {
                'min': [-1.0],
                'max': [1.0]
            }
        });
    noUiSlider.create(charCreatorNoseHeightSlider,
        {
            start: [0.0],
            step: 0.01,
            range: {
                'min': [-1.0],
                'max': [1.0]
            }
        });
    noUiSlider.create(charCreatorNoseLengthSlider,
        {
            start: [0.0],
            step: 0.01,
            range: {
                'min': [-1.0],
                'max': [1.0]
            }
        });
    noUiSlider.create(charCreatorNoseBridgeSlider,
        {
            start: [0.0],
            step: 0.01,
            range: {
                'min': [-1.0],
                'max': [1.0]
            }
        });
    noUiSlider.create(charCreatorNoseTipSlider,
        {
            start: [0.0],
            step: 0.01,
            range: {
                'min': [-1.0],
                'max': [1.0]
            }
        });
    noUiSlider.create(charCreatorNoseBridgeShiftSlider,
        {
            start: [0.0],
            step: 0.01,
            range: {
                'min': [-1.0],
                'max': [1.0]
            }
        });


    charCreatorSkinMixSlider.noUiSlider.on("update",
        function(values, handle) {
            $("#char-creator-skin-mix-text").html(values[handle]);
            updateGameSkin();
        });
    charCreatorSkinColorMixSlider.noUiSlider.on("update",
        function(values, handle) {
            $("#char-creator-skin-mix-color-text").html(values[handle]);
            updateGameSkin();
        });


    charCreatorNoseWidthSlider.noUiSlider.on("update",
        function(values, handle) {
            $("#char-creator-nose-width-text").html(values[handle]);
            updateGameSkin();
        });
    charCreatorNoseHeightSlider.noUiSlider.on("update",
        function(values, handle) {
            $("#char-creator-nose-height-text").html(values[handle]);
            updateGameSkin();
        });
    charCreatorNoseLengthSlider.noUiSlider.on("update",
        function(values, handle) {
            $("#char-creator-nose-length-text").html(values[handle]);
            updateGameSkin();
        });
    charCreatorNoseBridgeSlider.noUiSlider.on("update",
        function(values, handle) {
            $("#char-creator-nose-bridge-text").html(values[handle]);
            updateGameSkin();
        });
    charCreatorNoseTipSlider.noUiSlider.on("update",
        function(values, handle) {
            $("#char-creator-nose-tip-text").html(values[handle]);
            updateGameSkin();
        });
    charCreatorNoseBridgeShiftSlider.noUiSlider.on("update",
        function(values, handle) {
            $("#char-creator-nose-bridgeshift-text").html(values[handle]);
            updateGameSkin();
        });
});