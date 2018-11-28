/// <reference path="../index.d.ts" />

declare interface MpMarker extends MpEntity {
    setColor(r: number, g: number, b: number, a: number)
}

declare interface MpMarkerPool extends MpPool<MpMarker> {
    "new"(type: number,
        position: MpVector3,
        scale: number,
        options?: {
            color: [number, number, number, number];
        }): MpMarker;
}