/// <reference path="@types/index.d.ts" />

import * as SyncManager from "./syncManager"

const nicknamesRange: number = 20.0;
let showForYourself = false;
let timer = null;

let MathHelper = {
    // Get the linear interpolation between two value
    lerp: function (value1, value2, amount) {
        amount = amount < 0 ? 0 : amount;
        amount = amount > 1 ? 1 : amount;
        return value1 + (value2 - value1) * amount;
    }

};

function FixDrawText(text: string): string {
    if (text != null && text.length < 16) {
        for (let i = 0; i < 17; i++) {
            text += " ";
        }
    }
    return text;
}

function DescSplit(text: string): string {
    let split = text.split(" ");
    let output: string = "";
    let word: number = 0;
    for (let i = 0; i < split.length; i++) {
        word++;
        output += ` ${split[i]}`;
        if (word == 4) {
            output += "\n";
            word = 0;
        }
    }
    return output;
}

export function Load(): void {
    mp.events.add("client.descriptions.showDesc", function () {
        showForYourself = true;
        if (timer != null) {
            clearTimeout(timer);
        }
        timer = setTimeout(function () {
            timer = null;
            showForYourself = false;
        }, 10000);
    });

    mp.events.add("render", function () {
        let localPlayer = mp.players.local;
        mp.players.forEach(function (entity: MpPlayer) {
            if (localPlayer != entity || (localPlayer == entity && showForYourself)) {
                let entityLogged = SyncManager.GetPlayerData(entity, "player.isLogged");
                if (entityLogged !== undefined && entityLogged) {
                    let description = SyncManager.GetPlayerData(entity, "player.description");
                    if (description !== undefined && description !== null) {
                        let playerPosition = entity.getBoneCoords(31086, 0, 0, 0);
                        let dist = GetDistanceBetweenPositions(localPlayer.position, entity.position);
                        if (dist < nicknamesRange) {
                            let data = mp.game.graphics.world3dToScreen2d(playerPosition.x, playerPosition.y, playerPosition.z - 0.5);
                            if (data !== null && data !== undefined) {
                                let progress = dist / nicknamesRange;
                                let alpha = MathHelper.lerp(200, 0, progress);
                                let scale = MathHelper.lerp(0.3, 0.15, progress);

                                mp.game.graphics.drawText(`${DescSplit(FixDrawText(description))}`, [data.x, data.y], {
                                    font: 0,
                                    color: [255, 255, 255, alpha],
                                    scale: [scale, scale],
                                    outline: true
                                });
                            }
                        }
                    }
                }
            }
        });
    });
}

function GetDistanceBetweenPositions(posFirst: MpVector3, posSecond: MpVector3): number {
    let distance: number = Math.sqrt(Math.pow(posFirst.x - posSecond.x, 2) + Math.pow(posFirst.y - posSecond.y, 2) + Math.pow(posFirst.z - posSecond.z, 2));
    return distance;
}