import * as SyncManager from "./syncManager"

const descriptions = {
    "1": "nowa postać",
    "2": "zrelaksowany",
    "3": "nadpobudliwy",
    "4": "nieprzytomny"
};

let descShowForYourself = false;
let descTimer = null;

const nicknamesRange = 20.0;

class VehDesc {
    remoteId: number;
    description: string;

    constructor(remoteId: number, desc: string) {
        this.remoteId = remoteId;
        this.description = desc;
    }
}

let vehicleDescriptionsList: VehDesc[] = [];

export function getVehicleDescription(remoteId: number): VehDesc {
    for (let i = 0; i < vehicleDescriptionsList.length; i++) {
        if (vehicleDescriptionsList[i].remoteId === remoteId) return vehicleDescriptionsList[i];
    }
    return null;
}

export function removeVehicleDesc(remoteId: number): void {
    for (let i = 0; i < vehicleDescriptionsList.length; i++) {
        if (vehicleDescriptionsList[i].remoteId === remoteId) {
            vehicleDescriptionsList.splice(i, 1);
        }
    }
}

export function addVehicleDesc(remoteId: number, desc: string) {
    if (getVehicleDescription(remoteId) !== null) {
        removeVehicleDesc(remoteId);
    }
    vehicleDescriptionsList.push(new VehDesc(remoteId, desc));
}


let MathHelper = {
    // Get the linear interpolation between two value
    lerp: function(value1, value2, amount) {
        amount = amount < 0 ? 0 : amount;
        amount = amount > 1 ? 1 : amount;
        return value1 + (value2 - value1) * amount;
    }

};

function capitalizeFirstLetter(string: string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}

function joinDescriptions(remoteId: number) {
    const newArray = [];

    const data = SyncManager.getPlayerDescriptions(remoteId);
    if (data === null || data === undefined || data.length === 0) return null;

    for (let i = 0; i < data.length; i++) {
        if (descriptions.hasOwnProperty(data[i].toString())) {
            newArray.push(descriptions[data[i].toString()]);
        }
    }

    return capitalizeFirstLetter(newArray.join(", "));
}

function fixDrawText(text: string): string {
    if (text != null && text.length < 16) {
        for (let i = 0; i < 17; i++) {
            text += " ";
        }
    }
    return text;
}

function getAdminRankInfo(adminLevel: number): { color: [number, number, number], name: string } {
    if (adminLevel === 1) {
        return {
            color: [160, 72, 158],
            name: "Helper"
        };
    } else if (adminLevel === 2) {
        return {
            color: [0, 133, 221],
            name: "Support (1)"
        };
    } else if (adminLevel === 3) {
        return {
            color: [0, 133, 221],
            name: "Support (2)"
        };
    } else if (adminLevel === 4) {
        return {
            color: [0, 133, 221],
            name: "Support (3)"
        };
    } else if (adminLevel === 5) {
        return {
            color: [0, 133, 221],
            name: "Support (4)"
        };
    } else if (adminLevel === 6) {
        return {
            color: [24, 201, 31],
            name: "Gamemaster"
        };
    } else if (adminLevel === 7) {
        return {
            color: [255, 0, 0],
            name: "Administrator"
        };
    } else if (adminLevel === 8) {
        return {
            color: [255, 124, 82],
            name: "Developer"
        };
    } else if (adminLevel === 9) {
        return {
            color: [179, 102, 255],
            name: "Moderator serwera"
        };
    } else if (adminLevel === 10) {
        return {
            color: [144, 26, 255],
            name: "Senior moderator"
        };
    } else {
        return {
            color: [255, 255, 255],
            name: "Nieznana ranga"
        };
    }
}

function descSplit(text: string): string {
    const split = text.split(" ");
    let output: string = "";
    let word: number = 0;
    for (let i = 0; i < split.length; i++) {
        word++;
        output += ` ${split[i]}`;
        if (word === 4) {
            output += "\n";
            word = 0;
        }
    }
    return output;
}

