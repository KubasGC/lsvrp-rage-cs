import * as UiClass from "./ui"

export function load(): void {
    mp.events.add("client.offers.showOffer",
        function() {
            UiClass.getUiBrowser().execute(`CreateOffer('${arguments[0]}', '${arguments[1]}');`);
            mp.gui.cursor.visible = true;
        });

    mp.events.add("client.offers.hideOffer",
        function() {
            UiClass.getUiBrowser().execute(`HideOffer();`);
            mp.gui.cursor.visible = false;
        });
}