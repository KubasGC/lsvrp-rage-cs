const MUGSHOT = {
    boardPropName: "prop_police_id_board",
    textPropName: "prop_police_id_text",
    renderTargetName: "ID_Text",
    animDictionary: "mp_character_creation@lineup@male_a",
    animName: "loop_raised"
};

export interface MugshotInfo {
    title: string;
    top: string;
    middle: string;
    bottom: string;
}

var boardHandle: MpObject = null;
var textHandle: MpObject = null;

var scaleformHandle: number = null;
var renderTargetId: number = null;

/**
 * mugshotRequestedHandler
 */
let mugshotRequestedHandler = (player: MpPlayer, info: MugshotInfo) => {
    if (this.boardHandle == null) {
        // create props
        this.boardHandle = mp.objects.new(
            mp.game.joaat(MUGSHOT.boardPropName),
            player.position,
            { rotation: player.getRotation(2), alpha: 255, dimension: 0 }
        );

        this.textHandle = mp.objects.new(
            mp.game.joaat(MUGSHOT.textPropName),
            player.position,
            { rotation: player.getRotation(2), alpha: 255, dimension: 0 }
        );

        // load scaleform & set up the content
        this.scaleformHandle = mp.game.graphics.requestScaleformMovie("mugshot_board_01");
        var scaleformInterval = setInterval(() => {
            if (mp.game.graphics.hasScaleformMovieLoaded(this.scaleformHandle)) {
                mp.game.graphics.pushScaleformMovieFunction(this.scaleformHandle, "SET_BOARD");
                mp.game.graphics.pushScaleformMovieFunctionParameterString(info.title);
                mp.game.graphics.pushScaleformMovieFunctionParameterString(info.middle);
                mp.game.graphics.pushScaleformMovieFunctionParameterString(info.bottom);
                mp.game.graphics.pushScaleformMovieFunctionParameterString(info.top);
                mp.game.graphics.pushScaleformMovieFunctionParameterInt(0);
                mp.game.graphics.popScaleformMovieFunctionVoid();
                // set up rendertarget
                mp.game.ui.registerNamedRendertarget(MUGSHOT.renderTargetName, false);
                mp.game.ui.linkNamedRendertarget(mp.game.joaat(MUGSHOT.textPropName));
                this.renderTargetId = mp.game.ui.getNamedRendertargetRenderId(MUGSHOT.renderTargetName);

                // attach to the player
                this.boardHandle.attachTo(player.handle,
                    player.getBoneIndex(28422),
                    0.0,
                    0.0,
                    0.0,
                    0.0,
                    0.0,
                    0.0,
                    false,
                    false,
                    false,
                    false,
                    2,
                    true);
                this.textHandle.attachTo(player.handle,
                    player.getBoneIndex(28422),
                    0.0,
                    0.0,
                    0.0,
                    0.0,
                    0.0,
                    0.0,
                    false,
                    false,
                    false,
                    false,
                    2,
                    true);
                clearInterval(scaleformInterval);
            }
        }, 5);

        mp.game.streaming.requestAnimDict(MUGSHOT.animDictionary);
        var animInterval = setInterval(() => {
            if (mp.game.streaming.hasAnimDictLoaded(MUGSHOT.animDictionary)) {
                player.taskPlayAnim(MUGSHOT.animDictionary,
                    MUGSHOT.animName,
                    8.0,
                    -8.0,
                    -1,
                    1,
                    0.0,
                    false,
                    false,
                    false);
                clearInterval(animInterval);
            }
        }, 5);
    }
};

let mugshotDestroyRequestedHandler = (player: MpPlayer) => {
    if (this.boardHandle != null)
        this.boardHandle.destroy();
    if (this.textHandle != null)
        this.textHandle.destroy();
    if (this.scaleformHandle != null)
        mp.game.graphics.setScaleformMovieAsNoLongerNeeded(this.scaleformHandle);
    if (this.renderTargetId != null) {
        // should be renderTargetName string but says "expected Number", whatever
        mp.game.ui.releaseNamedRendertarget(mp.game.joaat(MUGSHOT.renderTargetName));
    }
    this.boardHandle = null;
    this.textHandle = null;
    this.scaleformHandle = null;
    this.renderTargetId = null;

    player.stopAnimTask(MUGSHOT.animDictionary, MUGSHOT.animName, -4.0);

    if (mp.game.streaming.hasAnimDictLoaded(MUGSHOT.animDictionary))
        mp.game.streaming.removeAnimDict(MUGSHOT.animDictionary);

};

let renderHandler = (...args: any[]) => {
    if (this.scaleformHandle != null && this.renderTargetId != null) {
        mp.game.ui.setTextRenderId(this.renderTargetId);
        mp.game.graphics.drawScaleformMovie(this.scaleformHandle, 0.405, 0.37, 0.81, 0.74, 255, 255, 255, 255, 0);
        mp.game.ui.setTextRenderId(1);
    }
};

export function load(): void {
    mp.events.add('client.mugshot.add',
        (...args: any[]) => {
            const info: MugshotInfo = {
                title: args[0].toString(),
                top: args[1].toString(),
                middle: args[2].toString(),
                bottom: args[3].toString(),
            };
            addMugshot(mp.players.local, info);
        });

    mp.events.add('client.mugshot.destroy',
        (...args: any[]) => {
            destroyMugshot(mp.players.local);
        });
}

export function addMugshot(player: MpPlayer, info: MugshotInfo) {
    mugshotRequestedHandler(player, info);
    mp.events.add('render', renderHandler);
}

export function destroyMugshot(player: MpPlayer) {
    mugshotDestroyRequestedHandler(player);
    mp.events.remove('render', renderHandler);
}