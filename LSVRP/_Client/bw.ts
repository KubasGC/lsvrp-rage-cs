/// <reference path="@types/index.d.ts" />

import * as UiClass from "./ui"

export function load(): void {
    mp.events.add("client.bw.toggleFadeout",
        function() {
            mp.game.gameplay.setFadeOutAfterDeath(false);
        });

    mp.events.add("client.bw.setTime",
        function() {
            UiClass.getUiBrowser().execute(`bwSetTime('${arguments[0]}');`);
        });

    mp.events.add("client.bw.toggleUi",
        function(state: boolean) {
            UiClass.getUiBrowser().execute(`bwToggle(${state});`);
        });
}