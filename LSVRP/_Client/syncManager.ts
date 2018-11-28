import * as TattooLibrary from "./tattoos"
import * as CefHandler from "./cef"
import * as Ui from "./ui"
import { MugshotInfo, addMugshot, destroyMugshot } from "./mugshot";

import getTattoo = TattooLibrary.getTattoo;
import getNewUiBrowser = Ui.getNewUiBrowser;

let playersData = {};
let tempPlayersData = {};

const movementClipSet = "move_ped_crouched";
const strafeClipSet = "move_ped_crouched_strafing";

const loadClipSet = (clipSetName) => {
    mp.game.streaming.requestClipSet(clipSetName);
    while (!mp.game.streaming.hasClipSetLoaded(clipSetName)) mp.game.wait(0);
};

let pAnimObject: MpObject = null;

enum BlendData {
    Father,
    Mother,
    SkinMix,
    ColorMix,
    Beard,
    BeardColor,
    Hair,
    HairColor,
    Eyebrows,
    EyebrowsColor,
    Scars,
    Aging,
    Makeup,
    Blush,
    BlushColor,
    Complexion,
    Burns,
    Lipstick,
    LipstickColor,
    Freckles,
    Chesthair,
    ChesthairColor,
    NoseWidth,
    NoseHeight,
    NoseLength,
    NoseBridge,
    NoseEnd,
    NoseShift,
    EyebrowsHeight,
    EyebrowsWidth,
    BoneHeight,
    BoneWidth,
    CheeksWidth,
    EyesWidth,
    LipsWidth,
    JawWidth,
    JawHeight,
    ChinLength,
    ChinPosition,
    ChinWidth,
    ChinShape,
    NeckLength,
    TorsoId,
    Legs,
    LegsTexture,
    Boots,
    BootsTexture,
    Accessories,
    AccessoriesTexture,
    Undershirt,
    UndershirtTexture,
    Tops,
    TopsTexture
}


