/// <reference path="@types/index.d.ts" />
import * as Ui from "./ui"

let show = false;

export function load() {
    mp.events.add("client.animation.sync",
        function(ppl, dict, name, flag) {
            mp.players.atRemoteId(ppl).freezePosition(false);
            const plr = mp.players.atRemoteId(ppl);

            if (mp.players.exists(plr)) {
                mp.game.streaming.requestAnimDict(dict);

                setTimeout(function() {

                        plr.clearTasks();
                        plr.clearTasksImmediately();
                        plr.taskPlayAnim(dict, name, 8.0, 0.0, -1, flag, 0.0, false, false, false);
                    },
                    200);
            }


        });

    mp.events.add("client.animation.showInfo",
        function() {
            show = true;
            Ui.getNewUiBrowser().execute(`lsvrpAnimVue.show = true;`);
        });

    mp.events.add("client.animation.hideInfo",
        function() {
            show = false;
            Ui.getNewUiBrowser().execute(`lsvrpAnimVue.show = false;`);
        });

    mp.events.add("render",
        function() {
            if (!show) return;

            mp.game.controls.disableControlAction(2, 22, true);
        });

    mp.keys.bind(0x20,
        false,
        function() {
            if (show) {
                mp.events.callRemote("server.anim.stopAnim");
            }
        });
}