/// <reference path="@types/index.d.ts" />
const timeOnServer = Math.floor(Date.now() / 1000);

export function load() {
    setInterval(function() {
            let time = Math.floor((Math.floor(Date.now() / 1000) - timeOnServer) / 60);
            let text = `${time} m`;
            if (time >= 60) {
                time = Math.floor(time / 60);
                text = `${time} h`;
            }
            mp.discord.update(`LSVRP 3.0α`, `Online od: ${text}`);
        },
        10000);
}