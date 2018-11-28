/// <reference path="@types/index.d.ts" />

import * as UiClass from "./ui"

let AtmModels = [
    -870868698, //prop_atm_01
    -1126237515, //prop_atm_02
    -1364697528, //prop_atm_03
    506770882 //prop_fleeca_atm
];


export function load(): void {
    // TODO: Trzeba refactor mocny strzelić
    mp.events.add("client.bank.check",
        function() {
            const localPlayer = mp.players.local;
            const pos = localPlayer.position;
            for (let i = 0; i < AtmModels.length; i++) {
                const object =
                    mp.game.object.getClosestObjectOfType(pos.x, pos.y, pos.z, 2.0, AtmModels[i], false, true, true);
                if (object.toString() != "0") {
                    mp.events.callRemote("server.bank.response", true);
                    return;
                }
            }
            mp.events.callRemote("server.bank.response", false);
        });
}