import * as CefClass from "./cef"
import * as SyncManager from "./syncManager"
import * as Global from "./global"

import * as NicknameClass from "./nicknames"

let vehFuel = 0;
let cruiseState = 0;
let currentvelo = new mp.Vector3(0, 0, 0);

export function load(): void {
    mp.events.add("client.vehicle.sync",
        function (vehicleId: number,
                  siren: boolean,
                  leftIndicator: boolean,
                  rightIndicator: boolean,
                  hood: boolean,
                  trunk: boolean,
                  health: number,
                  paintjob: any,
                  firstColor: any,
                  secondColor: any,
                  sirenLight: boolean,
                  jsonExtras: string,
                  jsonHandling: string,
                  vehicleDesc: string) {
            const vehHandle = GetVehicleByRemoteId(vehicleId);
            if (vehHandle != null) {
                vehHandle.setIndicatorLights(1, leftIndicator);
                vehHandle.setIndicatorLights(0, rightIndicator);
                vehHandle.setSirenSound(siren);
                vehHandle.setEngineHealth(health);
                vehHandle.setLivery(parseInt(paintjob));
                vehHandle.setColours(parseInt(firstColor), parseInt(secondColor));
                vehHandle.setSiren(sirenLight);
                const mappedExtras = JSON.parse(jsonExtras);
                for (let k in mappedExtras) {
                    if (mappedExtras.hasOwnProperty(k)) {
                        vehHandle.setExtra(parseInt(k), mappedExtras[k].toString() == "true" ? 1 : 0);
                    }

                }
                if (hood) {
                    vehHandle.setDoorOpen(4, false, false);
                } else {
                    vehHandle.setDoorShut(4, false);
                }

                if (trunk) {
                    vehHandle.setDoorOpen(5, false, false);
                } else {
                    vehHandle.setDoorShut(5, false);
                }

                const mappedHandling = JSON.parse(jsonHandling);
                for (let k in mappedHandling) {
                    if (!mappedHandling.hasOwnProperty(k)) continue;
                    vehHandle.setHandling(k, mappedHandling[k]);
                }

                if (vehicleDesc !== null && vehicleDesc !== undefined) {
                    NicknameClass.addVehicleDesc(vehicleId, vehicleDesc);
                }
            }
        });

    mp.events.add("client.vehicle.sync.option",
        function (vehicleId: number, optionName: string, data: any) {
            const vehHandle = GetVehicleByRemoteId(vehicleId);
            if (vehHandle !== null && vehHandle !== undefined) {
                switch (optionName) {
                    case "livery":
                        vehHandle.setLivery(parseInt(data));
                        break;

                    case "extra":
                        const mappedExtras = JSON.parse(data);
                        for (let k in mappedExtras) {
                            if (mappedExtras.hasOwnProperty(k)) {
                                vehHandle.setExtra(parseInt(k), mappedExtras[k].toString() == "true" ? 1 : 0);
                            }

                        }
                        break;

                    case "desc":
                        NicknameClass.addVehicleDesc(vehicleId, data);
                        break;

                    case "descdel":
                        NicknameClass.removeVehicleDesc(vehicleId);
                        break;
                }
            }
        });

    mp.events.add("client.vehicle.sync.siren",
        function (vehicleId: number, siren: boolean) {
            const vehHandle = GetVehicleByRemoteId(vehicleId);
            if (vehHandle != null) {
                vehHandle.setSirenSound(!siren);
            }
        });

    mp.events.add("client.vehicle.sync.indicator",
        function (vehicleId: number, leftIndicator: boolean, rightIndicator: boolean) {
            const vehHandle = GetVehicleByRemoteId(vehicleId);
            if (vehHandle != null) {
                vehHandle.setIndicatorLights(1, leftIndicator);
                vehHandle.setIndicatorLights(0, rightIndicator);
            }
        });

    mp.events.add("client.vehicle.sync.hood",
        function (vehicleId: number, hood: boolean) {
            const vehHandle = GetVehicleByRemoteId(vehicleId);
            if (vehHandle != null) {
                if (hood) {
                    vehHandle.setDoorOpen(4, false, false);
                } else {
                    vehHandle.setDoorShut(4, false);
                }
            }
        });

    mp.events.add("client.vehicle.sync.trunk",
        function (vehicleId: number, trunk: boolean) {
            const vehHandle = GetVehicleByRemoteId(vehicleId);
            if (vehHandle != null) {
                if (trunk) {
                    vehHandle.setDoorOpen(5, false, false);
                } else {
                    vehHandle.setDoorShut(5, false);
                }
            }
        });

    mp.events.add("client.vehicle.engine",
        function (remoteId: number, engineState: boolean) {
            const vehHandle = GetVehicleByRemoteId(remoteId);
            if (vehHandle != null) {
                vehHandle.setEngineOn(engineState, true, true);
                vehHandle.setUndriveable(!engineState);
            }
        });

    mp.keys.bind(0x4C,
        false,
        function () {
            if (mp.players.local.vehicle && !CefClass.getChatFocused() && !CefClass.isChatBlocked()) {
                if (!mp.game.vehicle.isThisModelABicycle(mp.players.local.vehicle.model)) {
                    mp.events.callRemote("server.events.vehicleEngine");
                    cruiseState = 0;
                }
            }
        });

    mp.keys.bind(51,
        false,
        function () {
            if (mp.players.local.vehicle && !CefClass.getChatFocused()) {
                // Lewy kierunkowskaz (,)
                if (Global.isPlayerDriver()) {
                    mp.events.callRemote("server.vehicle.bind.key", "left-indicator");
                }
            }
        });
    mp.keys.bind(52,
        false,
        function () {
            if (mp.players.local.vehicle && !CefClass.getChatFocused()) {
                // Prawy kierunkowskaz (.)
                if (Global.isPlayerDriver()) {
                    mp.events.callRemote("server.vehicle.bind.key", "right-indicator");
                }
            }
        });

    mp.keys.bind(0x4F,
        false,
        function () {
            if (mp.players.local.vehicle && !CefClass.getChatFocused()) {
                // koguty w aucie
                if (Global.isPlayerDriver()) {
                    mp.events.callRemote("server.vehicle.bind.key", "siren");
                }
            }
        });

    mp.events.add("entityStreamIn",
        function (entity: MpVehicle) {
            const entityType = entity.getType();
            if (entityType == 2) // Synchronizacja pojazdu
            {
                entity.setDirtLevel(0);
                entity.setDisablePetrolTankDamage(true);
                entity.setDisablePetrolTankFires(true);
                mp.events.callRemote("server.vehicle.sync", entity.remoteId);
            } else if (entityType == 4 || entityType == 5) // Synchronizacja gracza
            {
                mp.events.callRemote("server.player.sync", entity.remoteId);
            }
        });

    function getRandom(min, max) {
        return Math.random() * (max - min + 1) + min;
    }

    const lasthit: any = -1;
    mp.events.add("render",
        function () {
            if (mp.players.local.vehicle != null) {
                const vehicle = mp.players.local.vehicle;
                const speed = Math.round(vehicle.getSpeed() * 3.6).toFixed(0);

                if (SyncManager.getPlayerData(mp.players.local, "player.vehicle.cruise") == true &&
                    Global.isPlayerDriver()) {
                    if (cruiseState == 1) {
                        currentvelo = vehicle.getVelocity();

                        currentvelo.x = currentvelo.x * 1.1;
                        currentvelo.y = currentvelo.y * 1.1;
                        vehicle.setVelocity(currentvelo.x, currentvelo.y, currentvelo.z);

                        if (vehicle.hasCollidedWithAnything() || vehicle.isInAir()) {
                            cruiseState = 0;
                            toggle();
                        }

                        if (buttonchecker()) {
                            cruiseState = 0;
                            toggle();
                        }
                    }

                    if (SyncManager.getPlayerData(mp.players.local, "player.speed.block") == true && cruiseState == 0) {
                        vehicle.setMaxSpeed(GetKilometres(60));
                    } else if (SyncManager.getPlayerData(mp.players.local, "player.speed.block") == false &&
                        cruiseState == 0) {
                        vehicle.setMaxSpeed(mp.game.vehicle.getVehicleModelMaxSpeed(vehicle.model));
                    }

                }
            }
        });
}

