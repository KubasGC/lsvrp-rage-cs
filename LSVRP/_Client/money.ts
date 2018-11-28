import * as Ui from "./ui"

export function load(): void {
    mp.events.add("client.money.update",
        function() {
            Ui.getUiBrowser().execute(`setMoney(${arguments[0]});`);
        });
}