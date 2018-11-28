/// <reference path="@types/index.d.ts" />

import * as SyncManager from "./syncManager"
import { isPlayerDriver as IsPlayerDriver } from "./global";

export function load() {
    // let myVar = setInterval(myTimer, 5000);

    function getSteerBias() {
        const rand = Math.floor(Math.random() * 11);
        let ret = 0;
        switch (rand) {
        case 0:
            ret = 0.1;
            break;
        case 1:
            ret = 0.1;
            break;
        case 2:
            ret = 0.2;
            break;
        case 3:
            ret = 0.3;
            break;
        case 4:
            ret = 0.4;
            break;
        case 5:
            ret = 0.5;
            break;
        case 6:
            ret = -0.1;
            break;
        case 7:
            ret = -0.2;
            break;
        case 8:
            ret = -0.3;
            break;
        case 9:
            ret = -0.4;
            break;
        case 10:
            ret = -0.5;
            break;
        }
        return ret;
    }

    function repeat(fn, times) {
        const loop = function(times) {
            if (times) {
                fn(times);
                loop(--times);
            }
        };
        loop(times);
    }


    function myTimer() {
        let vehicle = mp.players.local.vehicle;
        let drunk = SyncManager.getPlayerData(mp.players.local, "player.drunk");
        if (drunk != null && drunk != undefined) {
            if (vehicle != null && IsPlayerDriver()) {
                if (drunk > 600) {
                    //vehicle.setSteerBias(getSteerBias());
                    let bias = getSteerBias();
                    count(10);

                    function count(num) {
                        setTimeout(function() {
                                vehicle.setSteerBias(bias);
                                if (num > 0) count(num - 1);
                            },
                            50);
                    }

                    //vehicle.setSteerBias(getSteerBias());
                }
            }

            let d = Math.random();
            if (drunk < 2 && drunk > 0) {
                mp.game.graphics.setTimecycleModifier("Drunk");
                mp.game.graphics.setTimecycleModifierStrength(0.0);
            } else if (drunk > 2 && drunk < 599) {
                mp.game.graphics.setTimecycleModifier("Drunk");
                mp.game.graphics.setTimecycleModifierStrength(0.2);
                //mp.players.local.setToRagdoll(2000, 2000, 1, false, false,false);
            } else if (drunk > 600 && drunk < 899) {
                mp.game.graphics.setTimecycleModifier("Drunk");
                mp.game.graphics.setTimecycleModifierStrength(0.5);
                if (mp.players.local.getSpeed() > 1.5 && mp.players.local.vehicle != null) {
                    if (d < 0.05) {
                        count2(10);
                    }
                }
            } else if (drunk > 900 && drunk < 1199) {
                mp.game.graphics.setTimecycleModifier("Drunk");
                mp.game.graphics.setTimecycleModifierStrength(0.6);
                if (mp.players.local.getSpeed() > 1.5 && mp.players.local.vehicle != null) {
                    if (d < 0.1) {
                        count2(10);
                    }
                }
            } else if (drunk > 1200 && drunk < 1499) {
                mp.game.graphics.setTimecycleModifier("Drunk");
                mp.game.graphics.setTimecycleModifierStrength(0.8);
                if (mp.players.local.getSpeed() > 1.5 && mp.players.local.vehicle != null) {
                    if (d < 0.25) {
                        count2(10);
                    }
                }
            } else if (drunk > 1500) {
                mp.game.graphics.setTimecycleModifier("Drunk");
                mp.game.graphics.setTimecycleModifierStrength(1.0);
                if (mp.players.local.getSpeed() > 1.5 && mp.players.local.vehicle != null) {
                    if (d < 0.30) {
                        count2(10);
                    }
                }
            }

            function count2(num) {
                setTimeout(function() {
                        mp.players.local.setToRagdoll(2000, 2000, 1, false, false, false);
                        if (num > 0) count2(num - 1);
                    },
                    50);
            }
        }
    }
}