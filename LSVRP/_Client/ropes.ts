
let testRope: MpObject | object = null;

export function load(): void {

    mp.events.add("TestRope",
        function() {
            mp.gui.chat.push("TESTOWA LINA");
            if (testRope !== null) {
                mp.game.rope.deleteRope(testRope);
            }

            const player = mp.players.local;

            testRope = mp.game.rope.addRope(player.position.x,
                player.position.y,
                player.position.z,
                0,
                0,
                0,
                20.0,
                5,
                20.0,
                5.0,
                0,
                false,
                false,
                false,
                5.0,
                false,
                0);
            mp.gui.chat.push(`Lina: ${testRope}`);
            mp.game.rope.attachRopeToEntity(testRope,
                player,
                player.position.x,
                player.position.y,
                player.position.z,
                0);
        });
}