/// <reference path="@types/index.d.ts" />

import * as CameraManager from "./cameras"
import * as Ui from "./ui"

export function createBrowser(): void {
    CameraManager.toggleBlurEffect(true, 1000);
    mp.gui.cursor.visible = true;
    mp.gui.chat.activate(false);
    Ui.getNewUiBrowser().execute(`LoginShow();`);
    if (mp.storage.data.loginData != undefined) {
        Ui.getNewUiBrowser()
            .execute(`LoginFillForm('${mp.storage.data.loginData.username}', '${mp.storage.data.loginData
                .password}');`);
    }
    mp.game.graphics.setTimecycleModifierStrength(0.0);
}

export function createEvents(): void {
    mp.events.add("cef.login.TryLogin",
        function() {
            if (arguments[2] == true) {
                mp.storage.data.loginData = { username: arguments[0], password: arguments[1] };
            } else {
                if (mp.storage.data.loginData != undefined) {
                    delete mp.storage.data.loginData;
                }
            }
            mp.events.callRemote("server.login.OnPlayerTriedToLogin", arguments[0], arguments[1]);
        });

    mp.events.add("client.login.BadLogin",
        function() {
            Ui.getNewUiBrowser().execute("LoginUnlockButton();");
        });

    mp.events.add("client.login.LoginSuccess",
        function() {

            // loginBrowser.execute(`ShowCharList();`);
        });

    mp.events.add("client.login.nochars",
        function() {
            // loginBrowser.execute(`showNoCharInfo();`);
        });

    mp.events.add("client.choosechar.show",
        function(serializedCharacters: string, username: string) {

            Ui.getNewUiBrowser().execute(`LoginHide();`);
            Ui.getNewUiBrowser()
                .execute(
                    `DashboardShow('${encodeURIComponent(serializedCharacters)}', '${encodeURIComponent(username)}');`);

        });

    mp.events.add("cef.choosechar.characterChoosed",
        function(charId: number) {
            mp.events.callRemote("server.login.OnClientChooseCharacter", charId);
            Ui.getUiBrowser().execute(`moneyToggle(true);`);
            mp.players.local.freezePosition(false);
        });

    mp.events.add("client.choosechar.hideDashboard",
        function() {
            Ui.getNewUiBrowser().execute(`DashboardHide()`);
            mp.gui.cursor.visible = false;
            mp.gui.chat.activate(true);
        });

}