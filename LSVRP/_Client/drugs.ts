export function load() {
    mp.events.add("client.drugs.startEffect",
        function(effectName: string) {
            mp.game.graphics.startScreenEffect(effectName, 0, true);
        });

    mp.events.add("client.drugs.stopEffect",
        function(effectName: string) {
            mp.game.graphics.stopScreenEffect(effectName);
        });
}