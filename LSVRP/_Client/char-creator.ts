/// <reference path="@types/index.d.ts" />

import * as UI from "./ui"

let creatorData = {
    camera: false
};

enum CreatorData {
    Blizny = 0,
    Zarost = 1,
    Brwi,
    Postarzanie,
    Makijaz,
    Rumieniec,
    Cera,
    Oparzenia,
    Pomadka,
    Piegi,
    Owlosienie,
    SzerNos,
    WysNos,
    DlNos,
    MosNos,
    KonNos,
    PrzesNos,
    WysBrwi,
    SzerBrwi,
    Wlosy
}

// Kamera do kreatora.
let creatorCamera = mp.cameras.new("camera-creator", new mp.Vector3(0, 0, 0), new mp.Vector3(0, 0, 0), 90.0);

// Event (render) do ustawiania kamery na twarz.
function SetCameraOnFace() {
    const facePos = mp.players.local.getBoneCoords(31086, 0, 0, 0);
    const frontPos = GetPositionInFrontOfPlayer(mp.players.local, 0.5);

    creatorCamera.setCoord(frontPos[0], frontPos[1], facePos.z);
    creatorCamera.pointAtCoord(facePos.x, facePos.y, facePos.z);
}

function SetCameraOnBody() {
    const facePos = mp.players.local.getBoneCoords(24818, 0, 0, 0);
    const frontPos = GetPositionInFrontOfPlayer(mp.players.local, 2.0);

    creatorCamera.setCoord(frontPos[0], frontPos[1], facePos.z);
    creatorCamera.pointAtCoord(facePos.x, facePos.y, facePos.z);
}

// Ładowanie przy starcie.
export function load() {

    mp.events.add("creator.cancel",
        function(data: number) {
            toggleCamera(false, 0, 0);
            mp.events.callRemote("server.creator.cancel", data);
        });

    mp.events.add("creator.saveChar",
        function(data: string) {
            const cData = JSON.parse(data);

            mp.events.callRemote("server.creator.saveFace",
                parseInt(cData.Matka),
                parseInt(cData.Ojciec),
                parseFloat(cData.MieszSkin),
                parseFloat(cData.MieszKolor),
                parseInt(cData.Zarost),
                parseInt(cData.ZarostKolor),
                parseInt(cData.Brwi),
                parseInt(cData.BrwiKolor),
                parseInt(cData.Blizny),
                parseInt(cData.Postarzanie),
                parseInt(cData.Makijaz),
                parseInt(cData.Rumieniec),
                parseInt(cData.RumieniecKolor),
                parseInt(cData.Cera),
                parseInt(cData.Oparzenia),
                parseInt(cData.Pomadka),
                parseInt(cData.PomadkaKolor),
                parseInt(cData.Piegi),
                parseInt(cData.Owlosienie),
                parseInt(cData.OwlosienieKolor),
                parseFloat(cData.SzerNos),
                parseFloat(cData.WysNos),
                parseFloat(cData.DlNos),
                parseFloat(cData.MosNos),
                parseFloat(cData.KonNos),
                parseFloat(cData.PrzesNos),
                parseFloat(cData.WysBrwi),
                parseFloat(cData.SzerBrwi),
                parseFloat(cData.WysKos),
                parseFloat(cData.SzerKos),
                parseFloat(cData.SzerPol),
                parseFloat(cData.SzerOcz),
                parseFloat(cData.SzerUst),
                parseFloat(cData.SzerSzcz),
                parseFloat(cData.WysSzcz),
                parseFloat(cData.DlPodbr),
                parseFloat(cData.PozPodbr),
                parseFloat(cData.SzerPodbr),
                parseFloat(cData.KsztPodbr),
                parseFloat(cData.DlSzyi),
                parseInt(cData.Wlosy),
                parseInt(cData.WlosyKolor)
            );
        });
    mp.events.add("client.charCreator.toggle",
        function(toggle: boolean, sex: number) {
            toggleCamera(toggle, 0, sex);
        });
    mp.events.add("client.charBinco.toggle",
        function(toggle: boolean, sex: number) {
            toggleCamera(toggle, 1, sex);
        });
    mp.events.add("creator.UpdateBinco",
        function(data: string) {
            const cData = JSON.parse(data);

            mp.players.local.setComponentVariation(3, parseInt(cData.Torso), 0, 0);
            mp.players.local.setComponentVariation(4, parseInt(cData.Legs), parseInt(cData.LegsColor), 0);
            mp.players.local.setComponentVariation(6, parseInt(cData.Boots), parseInt(cData.BootsColor), 0);
            mp.players.local.setComponentVariation(8, parseInt(cData.Undershirt), parseInt(cData.UndershirtColor), 0);
            mp.players.local.setComponentVariation(11, parseInt(cData.Top), parseInt(cData.TopColor), 0);

        });
    mp.events.add("creator.SaveBinco",
        function(data: string) {
            const cData = JSON.parse(data);

            mp.events.callRemote("server.creator.saveBinco",
                parseInt(cData.Torso),
                parseInt(cData.Legs),
                parseInt(cData.LegsColor),
                parseInt(cData.Boots),
                parseInt(cData.BootsColor),
                parseInt(cData.Undershirt),
                parseInt(cData.UndershirtColor),
                parseInt(cData.Top),
                parseInt(cData.TopColor)
            );
        });
    mp.events.add("creator.UpdateChar",
        function(data: string) {
            let cData = JSON.parse(data);

            mp.players.local.setHeadBlendData(
                parseInt(cData.Matka),
                parseInt(cData.Ojciec),
                0,
                parseInt(cData.Matka),
                parseInt(cData.Ojciec),
                0,
                parseFloat(cData.MieszSkin),
                parseFloat(cData.MieszKolor),
                0,
                false
            );

            mp.players.local.setHeadOverlay(CreatorData.Zarost, cData.Zarost, 1.0, parseInt(cData.ZarostKolor), 0);
            mp.players.local.setHeadOverlay(CreatorData.Brwi, cData.Brwi, 1.0, parseInt(cData.BrwiKolor), 0);
            mp.players.local.setHeadOverlay(CreatorData.Blizny, cData.Blizny, 1.0, 0, 0);
            mp.players.local.setHeadOverlay(CreatorData.Postarzanie, cData.Postarzanie, 1.0, 0, 0);
            mp.players.local.setHeadOverlay(CreatorData.Makijaz, cData.Makijaz, 1.0, 0, 0);
            mp.players.local.setHeadOverlay(CreatorData.Rumieniec,
                cData.Rumieniec,
                1.0,
                parseInt(cData.RumieniecKolor),
                0);
            mp.players.local.setHeadOverlay(CreatorData.Cera, cData.Cera, 1.0, 0, 0);
            mp.players.local.setHeadOverlay(CreatorData.Oparzenia, cData.Oparzenia, 1.0, 0, 0);
            mp.players.local.setHeadOverlay(CreatorData.Pomadka, cData.Pomadka, 1.0, parseInt(cData.PomadkaKolor), 0);
            mp.players.local.setHeadOverlay(CreatorData.Piegi, cData.Piegi, 1.0, 0, 0);
            mp.players.local.setHeadOverlay(CreatorData.Owlosienie,
                cData.Owlosienie,
                1.0,
                parseInt(cData.OwlosienieKolor),
                0);

            // Wlosy
            mp.players.local.setComponentVariation(2, parseInt(cData.Wlosy), 0, 0);
            mp.players.local.setHairColor(parseInt(cData.WlosyKolor), 0);

            // Nos
            mp.players.local.setFaceFeature(0, parseFloat(cData.SzerNos));
            mp.players.local.setFaceFeature(1, parseFloat(cData.WysNos));
            mp.players.local.setFaceFeature(2, parseFloat(cData.DlNos));
            mp.players.local.setFaceFeature(3, parseFloat(cData.MosNos));
            mp.players.local.setFaceFeature(4, parseFloat(cData.KonNos));
            mp.players.local.setFaceFeature(5, parseFloat(cData.PrzesNos));

            // Brwi
            mp.players.local.setFaceFeature(6, parseFloat(cData.WysBrwi));
            mp.players.local.setFaceFeature(7, parseFloat(cData.SzerBrwi));

            // Kość policzkowa
            mp.players.local.setFaceFeature(8, parseFloat(cData.WysKos));
            mp.players.local.setFaceFeature(9, parseFloat(cData.SzerKos));
            mp.players.local.setFaceFeature(10, parseFloat(cData.SzerPol));

            mp.players.local.setFaceFeature(11, parseFloat(cData.SzerOcz));
            mp.players.local.setFaceFeature(12, parseFloat(cData.SzerUst));

            mp.players.local.setFaceFeature(13, parseFloat(cData.SzerSzcz));
            mp.players.local.setFaceFeature(14, parseFloat(cData.WysSzcz));

            mp.players.local.setFaceFeature(15, parseFloat(cData.DlPodbr));
            mp.players.local.setFaceFeature(16, parseFloat(cData.PozPodbr));
            mp.players.local.setFaceFeature(17, parseFloat(cData.SzerPodbr));
            mp.players.local.setFaceFeature(18, parseFloat(cData.KsztPodbr));
            mp.players.local.setFaceFeature(19, parseFloat(cData.DlSzyi));


        });
}

