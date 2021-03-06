/// <reference path="../index.d.ts" />

declare interface MpGameStreaming {
    removeClipSet(clipSet: string): void;
    requestCollisionAtCoord(x: number, y: number, z: number): object;
    removeAnimSet(animSet: string): void;
    isModelAVehicle(model: number | string): boolean;
    newLoadSceneStart(p0: number,
        p1: number,
        p2: number,
        p3: number,
        p4: number,
        p5: number,
        p6: number,
        p7: object): boolean;
    setUnkCameraSettings(x: number, y: number, z: number, rad: number, p4: object, p5: object): object;
    hasCollisionForModelLoaded(model: number | string): boolean;
    doesAnimDictExist(animDict: string): boolean;
    hasClipSetLoaded(clipSet: string): boolean;
    isModelInCdimage(model: number | string): boolean;
    prefetchSrl(p0: object): void;
    requestIpl(iplName: string): void;
    setDitchPoliceModels(toggle: boolean): void;
    loadScene(x: number, y: number, z: number): void;
    removeNamedPtfxAsset(fxName: string): void;
    setStreaming(toggle: boolean): void;
    requestAnimSet(animSet: string): void;
    setGamePausesForStreaming(toggle: boolean): void;
    setReducePedModelBudget(toggle: boolean): void;
    setReduceVehicleModelBudget(toggle: boolean): void;
    hasNamedPtfxAssetLoaded(fxName: string): boolean;
    isIplActive(iplName: string): boolean;
    setPedPopulationBudget(p0: number): void;
    requestCollisionForModel(model: number | string): void;
    requestModel(model: number | string, cb?: Function): void;
    hasModelLoaded(model: number | string): boolean;
    requestModel2(model: number | string): void;
    setSrlTime(p0: number): void;
    newLoadSceneStartSafe(p0: number, p1: number, p2: number, p3: number, p4: object): boolean;
    getIdealPlayerSwitchType(x1: number, y1: number, z1: number, x2: number, y2: number, z2: number): number;
    requestNamedPtfxAsset(fxName: string): void;
    setHdArea(x: number, y: number, z: number, ground: number): void;
    setFocusArea(x: number, y: number, z: number, offsetX: number, offsetY: number, offsetZ: number): void;
    isModelValid(model: number | string): boolean;
    setPlayerSwitchLocation(p0: number,
        p1: number,
        p2: number,
        p3: number,
        p4: number,
        p5: number,
        p6: number,
        p7: number,
        p8: object): void;
    hasAnimSetLoaded(animSet: string): boolean;
    requestAdditionalCollisionAtCoord(p0: number, p1: number, p2: number): void;
    setVehiclePopulationBudget(p0: number): void;
    hasAnimDictLoaded(animDict: string): boolean;
    requestClipSet(clipSet: string): void;
    requestAnimDict(animDict: string): void;
    setInteriorActive(interiorID: number, toggle: boolean): void;
    setModelAsNoLongerNeeded(model: number | string): void;
    removeIpl(iplName: string): void;
    removeAnimDict(animDict: string): void;
    startPlayerSwitch(from: MpPed | object, to: MpPed | object, flags: number, switchType: number): void;
}