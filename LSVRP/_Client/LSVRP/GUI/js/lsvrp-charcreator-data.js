const TYPE_STANDARD = 1;
const TYPE_CUSTOM = 2;
const TYPE_STANDARD_SEX = 3;
const TYPE_SUBMIT = 4;
const TYPE_STANDARD_BINCO = 5;
const TYPE_TOP_BINCO = 6;
const TYPE_CANCEL = 7;

const CREATOR_TYPE_FULL = 0;
const CREATOR_TYPE_BINCO = 1;

const SEX_MALE = 0;
const SEX_FEMALE = 1;

const CreatorData = {
    Matka: 0,
    Ojciec: 1,
    MieszSkin: 2,
    MieszKolor: 3,
    Zarost: 4,
    Wlosy: 5,
    Brwi: 6,
    Blizny: 7,
    Postarzanie: 8,
    Makijaz: 9,
    Rumieniec: 10,
    Cera: 11,
    Oparzenia: 12,
    Pomadka: 13,
    Piegi: 14,
    Owlosienie: 15,
    SzerNos: 16,
    WysNos: 17,
    DlNos: 18,
    MosNos: 19,
    KonNos: 20,
    PrzesNos: 21,
    WysBrwi: 22,
    SzerBrwi: 23,
    WysKos: 24,
    SzerKos: 25,
    SzerPol: 26,
    SzerOcz: 27,
    SzerUst: 28,
    SzerSzcz: 29,
    WysSzcz: 30,
    DlPodbr: 31,
    PozPodbr: 32,
    SzerPodbr: 33,
    KsztPodbr: 34,
    DlSzyi: 35
};
const BincoData = {
    Top: 0,
    Undershirt: 1,
    Legs: 2,
    Boots: 3,
    Accessories: 4

};

