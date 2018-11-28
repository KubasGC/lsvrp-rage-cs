/// <reference path="@types/index.d.ts" />

import * as CefClass from "./cef"

let MathHelper = {
    // Get the linear interpolation between two value
    lerp: function(value1, value2, amount) {
        amount = amount < 0 ? 0 : amount;
        amount = amount > 1 ? 1 : amount;
        return value1 + (value2 - value1) * amount;
    }

};

class LabelBuses {
    name: string;
    position: MpVector3;
    text: string;
    dim: number;
}

let allLabelsBuses: LabelBuses[] = [];

const LABEL_MAX_DISTANCE = 15.0;


export function load(): void {
    mp.events.add("client.buses.loadBusesLabels",
        function(data: string) {
            const input: {
                name: string;
                text: string;
                x: number;
                y: number;
                z: number;
                dim: number;
            }[] = JSON.parse(data);
            allLabelsBuses.splice(0, allLabelsBuses.length);

            for (let i = 0; i < input.length; i++) {
                const newLabel = new LabelBuses();
                newLabel.name = input[i].name;
                newLabel.position = new mp.Vector3(input[i].x, input[i].y, input[i].z);
                newLabel.text = `~r~${input[i].text}\n~y~Naciśnij ~g~klawisz B`;
                newLabel.dim = 0;
                allLabelsBuses.push(newLabel);
            }
        });


    mp.events.add("client.bus.start",
        function() {
            mp.players.local.freezePosition(true);
            let busCamera1 = mp.cameras.new('default',
                new mp.Vector3(arguments[0], arguments[1], arguments[2] + 50),
                new mp.Vector3(0, 0, 0),
                40);
            let busCamera2 = mp.cameras.new('default',
                new mp.Vector3(arguments[0], arguments[1], arguments[2] + 100),
                new mp.Vector3(0, 0, 0),
                40);
            let busCamera3 = mp.cameras.new('default',
                new mp.Vector3(arguments[0], arguments[1], arguments[2] + 150),
                new mp.Vector3(0, 0, 0),
                40);
            busCamera1.pointAtCoord(arguments[0], arguments[1], arguments[2]);
            busCamera2.pointAtCoord(arguments[0], arguments[1], arguments[2]);
            busCamera3.pointAtCoord(arguments[0], arguments[1], arguments[2]);

            let busCamera1b = mp.cameras.new('default',
                new mp.Vector3(arguments[3], arguments[4], arguments[5] + 150),
                new mp.Vector3(0, 0, 0),
                40);
            let busCamera2b = mp.cameras.new('default',
                new mp.Vector3(arguments[3], arguments[4], arguments[5] + 100),
                new mp.Vector3(0, 0, 0),
                40);
            let busCamera3b = mp.cameras.new('default',
                new mp.Vector3(arguments[3], arguments[4], arguments[5] + 50),
                new mp.Vector3(0, 0, 0),
                40);
            busCamera1b.pointAtCoord(arguments[3], arguments[4], arguments[5]);
            busCamera2b.pointAtCoord(arguments[3], arguments[4], arguments[5]);
            busCamera3b.pointAtCoord(arguments[3], arguments[4], arguments[5]);


            mp.game.graphics.startScreenEffect("FocusOut", 16500, false);
            mp.game.audio.playSoundFrontend(1, "Hit_out", "PLAYER_SWITCH_CUSTOM_SOUNDSET", true);
            busCamera1.setActive(true);
            mp.game.cam.renderScriptCams(true, false, 0, true, false);
            setTimeout(function() {
                    busCamera2.setActive(true);
                    mp.game.cam.renderScriptCams(true, false, 0, true, false);
                    mp.game.audio.playSoundFrontend(1, "Hit_out", "PLAYER_SWITCH_CUSTOM_SOUNDSET", true);
                },
                1000);
            setTimeout(function() {
                    busCamera3.setActive(true);
                    mp.game.cam.renderScriptCams(true, false, 0, true, false);
                    mp.game.audio.playSoundFrontend(1, "Hit_out", "PLAYER_SWITCH_CUSTOM_SOUNDSET", true);
                },
                2000);
            setTimeout(function() {
                    mp.game.cam.doScreenFadeOut(1000);
                    mp.game.audio.playSoundFrontend(1, "Hit_out", "PLAYER_SWITCH_CUSTOM_SOUNDSET", true);
                },
                5000);

            setTimeout(function() {
                    busCamera1b.setActive(true);
                    mp.game.cam.doScreenFadeIn(1000);
                    mp.game.audio.playSoundFrontend(1, "Hit_out", "PLAYER_SWITCH_CUSTOM_SOUNDSET", true);
                },
                12000);
            setTimeout(function() {
                    busCamera2b.setActive(true);
                    mp.game.audio.playSoundFrontend(1, "Hit_out", "PLAYER_SWITCH_CUSTOM_SOUNDSET", true);
                },
                13000);
            setTimeout(function() {
                    busCamera3b.setActive(true);
                    mp.game.audio.playSoundFrontend(1, "Hit_out", "PLAYER_SWITCH_CUSTOM_SOUNDSET", true);
                },
                15000);
            setTimeout(function() {
                    mp.game.cam.renderScriptCams(false, false, 0, true, false);
                    mp.players.local.freezePosition(false);
                    mp.game.audio.playSoundFrontend(1, "Hit_out", "PLAYER_SWITCH_CUSTOM_SOUNDSET", true);
                },
                16500);
        });

    mp.events.add("render",
        function() {
            const playerPosition = mp.players.local.position;
            const playerDimension = mp.players.local.dimension;
            for (let i = 0; i < allLabelsBuses.length; i++) {
                if (allLabelsBuses[i].dim == playerDimension) {
                    const distance = GetDistanceBetweenPositions(playerPosition, allLabelsBuses[i].position);
                    if (distance < LABEL_MAX_DISTANCE) {
                        const hitData = mp.raycasting.testPointToPoint(playerPosition,
                            allLabelsBuses[i].position,
                            mp.players.local);
                        // mp.gui.chat.push(JSON.stringify(hitData));
                        if (!hitData) {
                            const progress = distance / LABEL_MAX_DISTANCE;
                            const alpha = MathHelper.lerp(240, 0, progress);
                            const scale = MathHelper.lerp(0.35, 0.1, progress);

                            mp.game.graphics.drawText(`${FixDrawText(allLabelsBuses[i].text)}`,
                                [
                                    allLabelsBuses[i].position.x, allLabelsBuses[i].position.y,
                                    allLabelsBuses[i].position.z
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
    const distance = Math.sqrt(Math.pow(posFirst.x - posSecond.x, 2) +
        Math.pow(posFirst.y - posSecond.y, 2) +
        Math.pow(posFirst.z - posSecond.z, 2));
    return distance;
}

function FixDrawText(text: string): string {
    if (text != null && text.length < 16) {
        for (let i = 0; i < 17; i++) {
            text += " ";
        }
    }
    return text;
}