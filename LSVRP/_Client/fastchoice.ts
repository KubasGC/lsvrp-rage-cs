/// <reference path="@types/index.d.ts" />

import * as Ui from "./ui"
import * as SyncManager from "./syncManager"
import * as CefClass from "./cef"
import * as CharCreator from "./char-creator"

let fastChoice: boolean = false;

export function load() {
    mp.events.add("fc.vehicles",
        function() {
            mp.events.callRemote("server.fc.vehicles");
            fastChoice = false;
        });
    mp.events.add("fc.groups",
        function() {
            mp.events.callRemote("server.fc.groups");
            fastChoice = false;
        });
    mp.events.add("fc.phone",
        function() {
            mp.events.callRemote("server.fc.phone");
            fastChoice = false;
        });
    mp.events.add("fc.stats",
        function() {
            mp.events.callRemote("server.fc.stats");
            fastChoice = false;
        });
    mp.events.add("fc.clothes",
        function() {
            mp.events.callRemote("server.fc.clothes");
            fastChoice = false;
        });
    mp.events.add("fc.desc",
        function() {
            mp.events.callRemote("server.fc.desc");
            fastChoice = false;
        });
    mp.events.add("fc.toggle",
        function() {
            if (!fastChoice) {
                Ui.getUiBrowser().execute(`fastChoiceToggle(true);`);

                fastChoice = true;
            } else {
                Ui.getUiBrowser().execute(`fastChoiceToggle(false);`);

                fastChoice = false;
            }
        });

    mp.events.add("fc.showmouse",
        function() {
            mp.gui.cursor.visible = true;
        });

    mp.events.add("fc.hidemouse",
        function() {
            mp.gui.cursor.visible = false;
        });

    /*mp.keys.bind(0x26, false, function() {
        let logged = SyncManager.GetPlayerData(mp.players.local, "player.isLogged");
        if(logged && !CefClass.getChatFocused())
        {
            mp.events.call("fc.toggle");
        }
    });*/

}