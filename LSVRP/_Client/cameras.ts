/// <reference path="@types/index.d.ts" />
let mainCamera: MpCamera = null;

export function init(): void {
    mainCamera = mp.cameras.new("default", new mp.Vector3(0, 0, 0), new mp.Vector3(0, 0, 0), 90.0);
}

export function setCamera(pos: MpVector3, head: MpVector3): void {
    mainCamera.setCoord(pos.x, pos.y, pos.z);
    mainCamera.pointAtCoord(head.x, head.y, head.z);
    mainCamera.setMotionBlurStrength(10.0);
    mainCamera.setActive(true);
    mainCamera.setFov(90);
    mp.game.cam.renderScriptCams(true, false, 0, true, false);
}

export function resetCamera(): void {
    mp.game.cam.renderScriptCams(false, false, 0, true, false);
}

export function createEvents(): void {
    mp.events.add("client.cameras.reset",
        function() {
            resetCamera();
        });
    mp.events.add("client.cameras.toggleblur",
        function() {
            toggleBlurEffect(arguments[0], arguments[1]);
        });
    mp.events.add("client.cameras.set",
        function(x: number, y: number, z: number, x1: number, y1: number, z1: number) {
            setCamera(new mp.Vector3(x, y, z), new mp.Vector3(x1, y1, z1));
        });
}

export function toggleBlurEffect(toggle: boolean, time: number) {
    if (toggle) {
        mp.game.graphics.transitionToBlurred(time);
    } else {
        mp.game.graphics.transitionFromBlurred(time);
    }

}