mp.keys.bind(18,
    false,
    function () {
        const vehicle = mp.players.local.vehicle;
        if (SyncManager.getPlayerData(mp.players.local, "player.vehicle.cruise") == true) {
            if (vehicle && !CefClass.getChatFocused()) {
                if (vehicle.getSpeed() > 2 && vehicle.getIsEngineRunning()) {
                    if (cruiseState == 0) {
                        cruiseState = 1;
                        toggle();
                    } else if (cruiseState == 1) {
                        cruiseState = 0;
                        toggle();
                    }
                }
            }
        }
    });

function toggle() {
    const vehicle = mp.players.local.vehicle;

    if (cruiseState == 1 && vehicle) {
        const speed = vehicle.getSpeed();
        vehicle.setMaxSpeed(speed);
    }


    if (cruiseState == 0 && vehicle) {
        if (SyncManager.getPlayerData(mp.players.local, "player.speed.block") == true) {
            vehicle.setMaxSpeed(GetKilometres(60));
        } else {
            const vehMaxSpeed = mp.game.vehicle.getVehicleModelMaxSpeed(vehicle.model);
            vehicle.setMaxSpeed(vehMaxSpeed);
        }
    }
}

function buttonchecker() {
    if (!CefClass.getChatFocused()) {
        if (mp.keys.isDown(32) === true) return true;
        if (mp.keys.isDown(83) === true) return true;
        if (mp.keys.isDown(70) === true) return true;
        if (mp.keys.isDown(13) === true) return true;
    }
    return false;
}


function GetKilometres(value: number) {
    return value / 3.6;
}

function GetVehicleByRemoteId(remoteId: number): MpVehicle {
    const veh = mp.vehicles.atRemoteId(remoteId);
    if (veh === undefined || veh === null) {
        return null;
    }
    return veh;
}