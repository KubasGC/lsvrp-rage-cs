/// <reference path="../index.d.ts" />

declare interface MpGameGraphics {
    notify(text: any): any;
    drawText(text: string,
        position: [number, number] | [number, number, number],
        options?: {
            font?: number,
            color?: [number, number, number, number],
            scale?: [number, number],
            outline?: boolean;
        });
    drawText3d(text: any,
        pos: any,
        rotation: any,
        scale: any,
        r: any,
        g: any,
        b: any,
        a: any,
        initialOffsetScaled: any): any; //TODO: Missing documentation
    getSafeZoneSize(): any; //TODO Missing documentation
    createCheckpoint(type: number,
        posX1: number,
        posY1: number,
        posZ1: number,
        posX2: number,
        posY2: number,
        posZ2: number,
        radius: number,
        colorR: number,
        colorG: number,
        colorB: number,
        alpha: number,
        reserved: number): number;
    hasStreamedTextureDictLoaded(textureDict: string): boolean;
    stopScreenEffect(effectName: string): void;
    drawDebugBox(x1: number,
        y1: number,
        z1: number,
        x2: number,
        y2: number,
        z2: number,
        r: number,
        g: number,
        b: number,
        alpha: number): void;
    setFlash(p0: number, p1: number, fadeIn: number, duration: number, fadeOut: number): void;
    loadTvChannel(tvChannel: number | string): boolean;
    hasNamedScaleformMovieLoaded(scaleformName: string): boolean;
    startParticleFxNonLoopedOnEntity(effectName: string,
        entity: MpEntity | object,
        offsetX: number,
        offsetY: number,
        offsetZ: number,
        rotX: number,
        rotY: number,
        rotZ: number,
        scale: number,
        axisX: boolean,
        axisY: boolean,
        axisZ: boolean): boolean;
    drawScaleformMovieFullscreen(scaleform: number,
        red: number,
        green: number,
        blue: number,
        alpha: number,
        unk: boolean): void;
    startParticleFxNonLoopedOnPedBone(effectName: string,
        ped: MpPed | object,
        offsetX: number,
        offsetY: number,
        offsetZ: number,
        rotX: number,
        rotY: number,
        rotZ: number,
        boneIndex: number,
        scale: number,
        axisX: boolean,
        axisY: boolean,
        axisZ: boolean): boolean;
    setTvAudioFrontend(toggle: boolean): void;
    requestScaleformMovie(scaleformName: string): number;
    setBlackout(enable: boolean): void;
    setTrackedPointInfo(point: MpObject | object, x: number, y: number, z: number, radius: number): object;
    setDebugLinesAndSpheresDrawingActive(enabled: boolean): void;
    setNightvision(toggle: boolean): void;
    startParticleFxLoopedOnEntity(effectName: string,
        entity: MpEntity | object,
        xOffset: number,
        yOffset: number,
        zOffset: number,
        xRot: number,
        yRot: number,
        zRot: number,
        scale: number,
        xAxis: boolean,
        yAxis: boolean,
        zAxis: boolean): number;
    drawScaleformMovie3dNonAdditive(scaleform: number,
        posX: number,
        posY: number,
        posZ: number,
        rotX: number,
        rotY: number,
        rotZ: number,
        p7: number,
        p8: number,
        p9: number,
        scaleX: number,
        scaleY: number,
        scaleZ: number,
        p13: object): void;
    setScaleformMovieAsNoLongerNeeded(scaleformHandle: number): number;
    startScreenEffect(effectName: string, duration: number, looped: boolean): void;
    startParticleFxNonLoopedAtCoord(effectName: string,
        xPos: number,
        yPos: number,
        zPos: number,
        xRot: number,
        yRot: number,
        zRot: number,
        scale: number,
        xAxis: boolean,
        yAxis: boolean,
        zAxis: boolean): boolean;
    setParticleFxNonLoopedColour(r: number, g: number, b: number): void;
    drawMarker(type: number,
        posX: number,
        posY: number,
        posZ: number,
        dirX: number,
        dirY: number,
        dirZ: number,
        rotX: number,
        rotY: number,
        rotZ: number,
        scaleX: number,
        scaleY: number,
        scaleZ: number,
        colorR: number,
        colorG: number,
        colorB: number,
        alpha: number,
        bobUpAndDown: boolean,
        faceCamera: boolean,
        p19: number,
        rotate: boolean,
        textureDict: string,
        textureName: string,
        drawOnEnts: boolean): void;
    setTvVolume(volume: number): void;
    setTimecycleModifier(modifierName: string): void;
    getDecalWashLevel(decal: number): number;
    world3dToScreen2d(worldX: number, worldY: number, worldZ: number): {
        readonly x: number;
        readonly y: number;
    };
    screen2dToWorld3d(x: number, y: number, test: boolean): {
        readonly x: number;
        readonly y: number,
        readonly z: number;
    };
    getTextureResolution(textureDict: string, textureName: string): MpVector3;
    getScreenEffectIsActive(effectName: string): number;
    drawDebugText(text: string, x: number, y: number, z: number, r: number, g: number, b: number, alpha: number): void;
    drawRect(x: number, y: number, width: number, height: number, r: number, g: number, b: number, a: number): void;
    setTransitionTimecycleModifier(modifierName: string, transition: number): void;
    setForceVehicleTrails(toggle: boolean): void;
    addPetrolDecal(x: number, y: number, z: number, groundLvl: number, width: number, transparency: number): object;
    callScaleformMovieFunctionStringParams(scaleform: number,
        functionName: string,
        param1: string,
        param2: string,
        param3: string,
        param4: string,
        param5: string): void;
    drawScaleformMovie(scaleformHandle: number,
        x: number,
        y: number,
        width: number,
        height: number,
        red: number,
        green: number,
        blue: number,
        alpha: number,
        p9: number): void;
    drawSpotLightWithShadow(posX: number,
        posY: number,
        posZ: number,
        dirX: number,
        dirY: number,
        dirZ: number,
        colorR: number,
        colorG: number,
        colorB: number,
        distance: number,
        brightness: number,
        roundness: number,
        radius: number,
        falloff: number,
        shadow: number): void;
    removeDecalsInRange(x: number, y: number, z: number, range: number): void;
    setParticleFxLoopedEvolution(ptfxHandle: number, propertyName: string, amount: number, Id: boolean): void;
    setParticleFxBloodScale(p0: boolean): void;
    set2dLayer(layer: number): void;
    drawLine(x1: number,
        y1: number,
        z1: number,
        x2: number,
        y2: number,
        z2: number,
        r: number,
        g: number,
        b: number,
        alpha: number): void;
    setPtfxAssetNextCall(name: string): void;
    setScaleformMovieToUseSystemTime(scaleform: number, toggle: boolean): void;
    startParticleFxLoopedOnEntity2(effectName: string,
        entity: MpEntity | object,
        xOffset: number,
        yOffset: number,
        zOffset: number,
        xRot: number,
        yRot: number,
        zRot: number,
        scale: number,
        xAxis: boolean,
        yAxis: boolean,
        zAxis: boolean): number;
    setParticleFxLoopedAlpha(ptfxHandle: number, alpha: number): void;
    drawDebugCross(x: number, y: number, z: number, size: number, r: number, g: number, b: number, alpha: number): void;
    doesParticleFxLoopedExist(ptfxHandle: number): boolean;
    setParticleFxNonLoopedAlpha(alpha: number): void;
    setSeethrough(toggle: boolean): void;
    setParticleFxLoopedColour(ptfxHandle: number, r: number, g: number, b: number, p4: boolean): void;
    drawDebugLine(x1: number,
        y1: number,
        z1: number,
        x2: number,
        y2: number,
        z2: number,
        r: number,
        g: number,
        b: number,
        alpha: number): void;
    beginTextComponent(componentType: string): void;
    setFarShadowsSuppressed(toggle: boolean): void;
    hasScaleformContainerMovieLoadedIntoParent(scaleformHandle: number): boolean;
    setTimecycleModifierStrength(strength: number): void;
    moveVehicleDecals(p0: object, p1: object): void;
    hasScaleformMovieLoaded(scaleformHandle: number): boolean;
    getScreenActiveResolution(x: number, y: number): {
        readonly x: number;
        readonly y: number;
    };
    enableMovieSubtitles(toggle: boolean): void;
    drawScaleformMovie3d(scaleform: number,
        posX: number,
        posY: number,
        posZ: number,
        rotX: number,
        rotY: number,
        rotZ: number,
        p7: number,
        p8: number,
        p9: number,
        scaleX: number,
        scaleY: number,
        scaleZ: number,
        p13: object): void;
    getScreenResolution(x: number, y: number): {
        readonly x: number;
        readonly y: number;
    };
    stopParticleFxLooped(ptfxHandle: number, p1: boolean): void;
    requestHudScaleform(hudComponent: number): void;
    setParticleFxShootoutBoat(p0: object): void;
    pushScaleformMovieFunctionFromHudComponent(hudComponent: number, functionName: string): boolean;
    washDecalsInRange(p0: object, p1: object, p2: object, p3: object, p4: object): void;
    enableAlienBloodVfx(toggle: boolean): void;
    transitionToBlurred(transitionTime: number): boolean;
    drawDebugText2d(text: string,
        x: number,
        y: number,
        z: number,
        r: number,
        g: number,
        b: number,
        alpha: number): void;
    startParticleFxNonLoopedOnPedBone2(effectName: string,
        ped: MpPed | object,
        offsetX: number,
        offsetY: number,
        offsetZ: number,
        rotX: number,
        rotY: number,
        rotZ: number,
        boneIndex: number,
        scale: number,
        axisX: boolean,
        axisY: boolean,
        axisZ: boolean): boolean;
    removeDecalsFromObjectFacing(obj: MpObject | object, x: number, y: number, z: number): void;
    setDrawOrigin(x: number, y: number, z: number, p3: object): void;
    drawDebugSphere(x: number,
        y: number,
        z: number,
        radius: number,
        r: number,
        g: number,
        b: number,
        alpha: number): void;
    pushScaleformMovieFunctionN(functionName: string): boolean;
    drawPoly(x1: number,
        y1: number,
        z1: number,
        x2: number,
        y2: number,
        z2: number,
        x3: number,
        y3: number,
        z3: number,
        r: number,
        g: number,
        b: number,
        alpha: number): void;
    setParticleFxCamInsideNonplayerVehicle(p0: object, p1: boolean): void;
    setForcePedFootstepsTracks(toggle: boolean): void;
    destroyTrackedPoint(point: MpObject | object): void;
    addDecal(p0: number,
        p1: number,
        p2: number,
        p3: number,
        p4: number,
        p5: number,
        p6: number,
        p7: number,
        p8: number,
        p9: number,
        p10: number,
        p11: number,
        p12: number,
        p13: number,
        p14: number,
        p15: number,
        p16: number,
        p17: boolean,
        p18: boolean,
        p19: boolean): number;
    setParticleFxLoopedScale(ptfxHandle: number, scale: number): void;
    loadMovieMeshSet(movieMeshSetName: string): number;
    setScreenDrawPosition(x: number, y: number): void;
    pushScaleformMovieFunctionParameterString(value: string): void;
    setTvChannel(channel: number): void;
    requestScaleformMovie3(scaleformName: string): number;
    setStreamedTextureDictAsNoLongerNeeded(textureDict: string): void;
    pushScaleformMovieFunctionParameterInt(value: number): void;
    popScaleformMovieFunctionVoid(): void;
    removeParticleFx(ptfxHandle: number, p1: boolean): void;
    isTrackedPointVisible(point: MpObject | object): boolean;
    requestScaleformMovieInstance(scaleformName: string): number;
    pushScaleformMovieFunctionParameterBool(value: boolean): void;
    isDecalAlive(decal: number): boolean;
    startParticleFxLoopedOnEntityBone(effectName: string,
        entity: MpEntity | object,
        xOffset: number,
        yOffset: number,
        zOffset: number,
        xRot: number,
        yRot: number,
        zRot: number,
        boneIndex: number,
        scale: number,
        xAxis: boolean,
        yAxis: boolean,
        zAxis: boolean): number;
    startParticleFxNonLoopedOnEntity2(effectName: string,
        entity: MpEntity | object,
        xOffset: number,
        yOffset: number,
        zOffset: number,
        xRot: number,
        yRot: number,
        zRot: number,
        boneIndex: number,
        scale: number,
        xAxis: boolean,
        yAxis: boolean,
        zAxis: boolean): boolean;
    disableVehicleDistantlights(toggle: boolean): void;
    setNoisinessoveride(value: number): void;
    removeDecalsFromObject(obj: MpObject | object): void;
    drawScaleformMovieFullscreenMasked(scaleform1: number,
        scaleform2: number,
        red: number,
        green: number,
        blue: number,
        alpha: number): void;
    callScaleformMovieFunctionFloatParams(scaleform: number,
        functionName: string,
        param1: number,
        param2: number,
        param3: number,
        param4: number,
        param5: number): void;
    drawSpotLight(posX: number,
        posY: number,
        posZ: number,
        dirX: number,
        dirY: number,
        dirZ: number,
        colorR: number,
        colorG: number,
        colorB: number,
        distance: number,
        brightness: number,
        roundness: number,
        radius: number,
        falloff: number): void;
    drawBox(x1: number,
        y1: number,
        z1: number,
        x2: number,
        y2: number,
        z2: number,
        r: number,
        g: number,
        b: number,
        alpha: number): void;
    pushScaleformMovieFunctionParameterFloat(value: number): void;
    fadeDecalsInRange(p0: object, p1: object, p2: object, p3: object, p4: object): void;
    enableClownBloodVfx(toggle: boolean): void;
    drawDebugLineWithTwoColours(x1: number,
        y1: number,
        z1: number,
        x2: number,
        y2: number,
        z2: number,
        r1: number,
        g1: number,
        b1: number,
        r2: number,
        g2: number,
        b2: number,
        alpha1: number,
        alpha2: number): void;
    setParticleFxLoopedRange(ptfxHandle: number, range: number): void;
    removeParticleFxInRange(X: number, Y: number, Z: number, radius: number): void;
    startParticleFxLoopedOnEntityBone2(effectName: string,
        entity: MpEntity | object,
        xOffset: number,
        yOffset: number,
        zOffset: number,
        xRot: number,
        yRot: number,
        zRot: number,
        boneIndex: number,
        scale: number,
        xAxis: boolean,
        yAxis: boolean,
        zAxis: boolean): number;
    hasHudScaleformLoaded(hudComponent: number): boolean;
    requestStreamedTextureDict(textureDict: string, p1: boolean): void;
    setFrozenRenderingDisabled(enabled: boolean): void;
    startParticleFxLoopedAtCoord(effectName: string,
        x: number,
        y: number,
        z: number,
        xRot: number,
        yRot: number,
        zRot: number,
        scale: number,
        xAxis: boolean,
        yAxis: boolean,
        zAxis: boolean,
        p11: boolean): number;
    sittingTv(scaleform: number): string;
    setNoiseoveride(toggle: boolean): void;
    drawSprite(textureDict: string,
        textureName: string,
        screenX: number,
        screenY: number,
        scaleX: number,
        scaleY: number,
        heading: number,
        colorR: number,
        colorG: number,
        colorB: number,
        alpha: number): void;
    setPtfxAssetOldToNew(oldAsset: string, newAsset: string): void;
    releaseMovieMeshSet(movieMeshSet: number): void;
    removeDecal(decal: number): void;
    setParticleFxCamInsideVehicle(p0: boolean): void;
    callScaleformMovieFunctionMixedParams(scaleform: number,
        functionName: string,
        floatParam1: number,
        floatParam2: number,
        floatParam3: number,
        floatParam4: number,
        floatParam5: number,
        stringParam1: string,
        stringParam2: string,
        stringParam3: string,
        stringParam4: string,
        stringParam5: string): void;
    transitionFromBlurred(transitionTime: number): boolean;
    getScreenAspectRatio(b: boolean): number;
    startParticleFxLoopedOnPedBone(effectName: string,
        ped: MpPed | object,
        xOffset: number,
        yOffset: number,
        zOffset: number,
        xRot: number,
        yRot: number,
        zRot: number,
        boneIndex: number,
        scale: number,
        xAxis: boolean,
        yAxis: boolean,
        zAxis: boolean): number;
    drawLightWithRange(posX: number,
        posY: number,
        posZ: number,
        colorR: number,
        colorG: number,
        colorB: number,
        range: number,
        intensity: number): void;
    drawLightWithRangeAndShadow(x: number,
        y: number,
        z: number,
        r: number,
        g: number,
        b: number,
        range: number,
        intensity: number,
        shadow: number): void;
    startParticleFxNonLoopedAtCoord2(effectName: string,
        xPos: number,
        yPos: number,
        zPos: number,
        xRot: number,
        yRot: number,
        zRot: number,
        scale: number,
        xAxis: boolean,
        yAxis: boolean,
        zAxis: boolean): boolean;
    pushScaleformMovieFunction(scaleform: number, functionName: string): boolean;
    setParticleFxLoopedOffsets(ptfxHandle: number,
        x: number,
        y: number,
        z: number,
        rotX: number,
        rotY: number,
        rotZ: number): void;
    callScaleformMovieMethod(scaleform: number, method: string): void;
    drawTvChannel(xPos: number,
        yPos: number,
        xScale: number,
        yScale: number,
        rotation: number,
        r: number,
        g: number,
        b: number,
        alpha: number): void;
}