export function load(): void {

    loadClipSet(movementClipSet);
    loadClipSet(strafeClipSet);

    mp.events.add("client.syncmanager.loadallplayersdata",
        function () {
            playersData = JSON.parse(arguments[0]);

        });
    mp.events.add("client.syncmanager.loadplayerdata",
        function (remoteId: number, dataName: string, dataValue: any) {
            if (playersData[remoteId] === null || playersData[remoteId] === undefined) {
                playersData[remoteId] = {};
            }
            dataName = dataName.toString();
            playersData[remoteId][dataName] = dataValue;
        });
    mp.events.add("client.syncmanager.loadplayermoredata",
        function (remoteId: number, data: string) {
            if (playersData[remoteId] === null || playersData[remoteId] === undefined) {
                playersData[remoteId] = {};
            }
            const parsedJson = JSON.parse(data);
            for (let i = 0; i < parsedJson.length; i++) {
                parsedJson[i].Name = parsedJson[i].Name.toString();

                playersData[remoteId][parsedJson[i].Name] = parsedJson[i].Value;

                // mp.gui.chat.push(`${parsedJson[i].Name} = ${parsedJson[i].Value}`);
            }

        });
    mp.events.add("client.syncmanager.deleteplayerdata",
        function (remoteId: number, dataName: string) {
            dataName = dataName.toString();

            if (playersData[remoteId] && playersData[remoteId][dataName] !== undefined) {
                delete playersData[remoteId][dataName];
            }

        });
    mp.events.add("client.syncmanager.resetplayerdata",
        function () {
            const id = arguments[0];
            if (playersData[id] !== undefined) {
                playersData[id] = undefined;
            }

        });
    mp.events.callRemote("server.syncmanager.syncdataafterlogin");

    mp.events.add("client.syncmanager.syncFactions",
        function (data: number) {
            getNewUiBrowser().execute(`changeFactionsOnline(${data});`);
        });

    // Synchronizacja gracza
    mp.events.add("client.syncmanager.syncplayer",
        function (
            remoteId: number,
            walkingStyle: string,
            crouch: boolean,
            hairId: number,
            hairColor: number,
            tattoos: string,
            syncedTattoos: string,
            nicknameDesc: string,
            blend: string,
            animObject: any,
            mugshot: string) {
            let player = GetPlayerByRemoteId(remoteId);
            if (player === null) return;

            let blendData = JSON.parse(blend);

            player.setHeadBlendData(
                parseInt(blendData[BlendData.Mother]),
                parseInt(blendData[BlendData.Father]),
                0,
                parseInt(blendData[BlendData.Mother]),
                parseInt(blendData[BlendData.Father]),
                0,
                parseFloat(blendData[BlendData.SkinMix]),
                parseFloat(blendData[BlendData.ColorMix]),
                0,
                false
            );

            player.setHeadOverlay(0, parseInt(blendData[BlendData.Scars]), 1.0, 0, 0);
            player.setHeadOverlay(1,
                parseInt(blendData[BlendData.Beard]),
                1.0,
                parseInt(blendData[BlendData.BeardColor]),
                0);
            player.setHeadOverlay(2,
                parseInt(blendData[BlendData.Eyebrows]),
                1.0,
                parseInt(blendData[BlendData.EyebrowsColor]),
                0);
            player.setHeadOverlay(3, parseInt(blendData[BlendData.Aging]), 1.0, 0, 0);
            player.setHeadOverlay(4, parseInt(blendData[BlendData.Makeup]), 1.0, 0, 0);
            player.setHeadOverlay(5,
                parseInt(blendData[BlendData.Blush]),
                1.0,
                parseInt(blendData[BlendData.BlushColor]),
                0);
            player.setHeadOverlay(6, parseInt(blendData[BlendData.Complexion]), 1.0, 0, 0);
            player.setHeadOverlay(7, parseInt(blendData[BlendData.Burns]), 1.0, 0, 0);
            player.setHeadOverlay(8,
                parseInt(blendData[BlendData.Lipstick]),
                1.0,
                parseInt(blendData[BlendData.LipstickColor]),
                0);
            player.setHeadOverlay(9, parseInt(blendData[BlendData.Freckles]), 1.0, 0, 0);
            player.setHeadOverlay(10,
                parseInt(blendData[BlendData.Chesthair]),
                1.0,
                parseInt(blendData[BlendData.ChesthairColor]),
                0);

            // Wlosy
            player.setComponentVariation(2, parseInt(blendData[BlendData.Hair]), 0, 0);
            player.setHairColor(parseInt(blendData[BlendData.HairColor]), 0);

            // Nos
            player.setFaceFeature(0, parseFloat(blendData[BlendData.NoseWidth]));
            player.setFaceFeature(1, parseFloat(blendData[BlendData.NoseHeight]));
            player.setFaceFeature(2, parseFloat(blendData[BlendData.NoseLength]));
            player.setFaceFeature(3, parseFloat(blendData[BlendData.NoseBridge]));
            player.setFaceFeature(4, parseFloat(blendData[BlendData.NoseEnd]));
            player.setFaceFeature(5, parseFloat(blendData[BlendData.NoseShift]));

            // Brwi
            player.setFaceFeature(6, parseFloat(blendData[BlendData.EyebrowsWidth]));
            player.setFaceFeature(7, parseFloat(blendData[BlendData.EyebrowsHeight]));

            // Kość policzkowa
            player.setFaceFeature(8, parseFloat(blendData[BlendData.BoneHeight]));
            player.setFaceFeature(9, parseFloat(blendData[BlendData.BoneWidth]));
            player.setFaceFeature(10, parseFloat(blendData[BlendData.CheeksWidth]));

            player.setFaceFeature(11, parseFloat(blendData[BlendData.EyesWidth]));
            player.setFaceFeature(12, parseFloat(blendData[BlendData.LipsWidth]));

            player.setFaceFeature(13, parseFloat(blendData[BlendData.JawWidth]));
            player.setFaceFeature(14, parseFloat(blendData[BlendData.JawHeight]));

            player.setFaceFeature(15, parseFloat(blendData[BlendData.ChinLength]));
            player.setFaceFeature(16, parseFloat(blendData[BlendData.ChinPosition]));
            player.setFaceFeature(17, parseFloat(blendData[BlendData.ChinWidth]));
            player.setFaceFeature(18, parseFloat(blendData[BlendData.ChinShape]));
            player.setFaceFeature(19, parseFloat(blendData[BlendData.NeckLength]));

            player.setComponentVariation(3, parseInt(blendData[BlendData.TorsoId]), 0, 0);
            player.setComponentVariation(4,
                parseInt(blendData[BlendData.Legs]),
                parseInt(blendData[BlendData.LegsTexture]),
                0);
            player.setComponentVariation(6,
                parseInt(blendData[BlendData.Boots]),
                parseInt(blendData[BlendData.BootsTexture]),
                0);
            player.setComponentVariation(7,
                parseInt(blendData[BlendData.Accessories]),
                parseInt(blendData[BlendData.AccessoriesTexture]),
                0);
            player.setComponentVariation(8,
                parseInt(blendData[BlendData.Undershirt]),
                parseInt(blendData[BlendData.UndershirtTexture]),
                0);
            player.setComponentVariation(11,
                parseInt(blendData[BlendData.Tops]),
                parseInt(blendData[BlendData.TopsTexture]),
                0);

            // Ustawianie stylu chodzenia
            if (crouch) {
                player.setMovementClipset(movementClipSet, 0.25);
                player.setStrafeClipset(strafeClipSet);
            } else {
                player.resetStrafeClipset();
                if (walkingStyle.toString() === "null") {
                    player.resetMovementClipset(0.25);
                } else {
                    if (!mp.game.streaming.hasClipSetLoaded(walkingStyle)) {
                        mp.game.streaming.requestClipSet(walkingStyle);
                        while (!mp.game.streaming.hasClipSetLoaded(walkingStyle)) mp.game.wait(0);
                    }
                    player.setMovementClipset(walkingStyle, 0.25);
                }
            }

            let tattoosList = JSON.parse(tattoos);
            let sTattoos = JSON.parse(syncedTattoos);

            player.clearDecorations();

            for (let i = 0; i < sTattoos.length; i++) {
                let tattooData = getTattoo(parseInt(sTattoos[i]));
                if (tattooData === undefined) continue;

                player.setDecoration(mp.game.joaat(tattooData.Collection), mp.game.joaat(tattooData.Hash));
            }

            for (let i = 0; i < tattoosList.length; i++) {
                player.setDecoration(mp.game.joaat(tattoosList[i].Collection), mp.game.joaat(tattoosList[i].Hash));
            }

            tempPlayersData[remoteId] = {
                "descriptions": JSON.parse(nicknameDesc)
            };
            
            if (mugshot !== null) {
                addMugshot(player, JSON.parse(mugshot));
            } else {
                destroyMugshot(player);
            }

            // AnimObject
            /* if (pAnimObject !== null) {
                 if (mp.objects.exists(pAnimObject)) {
                     pAnimObject.destroy();
                 }
             }
     
             
             if (animObject !== null) {
                 animObject = JSON.parse(animObject);
     
     
                 pAnimObject = mp.objects.new(
                     parseInt(animObject.ObjectId),
                     player.position,
                     {
                         rotation: new mp.Vector3(0, 0, 0),
                         alpha: 255,
                         dimension: 0
                     }
                 );
                 
                 
     
                 mp.gui.chat.push(`BoneName: ${animObject.BoneName.toString()}, ${player.getBoneIndexByName(animObject.BoneName.toString())}`);
                 mp.gui.chat.push(`${parseInt(animObject.ObjectId)}`);
                 
                 pAnimObject.attachTo(
                     player.handle,
                     28422,
                     parseFloat(animObject.Position.x),
                     parseFloat(animObject.Position.y),
                     parseFloat(animObject.Position.z),
                     parseFloat(animObject.Rotation.x),
                     parseFloat(animObject.Rotation.y),
                     parseFloat(animObject.Rotation.z),
                     true,
                     false,
                     false,
                     false,
                     0,
                     false
                 );
             }*/
        });

    mp.keys.bind(0x11,
        false,
        () => {
            if (CefHandler.getChatFocused()) return;
            mp.events.callRemote("server.player.crouch");
        });
}

export function getPlayerDescriptions(remoteId: number) {
    if (tempPlayersData[remoteId] === null || tempPlayersData[remoteId] === undefined) return null;

    if (tempPlayersData[remoteId].hasOwnProperty("descriptions")) {
        return tempPlayersData[remoteId]["descriptions"];
    }
    return null;
}

export function getPlayerData(player: MpPlayer, dataName: string): any {

    if (player === null || player === undefined) return null;
    if (playersData[player.remoteId] === null || playersData[player.remoteId] === undefined) {
        return null;
    }
    if (playersData[player.remoteId][dataName] === undefined) {
        return null;
    }
    return playersData[player.remoteId][dataName];
}

function GetPlayerByRemoteId(remoteId: number): MpPlayer {
    const player = mp.players.atRemoteId(remoteId);
    if (player == undefined || player == null) {
        return null;
    }
    return player;
}