import * as UiClass from "./ui"

let penaltiesTimeout = null;

export function load(): void {
    mp.events.add("client.penalties.show",
        function(state: boolean, type: number, target: string, admin: string, reason: string, time: number) {
            if (state) {
                UiClass.getUiBrowser().execute(`updatePenalty(${type},"${target}","${admin}","${reason}",${time});`);
                UiClass.getUiBrowser().execute(`penaltiesToggle(true);`);
                if (penaltiesTimeout != null) {
                    clearTimeout(penaltiesTimeout);
                    penaltiesTimeout = null;
                }
                penaltiesTimeout = setTimeout(function() {
                        UiClass.getUiBrowser().execute(`penaltiesToggle(false);`);
                        penaltiesTimeout = null;
                    },
                    10000);
            } else {
                UiClass.getUiBrowser().execute(`penaltiesToggle(false);`);
                if (penaltiesTimeout != null) {
                    clearTimeout(penaltiesTimeout);
                    penaltiesTimeout = null;
                }
            }
        });
}