/// <reference path="@types/index.d.ts" />

import * as UiClass from "./ui"
import * as CefClass from "./cef"

export let playerDialogId = -1;
let playerDialogType = -1;

export function load(): void {
    mp.events.add("cef.dialog.responseToServer",
        function(data: any, button: number) {
            mp.gui.cursor.visible = false;
            CefClass.blockChat(false);
            mp.events.callRemote("server.modal.getData", playerDialogId, data, playerDialogType, button);

            playerDialogId = -1;
            playerDialogType = -1;
        });

    mp.events.add("client.dialog.create",
        function(dialogId: number, title: string, subtitle: string, data: string, dialogType: number) {
            UiClass.getUiBrowser()
                .execute(`modalListLoad('${title}', '${subtitle}', '${encodeURIComponent(data)}', '${dialogType}');`);
            UiClass.getUiBrowser().execute('modalListToggle(true);');
            playerDialogId = dialogId;
            playerDialogType = dialogType;
            mp.gui.cursor.visible = true;
            CefClass.blockChat(true);
        });

    mp.events.add("client.dialog.new.create",
        function(dialogId: number, title: string, dialogColumns: string, dialogRows: string, dialogButtons: string) {
            UiClass.getNewUiBrowser()
                .execute(
                    `LoadModal('${addslashes(title)}', '${addslashes(encodeURIComponent(dialogColumns))}', '${
                    addslashes(encodeURIComponent(dialogRows))}', '${encodeURIComponent(dialogButtons)}');`);

            playerDialogId = dialogId;
            playerDialogType = 1;
            mp.gui.cursor.visible = true;
            CefClass.blockChat(true);

        });

    mp.events.add("client.dialog.new.text.create",
        function(dialogId: number, title: string, desc: string, startVal: string, dialogButtons: string) {

            UiClass.getNewUiBrowser()
                .execute(
                    `LoadEnterText('${title}', '${desc}', '${startVal}', '${encodeURIComponent(dialogButtons)}');`);
            playerDialogId = dialogId;
            playerDialogType = 2;
            mp.gui.cursor.visible = true;
            CefClass.blockChat(true);
        });

    mp.events.add("client.dialog.new.info.create",
        function(dialogId: number, title: string, desc: string, dialogButtons: string) {

            UiClass.getNewUiBrowser()
                .execute(`Modal_LoadInfo('${title}', '${desc}', '${encodeURIComponent(dialogButtons)}');`);
            playerDialogId = dialogId;
            playerDialogType = 3;
            mp.gui.cursor.visible = true;
            CefClass.blockChat(true);
        });

    mp.events.add("client.dialog.togglechat",
        function(state: boolean) {
            CefClass.blockChat(state);
        });
}

function escapeHtml(text) {
    const map = {
        '"': '&quot;',
        "'": '&#039;',
        "`": '&#96;'
    };

    return text.replace(/["'`]/g,
        function(m) {
            return map[m];
        });
}

function addslashes(str) {
    str = str.replace(/\\/g, '\\\\');
    str = str.replace(/\'/g, '\\\'');
    str = str.replace(/\"/g, '\\"');
    str = str.replace(/\0/g, '\\0');
    return str;
}