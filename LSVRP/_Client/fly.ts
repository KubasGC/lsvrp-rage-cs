/// <reference path="@types/index.d.ts" />

import * as Cameras from "./cameras";

// we create new camera instead of using default one to prevent character free fall in space, and to make player collisionless
let flyCamera: MpCamera = null;

let freeCamHandler = () => {
    var defaultCamera = mp.cameras.at(2);
    var defaultCameraRotation = mp.game.cam.getGameplayCamRot(2);
    // set camera rotation from mouse
    flyCamera.setRot(defaultCameraRotation.x, defaultCameraRotation.y, defaultCameraRotation.z, 2);
    // getting coords once is cheaper
    var flyCameraCoord = flyCamera.getCoord();

    mp.players.local.position = new mp.Vector3(flyCameraCoord.x, flyCameraCoord.y, flyCameraCoord.z);
    mp.players.local.setRotation(defaultCameraRotation.x, defaultCameraRotation.y, defaultCameraRotation.z, 2, true);

    var speed = 1.5;
    if (mp.keys.isDown(16)) { /* Left Shift */
        speed = 7; // faster
    } else if (mp.keys.isDown(17)) { /* Left Ctrl */
        speed = 0.75; // slower
    }

    var oldPosition = flyCamera.getCoord();
    var defaultCameraDirection = defaultCamera.getDirection();

    if (mp.keys.isDown(87)) { // w
        // set new coords where default camera points
        flyCamera.setCoord(
            oldPosition.x + defaultCameraDirection.x * speed,
            oldPosition.y + defaultCameraDirection.y * speed,
            oldPosition.z + defaultCameraDirection.z * speed
        );
    }
};

let setCamera = () => {
    flyCamera = mp.cameras.new("flyCamera");

    flyCamera.setCoord(
        mp.players.local.position.x,
        mp.players.local.position.y,
        mp.players.local.position.z
    );

    flyCamera.setActive(true);
    mp.game.cam.renderScriptCams(false, false, 0, true, true);

    mp.events.add('render', freeCamHandler);
};

/**
 * destroy the free camera
 */
let destroy = () => {
    mp.events.remove('render', freeCamHandler);

    flyCamera.destroy();
    flyCamera = null;

    Cameras.resetCamera();
};

export function load() {
    mp.events.add("client.fly.on",
        () => {
            setCamera();
        });
    mp.events.add("client.fly.off",
        () => {
            destroy();
        });
}