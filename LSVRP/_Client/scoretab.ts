import * as Ui from "./ui"
import * as CefClass from "./cef"

export function load(): void {
    let scoretab: boolean = false;
    mp.events.add("client.scoretab.show",
        function() {
            if (!scoretab) {
                Ui.getUiBrowser().execute(`loadPlayersList('${arguments[0]}');`);
                Ui.getUiBrowser().execute(`playersListToggle(true);`);
                mp.gui.cursor.visible = true;
                scoretab = true;
            } else {
                Ui.getUiBrowser().execute(`playersListToggle(false);`);
                mp.gui.cursor.visible = false;
                scoretab = false;
            }

        });

    mp.keys.bind(0x71,
        false,
        function() {
            if (!CefClass.getChatFocused()) {
                mp.events.callRemote("server.scoretab.pressed");
            }
        });
}