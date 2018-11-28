/// <reference path="@types/index.d.ts" />

import * as UiClass from "./ui"
let AfkTime = 0;
let AfkStatus: boolean = false;

export function load(): void {
    mp.events.add("ui.afk.get",
        function() {
            const unix = Math.round(+new Date() / 1000);
            AfkTime = unix;
        });

    mp.events.add("ui.afk.set",
        function() {
            const unix = Math.round(+new Date() / 1000);
            if ((unix - AfkTime) > 120) {
                if (!AfkStatus) {
                    AfkStatus = true;
                    // mp.events.callRemote("ui.afk.send");
                }
            } else {
                if (AfkStatus) {
                    AfkStatus = false;
                    // mp.events.callRemote("ui.afk.send");
                }
            }
        });
}