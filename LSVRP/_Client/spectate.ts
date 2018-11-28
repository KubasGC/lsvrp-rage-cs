import * as Ui from "./ui"
import * as CefClass from "./cef"
import * as SyncManager from "./syncManager"

let specCamera: MpCamera = null;
let spectatedPlayer: MpPlayer = null;
let specId: number = null;

export function load(): void {
    const scoretab: boolean = false;
    mp.events.add("client.spectate.player",
        function(remoteId: number) {
            const target = mp.players.atRemoteId(remoteId);
            specId = target.id;
            spectatedPlayer = target;
            mp.players.local.attachTo(target.handle, 31086, 0, 0, 0, 0, 0, 0, true, true, false, true, 0, false);
        });

    mp.events.add("client.spectate.off",
        function() {
            spectatedPlayer = null;
            specId = null;
            mp.players.local.detach(true, true);
        });

    mp.events.add("render",
        function() {
            if (spectatedPlayer == null) {
                return;
            }

            if (mp.players.exists(spectatedPlayer) && spectatedPlayer != null && !spectatedPlayer.vehicle) {
                if (spectatedPlayer.dimension != mp.players.local.dimension) {
                    mp.players.local.dimension = spectatedPlayer.dimension;
                }
                mp.players.local.attachTo(spectatedPlayer.handle,
                    31086,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    true,
                    true,
                    false,
                    true,
                    0,
                    false);
            } else if (mp.players.exists(spectatedPlayer) && spectatedPlayer != null) {
                if (spectatedPlayer.dimension != mp.players.local.dimension) {
                    mp.players.local.dimension = spectatedPlayer.dimension;
                }
                mp.players.local.attachTo(spectatedPlayer.handle,
                    31086,
                    1,
                    -2,
                    1.5,
                    0,
                    0,
                    0,
                    true,
                    true,
                    false,
                    true,
                    0,
                    false);
            }
        });
}