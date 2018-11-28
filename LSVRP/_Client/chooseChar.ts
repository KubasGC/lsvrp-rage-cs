/// <reference path="@types/index.d.ts" />

let chooseCharBrowser: MpBrowser = null;
let characters: string = null;

export function createBrowser(): void {
    destroyBrowser();
    chooseCharBrowser = mp.browsers.new("package://LSVRP/CEF/Pages/CharactersChoose.html");
    mp.gui.cursor.visible = true;
    mp.gui.chat.activate(true);
}

export function destroyBrowser(): void {
    if (chooseCharBrowser != null) {
        mp.browsers.exists(chooseCharBrowser);
        chooseCharBrowser.destroy();
        chooseCharBrowser = null;

        mp.gui.cursor.visible = false;
        mp.gui.chat.activate(true);
    }
}