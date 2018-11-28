/// <reference path="@types/index.d.ts" />

import * as Ui from "./ui"

export function load() {
    mp.events.add("ui.toggleduty",
        function(state: boolean) {
            if (state) {
                Ui.getUiBrowser().execute(`dutyToggle(true);`);
            } else {
                Ui.getUiBrowser().execute(`dutyToggle(false);`);
            }
        });

    mp.events.add("ui.updateduty",
        function(seconds) {
            Ui.getUiBrowser().execute(`setDuty(${seconds});`);
        });
}