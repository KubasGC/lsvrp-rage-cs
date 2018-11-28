import * as UiClass from "./ui"

let GasPumpModels = [
    1339433404,
    1933174915,
    -2007231801,
    -462817101,
    -469694731,
    1694452750
];

export function doesPlayerHasNearestPumpObject(): boolean {
    const localPlayer = mp.players.local;
    const pos = localPlayer.position;
    for (let i = 0; i < GasPumpModels.length; i++) {
        const object =
            mp.game.object.getClosestObjectOfType(pos.x, pos.y, pos.z, 5.0, GasPumpModels[i], false, true, true);
        if (object.toString() != "0") {
            return true;
        }
    }
    return false;
}

export function load(): void {
    mp.events.add("clgascommand",
        function() {
            if (!doesPlayerHasNearestPumpObject()) {
                // mp.events.call("client.ui.showNotification", "Nie znajdujesz się przy dystrybutorze.", 2);
                mp.gui.chat.push("Nie znajdujesz się przy dystrybutorze.");
                return;
            }

            UiClass.getUiBrowser().execute(`gasSetMaxValue(${parseInt(arguments[0].toString())});`);
            UiClass.getUiBrowser().execute(`gasPumpToggle(true);`);
            mp.gui.cursor.visible = true;

        });

    mp.events.add("client.gasstations.check",
        function() {
            const localPlayer = mp.players.local;
            const pos = localPlayer.position;
            for (let i = 0; i < GasPumpModels.length; i++) {
                const object =
                    mp.game.object.getClosestObjectOfType(pos.x,
                        pos.y,
                        pos.z,
                        5.0,
                        GasPumpModels[i],
                        false,
                        true,
                        true);
                if (object.toString() != "0") {
                    mp.events.callRemote("server.gasstations.response", true);
                    return;
                }
            }
            mp.events.callRemote("server.gasstations.response", false);
        });

    mp.events.add("client.gasstations.start",
        function() {
            UiClass.getUiBrowser().execute(`gasSetMaxValue(${Number(arguments[0])});`);
            UiClass.getUiBrowser().execute(`gasPumpToggle(true);`);
            mp.gui.cursor.visible = true;
        });

    mp.events.add("client.gasstations.hide",
        function() {
            hideGasPump();
        });

    mp.events.add("client.gasstations.pay",
        function(fuel: number, cash: number) {
            mp.events.callRemote("server.gas.offer", parseInt(fuel.toString()), parseInt(cash.toString()));
            hideGasPump();
        });

}

export function hideGasPump(): void {
    UiClass.getUiBrowser().execute(`gasPumpToggle(false);`);
    UiClass.getUiBrowser().execute('resetPump()');
    mp.gui.cursor.visible = false;
}