function renderNicknames() {
    mp.game.player.setHealthRechargeMultiplier(-1); // Wyłączenie odnawiania się HP.
    let localPlayer = mp.players.local;
    for (let i = 0; i < mp.players.length; i++) {
        let player = mp.players.at(i);

        // Wyłączenie renderowania własnego nicku.
        if (localPlayer === player && !descShowForYourself) continue;

        // Sprawdzenie, czy gracz jest zalogowany.
        let entityLogged = SyncManager.getPlayerData(player, "player.isLogged");
        if (entityLogged === undefined || !entityLogged) continue;

        // Wyłączanie kolizji w momencie speca.
        let spectator = SyncManager.getPlayerData(player, "Spectator");
        if (spectator) player.setCollision(false, false);
        else player.setCollision(true, true);

        // Pobieranie nicku z entityData.
        let visibleName = SyncManager.getPlayerData(player, "player.visibleName");
        if (visibleName === undefined || visibleName === null || spectator) continue;

        // Sprawdzanie pozycji gracza.
        let playerPosition = player.getBoneCoords(31086, 0, 0, 0);
        let dist = getDistanceBetweenPositions(localPlayer.position, player.position);
        if (dist > nicknamesRange) continue;

        // Pobieranie pozycji 2d z 3d.
        let data = mp.game.graphics.world3dToScreen2d(playerPosition.x, playerPosition.y, playerPosition.z + 0.65);
        if (data === null || data === undefined) continue;

        // Obliczenie potrzebnych rzeczy.
        let progress = dist / nicknamesRange;
        let alpha = MathHelper.lerp(200, 0, progress);
        let scale = MathHelper.lerp(0.3, 0.15, progress);
        let color: [number, number, number] = [255, 255, 255];

        // Renderowanie duty administratora.
        let adminDuty = SyncManager.getPlayerData(player, "player.adminDuty");
        if (adminDuty !== undefined && adminDuty !== null && adminDuty) {
            let adminColor = getAdminRankInfo(SyncManager.getPlayerData(player, "player.adminLevel"));
            mp.game.graphics.drawText(`${fixDrawText(adminColor.name)}`,
                [data.x, data.y - 0.02],
                {
                    font: 0,
                    color: [adminColor.color[0], adminColor.color[1], adminColor.color[2], alpha],
                    scale: [scale, scale],
                    outline: true
                });
        }

        // Renderowanie opisów pod nickiem.
        let pDescriptions = joinDescriptions(player.remoteId);
        if (pDescriptions !== null) {
            mp.game.graphics.drawText(`(( ${pDescriptions} ))`,
                [data.x, data.y + 0.02],
                {
                    font: 0,
                    color: [150, 150, 150, alpha],
                    scale: [scale, scale],
                    outline: true
                });
        }

        // Renderowanie właściwego nicku
        mp.game.graphics.drawText(`${fixDrawText(visibleName)}`,
            [data.x, data.y],
            {
                font: 0,
                color: [color[0], color[1], color[2], alpha],
                scale: [scale, scale],
                outline: true
            });

        // Renderowanie tagu grupy na której duty się znajduje.
        let groupDutyInfo = SyncManager.getPlayerData(player, "player.groupDutyInfo");
        if (groupDutyInfo !== null && !adminDuty) {
            if (groupDutyInfo.GroupTag !== "XXXX" && groupDutyInfo.GroupTag !== "[]") {
                mp.game.graphics.drawText(`${fixDrawText(groupDutyInfo.GroupTag)}`,
                    [data.x, data.y + 0.04],
                    {
                        font: 0,
                        color: [
                            groupDutyInfo.GroupColor[0], groupDutyInfo.GroupColor[1], groupDutyInfo.GroupColor[2], alpha
                        ],
                        scale: [scale, scale],
                        outline: true
                    });
            }
        }

        //
        // OPISY
        //

        // Pobieranie opisu z entityData.
        let descriptionText = SyncManager.getPlayerData(player, "player.description");
        if (descriptionText === undefined || descriptionText === null || spectator) continue;

        // Pobieranie pozycji 2d.
        let secondPlayerPosition = player.getBoneCoords(11816, 0, 0, 0);
        let secondData =
            mp.game.graphics.world3dToScreen2d(secondPlayerPosition.x, secondPlayerPosition.y, secondPlayerPosition.z);
        if (secondData === null || data === undefined) continue;

        mp.game.graphics.drawText(`${descSplit(fixDrawText(descriptionText))}`,
            [secondData.x, secondData.y],
            {
                font: 4,
                color: [255, 255, 255, alpha],
                scale: [scale, scale],
                outline: true
            });
    }

    for (let j = 0; j < vehicleDescriptionsList.length; j++) {
        let vehData = mp.vehicles.atRemoteId(vehicleDescriptionsList[j].remoteId);
        if (vehData === null || vehData === undefined) continue;

        let dist = getDistanceBetweenPositions(localPlayer.position, vehData.position);
        if (dist > nicknamesRange) continue;

        let vehPos = mp.game.graphics.world3dToScreen2d(vehData.position.x, vehData.position.y, vehData.position.z);
        if (vehPos === null || vehPos === undefined) continue;

        // Obliczenie potrzebnych rzeczy.
        let progress = dist / nicknamesRange;
        let alpha = MathHelper.lerp(200, 0, progress);
        let scale = MathHelper.lerp(0.3, 0.15, progress);
        let color: [number, number, number] = [255, 255, 255];

        mp.game.graphics.drawText(`${descSplit(fixDrawText(vehicleDescriptionsList[j].description))}`,
            [vehPos.x, vehPos.y],
            {
                font: 4,
                color: [194, 162, 218, alpha],
                scale: [scale, scale],
                outline: true
            });
    }
}

export function load(): void {

    mp.events.add("client.descriptions.showDesc",
        function() {
            descShowForYourself = true;
            if (descTimer !== null) {
                clearTimeout(descTimer);
            }
            descTimer = setTimeout(function() {
                    descTimer = null;
                    descShowForYourself = false;
                },
                10000);
        });

    mp.events.add("render", renderNicknames);


}

function getDistanceBetweenPositions(posFirst: MpVector3, posSecond: MpVector3): number {
    const distance = Math.sqrt(Math.pow(posFirst.x - posSecond.x, 2) +
        Math.pow(posFirst.y - posSecond.y, 2) +
        Math.pow(posFirst.z - posSecond.z, 2));
    return distance;
}