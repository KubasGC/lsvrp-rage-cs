export function load(): void {
    mp.events.add("client.gov.loadbot",
        function(position: MpVector3, dimension: number) {
            const oldPed =
                mp.game.ped.getRandomPedAtCoord(247.1038360595703, 225.0289764404297, 106.28755187988281, 1, 1, 1, -1);
            if (oldPed.handle != null) {
                oldPed.destroy();
            }
            const Ped = mp.peds.new(mp.game.joaat('a_f_y_bevhills_01'),
                new mp.Vector3(247.1038360595703, 225.0289764404297, 106.28755187988281),
                158.0,
                (streamPed) => {
                    streamPed.setAlpha(0);
                },
                6);
        });
}