const CREATOR_DATA_FULL = [
    {
        Text: "Skin ojca",
        Type: TYPE_STANDARD,
        Active: 0,
        Datas: [
            { Value: 0, Data: "James" },
            { Value: 1, Data: "David" },
            { Value: 2, Data: "Martin" },
            { Value: 3, Data: "Michael" },
            { Value: 4, Data: "Kenneth" },
            { Value: 5, Data: "Jesse" },
            { Value: 6, Data: "Fredrick" },
            { Value: 7, Data: "Ronald" },
            { Value: 8, Data: "Carl" },
            { Value: 9, Data: "Randolph" },
            { Value: 10, Data: "Jason" },
            { Value: 11, Data: "Shawn" },
            { Value: 12, Data: "William" },
            { Value: 13, Data: "Thomas" },
            { Value: 14, Data: "Jerry" },
            { Value: 15, Data: "Lewis" },
            { Value: 16, Data: "Gustavo" },
            { Value: 17, Data: "Oscar" },
            { Value: 18, Data: "Mark" },
            { Value: 19, Data: "Harold" },
            { Value: 20, Data: "Juan" },
            { Value: 42, Data: "Randall" },
            { Value: 43, Data: "Billy" },
            { Value: 44, Data: "Mike" }
        ],
        Color: false
    },
    {
        Text: "Skin matki",
        Type: TYPE_STANDARD,
        Active: 0,
        Datas: [
            { Value: 21, Data: "Emma" },
            { Value: 22, Data: "Towanda" },
            { Value: 23, Data: "Florene" },
            { Value: 24, Data: "Carol" },
            { Value: 25, Data: "Kristine" },
            { Value: 26, Data: "Cheryl" },
            { Value: 27, Data: "Caitlin" },
            { Value: 28, Data: "Patricia" },
            { Value: 29, Data: "Myrtle" },
            { Value: 30, Data: "Jane" },
            { Value: 31, Data: "Linda" },
            { Value: 32, Data: "Jamie" },
            { Value: 33, Data: "Lucille" },
            { Value: 34, Data: "Erica" },
            { Value: 35, Data: "Anita" },
            { Value: 36, Data: "Ella" },
            { Value: 37, Data: "Susanne" },
            { Value: 38, Data: "Pamela" },
            { Value: 39, Data: "Laurene" },
            { Value: 40, Data: "Agnes" },
            { Value: 41, Data: "Eleanor" },
            { Value: 42, Data: "Brianna" }
        ],
        Color: false
    },
    {
        Text: "Mieszanka skinów",
        Type: TYPE_CUSTOM,
        Value: 0.5,
        Min: 0,
        Max: 1.0,
        LeftText: "Szersze",
        RightText: "Węższe",
        Color: false
    },
    {
        Text: "Mieszanka kolorów skóry",
        Type: TYPE_CUSTOM,
        Value: 0.5,
        Min: 0,
        Max: 1.0,
        LeftText: "Szersze",
        RightText: "Węższe",
        Color: false
    },
    {
        Text: "Zarost",
        Type: TYPE_STANDARD,
        Active: 0,
        Datas: [
            { Value: 255, Data: "Brak" },
            { Value: 0, Data: "0" },
            { Value: 1, Data: "1" },
            { Value: 2, Data: "2" },
            { Value: 3, Data: "3" },
            { Value: 4, Data: "4" },
            { Value: 5, Data: "5" },
            { Value: 6, Data: "6" },
            { Value: 7, Data: "7" },
            { Value: 8, Data: "8" },
            { Value: 9, Data: "9" },
            { Value: 10, Data: "10" },
            { Value: 11, Data: "11" },
            { Value: 12, Data: "12" },
            { Value: 13, Data: "13" },
            { Value: 14, Data: "14" },
            { Value: 15, Data: "15" },
            { Value: 16, Data: "16" },
            { Value: 17, Data: "17" },
            { Value: 18, Data: "18" },
            { Value: 19, Data: "19" },
            { Value: 20, Data: "20" },
            { Value: 21, Data: "21" },
            { Value: 22, Data: "22" },
            { Value: 23, Data: "23" },
            { Value: 24, Data: "24" },
            { Value: 25, Data: "25" },
            { Value: 26, Data: "26" },
            { Value: 27, Data: "27" },
            { Value: 28, Data: "28" }
        ],
        Color: 0,
    },
    {
        Text: "Włosy",
        Type: TYPE_STANDARD_SEX,
        Active: 0,
        Datas: [
            // Mężczyzna
            [
                { Value: 0, Data: "Łysina" },
                { Value: 1, Data: "Krótkie kręcone" },
                { Value: 2, Data: "Przód dłuższy boki krótsze" },
                { Value: 3, Data: "Wygolone boki" },
                { Value: 4, Data: "Wycieniowane i zaczesane do tyłu" },
                { Value: 5, Data: "Krótko ścięty" },
                { Value: 6, Data: "Pasek włosów" },
                { Value: 7, Data: "Mocno zaczesae do tyłu" },
                { Value: 8, Data: "Warkoczyki" },
                { Value: 9, Data: "Zaczesana góra z niesfornym tyłem" },
                { Value: 10, Data: "Podniesiona grzywka" },
                { Value: 11, Data: "Boki krótsze z lekkim irokezem" },
                { Value: 12, Data: "Włosy zaczesane do przodu" },
                { Value: 13, Data: "Długa grzywka" },
                { Value: 14, Data: "Dredy" },
                { Value: 15, Data: "Proste z przedziałkiem na środku" },
                { Value: 16, Data: "Niesforne loki" },
                { Value: 17, Data: "Proste z podkręconą grzywką" },
                { Value: 18, Data: "Zaczesana grzywka" },
                { Value: 19, Data: "Zaczeska" },
                { Value: 20, Data: "Cieniowane uczesane na bok" },
                { Value: 21, Data: "Boki łyse góra zaczesana" },
                { Value: 22, Data: "Lata 80-te" },
                { Value: 24, Data: "Warkoczyki style 1" },
                { Value: 25, Data: "Warkoczyki style 2" },
                { Value: 26, Data: "Warkoczyki style 3" },
                { Value: 27, Data: "Warkoczyki style 4" },
                { Value: 28, Data: "Warkoczyki style 5" },
                { Value: 29, Data: "Warkoczyki style 6" },
                { Value: 30, Data: "Wystylizowane afro" },
                { Value: 31, Data: "Długie zaczesane do tyłu" },
                { Value: 32, Data: "Boki lekki odrost długa gróra" },
                { Value: 33, Data: "Boki lekki odrost góra zaczesana" },
                { Value: 34, Data: "Punk Rock" },
                { Value: 35, Data: "Niesforne" },
                { Value: 36, Data: "Proste z krótsza grzywka" }
            ],
            // Kobieta
            [
                { Value: 0, Data: "Łysina" },
                { Value: 1, Data: "Bowl cut" },
                { Value: 2, Data: "Pixi" },
                { Value: 3, Data: "Warkoczyki" },
                { Value: 4, Data: "Kita z grzywką" },
                { Value: 5, Data: "Fala z warkoczami" },
                { Value: 6, Data: "Kitka z warkoczy" },
                { Value: 7, Data: "Shortbob" },
                { Value: 8, Data: "Irokez" },
                { Value: 9, Data: "Kok banan" },
                { Value: 10, Data: "Bob" },
                { Value: 11, Data: "Niski kok" },
                { Value: 12, Data: "Chop-Chop" },
                { Value: 13, Data: "Undercut" },
                { Value: 14, Data: "Niesforny kok" },
                { Value: 15, Data: "Falowany bob" },
                { Value: 16, Data: "Pin up" },
                { Value: 17, Data: "Kok z grzywą" },
                { Value: 18, Data: "Lata dwudzieste" },
                { Value: 19, Data: "Kucyk z węzłem" },
                { Value: 20, Data: "Afro" },
                { Value: 21, Data: "Krótkie loczki" },
                { Value: 22, Data: "Warkoczykowy kok" },
                { Value: 23, Data: "Lata 80-te" },
                { Value: 25, Data: "Warkocze francuskie 1" },
                { Value: 26, Data: " Warkocze francuskie 2" },
                { Value: 27, Data: "Warkocze francuskie 3" },
                { Value: 28, Data: "Warkoczyki z grzywką" },
                { Value: 29, Data: "Wzburzone morze" },
                { Value: 30, Data: "Upadły wąż" },
                { Value: 31, Data: "Banan z kitą" },
                { Value: 32, Data: "Zaczeska" },
                { Value: 33, Data: "Undercut 2" },
                { Value: 34, Data: "Undercut 3" },
                { Value: 35, Data: "Irokez z wygolonymi bokami" },
                { Value: 36, Data: "Warkoczyki bokserskie" },
                { Value: 37, Data: "Sama grzywa" },
                { Value: 38, Data: "Paź" }
            ]
        ],
        Color: 0
    },
    {
        Text: "Brwi",
        Type: TYPE_STANDARD,
        Active: 0,
        Datas: [
            { Value: 255, Data: "Brak" },
            { Value: 0, Data: "0" },
            { Value: 1, Data: "1" },
            { Value: 2, Data: "2" },
            { Value: 3, Data: "3" },
            { Value: 4, Data: "4" },
            { Value: 5, Data: "5" },
            { Value: 6, Data: "6" },
            { Value: 7, Data: "7" },
            { Value: 8, Data: "8" },
            { Value: 9, Data: "9" },
            { Value: 10, Data: "10" },
            { Value: 11, Data: "11" },
            { Value: 12, Data: "12" },
            { Value: 13, Data: "13" },
            { Value: 14, Data: "14" },
            { Value: 15, Data: "15" },
            { Value: 16, Data: "16" },
            { Value: 17, Data: "17" },
            { Value: 18, Data: "18" },
            { Value: 19, Data: "19" },
            { Value: 20, Data: "20" },
            { Value: 21, Data: "21" },
            { Value: 22, Data: "22" },
            { Value: 23, Data: "23" },
            { Value: 24, Data: "24" },
            { Value: 25, Data: "25" },
            { Value: 26, Data: "26" },
            { Value: 27, Data: "27" },
            { Value: 28, Data: "28" },
            { Value: 29, Data: "29" },
            { Value: 30, Data: "30" },
            { Value: 31, Data: "31" },
            { Value: 32, Data: "32" },
            { Value: 33, Data: "33" }
        ],
        Color: 0
    },
    {
        Text: "Blizny",
        Type: TYPE_STANDARD,
        Active: 0,
        Datas: [
            { Value: 255, Data: "Brak" },
            { Value: 0, Data: "0" },
            { Value: 1, Data: "1" },
            { Value: 2, Data: "2" },
            { Value: 3, Data: "3" },
            { Value: 4, Data: "4" },
            { Value: 5, Data: "5" },
            { Value: 6, Data: "6" },
            { Value: 7, Data: "7" },
            { Value: 8, Data: "8" },
            { Value: 9, Data: "9" },
            { Value: 10, Data: "10" },
            { Value: 11, Data: "11" },
            { Value: 12, Data: "12" },
            { Value: 13, Data: "13" },
            { Value: 14, Data: "14" },
            { Value: 15, Data: "15" },
            { Value: 16, Data: "16" },
            { Value: 17, Data: "17" },
            { Value: 18, Data: "18" },
            { Value: 19, Data: "19" },
            { Value: 20, Data: "20" },
            { Value: 21, Data: "21" },
            { Value: 22, Data: "22" },
            { Value: 23, Data: "23" }
        ],
        Color: false
    },
    {
        Text: "Postarzanie postaci",
        Type: TYPE_STANDARD,
        Active: 0,
        Datas: [
            { Value: 255, Data: "Brak" },
            { Value: 0, Data: "0" },
            { Value: 1, Data: "1" },
            { Value: 2, Data: "2" },
            { Value: 3, Data: "3" },
            { Value: 4, Data: "4" },
            { Value: 5, Data: "5" },
            { Value: 6, Data: "6" },
            { Value: 7, Data: "7" },
            { Value: 8, Data: "8" },
            { Value: 9, Data: "9" },
            { Value: 10, Data: "10" },
            { Value: 11, Data: "11" },
            { Value: 12, Data: "12" },
            { Value: 13, Data: "13" },
            { Value: 14, Data: "14" }
        ],
        Color: false
    },
    {
        Text: "Makijaż",
        Type: TYPE_STANDARD,
        Active: 0,
        Datas: [
            { Value: 255, Data: "Brak" },
            { Value: 0, Data: "0" },
            { Value: 1, Data: "1" },
            { Value: 2, Data: "2" },
            { Value: 3, Data: "3" },
            { Value: 4, Data: "4" },
            { Value: 5, Data: "5" },
            { Value: 6, Data: "6" },
            { Value: 7, Data: "7" },
            { Value: 8, Data: "8" },
            { Value: 9, Data: "9" },
            { Value: 10, Data: "10" },
            { Value: 11, Data: "11" },
            { Value: 12, Data: "12" },
            { Value: 13, Data: "13" },
            { Value: 14, Data: "14" },
            { Value: 15, Data: "15" },
            { Value: 16, Data: "16" },
            { Value: 17, Data: "17" },
            { Value: 18, Data: "18" },
            { Value: 19, Data: "19" },
            { Value: 20, Data: "20" },
            { Value: 21, Data: "21" },
            { Value: 22, Data: "22" },
            { Value: 23, Data: "23" },
            { Value: 24, Data: "24" },
            { Value: 25, Data: "25" },
            { Value: 26, Data: "26" },
            { Value: 27, Data: "27" },
            { Value: 28, Data: "28" },
            { Value: 29, Data: "29" },
            { Value: 30, Data: "30" },
            { Value: 31, Data: "31" },
            { Value: 32, Data: "32" },
            { Value: 33, Data: "33" },
            { Value: 34, Data: "34" },
            { Value: 35, Data: "35" },
            { Value: 36, Data: "36" },
            { Value: 37, Data: "37" },
            { Value: 38, Data: "38" },
            { Value: 39, Data: "39" },
            { Value: 40, Data: "40" },
            { Value: 41, Data: "41" },
            { Value: 42, Data: "42" },
            { Value: 43, Data: "43" },
            { Value: 44, Data: "44" },
            { Value: 45, Data: "45" },
            { Value: 46, Data: "46" },
            { Value: 47, Data: "47" },
            { Value: 48, Data: "48" },
            { Value: 49, Data: "49" },
            { Value: 50, Data: "50" },
            { Value: 51, Data: "51" },
            { Value: 52, Data: "52" },
            { Value: 53, Data: "53" },
            { Value: 54, Data: "54" },
            { Value: 55, Data: "55" },
            { Value: 56, Data: "56" },
            { Value: 57, Data: "57" },
            { Value: 58, Data: "58" },
            { Value: 59, Data: "59" },
            { Value: 60, Data: "60" },
            { Value: 61, Data: "61" },
            { Value: 62, Data: "62" },
            { Value: 63, Data: "63" },
            { Value: 64, Data: "64" },
            { Value: 65, Data: "65" },
            { Value: 66, Data: "66" },
            { Value: 67, Data: "67" },
            { Value: 68, Data: "68" },
            { Value: 69, Data: "69" },
            { Value: 70, Data: "70" },
            { Value: 71, Data: "71" },
            { Value: 72, Data: "72" },
            { Value: 73, Data: "73" },
            { Value: 74, Data: "74" }
        ],
        Color: false
    },
    {
        Text: "Rumieniec",
        Type: TYPE_STANDARD,
        Active: 0,
        Datas: [
            { Value: 255, Data: "Brak" },
            { Value: 0, Data: "0" },
            { Value: 1, Data: "1" },
            { Value: 2, Data: "2" },
            { Value: 3, Data: "3" },
            { Value: 4, Data: "4" },
            { Value: 5, Data: "5" },
            { Value: 6, Data: "6" }
        ],
        Color: 0
    },
    {
        Text: "Cera",
        Type: TYPE_STANDARD,
        Active: 0,
        Datas: [
            { Value: 255, Data: "Brak" },
            { Value: 0, Data: "0" },
            { Value: 1, Data: "1" },
            { Value: 2, Data: "2" },
            { Value: 3, Data: "3" },
            { Value: 4, Data: "4" },
            { Value: 5, Data: "5" },
            { Value: 6, Data: "6" },
            { Value: 7, Data: "7" },
            { Value: 8, Data: "8" },
            { Value: 9, Data: "9" },
            { Value: 10, Data: "10" },
            { Value: 11, Data: "11" }
        ],
        Color: false
    },
    {
        Text: "Oparzenia",
        Type: TYPE_STANDARD,
        Active: 0,
        Datas: [
            { Value: 255, Data: "Brak" },
            { Value: 0, Data: "0" },
            { Value: 1, Data: "1" },
            { Value: 2, Data: "2" },
            { Value: 3, Data: "3" },
            { Value: 4, Data: "4" },
            { Value: 5, Data: "5" },
            { Value: 6, Data: "6" },
            { Value: 7, Data: "7" },
            { Value: 8, Data: "8" },
            { Value: 9, Data: "9" },
            { Value: 10, Data: "10" }
        ],
        Color: false
    },
    {
        Text: "Pomadka",
        Type: TYPE_STANDARD,
        Active: 0,
        Datas: [
            { Value: 255, Data: "Brak" },
            { Value: 0, Data: "0" },
            { Value: 1, Data: "1" },
            { Value: 2, Data: "2" },
            { Value: 3, Data: "3" },
            { Value: 4, Data: "4" },
            { Value: 5, Data: "5" },
            { Value: 6, Data: "6" },
            { Value: 7, Data: "7" },
            { Value: 8, Data: "8" },
            { Value: 9, Data: "9" }
        ],
        Color: 0
    },
    {
        Text: "Piegi",
        Type: TYPE_STANDARD,
        Active: 0,
        Datas: [
            { Value: 255, Data: "Brak" },
            { Value: 0, Data: "0" },
            { Value: 1, Data: "1" },
            { Value: 2, Data: "2" },
            { Value: 3, Data: "3" },
            { Value: 4, Data: "4" },
            { Value: 5, Data: "5" },
            { Value: 6, Data: "6" },
            { Value: 7, Data: "7" },
            { Value: 8, Data: "8" },
            { Value: 9, Data: "9" },
            { Value: 10, Data: "10" },
            { Value: 11, Data: "11" },
            { Value: 12, Data: "12" },
            { Value: 13, Data: "13" },
            { Value: 14, Data: "14" },
            { Value: 15, Data: "15" },
            { Value: 16, Data: "16" },
            { Value: 17, Data: "17" }
        ],
        Color: false
    },
    {
        Text: "Owłosienie",
        Type: TYPE_STANDARD,
        Active: 0,
        Datas: [
            { Value: 255, Data: "Brak" },
            { Value: 0, Data: "0" },
            { Value: 1, Data: "1" },
            { Value: 2, Data: "2" },
            { Value: 3, Data: "3" },
            { Value: 4, Data: "4" },
            { Value: 5, Data: "5" },
            { Value: 6, Data: "6" },
            { Value: 7, Data: "7" },
            { Value: 8, Data: "8" },
            { Value: 9, Data: "9" },
            { Value: 10, Data: "10" },
            { Value: 11, Data: "11" },
            { Value: 12, Data: "12" },
            { Value: 13, Data: "13" },
            { Value: 14, Data: "14" },
            { Value: 15, Data: "15" },
            { Value: 16, Data: "16" },
        ],
        Color: 0
    },
    {
        Text: "Szerokość nosa",
        Type: TYPE_CUSTOM,
        Value: 0.5,
        Min: -1.0,
        Max: 1.0,
        LeftText: "Węższy",
        RightText: "Szerszy",
        Color: false
    },
    {
        Text: "Wysokość nosa",
        Type: TYPE_CUSTOM,
        Value: 0.5,
        Min: -1.0,
        Max: 1.0,
        LeftText: "Wyżej",
        RightText: "Niżej",
        Color: false
    },
    {
        Text: "Długość nosa",
        Type: TYPE_CUSTOM,
        Value: 0.5,
        Min: -1.0,
        Max: 1.0,
        LeftText: "Długi",
        RightText: "Krótki",
        Color: false
    },
    {
        Text: "Mostek nosa",
        Type: TYPE_CUSTOM,
        Value: 0.5,
        Min: -1.0,
        Max: 1.0,
        LeftText: "Okrągły",
        RightText: "Ostry",
        Color: false
    },
    {
        Text: "Końcówka nosa",
        Type: TYPE_CUSTOM,
        Value: 0.5,
        Min: -1.0,
        Max: 1.0,
        LeftText: "W górę",
        RightText: "W dół",
        Color: false
    },
    {
        Text: "Przesunięcie nosa",
        Type: TYPE_CUSTOM,
        Value: 0.5,
        Min: -1.0,
        Max: 1.0,
        LeftText: "W prawo",
        RightText: "W lewo",
        Color: false
    },
    {
        Text: "Wysokość brwi",
        Type: TYPE_CUSTOM,
        Value: 0.5,
        Min: -1.0,
        Max: 1.0,
        LeftText: "Wyższe",
        RightText: "Niższe",
        Color: false
    },
    {
        Text: "Szerokość brwi",
        Type: TYPE_CUSTOM,
        Value: 0.5,
        Min: -1.0,
        Max: 1.0,
        LeftText: "Szersze",
        RightText: "Węższe",
        Color: false
    },
    {
        Text: "Wysokość kości",
        Type: TYPE_CUSTOM,
        Value: 0.5,
        Min: -1.0,
        Max: 1.0,
        LeftText: "Szersze",
        RightText: "Węższe",
        Color: false
    },
    {
        Text: "Szerokość kości",
        Type: TYPE_CUSTOM,
        Value: 0.5,
        Min: -1.0,
        Max: 1.0,
        LeftText: "Szersze",
        RightText: "Węższe",
        Color: false
    },
    {
        Text: "Szerokość policzków",
        Type: TYPE_CUSTOM,
        Value: 0.5,
        Min: -1.0,
        Max: 1.0,
        LeftText: "Szersze",
        RightText: "Węższe",
        Color: false
    },
    {
        Text: "Szerokość oczu",
        Type: TYPE_CUSTOM,
        Value: 0.5,
        Min: -1.0,
        Max: 1.0,
        LeftText: "Szersze",
        RightText: "Węższe",
        Color: false
    },
    {
        Text: "Szerokość ust",
        Type: TYPE_CUSTOM,
        Value: 0.5,
        Min: -1.0,
        Max: 1.0,
        LeftText: "Szersze",
        RightText: "Węższe",
        Color: false
    },
    {
        Text: "Szerokość szczęki",
        Type: TYPE_CUSTOM,
        Value: 0.5,
        Min: -1.0,
        Max: 1.0,
        LeftText: "Szersze",
        RightText: "Węższe",
        Color: false
    },
    {
        Text: "Wysokość szczęki",
        Type: TYPE_CUSTOM,
        Value: 0.5,
        Min: -1.0,
        Max: 1.0,
        LeftText: "Szersze",
        RightText: "Węższe",
        Color: false
    },
    {
        Text: "Długość podbródka",
        Type: TYPE_CUSTOM,
        Value: 0.5,
        Min: -1.0,
        Max: 1.0,
        LeftText: "Szersze",
        RightText: "Węższe",
        Color: false
    },
    {
        Text: "Pozycja podbródka",
        Type: TYPE_CUSTOM,
        Value: 0.5,
        Min: 0.0,
        Max: 1.0,
        LeftText: "Szersze",
        RightText: "Węższe",
        Color: false
    },
    {
        Text: "Szerokość podbródka",
        Type: TYPE_CUSTOM,
        Value: 0.5,
        Min: -1.0,
        Max: 1.0,
        LeftText: "Szersze",
        RightText: "Węższe",
        Color: false
    },
    {
        Text: "Kształt podbródka",
        Type: TYPE_CUSTOM,
        Value: 0.5,
        Min: -1.0,
        Max: 1.0,
        LeftText: "Szersze",
        RightText: "Węższe",
        Color: false
    },
    {
        Text: "Szerokość szyi",
        Type: TYPE_CUSTOM,
        Value: 0.5,
        Min: -1.0,
        Max: 1.0,
        LeftText: "Szersze",
        RightText: "Węższe",
        Color: false
    },
    {
        Text: "Zapisz postać",
        Type: TYPE_SUBMIT,
        Color: false
    }
];
const CREATOR_DATA_BINCO = [
    {
        Text: "Top",
        Type: TYPE_TOP_BINCO,
        Active: 0,
        Color: 0,
        Datas: [
            // SEX_MALE
            [
                { Value: 0, Data: "0", Torso: 0, Textures: [0, 1, 2, 3, 4, 5, 7, 8, 11] },
                { Value: 1, Data: "1", Torso: 0, Textures: [0, 1, 3, 4, 5, 6, 7, 8, 11, 12, 14] },
                { Value: 3, Data: "3", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 4, Data: "4", Torso: 14, Textures: [0, 2, 3, 11, 14] },
                { Value: 5, Data: "5", Torso: 5, Textures: [0, 1, 2, 7] },
                { Value: 6, Data: "6", Torso: 14, Textures: [0, 1, 3, 4, 5, 6, 8, 9, 11] },
                { Value: 7, Data: "7", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 8, Data: "8", Torso: 8, Textures: [0, 10, 13, 14] },
                { Value: 9, Data: "9", Torso: 0, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 10, 11, 12, 13, 14, 15] },
                { Value: 10, Data: "10", Torso: 14, Textures: [0, 1, 2] },
                { Value: 11, Data: "11", Torso: 15, Textures: [0, 1, 7, 14] },
                { Value: 12, Data: "12", Torso: 12, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 13, Data: "13", Torso: 11, Textures: [0, 1, 2, 3, 5, 13] },
                { Value: 14, Data: "14", Torso: 12, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 15, Data: "15", Torso: 15, Textures: [0] },
                { Value: 16, Data: "16", Torso: 0, Textures: [0, 1, 2] },
                { Value: 17, Data: "17", Torso: 5, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 18, Data: "18", Torso: 0, Textures: [0, 1, 2, 3] },
                { Value: 19, Data: "19", Torso: 14, Textures: [0, 1] },
                { Value: 20, Data: "20", Torso: 14, Textures: [0, 1, 2, 3] },
                { Value: 21, Data: "21", Torso: 15, Textures: [0, 1, 2, 3] },
                { Value: 22, Data: "22", Torso: 0, Textures: [0, 1, 2] },
                { Value: 23, Data: "23", Torso: 14, Textures: [0, 1, 2, 3] },
                { Value: 24, Data: "24", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12] },
                { Value: 25, Data: "25", Torso: 15, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 26, Data: "26", Torso: 11, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 27, Data: "27", Torso: 14, Textures: [0, 1, 2] },
                { Value: 28, Data: "28", Torso: 14, Textures: [0, 1, 2] },
                { Value: 29, Data: "29", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 30, Data: "30", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 31, Data: "31", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 32, Data: "32", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 33, Data: "33", Torso: 0, Textures: [0] },
                { Value: 34, Data: "34", Torso: 0, Textures: [0, 1] },
                { Value: 35, Data: "35", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6] },
                { Value: 36, Data: "36", Torso: 5, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 37, Data: "37", Torso: 14, Textures: [0, 1, 2] },
                { Value: 38, Data: "38", Torso: 8, Textures: [0, 1, 2, 3, 4] },
                { Value: 39, Data: "39", Torso: 0, Textures: [0, 1] },
                { Value: 40, Data: "40", Torso: 15, Textures: [0, 1] },
                { Value: 41, Data: "41", Torso: 12, Textures: [0, 1, 2, 3] },
                { Value: 42, Data: "42", Torso: 11, Textures: [0] },
                { Value: 43, Data: "43", Torso: 11, Textures: [0] },
                { Value: 44, Data: "44", Torso: 0, Textures: [0, 1, 2, 3] },
                { Value: 45, Data: "45", Torso: 15, Textures: [0, 1, 2] },
                { Value: 46, Data: "46", Torso: 14, Textures: [0, 1, 2] },
                { Value: 47, Data: "47", Torso: 0, Textures: [0, 1] },
                { Value: 48, Data: "48", Torso: 1, Textures: [0] },
                { Value: 49, Data: "49", Torso: 1, Textures: [0, 1, 2, 3, 4] },
                { Value: 50, Data: "50", Torso: 1, Textures: [0, 1, 2, 3, 4] },
                { Value: 51, Data: "51", Torso: 1, Textures: [0, 1, 2] },
                { Value: 52, Data: "52", Torso: 2, Textures: [0, 1, 2, 3] },
                { Value: 53, Data: "53", Torso: 0, Textures: [0, 1, 2, 3] },
                { Value: 54, Data: "54", Torso: 1, Textures: [0] },
                { Value: 55, Data: "55", Torso: 0, Textures: [0] },
                { Value: 56, Data: "56", Torso: 0, Textures: [0] },
                { Value: 57, Data: "57", Torso: 0, Textures: [0] },
                { Value: 58, Data: "58", Torso: 14, Textures: [0] },
                { Value: 59, Data: "59", Torso: 14, Textures: [0, 1, 2, 3] },
                { Value: 60, Data: "60", Torso: 15, Textures: [0, 1, 2, 3] },
                { Value: 61, Data: "61", Torso: 0, Textures: [0, 1, 2, 3] },
                { Value: 62, Data: "62", Torso: 14, Textures: [0] },
                { Value: 63, Data: "63", Torso: 5, Textures: [0] },
                { Value: 64, Data: "64", Torso: 14, Textures: [0] },
                { Value: 65, Data: "65", Torso: 14, Textures: [0, 1, 2, 3] },
                { Value: 66, Data: "66", Torso: 15, Textures: [0, 1, 2, 3] },
                { Value: 67, Data: "67", Torso: 1, Textures: [0, 1, 2, 3] },
                { Value: 68, Data: "68", Torso: 14, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 69, Data: "69", Torso: 14, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 70, Data: "70", Torso: 0, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 71, Data: "71", Torso: 14, Textures: [0] },
                { Value: 72, Data: "72", Torso: 0, Textures: [0, 1, 2, 3] },
                {
                    Value: 73,
                    Data: "73",
                    Torso: 14,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]
                },
                { Value: 74, Data: "74", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 75, Data: "75", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 76, Data: "76", Torso: 14, Textures: [0, 1, 2, 3, 4] },
                { Value: 77, Data: "77", Torso: 14, Textures: [0, 1, 2, 3] },
                { Value: 78, Data: "78", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 79, Data: "79", Torso: 14, Textures: [0] },
                { Value: 80, Data: "80", Torso: 0, Textures: [0, 1, 2] },
                { Value: 81, Data: "81", Torso: 0, Textures: [0, 1, 2] },
                { Value: 82, Data: "82", Torso: 0, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 83, Data: "83", Torso: 0, Textures: [0, 1, 2, 3, 4] },
                { Value: 84, Data: "84", Torso: 1, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 85, Data: "85", Torso: 1, Textures: [0] },
                { Value: 86, Data: "86", Torso: 1, Textures: [0, 1, 2, 3, 4] },
                { Value: 87, Data: "87", Torso: 1, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 88, Data: "88", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 89, Data: "89", Torso: 14, Textures: [0, 1, 2, 3] },
                { Value: 90, Data: "90", Torso: 14, Textures: [0] },
                { Value: 91, Data: "91", Torso: 15, Textures: [0] },
                { Value: 92, Data: "92", Torso: 6, Textures: [0, 1, 2, 3, 4, 5, 6] },
                { Value: 93, Data: "93", Torso: 0, Textures: [0, 1, 2] },
                { Value: 94, Data: "94", Torso: 0, Textures: [0, 1, 2] },
                { Value: 95, Data: "95", Torso: 11, Textures: [0, 1, 2] },
                { Value: 96, Data: "96", Torso: 11, Textures: [0] },
                { Value: 97, Data: "97", Torso: 0, Textures: [0, 1] },
                { Value: 98, Data: "98", Torso: 0, Textures: [0, 1] },
                { Value: 99, Data: "99", Torso: 14, Textures: [0, 1, 2, 3, 4] },
                { Value: 100, Data: "100", Torso: 14, Textures: [0, 1, 2, 3, 4] },
                { Value: 101, Data: "101", Torso: 14, Textures: [0, 1, 2, 3] },
                { Value: 102, Data: "102", Torso: 14, Textures: [0, 1, 2, 3] },
                { Value: 103, Data: "103", Torso: 14, Textures: [0] },
                { Value: 104, Data: "104", Torso: 14, Textures: [0] },
                { Value: 105, Data: "105", Torso: 11, Textures: [0] },
                { Value: 106, Data: "106", Torso: 14, Textures: [0] },
                { Value: 107, Data: "107", Torso: 14, Textures: [0, 1, 2, 3, 4] },
                { Value: 108, Data: "108", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 109, Data: "109", Torso: 5, Textures: [0] },
                { Value: 110, Data: "110", Torso: 1, Textures: [0] },
                { Value: 111, Data: "111", Torso: 4, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 112, Data: "112", Torso: 14, Textures: [0] },
                { Value: 113, Data: "113", Torso: 6, Textures: [0, 1, 2, 3] },
                { Value: 114, Data: "114", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 115, Data: "115", Torso: 14, Textures: [0] },
                { Value: 116, Data: "116", Torso: 14, Textures: [0, 1, 2] },
                { Value: 117, Data: "117", Torso: 6, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 118, Data: "118", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 119, Data: "119", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 120, Data: "120", Torso: 15, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 121, Data: "121", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 122, Data: "122", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13] },
                { Value: 123, Data: "123", Torso: 11, Textures: [0, 1, 2] },
                { Value: 124, Data: "124", Torso: 14, Textures: [0] },
                { Value: 125, Data: "125", Torso: 14, Textures: [0] },
                { Value: 126, Data: "126", Torso: 1, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14] },
                { Value: 127, Data: "127", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14] },
                { Value: 128, Data: "128", Torso: 0, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 129, Data: "129", Torso: 0, Textures: [0] },
                { Value: 130, Data: "130", Torso: 14, Textures: [0] },
                { Value: 131, Data: "131", Torso: 0, Textures: [0] },
                { Value: 132, Data: "132", Torso: 0, Textures: [0] },
                { Value: 133, Data: "133", Torso: 0, Textures: [0] },
                { Value: 134, Data: "134", Torso: 0, Textures: [0, 1, 2] },
                { Value: 135, Data: "135", Torso: 0, Textures: [0, 1, 2, 3, 4, 5, 6] },
                { Value: 136, Data: "136", Torso: 14, Textures: [, 0, 1, 2, 3, 4, 5, 6] },
                { Value: 137, Data: "137", Torso: 15, Textures: [0, 1, 2] },
                { Value: 138, Data: "138", Torso: 14, Textures: [0, 1, 2] },
                { Value: 139, Data: "139", Torso: 12, Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 140, Data: "140", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14] },
                { Value: 141, Data: "141", Torso: 6, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 142, Data: "142", Torso: 14, Textures: [0, 1, 2,] },
                { Value: 143, Data: "143", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 144, Data: "144", Torso: 6, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13] },
                { Value: 145, Data: "145", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13] },
                { Value: 146, Data: "146", Torso: 0, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8] },
                { Value: 147, Data: "147", Torso: 4, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 148, Data: "148", Torso: 4, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 149, Data: "149", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 150, Data: "150", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 151, Data: "151", Torso: 14, Textures: [0, 1, 2, 3, 4, 5] },
                {
                    Value: 152,
                    Data: "152",
                    Torso: 14,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]
                },
                {
                    Value: 153,
                    Data: "153",
                    Torso: 14,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 154, Data: "154", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 155, Data: "155", Torso: 14, Textures: [0, 1, 2, 3] },
                { Value: 156, Data: "156", Torso: 14, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 157, Data: "157", Torso: 15, Textures: [0, 1, 2, 3] },
                { Value: 158, Data: "158", Torso: 15, Textures: [0, 1, 2,] },
                { Value: 159, Data: "159", Torso: 15, Textures: [0, 1] },
                { Value: 160, Data: "160", Torso: 15, Textures: [0, 1] },
                { Value: 161, Data: "161", Torso: 14, Textures: [0, 1, 2, 3] },
                { Value: 162, Data: "162", Torso: 15, Textures: [0, 1, 2, 3] },
                { Value: 163, Data: "163", Torso: 14, Textures: [0] },
                { Value: 164, Data: "164", Torso: 0, Textures: [0, 1, 2] },
                { Value: 165, Data: "165", Torso: 0, Textures: [0, 1, 2, 3, 4, 5, 6] },
                { Value: 166, Data: "166", Torso: 14, Textures: [0, 1, 2, 3, 4, 5] },
                {
                    Value: 167,
                    Data: "167",
                    Torso: 14,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]
                },
                { Value: 168, Data: "168", Torso: 14, Textures: [0, 1, 2] },
                { Value: 169, Data: "169", Torso: 14, Textures: [0, 1, 2, 3] },
                { Value: 170, Data: "170", Torso: 15, Textures: [0, 1, 2, 3] },
                { Value: 171, Data: "171", Torso: 1, Textures: [0, 1] },
                { Value: 172, Data: "172", Torso: 14, Textures: [0, 1, 2, 3] },
                { Value: 173, Data: "173", Torso: 15, Textures: [0, 1, 2, 3] },
                { Value: 174, Data: "174", Torso: 14, Textures: [0, 1, 2, 3] },
                { Value: 175, Data: "175", Torso: 15, Textures: [0, 1, 2, 3] },
                { Value: 176, Data: "176", Torso: 15, Textures: [0] },
                { Value: 177, Data: "177", Torso: 15, Textures: [0, 1, 2, 3, 4, 5, 6] },
                { Value: 178, Data: "178", Torso: 1, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 179, Data: "179", Torso: 15, Textures: [0, 1, 2, 3] },
                { Value: 180, Data: "180", Torso: 15, Textures: [0, 1, 2] },
                { Value: 181, Data: "181", Torso: 15, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 182, Data: "182", Torso: 1, Textures: [0, 1] },
                { Value: 183, Data: "183", Torso: 14, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 184, Data: "184", Torso: 14, Textures: [0, 1, 2, 3] },
                { Value: 185, Data: "185", Torso: 14, Textures: [0, 1, 2, 3] },
                { Value: 186, Data: "186", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 187, Data: "187", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12] },
                { Value: 188, Data: "188", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 189, Data: "189", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                {
                    Value: 190,
                    Data: "190",
                    Torso: 14,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 191,
                    Data: "191",
                    Torso: 14,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 192, Data: "192", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                {
                    Value: 193,
                    Data: "193",
                    Torso: 0,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 194, Data: "194", Torso: 1, Textures: [0, 1, 2] },
                { Value: 195, Data: "195", Torso: 1, Textures: [0, 1, 2] },
                { Value: 196, Data: "196", Torso: 1, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 197, Data: "197", Torso: 1, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 198, Data: "198", Torso: 1, Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 199, Data: "199", Torso: 1, Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                {
                    Value: 200,
                    Data: "200",
                    Torso: 1,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 201, Data: "201", Torso: 3, Textures: [0, 1, 2] },
                { Value: 202, Data: "202", Torso: 4, Textures: [0, 1, 2, 3, 4] },
                {
                    Value: 203,
                    Data: "203",
                    Torso: 1,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 204, Data: "204", Torso: 6, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12] },
                { Value: 205, Data: "205", Torso: 5, Textures: [0, 1, 2, 3, 4] },
                {
                    Value: 206,
                    Data: "206",
                    Torso: 5,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 207,
                    Data: "207",
                    Torso: 5,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 208,
                    Data: "208",
                    Torso: 0,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 209,
                    Data: "209",
                    Torso: 0,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 210,
                    Data: "210",
                    Torso: 0,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 211,
                    Data: "211",
                    Torso: 0,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 216,
                    Data: "216",
                    Torso: 15,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                { Value: 217, Data: "217", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14] },
                { Value: 218, Data: "218", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14] },
                {
                    Value: 219,
                    Data: "219",
                    Torso: 15,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 220,
                    Data: "220",
                    Torso: 14,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 221,
                    Data: "221",
                    Torso: 14,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 222,
                    Data: "222",
                    Torso: 11,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 223, Data: "223", Torso: 5, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 224, Data: "224", Torso: 1, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 225, Data: "225", Torso: 8, Textures: [0, 1] },
                { Value: 226, Data: "226", Torso: 0, Textures: [0] },
                { Value: 227, Data: "227", Torso: 4, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13] },
                {
                    Value: 228,
                    Data: "228",
                    Torso: 4,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19]
                },
                { Value: 229, Data: "229", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 230, Data: "230", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 231, Data: "231", Torso: 4, Textures: [0] },
                { Value: 232, Data: "232", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 233, Data: "233", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                {
                    Value: 234,
                    Data: "234",
                    Torso: 11,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 235, Data: "235", Torso: 0, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 236, Data: "236", Torso: 0, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                {
                    Value: 237,
                    Data: "237",
                    Torso: 5,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 238, Data: "238", Torso: 2, Textures: [0, 1, 2, 3, 4, 5] },
                {
                    Value: 239,
                    Data: "239",
                    Torso: 2,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                { Value: 240, Data: "240", Torso: 4, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 241, Data: "241", Torso: 0, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 242, Data: "242", Torso: 0, Textures: [0, 1, 2, 3, 4, 5] },
                {
                    Value: 243,
                    Data: "243",
                    Torso: 4,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 244,
                    Data: "244",
                    Torso: 14,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 245, Data: "245", Torso: 6, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 246, Data: "246", Torso: 3, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                {
                    Value: 247,
                    Data: "247",
                    Torso: 5,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 248,
                    Data: "248",
                    Torso: 6,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 249, Data: "249", Torso: 6, Textures: [0, 1] },
                { Value: 250, Data: "250", Torso: 0, Textures: [0, 1] },
                {
                    Value: 251,
                    Data: "251",
                    Torso: 4,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 252, Data: "252", Torso: 15, Textures: [0] },
                {
                    Value: 253,
                    Data: "253",
                    Torso: 4,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
            ],
            // SEX_FEMALE
            [
                { Value: 0, Data: "0", Torso: 0, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 1, Data: "1", Torso: 5, Textures: [0, 1, 2, 4, 5, 6, 9, 11, 14] },
                { Value: 2, Data: "2", Torso: 2, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 3, Data: "3", Torso: 3, Textures: [0, 1, 2, 3, 4, 10, 11, 12, 13, 14] },
                { Value: 4, Data: "4", Torso: 4, Textures: [13, 14] },
                { Value: 5, Data: "5", Torso: 4, Textures: [0, 1, 7, 9] },
                { Value: 6, Data: "6", Torso: 5, Textures: [0, 1, 2, 4] },
                { Value: 7, Data: "7", Torso: 5, Textures: [0, 1, 2, 8] },
                { Value: 8, Data: "8", Torso: 5, Textures: [0, 1, 2, 12] },
                { Value: 9, Data: "9", Torso: 0, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14] },
                { Value: 10, Data: "10", Torso: 5, Textures: [0, 1, 2, 7, 10, 11, 13, 15] },
                { Value: 11, Data: "11", Torso: 4, Textures: [0, 1, 2, 10, 11, 15] },
                { Value: 12, Data: "12", Torso: 12, Textures: [7, 8, 9] },
                { Value: 13, Data: "13", Torso: 15, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 14, Data: "14", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 15, Data: "15", Torso: 15, Textures: [0, 3, 10, 11] },
                { Value: 16, Data: "16", Torso: 15, Textures: [0, 1, 2, 3, 4, 5, 6] },
                { Value: 17, Data: "17", Torso: 0, Textures: [0] },
                { Value: 18, Data: "18", Torso: 15, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 19, Data: "19", Torso: 15, Textures: [0, 1, 2, 3] },
                { Value: 20, Data: "20", Torso: 5, Textures: [0, 1] },
                { Value: 21, Data: "21", Torso: 4, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 22, Data: "22", Torso: 4, Textures: [0, 1, 2, 3, 4] },
                { Value: 23, Data: "23", Torso: 4, Textures: [0, 1, 2] },
                { Value: 24, Data: "24", Torso: 5, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 25, Data: "25", Torso: 5, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 26, Data: "26", Torso: 12, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12] },
                { Value: 27, Data: "27", Torso: 0, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 28, Data: "28", Torso: 15, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 29, Data: "29", Torso: 9, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 30, Data: "30", Torso: 2, Textures: [0, 1, 2] },
                { Value: 31, Data: "31", Torso: 5, Textures: [0, 1, 2, 3, 5, 5, 6] },
                { Value: 32, Data: "32", Torso: 4, Textures: [0, 1, 2] },
                { Value: 33, Data: "33", Torso: 4, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8] },
                { Value: 34, Data: "34", Torso: 6, Textures: [0] },
                { Value: 35, Data: "35", Torso: 5, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 36, Data: "36", Torso: 4, Textures: [0, 1, 2, 3, 4] },
                { Value: 37, Data: "37", Torso: 4, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 38, Data: "38", Torso: 2, Textures: [0, 1, 2, 3] },
                { Value: 39, Data: "39", Torso: 1, Textures: [0] },
                { Value: 40, Data: "40", Torso: 2, Textures: [0, 1] },
                { Value: 41, Data: "41", Torso: 5, Textures: [0] },
                { Value: 42, Data: "42", Torso: 5, Textures: [0, 1, 2, 3, 4] },
                { Value: 43, Data: "43", Torso: 3, Textures: [0, 1, 2, 3, 4] },
                { Value: 44, Data: "44", Torso: 3, Textures: [0, 1, 2] },
                { Value: 45, Data: "45", Torso: 3, Textures: [0, 1, 2, 3] },
                { Value: 46, Data: "46", Torso: 3, Textures: [0, 1, 2, 3] },
                { Value: 47, Data: "47", Torso: 3, Textures: [0] },
                { Value: 48, Data: "48", Torso: 14, Textures: [0] },
                { Value: 49, Data: "49", Torso: 14, Textures: [0, 1] },
                { Value: 50, Data: "50", Torso: 14, Textures: [0] },
                { Value: 51, Data: "51", Torso: 6, Textures: [0] },
                { Value: 52, Data: "52", Torso: 6, Textures: [0, 1, 2, 3] },
                { Value: 53, Data: "53", Torso: 5, Textures: [0, 1, 2, 3] },
                { Value: 54, Data: "54", Torso: 5, Textures: [0, 1, 2, 3] },
                { Value: 55, Data: "55", Torso: 5, Textures: [0] },
                { Value: 56, Data: "56", Torso: 14, Textures: [0] },
                { Value: 57, Data: "57", Torso: 5, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8] },
                { Value: 58, Data: "58", Torso: 5, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8] },
                { Value: 59, Data: "59", Torso: 5, Textures: [0, 1, 2, 3] },
                { Value: 60, Data: "60", Torso: 14, Textures: [0, 1, 2, 3] },
                { Value: 61, Data: "61", Torso: 3, Textures: [0, 1, 2, 3] },
                { Value: 62, Data: "62", Torso: 5, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 63, Data: "63", Torso: 5, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 64, Data: "64", Torso: 5, Textures: [0, 1, 2, 3, 4] },
                { Value: 65, Data: "65", Torso: 5, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 66, Data: "66", Torso: 6, Textures: [0, 1, 2, 3] },
                { Value: 67, Data: "67", Torso: 2, Textures: [0] },
                {
                    Value: 68,
                    Data: "68",
                    Torso: 0,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19]
                },
                { Value: 69, Data: "69", Torso: 0, Textures: [0] },
                { Value: 70, Data: "70", Torso: 0, Textures: [0, 1, 2, 3, 4] },
                { Value: 71, Data: "71", Torso: 0, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 72, Data: "72", Torso: 0, Textures: [0] },
                { Value: 73, Data: "73", Torso: 14, Textures: [0, 1, 2] },
                { Value: 74, Data: "74", Torso: 15, Textures: [0, 1, 2] },
                { Value: 75, Data: "75", Torso: 9, Textures: [0, 1, 2, 3] },
                { Value: 76, Data: "76", Torso: 9, Textures: [0, 1, 2, 3, 4] },
                { Value: 77, Data: "77", Torso: 9, Textures: [0] },
                { Value: 78, Data: "78", Torso: 9, Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 79, Data: "79", Torso: 9, Textures: [0, 1, 2, 3] },
                { Value: 80, Data: "80", Torso: 9, Textures: [0] },
                { Value: 81, Data: "81", Torso: 9, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 82, Data: "82", Torso: 15, Textures: [0] },
                { Value: 83, Data: "83", Torso: 9, Textures: [0, 1, 2, 3, 4, 5, 6] },
                { Value: 84, Data: "84", Torso: 14, Textures: [0, 1, 2] },
                { Value: 85, Data: "85", Torso: 14, Textures: [0, 1, 2] },
                { Value: 86, Data: "86", Torso: 9, Textures: [0, 1, 2] },
                { Value: 87, Data: "87", Torso: 9, Textures: [0] },
                { Value: 88, Data: "88", Torso: 0, Textures: [0, 1] },
                { Value: 89, Data: "89", Torso: 0, Textures: [0, 1] },
                { Value: 90, Data: "90", Torso: 6, Textures: [0, 1, 2, 3, 4] },
                { Value: 91, Data: "91", Torso: 6, Textures: [0, 1, 2, 3, 4] },
                { Value: 92, Data: "92", Torso: 5, Textures: [0, 1, 2, 3] },
                { Value: 93, Data: "93", Torso: 5, Textures: [0, 1, 2, 3] },
                { Value: 94, Data: "94", Torso: 5, Textures: [0] },
                { Value: 95, Data: "95", Torso: 5, Textures: [0] },
                { Value: 96, Data: "96", Torso: 4, Textures: [0] },
                { Value: 97, Data: "97", Torso: 5, Textures: [0] },
                { Value: 98, Data: "98", Torso: 5, Textures: [0, 1, 2, 3, 4] },
                { Value: 99, Data: "99", Torso: 5, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 100, Data: "100", Torso: 0, Textures: [0] },
                { Value: 101, Data: "101", Torso: 15, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 102, Data: "102", Torso: 3, Textures: [0] },
                { Value: 103, Data: "103", Torso: 3, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 104, Data: "104", Torso: 5, Textures: [0] },
                { Value: 105, Data: "105", Torso: 4, Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 106, Data: "106", Torso: 6, Textures: [0, 1, 2, 3] },
                { Value: 107, Data: "107", Torso: 6, Textures: [0] },
                { Value: 108, Data: "108", Torso: 6, Textures: [0, 1, 2] },
                { Value: 109, Data: "109", Torso: 6, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 110, Data: "110", Torso: 6, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 111, Data: "111", Torso: 4, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 112, Data: "112", Torso: 4, Textures: [0, 1, 2] },
                { Value: 113, Data: "113", Torso: 4, Textures: [0, 1, 2] },
                { Value: 114, Data: "114", Torso: 4, Textures: [0, 1, 2] },
                { Value: 115, Data: "115", Torso: 4, Textures: [0, 1, 2] },
                { Value: 116, Data: "116", Torso: 4, Textures: [0, 1, 2] },
                { Value: 117, Data: "117", Torso: 11, Textures: [0, 1, 2] },
                { Value: 118, Data: "118", Torso: 11, Textures: [0, 1, 2] },
                { Value: 119, Data: "119", Torso: 11, Textures: [0, 1, 2] },
                {
                    Value: 120,
                    Data: "120",
                    Torso: 6,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
                },
                {
                    Value: 121,
                    Data: "121",
                    Torso: 6,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
                },
                { Value: 122, Data: "122", Torso: 2, Textures: [0] },
                { Value: 123, Data: "123", Torso: 2, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 124, Data: "124", Torso: 0, Textures: [0, 1, 2] },
                { Value: 125, Data: "125", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 126, Data: "126", Torso: 14, Textures: [0, 1, 2] },
                { Value: 127, Data: "127", Torso: 14, Textures: [0] },
                { Value: 128, Data: "128", Torso: 14, Textures: [0] },
                { Value: 129, Data: "129", Torso: 14, Textures: [0] },
                { Value: 130, Data: "130", Torso: 0, Textures: [0] },
                { Value: 131, Data: "131", Torso: 3, Textures: [0, 1, 2] },
                { Value: 132, Data: "132", Torso: 2, Textures: [0, 1, 2, 3, 4, 5, 6] },
                { Value: 133, Data: "133", Torso: 5, Textures: [0, 1, 2, 3, 4, 5, 6] },
                { Value: 134, Data: "134", Torso: 0, Textures: [0, 1, 2] },
                { Value: 135, Data: "135", Torso: 3, Textures: [0, 1, 2] },
                { Value: 136, Data: "136", Torso: 3, Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 137, Data: "137", Torso: 5, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14] },
                { Value: 138, Data: "138", Torso: 6, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 139, Data: "139", Torso: 5, Textures: [0, 1, 2] },
                { Value: 140, Data: "140", Torso: 5, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 141, Data: "141", Torso: 14, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 142, Data: "142", Torso: 9, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13] },
                { Value: 143, Data: "143", Torso: 5, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13] },
                { Value: 144, Data: "144", Torso: 3, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 145, Data: "145", Torso: 3, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 146, Data: "146", Torso: 7, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 147, Data: "147", Torso: 1, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 148, Data: "148", Torso: 5, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 149, Data: "149", Torso: 5, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                {
                    Value: 150,
                    Data: "150",
                    Torso: 0,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 151, Data: "151", Torso: 0, Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 152, Data: "152", Torso: 7, Textures: [0, 1, 2, 3] },
                { Value: 153, Data: "153", Torso: 5, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 154, Data: "154", Torso: 15, Textures: [0, 1, 2, 3] },
                { Value: 155, Data: "155", Torso: 15, Textures: [0, 1, 2] },
                { Value: 156, Data: "156", Torso: 15, Textures: [0, 1] },
                { Value: 157, Data: "157", Torso: 15, Textures: [, 0, 1,] },
                { Value: 158, Data: "158", Torso: 15, Textures: [0, 1, 2, 3] },
                { Value: 159, Data: "159", Torso: 15, Textures: [0, 1, 2, 3] },
                { Value: 160, Data: "160", Torso: 15, Textures: [0] },
                { Value: 161, Data: "161", Torso: 11, Textures: [0, 1, 2] },
                { Value: 162, Data: "162", Torso: 0, Textures: [0, 1, 2, 3, 4, 5, 6] },
                { Value: 163, Data: "163", Torso: 5, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 164, Data: "164", Torso: 5, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 165, Data: "165", Torso: 5, Textures: [0, 1, 2] },
                { Value: 166, Data: "166", Torso: 5, Textures: [0, 1, 2, 3] },
                { Value: 167, Data: "167", Torso: 15, Textures: [0, 1, 2, 3] },
                { Value: 168, Data: "168", Torso: 15, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 169, Data: "169", Torso: 15, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 170, Data: "170", Torso: 15, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 171, Data: "171", Torso: 15, Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 172, Data: "172", Torso: 14, Textures: [0, 1] },
                { Value: 173, Data: "173", Torso: 15, Textures: [0] },
                { Value: 174, Data: "174", Torso: 15, Textures: [0, 1, 2, 3] },
                { Value: 175, Data: "175", Torso: 15, Textures: [0, 1, 2, 3] },
                { Value: 176, Data: "176", Torso: 15, Textures: [0, 1, 2, 3] },
                { Value: 177, Data: "177", Torso: 15, Textures: [0, 1, 2, 3] },
                { Value: 178, Data: "178", Torso: 15, Textures: [0] },
                { Value: 179, Data: "179", Torso: 11, Textures: [0, 1, 2, 3, 4, 5, 6] },
                { Value: 180, Data: "180", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 181, Data: "181", Torso: 15, Textures: [0, 1, 2, 3] },
                { Value: 182, Data: "182", Torso: 15, Textures: [0, 1, 2] },
                { Value: 183, Data: "183", Torso: 15, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 184, Data: "184", Torso: 14, Textures: [0, 1] },
                { Value: 185, Data: "185", Torso: 6, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 186, Data: "186", Torso: 6, Textures: [0, 1, 2, 3] },
                { Value: 187, Data: "187", Torso: 6, Textures: [0, 1, 2, 3] },
                { Value: 188, Data: "188", Torso: 6, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 189, Data: "189", Torso: 6, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12] },
                { Value: 190, Data: "190", Torso: 6, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 191, Data: "191", Torso: 6, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                {
                    Value: 192,
                    Data: "192",
                    Torso: 5,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 193,
                    Data: "193",
                    Torso: 5,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 194, Data: "194", Torso: 5, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                {
                    Value: 195,
                    Data: "195",
                    Torso: 4,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 196, Data: "196", Torso: 1, Textures: [0, 1, 2] },
                { Value: 197, Data: "197", Torso: 1, Textures: [0, 1, 2] },
                { Value: 198, Data: "198", Torso: 1, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 199, Data: "199", Torso: 1, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 200, Data: "200", Torso: 1, Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 201, Data: "201", Torso: 1, Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                {
                    Value: 202,
                    Data: "202",
                    Torso: 1,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 203, Data: "203", Torso: 8, Textures: [0, 1, 2] },
                { Value: 204, Data: "204", Torso: 4, Textures: [0, 1, 2, 3, 4] },
                {
                    Value: 205,
                    Data: "205",
                    Torso: 0,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 206, Data: "206", Torso: 1, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12] },
                { Value: 207, Data: "207", Torso: 4, Textures: [0, 1, 2, 3, 4] },
                {
                    Value: 208,
                    Data: "208",
                    Torso: 11,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
                },
                {
                    Value: 209,
                    Data: "209",
                    Torso: 11,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
                },
                {
                    Value: 210,
                    Data: "210",
                    Torso: 11,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 211,
                    Data: "211",
                    Torso: 11,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 212,
                    Data: "212",
                    Torso: 5,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 213,
                    Data: "213",
                    Torso: 1,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 214,
                    Data: "214",
                    Torso: 1,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 215,
                    Data: "215",
                    Torso: 1,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 216,
                    Data: "216",
                    Torso: 5,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 217,
                    Data: "217",
                    Torso: 4,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 218,
                    Data: "218",
                    Torso: 0,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 219,
                    Data: "219",
                    Torso: 5,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 220,
                    Data: "220",
                    Torso: 15,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 221,
                    Data: "221",
                    Torso: 15,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 222,
                    Data: "222",
                    Torso: 15,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 223,
                    Data: "223",
                    Torso: 15,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 224,
                    Data: "224",
                    Torso: 14,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 225,
                    Data: "225",
                    Torso: 15,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 226,
                    Data: "226",
                    Torso: 11,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                { Value: 227, Data: "227", Torso: 3, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14] },
                { Value: 228, Data: "228", Torso: 3, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14] },
                {
                    Value: 229,
                    Data: "229",
                    Torso: 4,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 230,
                    Data: "230",
                    Torso: 0,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 231,
                    Data: "231",
                    Torso: 0,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 232,
                    Data: "232",
                    Torso: 0,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 233,
                    Data: "233",
                    Torso: 11,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]
                },
                { Value: 234, Data: "234", Torso: 6, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 235, Data: "235", Torso: 1, Textures: [0, 1] },
                { Value: 236, Data: "236", Torso: 14, Textures: [0] },
                { Value: 237, Data: "237", Torso: 3, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13] },
                {
                    Value: 238,
                    Data: "238",
                    Torso: 3,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19]
                },
                { Value: 239, Data: "239", Torso: 3, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 240, Data: "240", Torso: 5, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 241, Data: "241", Torso: 3, Textures: [0] },
                { Value: 242, Data: "242", Torso: 6, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 243, Data: "243", Torso: 6, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                {
                    Value: 244,
                    Data: "244",
                    Torso: 9,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 245, Data: "245", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 246, Data: "246", Torso: 14, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                {
                    Value: 247,
                    Data: "247",
                    Torso: 4,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 248, Data: "248", Torso: 5, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 249, Data: "249", Torso: 0, Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 250, Data: "250", Torso: 0, Textures: [0, 1, 2, 3, 4, 5] },
                {
                    Value: 251,
                    Data: "251",
                    Torso: 3,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 252,
                    Data: "252",
                    Torso: 5,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 253, Data: "253", Torso: 1, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 254, Data: "254", Torso: 8, Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                {
                    Value: 255,
                    Data: "255",
                    Torso: 11,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 256,
                    Data: "256",
                    Torso: 9,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 257, Data: "257", Torso: 6, Textures: [0, 1] },
                { Value: 258, Data: "258", Torso: 0, Textures: [0, 1] },
                {
                    Value: 259,
                    Data: "259",
                    Torso: 3,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 260, Data: "260", Torso: 4, Textures: [0] },
                {
                    Value: 261,
                    Data: "261",
                    Torso: 3,
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 262,
                    Data: "262",
                    Torso: 7,
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20]
                },
                { Value: 260, Data: "263", Torso: 15, Textures: [0] },
            ]
        ]
    },
    {
        Text: "Podkoszulek",
        Type: TYPE_TOP_BINCO,
        Active: 0,
        Color: 0,
        Datas: [
            // SEX_MALE
            [
                { Value: 15, Data: "Brak", Textures: [0] },
                { Value: 0, Data: "0", Textures: [0, 1, 2, 3, 4, 5, 7, 8, 11] },
                { Value: 1, Data: "1", Textures: [0, 1, 3, 4, 5, 6, 7, 8, 11, 12, 14] },
                { Value: 2, Data: "2", Textures: [0, 1, 2, 3, 4, 5, 7, 8, 11] },
                { Value: 3, Data: "3", Textures: [0, 1, 2] },
                { Value: 4, Data: "4", Textures: [0, 1, 2] },
                { Value: 5, Data: "5", Textures: [0, 1, 2, 7] },
                { Value: 6, Data: "6", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 7, Data: "7", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 8, Data: "8", Textures: [0, 10, 13, 14] },
                { Value: 9, Data: "9", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 10, 11, 12, 13, 14, 15] },
                { Value: 10, Data: "10", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 11, Data: "11", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 12, Data: "12", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 13, Data: "13", Textures: [0, 1, 2, 3, 5, 13] },
                { Value: 14, Data: "14", Textures: [0, 1, 3, 4, 5, 6, 7, 8, 11, 12, 14] },
                { Value: 16, Data: "16", Textures: [0, 1, 2] },
                { Value: 17, Data: "17", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 18, Data: "18", Textures: [0, 1, 2] },
                { Value: 19, Data: "19", Textures: [0, 1, 2, 3] },
                { Value: 20, Data: "20", Textures: [0, 1, 2, 3] },
                { Value: 21, Data: "21", Textures: [0, 1, 2, 3, 4] },
                { Value: 22, Data: "22", Textures: [0, 1, 2, 3, 4] },
                { Value: 23, Data: "23", Textures: [0, 1, 2] },
                { Value: 24, Data: "24", Textures: [0, 1, 2] },
                { Value: 25, Data: "25", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12] },
                { Value: 26, Data: "26", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12] },
                { Value: 27, Data: "27", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 28, Data: "28", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 29, Data: "29", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 30, Data: "30", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 31, Data: "31", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 32, Data: "32", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 33, Data: "33", Textures: [0, 1, 2, 3, 4, 5, 6] },
                { Value: 34, Data: "34", Textures: [0, 1, 2, 3, 4, 5, 6] },
                { Value: 35, Data: "35", Textures: [0, 1, 2, 3, 4, 5, 6] },
                { Value: 36, Data: "36", Textures: [0, 1, 2, 3, 4, 5, 6] },
                { Value: 37, Data: "37", Textures: [0] },
                { Value: 38, Data: "38", Textures: [0, 1] },
                { Value: 39, Data: "39", Textures: [0] },
                { Value: 40, Data: "40", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 41, Data: "41", Textures: [0, 1, 2, 3, 4] },
                { Value: 42, Data: "42", Textures: [0, 1] },
                { Value: 43, Data: "43", Textures: [0, 1, 2, 3] },
                { Value: 44, Data: "44", Textures: [0, 1] },
                { Value: 45, Data: "45", Textures: [0] },
                { Value: 46, Data: "46", Textures: [0] },
                { Value: 47, Data: "47", Textures: [0, 1, 2, 3] },
                { Value: 48, Data: "48", Textures: [0, 1, 2, 3] },
                { Value: 49, Data: "49", Textures: [0, 1] },
                { Value: 50, Data: "50", Textures: [0, 1] },
                { Value: 51, Data: "51", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8] },
                { Value: 52, Data: "52", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8] },
                { Value: 53, Data: "53", Textures: [0, 1] },
                { Value: 54, Data: "54", Textures: [0, 1] },
                { Value: 55, Data: "55", Textures: [0] },
                { Value: 56, Data: "56", Textures: [0, 1] },
                { Value: 57, Data: "57", Textures: [0] },
                { Value: 58, Data: "58", Textures: [0] },
                { Value: 59, Data: "59", Textures: [0, 1] },
                { Value: 60, Data: "60", Textures: [0] },
                { Value: 61, Data: "61", Textures: [3] },
                { Value: 62, Data: "62", Textures: [3] },
                { Value: 63, Data: "63", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 64, Data: "64", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 65, Data: "65", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18] },
                { Value: 66, Data: "66", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18] },
                { Value: 67, Data: "67", Textures: [0] },
                { Value: 68, Data: "68", Textures: [0] },
                { Value: 69, Data: "69", Textures: [0, 1, 2, 3, 4] },
                { Value: 70, Data: "70", Textures: [0] },
                { Value: 71, Data: "71", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 72, Data: "72", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 73, Data: "73", Textures: [0, 1, 2] },
                { Value: 74, Data: "74", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 75, Data: "75", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 76, Data: "76", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8] },
                { Value: 77, Data: "77", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8] },
                { Value: 78, Data: "78", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 79, Data: "79", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 80, Data: "80", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                {
                    Value: 81,
                    Data: "81",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 82,
                    Data: "82",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22]
                },
                {
                    Value: 83,
                    Data: "83",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 84,
                    Data: "84",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22]
                },
                {
                    Value: 85,
                    Data: "85",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 86,
                    Data: "86",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22]
                },
                { Value: 87, Data: "87", Textures: [0] },
                { Value: 88, Data: "88", Textures: [0] },
                { Value: 89, Data: "89", Textures: [0] },
                { Value: 90, Data: "90", Textures: [0, 1] },
                {
                    Value: 91,
                    Data: "91",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 92,
                    Data: "92",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                { Value: 93, Data: "93", Textures: [0, 1] },
                { Value: 94, Data: "94", Textures: [0, 1] },
                { Value: 95, Data: "95", Textures: [0, 1] },
                { Value: 96, Data: "96", Textures: [0, 1] },
                { Value: 97, Data: "97", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                {
                    Value: 98,
                    Data: "98",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 99,
                    Data: "99",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 100,
                    Data: "100",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 101,
                    Data: "101",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 102,
                    Data: "102",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                { Value: 103, Data: "103", Textures: [0] },
                { Value: 104, Data: "104", Textures: [0] },
                { Value: 105, Data: "105", Textures: [0] },
                { Value: 106, Data: "106", Textures: [0] },
                { Value: 107, Data: "107", Textures: [0] },
                { Value: 108, Data: "108", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13] },
                { Value: 109, Data: "109", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 110, Data: "110", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                {
                    Value: 111,
                    Data: "111",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 112, Data: "112", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 113, Data: "113", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 114, Data: "114", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 115, Data: "115", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 116, Data: "116", Textures: [0, 1, 2, 3, 4, 5] },
                {
                    Value: 117,
                    Data: "117",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 118,
                    Data: "118",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 119,
                    Data: "119",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 120,
                    Data: "120",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 121,
                    Data: "121",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                { Value: 122, Data: "122", Textures: [0] },
                { Value: 124, Data: "124", Textures: [0, 1, 2, 3, 4] },
                { Value: 125, Data: "125", Textures: [0, 1, 2, 3, 4] },
                { Value: 126, Data: "126", Textures: [0, 1, 2, 3, 4] },
                { Value: 127, Data: "127", Textures: [0, 1, 2, 3, 4] },
                { Value: 128, Data: "128", Textures: [0, 1, 2, 3, 4] },
                { Value: 129, Data: "129", Textures: [0] },
                { Value: 130, Data: "130", Textures: [0] },
                {
                    Value: 131,
                    Data: "131",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19]
                },
            ],
            // SEX_FEMALE
            [
                { Value: 2, Data: "Brak", Textures: [0] },
                { Value: 0, Data: "0", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 1, Data: "1", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 4, Data: "4", Textures: [13, 14] },
                { Value: 5, Data: "5", Textures: [0, 1, 7, 9] },
                { Value: 11, Data: "11", Textures: [0, 1, 2, 10, 11, 15] },
                { Value: 12, Data: "12", Textures: [7, 8, 9] },
                { Value: 13, Data: "13", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 15, Data: "15", Textures: [0, 3, 10, 11] },
                { Value: 16, Data: "16", Textures: [0, 1, 2, 3, 4, 5, 6] },
                { Value: 17, Data: "17", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 18, Data: "18", Textures: [0, 1, 2, 3] },
                { Value: 19, Data: "19", Textures: [0, 1, 2, 3] },
                { Value: 20, Data: "20", Textures: [0, 1, 2] },
                { Value: 21, Data: "21", Textures: [0, 1, 2] },
                { Value: 22, Data: "22", Textures: [0, 1, 2, 3, 4] },
                { Value: 23, Data: "23", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12] },
                { Value: 24, Data: "24", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 25, Data: "25", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 26, Data: "26", Textures: [0, 1, 2] },
                { Value: 27, Data: "27", Textures: [0, 1, 2] },
                { Value: 28, Data: "28", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8] },
                { Value: 29, Data: "29", Textures: [0, 1, 2, 3, 4] },
                { Value: 30, Data: "30", Textures: [0, 1, 2, 3] },
                { Value: 31, Data: "31", Textures: [0, 1] },
                { Value: 32, Data: "32", Textures: [0] },
                { Value: 33, Data: "33", Textures: [0, 1] },
                { Value: 35, Data: "35", Textures: [0] },
                { Value: 36, Data: "36", Textures: [0, 1] },
                { Value: 37, Data: "37", Textures: [0] },
                { Value: 38, Data: "38", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 39, Data: "39", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 40, Data: "40", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 41, Data: "41", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 42, Data: "42", Textures: [0, 1, 2, 3] },
                { Value: 43, Data: "43", Textures: [0, 1, 2, 3] },
                { Value: 44, Data: "44", Textures: [0, 1] },
                {
                    Value: 45,
                    Data: "45",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19]
                },
                {
                    Value: 46,
                    Data: "46",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19]
                },
                { Value: 47, Data: "47", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 48, Data: "48", Textures: [0] },
                { Value: 49, Data: "49", Textures: [0] },
                {
                    Value: 50,
                    Data: "50",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19]
                },
                { Value: 51, Data: "51", Textures: [0, 1] },
                { Value: 52, Data: "52", Textures: [0, 1] },
                { Value: 53, Data: "53", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 54, Data: "54", Textures: [0] },
                { Value: 55, Data: "55", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 56, Data: "56", Textures: [0] },
                { Value: 57, Data: "57", Textures: [0, 1, 2] },
                { Value: 58, Data: "58", Textures: [0, 1, 2] },
                { Value: 59, Data: "59", Textures: [0, 1, 2] },
                { Value: 60, Data: "60", Textures: [0, 1, 2] },
                { Value: 61, Data: "61", Textures: [0, 1, 2, 3] },
                { Value: 62, Data: "62", Textures: [0, 1, 2, 3] },
                { Value: 63, Data: "63", Textures: [0, 1, 2, 3] },
                { Value: 64, Data: "64", Textures: [0, 1, 2, 3, 4] },
                { Value: 65, Data: "65", Textures: [0] },
                { Value: 66, Data: "66", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 67, Data: "67", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 68, Data: "68", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 69, Data: "69", Textures: [0, 1, 2] },
                { Value: 70, Data: "70", Textures: [0, 1, 2] },
                { Value: 71, Data: "71", Textures: [0, 1, 2] },
                { Value: 72, Data: "72", Textures: [0, 1, 2] },
                { Value: 73, Data: "73", Textures: [0, 1, 2] },
                { Value: 74, Data: "74", Textures: [0, 1, 2] },
                { Value: 75, Data: "75", Textures: [0, 1, 2] },
                { Value: 76, Data: "76", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 77, Data: "77", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 78, Data: "78", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 79, Data: "79", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 80, Data: "80", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 81, Data: "81", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 82, Data: "82", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 83, Data: "83", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 84, Data: "84", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 85, Data: "85", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                {
                    Value: 86,
                    Data: "86",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 87, Data: "87", Textures: [0, 1, 2, 3, 4, 5, 6] },
                {
                    Value: 88,
                    Data: "88",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 89, Data: "89", Textures: [0, 1, 2, 3, 4, 5, 6] },
                {
                    Value: 90,
                    Data: "90",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 91, Data: "91", Textures: [0, 1, 2, 3, 4, 5, 6] },
                { Value: 92, Data: "92", Textures: [0, 1, 2] },
                { Value: 93, Data: "93", Textures: [0, 1, 2] },
                { Value: 94, Data: "94", Textures: [0, 1, 2] },
                { Value: 95, Data: "95", Textures: [0, 1, 2] },
                { Value: 96, Data: "96", Textures: [0, 1, 2] },
                { Value: 97, Data: "97", Textures: [0, 1, 2] },
                { Value: 98, Data: "98", Textures: [0, 1, 2] },
                { Value: 99, Data: "99", Textures: [0, 1, 2] },
                { Value: 100, Data: "100", Textures: [0, 1, 2] },
                { Value: 101, Data: "101", Textures: [0, 1] },
                {
                    Value: 102,
                    Data: "102",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 103,
                    Data: "103",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                { Value: 104, Data: "104", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17] },
                { Value: 105, Data: "105", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 106, Data: "106", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16] },
                { Value: 107, Data: "107", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16] },
                { Value: 108, Data: "108", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16] },
                { Value: 109, Data: "109", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16] },
                { Value: 110, Data: "110", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16] },
                { Value: 111, Data: "111", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16] },
                { Value: 112, Data: "112", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16] },
                { Value: 113, Data: "113", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16] },
                { Value: 114, Data: "114", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16] },
                { Value: 115, Data: "115", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16] },
                { Value: 116, Data: "116", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16] },
                { Value: 117, Data: "117", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16] },
                {
                    Value: 118,
                    Data: "118",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 119,
                    Data: "119",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 120,
                    Data: "120",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 121,
                    Data: "121",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 122,
                    Data: "122",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 123,
                    Data: "123",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 124,
                    Data: "124",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 125,
                    Data: "125",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 126,
                    Data: "126",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 127,
                    Data: "127",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 128,
                    Data: "128",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 129,
                    Data: "129",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 130,
                    Data: "130",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 131,
                    Data: "131",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 132,
                    Data: "132",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 133,
                    Data: "133",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 134,
                    Data: "134",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 135,
                    Data: "135",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 136,
                    Data: "136",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 137,
                    Data: "137",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 138,
                    Data: "138",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 139,
                    Data: "139",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 140,
                    Data: "140",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 141,
                    Data: "141",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                { Value: 142, Data: "142", Textures: [0] },
                { Value: 143, Data: "143", Textures: [0] },
                { Value: 144, Data: "144", Textures: [0] },
                { Value: 145, Data: "145", Textures: [0] },
                { Value: 146, Data: "146", Textures: [0] },
                { Value: 147, Data: "147", Textures: [0] },
                { Value: 148, Data: "148", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13] },
                { Value: 149, Data: "149", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 150, Data: "150", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                {
                    Value: 151,
                    Data: "151",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 152, Data: "152", Textures: [0] },
                {
                    Value: 153,
                    Data: "153",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21]
                },
                { Value: 154, Data: "154", Textures: [0, 1, 2, 3, 4] },
                { Value: 155, Data: "155", Textures: [0, 1, 2, 3, 4] },
                { Value: 156, Data: "156", Textures: [0, 1, 2, 3, 4] },
                { Value: 157, Data: "157", Textures: [0, 1, 2, 3, 4] },
                { Value: 158, Data: "158", Textures: [0, 1, 1, 2, 4] },
                { Value: 159, Data: "159", Textures: [0] },
                { Value: 160, Data: "160", Textures: [0] },
                {
                    Value: 161,
                    Data: "161",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19]
                },
            ]
        ]
    },
    {
        Text: "Spodnie",
        Type: TYPE_TOP_BINCO,
        Active: 0,
        Color: 0,
        Datas: [
            // SEX_MALE
            [
                { Value: 0, Data: "0", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 1, Data: "1", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 2, Data: "2", Textures: [11] },
                { Value: 3, Data: "3", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 4, Data: "4", Textures: [0, 1, 2, 4] },
                { Value: 5, Data: "5", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 6, Data: "6", Textures: [0, 1, 2, 10] },
                { Value: 7, Data: "7", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 8, Data: "8", Textures: [0, 3, 4, 14] },
                { Value: 9, Data: "9", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 10, Data: "10", Textures: [0, 1, 2] },
                { Value: 11, Data: "11", Textures: [0] },
                { Value: 12, Data: "12", Textures: [0, 4, 5, 7, 12] },
                { Value: 13, Data: "13", Textures: [0, 1, 2] },
                { Value: 14, Data: "14", Textures: [0, 1, 3, 12] },
                { Value: 15, Data: "15", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 16, Data: "16", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 17, Data: "17", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 18, Data: "18", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 19, Data: "19", Textures: [0, 1] },
                { Value: 20, Data: "20", Textures: [0, 1, 2, 3] },
                { Value: 21, Data: "21", Textures: [0] },
                { Value: 22, Data: "22", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12] },
                { Value: 23, Data: "23", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12] },
                { Value: 24, Data: "24", Textures: [0, 1, 2, 3, 4, 5, 6] },
                { Value: 25, Data: "25", Textures: [0, 1, 2, 3, 4, 5, 6] },
                { Value: 26, Data: "26", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 27, Data: "27", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 28, Data: "28", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 29, Data: "29", Textures: [0, 1, 2] },
                { Value: 30, Data: "30", Textures: [0] },
                { Value: 31, Data: "31", Textures: [0, 1, 2, 3, 4] },
                { Value: 32, Data: "32", Textures: [0, 1, 2, 3] },
                { Value: 33, Data: "33", Textures: [0] },
                { Value: 34, Data: "34", Textures: [0] },
                { Value: 35, Data: "35", Textures: [0] },
                { Value: 36, Data: "36", Textures: [0] },
                { Value: 37, Data: "37", Textures: [0, 1, 2, 3] },
                { Value: 38, Data: "38", Textures: [0, 1, 2, 3] },
                { Value: 39, Data: "39", Textures: [0, 1, 2, 3] },
                { Value: 40, Data: "40", Textures: [0, 1, 2, 3] },
                { Value: 41, Data: "41", Textures: [0] },
                { Value: 42, Data: "42", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 43, Data: "43", Textures: [0, 1] },
                { Value: 45, Data: "45", Textures: [0, 1, 2, 3, 4, 5, 6] },
                { Value: 46, Data: "46", Textures: [0, 1] },
                { Value: 47, Data: "47", Textures: [0, 1] },
                { Value: 48, Data: "48", Textures: [0, 1, 2, 3, 4] },
                { Value: 49, Data: "49", Textures: [0, 1, 2, 3, 4] },
                { Value: 50, Data: "50", Textures: [0, 1, 2, 3] },
                { Value: 51, Data: "51", Textures: [0] },
                { Value: 52, Data: "52", Textures: [0, 1, 2, 3] },
                { Value: 53, Data: "53", Textures: [0] },
                { Value: 54, Data: "54", Textures: [0, 1, 2, 3, 4, 5, 6] },
                { Value: 55, Data: "55", Textures: [0, 1, 2, 3] },
                { Value: 56, Data: "56", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 57, Data: "57", Textures: [0, 1, 2] },
                { Value: 58, Data: "58", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 59, Data: "59", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 60, Data: "60", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 61, Data: "61", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13] },
                { Value: 62, Data: "62", Textures: [0, 1, 2, 3] },
                { Value: 63, Data: "63", Textures: [0] },
                { Value: 64, Data: "64", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 65, Data: "65", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13] },
                { Value: 66, Data: "66", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 67, Data: "67", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 68, Data: "68", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 69, Data: "69", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17] },
                { Value: 70, Data: "70", Textures: [0, 1, 2, 3] },
                { Value: 71, Data: "71", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 72, Data: "72", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 73, Data: "73", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 74, Data: "74", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 75, Data: "75", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 76, Data: "76", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 77, Data: "77", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 78, Data: "78", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 79, Data: "79", Textures: [0, 1, 2] },
                { Value: 80, Data: "80", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 81, Data: "81", Textures: [0, 1, 2] },
                { Value: 82, Data: "82", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 83, Data: "83", Textures: [0, 1, 2, 3] },
                { Value: 84, Data: "84", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 85, Data: "85", Textures: [0, 1, 2] },
                {
                    Value: 86,
                    Data: "86",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 87,
                    Data: "87",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 88,
                    Data: "88",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 89,
                    Data: "89",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 90, Data: "90", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 91, Data: "91", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13] },
                {
                    Value: 92,
                    Data: "92",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19]
                },
                { Value: 93, Data: "93", Textures: [0] },
                {
                    Value: 94,
                    Data: "94",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 95, Data: "95", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 96, Data: "96", Textures: [0, 1] },
                {
                    Value: 97,
                    Data: "97",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 98,
                    Data: "98",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
            ],
            // SEX_FEMALE
            [
                { Value: 0, Data: "0", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 1, Data: "1", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 2, Data: "2", Textures: [0, 1, 2] },
                { Value: 3, Data: "3", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 4, Data: "4", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 5, Data: "5", Textures: [8, 14, 15] },
                { Value: 6, Data: "6", Textures: [0, 1, 2] },
                { Value: 7, Data: "7", Textures: [0, 1, 2] },
                { Value: 8, Data: "8", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 15] },
                { Value: 9, Data: "9", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 10, Data: "10", Textures: [0, 1, 2] },
                { Value: 11, Data: "11", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 12, Data: "12", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 13, Data: "13", Textures: [0] },
                { Value: 14, Data: "14", Textures: [0, 1] },
                { Value: 15, Data: "15", Textures: [0, 3] },
                { Value: 16, Data: "16", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 17, Data: "17", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 18, Data: "18", Textures: [0, 1] },
                { Value: 19, Data: "19", Textures: [0, 1, 2, 3, 4] },
                { Value: 20, Data: "20", Textures: [0, 1, 2] },
                { Value: 21, Data: "21", Textures: [0] },
                { Value: 22, Data: "22", Textures: [0, 1, 2] },
                { Value: 23, Data: "23", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12] },
                { Value: 24, Data: "24", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12] },
                { Value: 25, Data: "25", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12] },
                { Value: 26, Data: "26", Textures: [0] },
                { Value: 27, Data: "27", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 28, Data: "28", Textures: [0] },
                { Value: 29, Data: "29", Textures: [0] },
                { Value: 30, Data: "30", Textures: [0, 1, 2, 3, 4] },
                { Value: 31, Data: "31", Textures: [0, 1, 2, 3] },
                { Value: 32, Data: "32", Textures: [0] },
                { Value: 33, Data: "33", Textures: [0] },
                { Value: 34, Data: "34", Textures: [0] },
                { Value: 35, Data: "35", Textures: [0] },
                { Value: 36, Data: "36", Textures: [0, 1, 2, 3] },
                { Value: 37, Data: "37", Textures: [0, 1, 2, 3, 4, 5, 6] },
                { Value: 38, Data: "38", Textures: [0, 1, 2, 3] },
                { Value: 39, Data: "39", Textures: [0, 1, 2, 3] },
                { Value: 40, Data: "40", Textures: [0, 1, 2, 3] },
                { Value: 41, Data: "41", Textures: [0, 1, 2, 3] },
                { Value: 42, Data: "42", Textures: [0] },
                { Value: 43, Data: "43", Textures: [0, 1, 2, 3, 4] },
                { Value: 44, Data: "44", Textures: [0, 1, 2, 3, 4] },
                { Value: 45, Data: "45", Textures: [0, 1, 2, 3] },
                { Value: 47, Data: "47", Textures: [0, 1, 2, 3, 4, 5, 6] },
                { Value: 48, Data: "48", Textures: [0, 1] },
                { Value: 49, Data: "49", Textures: [0, 1] },
                { Value: 50, Data: "50", Textures: [0, 1, 2, 3, 4] },
                { Value: 51, Data: "51", Textures: [0, 1, 2, 3, 4] },
                { Value: 52, Data: "52", Textures: [0, 1, 2, 3] },
                { Value: 53, Data: "53", Textures: [0] },
                { Value: 54, Data: "54", Textures: [0, 1, 2, 3] },
                { Value: 55, Data: "55", Textures: [0] },
                { Value: 56, Data: "56", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 57, Data: "57", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 58, Data: "58", Textures: [0, 1, 2, 3] },
                { Value: 59, Data: "59", Textures: [0, 1, 2] },
                { Value: 60, Data: "60", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 61, Data: "61", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 62, Data: "62", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 63, Data: "63", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 64, Data: "64", Textures: [0, 1, 2, 3] },
                { Value: 65, Data: "65", Textures: [0, 1, 2] },
                { Value: 66, Data: "66", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 67, Data: "67", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13] },
                { Value: 68, Data: "68", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 69, Data: "69", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 70, Data: "70", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 71, Data: "71", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17] },
                { Value: 72, Data: "72", Textures: [0, 1, 2, 3] },
                { Value: 73, Data: "73", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 74, Data: "74", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 75, Data: "75", Textures: [0, 1, 2] },
                { Value: 77, Data: "77", Textures: [0, 1, 2] },
                { Value: 78, Data: "78", Textures: [0, 1, 2, 3] },
                { Value: 79, Data: "79", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 80, Data: "80", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 81, Data: "81", Textures: [0, 1, 2] },
                { Value: 82, Data: "82", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 83, Data: "83", Textures: [0, 1, 2] },
                { Value: 84, Data: "84", Textures: [1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 85, Data: "85", Textures: [0, 1, 2, 3] },
                { Value: 86, Data: "86", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 87, Data: "87", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 88, Data: "88", Textures: [0, 1, 2] },
                {
                    Value: 89,
                    Data: "89",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 90,
                    Data: "90",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 91,
                    Data: "91",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                {
                    Value: 92,
                    Data: "92",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 93, Data: "93", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 94, Data: "94", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13] },
                {
                    Value: 95,
                    Data: "95",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19]
                },
                { Value: 96, Data: "96", Textures: [0] },
                {
                    Value: 97,
                    Data: "97",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 98, Data: "98", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 99, Data: "99", Textures: [0, 1] },
                {
                    Value: 100,
                    Data: "100",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 101,
                    Data: "101",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 102,
                    Data: "102",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20]
                },
            ]
        ]
    },
    {
        Text: "Buty",
        Type: TYPE_TOP_BINCO,
        Active: 0,
        Color: 0,
        Datas: [
            // SEX_MALE
            [
                { Value: 0, Data: "0", Textures: [1, 0] },
                { Value: 1, Data: "1", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 2, Data: "2", Textures: [6] },
                { Value: 3, Data: "3", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 4, Data: "4", Textures: [0, 1, 2, 4] },
                { Value: 5, Data: "5", Textures: [0, 1, 2, 3] },
                { Value: 6, Data: "6", Textures: [0, 1] },
                { Value: 7, Data: "7", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 8, Data: "8", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 9, Data: "9", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 10, Data: "10", Textures: [0, 7, 14] },
                { Value: 11, Data: "11", Textures: [9, 14, 15] },
                { Value: 12, Data: "12", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 13, Data: "13", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 14, Data: "14", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 15, Data: "15", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 16, Data: "16", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 17, Data: "17", Textures: [0] },
                { Value: 18, Data: "18", Textures: [0, 1] },
                { Value: 19, Data: "19", Textures: [0] },
                { Value: 20, Data: "20", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 21, Data: "21", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 22, Data: "22", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 23, Data: "23", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 24, Data: "24", Textures: [0] },
                { Value: 25, Data: "25", Textures: [0] },
                { Value: 26, Data: "26", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 27, Data: "27", Textures: [0] },
                { Value: 28, Data: "28", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 29, Data: "29", Textures: [0] },
                { Value: 30, Data: "30", Textures: [0, 1] },
                { Value: 31, Data: "31", Textures: [0, 1, 2, 3, 4] },
                { Value: 32, Data: "32", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 34, Data: "34", Textures: [0] },
                { Value: 35, Data: "35", Textures: [0, 1] },
                { Value: 36, Data: "36", Textures: [0, 1, 2, 3] },
                { Value: 37, Data: "37", Textures: [0, 1, 2, 3, 4] },
                { Value: 38, Data: "38", Textures: [0, 1, 2, 3, 4] },
                { Value: 39, Data: "39", Textures: [0] },
                { Value: 40, Data: "40", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 41, Data: "41", Textures: [0] },
                { Value: 42, Data: "42", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 43, Data: "43", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 44, Data: "44", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 45, Data: "45", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 46, Data: "46", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 47, Data: "47", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 48, Data: "48", Textures: [0, 1] },
                { Value: 49, Data: "49", Textures: [0, 1] },
                { Value: 50, Data: "50", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 51, Data: "51", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 52, Data: "52", Textures: [0, 1] },
                { Value: 53, Data: "53", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 54, Data: "54", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 55, Data: "55", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 56, Data: "56", Textures: [0, 1] },
                { Value: 57, Data: "57", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 58, Data: "58", Textures: [0, 1, 2] },
                {
                    Value: 59,
                    Data: "59",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 60, Data: "60", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 61, Data: "61", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 62, Data: "62", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 63, Data: "63", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 64, Data: "64", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13] },
                { Value: 65, Data: "65", Textures: [0, 1, 2, 3, 4, 5, 6] },
                { Value: 66, Data: "66", Textures: [0, 1, 2, 3, 4, 5, 6] },
                {
                    Value: 67,
                    Data: "67",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 68, Data: "68", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                {
                    Value: 69,
                    Data: "69",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 70,
                    Data: "70",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 71,
                    Data: "71",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 72,
                    Data: "72",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 73,
                    Data: "73",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
            ],
            // SEX_FEMALE
            [
                { Value: 0, Data: "0", Textures: [0, 1, 2, 3] },
                { Value: 1, Data: "1", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 2, Data: "2", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 3, Data: "3", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 4, Data: "4", Textures: [0, 1, 2, 3] },
                { Value: 5, Data: "5", Textures: [0, 1, 10, 13] },
                { Value: 6, Data: "6", Textures: [0, 1, 2, 3] },
                { Value: 7, Data: "7", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 8, Data: "8", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 9, Data: "9", Textures: [0, 1, 2, 3, 11, 12] },
                { Value: 10, Data: "10", Textures: [0, 1, 2, 3] },
                { Value: 11, Data: "11", Textures: [0, 1, 2, 3] },
                { Value: 13, Data: "13", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 14, Data: "14", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 15, Data: "15", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 16, Data: "16", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 17, Data: "17", Textures: [0] },
                { Value: 18, Data: "18", Textures: [0, 1, 2] },
                { Value: 19, Data: "19", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 20, Data: "20", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 21, Data: "21", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 22, Data: "22", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15] },
                { Value: 23, Data: "23", Textures: [0, 1, 2] },
                { Value: 24, Data: "24", Textures: [0] },
                { Value: 25, Data: "25", Textures: [0] },
                { Value: 26, Data: "26", Textures: [0] },
                { Value: 27, Data: "27", Textures: [0] },
                { Value: 28, Data: "28", Textures: [0] },
                { Value: 29, Data: "29", Textures: [0, 1, 2] },
                { Value: 30, Data: "30", Textures: [0] },
                { Value: 31, Data: "31", Textures: [0] },
                { Value: 32, Data: "32", Textures: [0, 1, 2, 3, 4] },
                { Value: 33, Data: "33", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 35, Data: "35", Textures: [0] },
                { Value: 36, Data: "36", Textures: [0, 1] },
                { Value: 37, Data: "37", Textures: [0, 1, 2, 3] },
                { Value: 38, Data: "38", Textures: [0, 1, 2, 3, 4] },
                { Value: 39, Data: "39", Textures: [0, 1, 2, 3, 4] },
                { Value: 40, Data: "40", Textures: [0] },
                { Value: 41, Data: "41", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 42, Data: "42", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 43, Data: "43", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 44, Data: "44", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 45, Data: "45", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 46, Data: "46", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 47, Data: "47", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9] },
                { Value: 48, Data: "48", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 49, Data: "49", Textures: [0, 1] },
                { Value: 50, Data: "50", Textures: [0, 1] },
                { Value: 51, Data: "51", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 52, Data: "52", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 53, Data: "53", Textures: [0, 1] },
                { Value: 54, Data: "54", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 55, Data: "55", Textures: [0, 1, 2, 3, 4, 5] },
                { Value: 56, Data: "56", Textures: [0, 1, 2] },
                { Value: 57, Data: "57", Textures: [0, 1, 2] },
                { Value: 58, Data: "58", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] },
                { Value: 59, Data: "59", Textures: [0, 1] },
                { Value: 60, Data: "60", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                { Value: 61, Data: "61", Textures: [0, 1, 2] },
                {
                    Value: 62,
                    Data: "62",
                    Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 24, 25]
                },
                { Value: 63, Data: "63", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 64, Data: "64", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 65, Data: "65", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 66, Data: "66", Textures: [0, 1, 2, 3, 4, 5, 6, 7] },
                { Value: 67, Data: "67", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13] },
                { Value: 68, Data: "68", Textures: [0, 1, 2, 3, 4, 5, 6] },
                { Value: 69, Data: "69", Textures: [0, 1, 2, 3, 4, 5, 6] },
                {
                    Value: 70,
                    Data: "70",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 71, Data: "71", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11] },
                {
                    Value: 72,
                    Data: "72",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 73,
                    Data: "73",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 74,
                    Data: "74",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 75,
                    Data: "75",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                {
                    Value: 76,
                    Data: "76",
                    Textures: [
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
                    ]
                },
                { Value: 77, Data: "77", Textures: [0, 1, 2, 3, 4, 5, 6, 7, 8] },
            ]
        ]
    },
    {
        Text: "Akcesoria",
        Type: TYPE_STANDARD_BINCO,
        Active: 0,
        Color: 0,
        MaxData: [128, 98]
    },
    {
        Text: "Zapisz ubranie",
        Type: TYPE_SUBMIT,
        Color: false
    },
    {
        Text: "Wyjdź z kreatora",
        Type: TYPE_CANCEL,
        Color: false
    }
];