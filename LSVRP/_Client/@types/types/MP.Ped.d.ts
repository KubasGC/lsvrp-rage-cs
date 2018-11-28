/// <reference path="../index.d.ts" />

declare interface MpPed extends MpEntity {

}

declare interface MpPedPool extends MpPool<MpPed> {
    "new"(modelHash: string | number,
        position: MpVector3,
        heading: number,
        streamInEventHandler: (streamPed: MpPed) => void,
        dimension: number): MpPed;
}