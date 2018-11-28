import * as Ui from "./ui"
import * as CefClass from "./cef"

export function load(): void {
    mp.events.add("client.radio.setMessage",
        function() {
            Ui.getUiBrowser()
                .execute(`setMessage('${arguments[0]}','${arguments[1]}','${arguments[2]}', ${arguments[3]});`);
            mp.game.audio.playSoundFrontend(0, "Beep_Red", "DLC_HEIST_HACKING_SNAKE_SOUNDS", true);
        });
}