// Włączanie/wyłączanie kamery.
export function toggleCamera(state: boolean, cType: number, sex: number) {
    if (state) {
        if (creatorData.camera) return;

        creatorData.camera = true;

        // Ustawianie bokserek jeśli pełny kreator postaci.
        if (cType === 0) {
            mp.events.add("render", SetCameraOnFace);
            const player = mp.players.local;
            player.setComponentVariation(3, 15, 0, 0);
            player.setComponentVariation(4, 61, 5, 0);
            player.setComponentVariation(6, 34, 0, 0);
            player.setComponentVariation(7, 0, 0, 0);
            player.setComponentVariation(8, 15, 0, 0);
            player.setComponentVariation(11, 15, 0, 0);
        } else if (cType === 1) {
            mp.events.add("render", SetCameraOnBody);
        }

        creatorCamera.setMotionBlurStrength(0.0);
        creatorCamera.setActive(true);
        creatorCamera.setFov(70);

        mp.game.cam.renderScriptCams(true, false, 0, true, false);
        UI.getNewUiBrowser().execute(`ToggleCharCreator(true, ${cType}, ${sex})`);
        mp.gui.cursor.visible = true;
    } else {
        if (!creatorData.camera) return;
        mp.events.remove("render", SetCameraOnFace);
        mp.events.remove("render", SetCameraOnBody);
        creatorData.camera = false;
        mp.game.cam.renderScriptCams(false, false, 0, true, false);
        UI.getNewUiBrowser().execute('ToggleCharCreator(false)');
        mp.gui.cursor.visible = false;
    }
}

// Pobieranie pozycji z porzdu gracza.
function GetPositionInFrontOfPlayer(player: MpPlayer, distance: number): [number, number, number] {
    const x = Number(distance * Math.sin(-(player.getHeading() * 3.14 / 180)));
    const y = Number(distance * Math.cos(-(player.getHeading() * 3.14 / 180)));
    return [player.position.x + x, player.position.y + y, player.position.z];
}