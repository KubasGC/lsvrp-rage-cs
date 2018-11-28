/// <reference path="@types/index.d.ts" />

import * as CameraManager from "./cameras";
import toggleBlurEffect = CameraManager.toggleBlurEffect;

let uiBrowser: MpBrowser = null;
let newUiBrowser: MpBrowser = null;
let notificationBrowser: MpBrowser = null;

export function load(): void {
    uiBrowser = mp.browsers.new("package://LSVRP/UI/index.html");
    notificationBrowser = mp.browsers.new("package://LSVRP/Notifications/index.html");
    notificationBrowser.debug = true;

    newUiBrowser = mp.browsers.new("package://LSVRP/GUI/index.html");

    mp.events.add("client.ui.login",
        function() {
            mp.game.ui.displayRadar(true);
        });

    mp.events.add("client.ui.loader",
        function(state) {
            uiBrowser.execute(`ToggleLoader(${state});`);
        });

    mp.events.add("client.help.toggle",
        function() {
            getUiBrowser().execute("toggleHelp();");
        });

    mp.events.add("browserDomReady",
        function(browser: MpBrowser) {
            if (browser === uiBrowser) {
                toggleBlurEffect(true, 1000);
                mp.gui.cursor.visible = true;
                mp.gui.chat.activate(false);
                if (mp.storage.data.loginData != undefined) {
                    newUiBrowser.execute(
                        `LoginFillForm('${mp.storage.data.loginData.username}', '${mp.storage.data.loginData.password
                        }');`);
                }
                newUiBrowser.execute(`LoginShow();`);
                mp.game.graphics.setTimecycleModifierStrength(0.0);
            }
        });
}

export function getUiBrowser(): MpBrowser {
    return uiBrowser;
}

export function getNewUiBrowser(): MpBrowser {
    return newUiBrowser;

}

export function getNotificationBrowser(): MpBrowser {
    return notificationBrowser;
}