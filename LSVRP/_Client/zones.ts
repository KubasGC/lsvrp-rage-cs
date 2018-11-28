/// <reference path="@types/index.d.ts" />

import * as UiClass from "./ui"


export function load(): void {
    mp.events.add("client.zones.changeZone",
        function() {
            UiClass.getUiBrowser().execute(`setZone('${arguments[0]}');`);
        });
}