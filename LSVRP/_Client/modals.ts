import * as UiClass from "./ui"

export function load(): void {
    mp.events.add("client.modal.createModal",
        function() {
            UiClass.getUiBrowser()
                .execute(
                    `ModalCreateList('${arguments[0]}', '${encodeURIComponent(arguments[1])}', '${arguments[2]}');`);
            mp.events.call("client.dialog.togglechat", true);
            mp.gui.cursor.visible = true;
        });
}