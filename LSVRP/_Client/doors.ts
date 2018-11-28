/// <reference path="@types/index.d.ts" />

import * as CefClass from "./cef"
import * as SyncManager from "./syncManager"

let blockEnter: boolean = false;

let MathHelper = {
    // Get the linear interpolation between two value
    lerp: function(value1, value2, amount) {
        amount = amount < 0 ? 0 : amount;
        amount = amount > 1 ? 1 : amount;
        return value1 + (value2 - value1) * amount;
    }

};

class LabelDoors {
    name: string;
    position: MpVector3;
    text: string;
    dim: number;
}

let allLabelsDoors: LabelDoors[] = [];

const LABEL_MAX_DISTANCE = 15.0;

export function load(): void {
    mp.events.add("client.doors.loadDoorsLabels",
        function(data: string) {
            const input: {
                name: string;
                text: string;
                x: number;
                y: number;
                z: number;
                dim: number;
            }[] = JSON.parse(data);
            allLabelsDoors.splice(0, allLabelsDoors.length);

            for (let i = 0; i < input.length; i++) {
                const newLabel = new LabelDoors();
                newLabel.name = input[i].name;
                newLabel.position = new mp.Vector3(input[i].x, input[i].y, input[i].z);
                newLabel.text = `~r~${input[i].text}\n~y~Naciśnij ~g~E~y~ aby wejść`;
                newLabel.dim = input[i].dim;
                allLabelsDoors.push(newLabel);
            }
        });

    mp.events.add("client.doors.freezePosition",
        function(data: boolean) {
            //mp.players.local.freezePosition(data);
        });

    mp.keys.bind(13,
        false,
        function() {
            if (!CefClass.getChatFocused()) {
                const localPlayer = mp.players.local;
                if (SyncManager.getPlayerData(localPlayer, "player.interior.editorEnabled")) {
                    //mp.gui.chat.push(`Pozycja ${localPlayer.position.x}, ${localPlayer.position.y}, ${localPlayer.position.z}`);
                    mp.events.callRemote("server.interiors.createNew", []);
                } else if (SyncManager.getPlayerData(localPlayer, "player.interior.editorEnabledInPos")) {
                    mp.events.callRemote("server.interiors.editInPos", []);
                } else if (SyncManager.getPlayerData(localPlayer, "player.interior.editorEnabledOutPos")) {
                    mp.events.callRemote("server.interiors.editOutPos", []);
                } else if (SyncManager.getPlayerData(localPlayer, "player.interior.editorEnabledAddAnotherDoors")) {
                    mp.events.callRemote("server.interiors.addNewDoors", []);
                }
            }
        });

    // server.interiors.enterInterior
    mp.keys.bind(0x45,
        false,
        function() {
            if (!CefClass.getChatFocused() && !CefClass.isChatBlocked()) {
                if (!blockEnter) {
                    mp.events.callRemote("server.interiors.tryEnterToInterior");
                }
            }
        });

    mp.events.add("client.doors.fadeOut",
        function() {
            blockEnter = true;
            mp.game.cam.doScreenFadeOut(1000);
            setTimeout(function() {
                    mp.events.callRemote("server.interiors.enterInterior");
                },
                1050);
        });

    mp.events.add("client.doors.fadeIn",
        function() {
            mp.game.cam.doScreenFadeIn(1000);
            setTimeout(function() {
                    blockEnter = false;
                },
                1050);
        });

    mp.events.add("client.interiors.syncplayers",
        function(array) {
            for (let i = 0; i < array.length; i++) {
                if (!mp.players.atRemoteId(array[i].Handle).vehicle) {
                    mp.players.atRemoteId(array[i].Handle).position = array[i].Position;
                    mp.players.atRemoteId(array[i].Handle).heading = array[i].Rotation;
                }
            }
        });

    mp.events.add("render",
        function() {
            const playerPosition = mp.players.local.position;
            const playerDimension = mp.players.local.dimension;
            for (let i = 0; i < allLabelsDoors.length; i++) {
                if (allLabelsDoors[i].dim == playerDimension) {
                    const distance = GetDistanceBetweenPositions(playerPosition, allLabelsDoors[i].position);
                    if (distance < LABEL_MAX_DISTANCE) {
                        const hitData = mp.raycasting.testPointToPoint(playerPosition,
                            allLabelsDoors[i].position,
                            mp.players.local);
                        // mp.gui.chat.push(JSON.stringify(hitData));
                        if (!hitData) {
                            const progress = distance / LABEL_MAX_DISTANCE;
                            const alpha = MathHelper.lerp(240, 0, progress);
                            const scale = MathHelper.lerp(0.35, 0.1, progress);

                            mp.game.graphics.drawText(`${FixDrawText(allLabelsDoors[i].text)}`,
                                [
                                    allLabelsDoors[i].position.x, allLabelsDoors[i].position.y,
                                    allLabelsDoors[i].position.z
                                ],
                                {
                                    font: 0,
                                    color: [255, 255, 255, alpha],
                                    scale: [scale, scale],
                                    outline: true
                                });
                        }
                    }
                }
            }
        });
}

function GetDistanceBetweenPositions(posFirst: MpVector3, posSecond: MpVector3): number {
    return Math.sqrt(Math.pow(posFirst.x - posSecond.x, 2) +
        Math.pow(posFirst.y - posSecond.y, 2) +
        Math.pow(posFirst.z - posSecond.z, 2));
}

function FixDrawText(text: string): string {
    if (text != null && text.length < 16) {
        for (let i = 0; i < 17; i++) {
            text += " ";
        }
    }
    return text;
}

function GetPositionInFrontOfPlayer(player: MpPlayer, distance: number): [number, number, number] {
    const x = Number(distance * Math.sin(-(player.getHeading() * 3.14 / 180)));
    const y = Number(distance * Math.cos(-(player.getHeading() * 3.14 / 180)));
    return [player.position.x + x, player.position.y + y, player.position.z];
}