/// <reference path="../index.d.ts" />

declare interface MpEntity {
    readonly id: number;
    dimension: number;
    readonly type: string;
    position: MpVector3;
    model: number;
    alpha: number;
    readonly handle: object;
    remoteId: number;

    destroy(): void;

    getVariable(name: string): any | undefined;
    setVariable(name: string, value: any): void;
    hasClearLosToInFront(entity: MpEntity | object): boolean;
    getPedIndexFromIndex(): MpPed | object;
    doesHaveDrawable(): boolean;
    setCoords(xPos: number,
        yPos: number,
        zPos: number,
        xAxis: boolean,
        yAxis: boolean,
        zAxis: boolean,
        clearArea: boolean): void;
    setRecordsCollisions(toggle: boolean): void;
    getForwardVector(): MpVector3;
    isAMission(): boolean;
    setLoadCollisionFlag(toggle: boolean): void;
    setMaxSpeed(speed: number): void;
    isTouchingModel(modelHash: string | number): boolean;
    isStatic(): boolean;
    getMaxHealth(): number;
    setMaxHealth(value: number): void;
    setDynamic(toggle: boolean): void;
    setCanBeDamaged(toggle: boolean): void;
    isTouching(targetEntity: MpEntity | object): boolean;
    getOffsetFromInWorldCoords(offsetX: number, offsetY: number, offsetZ: number): MpVector3;
    applyForceToCenterOfMass(forceType: number,
        x: number,
        y: number,
        z: number,
        p4: boolean,
        isRel: boolean,
        highForce: boolean,
        p7: boolean): void;
    setCollision(toggle: boolean, keepPhysics: boolean): void;
    setVelocity(x: number, y: number, z: number): void;
    isUpsidedown(): boolean;
    getHeightAboveGround(): number;
    isPlayingAnim(animDict: string, animName: string, p2: number): boolean;
    isAtCoord(xPos: number,
        yPos: number,
        zPos: number,
        xSize: number,
        ySize: number,
        zSize: number,
        p6: boolean,
        p7: boolean,
        p8: number): boolean;
    hasAnimFinished(animDict: string, animName: string, p2: number): boolean;
    getRotationVelocity(): MpVector3;
    getOffsetFromGivenWorldCoords(posX: number, posY: number, posZ: number): MpVector3;
    setCoordsNoOffset(xPos: number, yPos: number, zPos: number, xAxis: number, yAxis: number, zAxis: number): void;
    isAttachedToAnyVehicle(): boolean;
    stopAnim(animation: string, animGroup: string, p2: number): void;
    setAnimSpeed(animDict: string, animName: string, speedMultiplier: number): void;
    setMotionBlur(toggle: boolean): void;
    getAnimCurrentTime(animDict: string, animName: string): number;
    setInvincible(toggle: boolean): void;
    getCoords(alive: boolean): MpVector3;
    forceAiAndAnimationUpdate(): void;
    getLodDist(): number;
    freezePosition(toggle: boolean): void;
    stopSynchronizedAnim(p0: number, p1: boolean): boolean;
    setAnimCurrentTime(animDict: string, animName: string, time: number): void;
    setAlpha(alphaLevel: number): void;
    getWorldPositionOfBone(boneIndex: number): MpVector3;
    isVisible(): boolean;
    getVelocity(): MpVector3;
    getAttachedTo(): MpEntity | object;
    setHasGravity(toggle: boolean): void;
    getVehicleIndexFromIndex(): MpVehicle | object;
    getNearestPlayerToOnTeam(team: number): MpPlayer;
    getAnimTotalTime(animDict: string, animName: string): number;
    isInAngledArea(originX: number,
        originY: number,
        originZ: number,
        edgeX: number,
        edgeY: number,
        edgeZ: number,
        angle: number,
        p7: boolean,
        p8: boolean,
        p9: object): boolean;
    isAPed(): boolean;
    isUpright(angle: number): boolean;
    isInArea(x1: number,
        y1: number,
        z1: number,
        x2: number,
        y2: number,
        z2: number,
        p6: boolean,
        p7: boolean,
        p8: object): boolean;
    setTrafficlightOverride(state: number): void;
    setLodDist(value: number): void;
    getAlpha(): number;
    getHeight(x: number, y: number, z: number, atTop: boolean, inWorldCoords: boolean): number;
    getLastMaterialHitBy(): string | number;
    isDead(): boolean;
    hasBeenDamagedByAnyPed(): boolean;
    setCoords2(xPos: number,
        yPos: number,
        zPos: number,
        xAxis: number,
        yAxis: number,
        zAxis: number,
        clearArea: boolean): void;
    isAVehicle(): boolean;
    setHealth(health: number): void;
    attachTo(entity: MpEntity | object,
        boneIndex: number,
        xPos: number,
        yPos: number,
        zPos: number,
        xRot: number,
        yRot: number,
        zRot: number,
        p8: boolean,
        useSoftPinning: boolean,
        collision: boolean,
        isPed: boolean,
        vertexIndex: number,
        fixedRot: boolean): void;
    setOnlyDamagedByRelationshipGroup(p0: boolean, p1: object): void;
    getNearestPlayerTo(): MpPlayer;
    doesExist(): boolean;
    setRenderScorched(toggle: boolean): void;
    isAt(entity: MpEntity | object,
        xSize: number,
        ySize: number,
        zSize: number,
        p4: boolean,
        p5: boolean,
        p6: number): boolean;
    setQuaternion(x: number, y: number, z: number, w: number): void;
    setOnlyDamagedByPlayer(toggle: boolean): void;
    getQuaternion(x: number, y: number, z: number, w: number): MpQuaternion;
    setLights(toggle: boolean): void;
    playAnim(animName: string,
        propName: string,
        p2: number,
        p3: boolean,
        p4: boolean,
        p5: boolean,
        delta: number,
        bitset: object): boolean;
    getRoll(): number;
    getPhysicsHeading(): number;
    setRotation(pitch: number, roll: number, yaw: number, rotationOrder: number, p4: boolean): void;
    getForwardY(): number;
    isInAir(): boolean;
    getType(): number;
    hasCollidedWithAnything(): boolean;
    getForwardX(): number;
    isAnObject(): boolean;
    setHeading(heading: number): void;
    hasBeenDamagedByAnyObject(): boolean;
    getUprightValue(): number;
    detach(p0: boolean, collision: boolean): void;
    getSpeedVector(relative: boolean): MpVector3;
    resetAlpha(): void;
    getModel(): string | number;
    setNoCollision(entity: MpEntity | object, collision: boolean): void;
    getScript(script: MpGameScript): MpGameScript;
    clearLastDamage(): void;
    setAlwaysPrerender(toggle: boolean): void;
    setAsMission(p0: boolean, byThisScript: boolean): void;
    getRotation(rotationOrder: number): MpVector3;
    isAttachedToAnyPed(): boolean;
    isAttached(): boolean;
    isInZone(zone: string): boolean;
    attachToPhysically(entity: MpEntity | object,
        boneIndex1: number,
        boneIndex2: number,
        xPos1: number,
        yPos1: number,
        zPos1: number,
        xPos2: number,
        yPos2: number,
        zPos2: number,
        xRot: number,
        yRot: number,
        zRot: number,
        breakForce: number,
        fixedRot: boolean,
        p14: boolean,
        collision: boolean,
        p16: boolean,
        p17: number): void;
    applyForceTo(forceType: number,
        x: number,
        y: number,
        z: number,
        xRot: number,
        yRot: number,
        zRot: number,
        boneIndex: number,
        isRel: boolean,
        p9: boolean,
        highForce: boolean,
        p11: boolean,
        p12: boolean): void;
    playSynchronizedAnim(syncedScene: number,
        animation: string,
        propName: string,
        p3: number,
        p4: number,
        p5: object,
        p6: number): boolean;
    hasBeenDamagedBy(entity: MpEntity | object, p1: boolean): boolean;
    isCollisonDisabled(): boolean; // TODO: Is this correct?
    isAttachedToAnyObject(): boolean;
    isInWater(): boolean;
    isWaitingForWorldCollision(): boolean;
    setCanBeTargetedWithoutLos(toggle: boolean): void;
    getPitch(): number;
    getSpeed(): number;
    isVisibleToScript(): boolean;
    getObjectIndexFromIndex(): MpObject | object;
    doesHavePhysics(): boolean;
    doesBelongToThisScript(p0: boolean): boolean;
    hasBeenDamagedByAnyVehicle(): boolean;
    setCanBeDamagedByRelationshipGroup(p0: boolean, p1: object): void;
    isOccluded(): boolean;
    getCollisionNormalOfLastHitFor(): MpVector3;
    isOnScreen(): boolean;
    getSubmergedLevel(): number;
    getHeading(): number;
    hasCollisionLoadedAround(): boolean;
    setIsTargetPriority(p0: boolean, p1: number): void;
    setVisible(toggle: boolean, p1: boolean): void;
    hasAnimEventFired(actionHash: string | number): boolean;
    getMatrix(rightVector: MpVector3, forwardVector: MpVector3, upVector: MpVector3, position: MpVector3): {
        readonly rightVector: MpVector3;
        readonly forwardVector: MpVector3;
        readonly upVector: MpVector3;
        readonly position: MpVector3;
    };
    getHealth(): number;
    isAttachedTo(to: MpEntity | object): boolean;
    processAttachments(): void;
    getPopulationType(): number;
    setProofs(bulletProof: boolean,
        fireProof: boolean,
        explosionProof: boolean,
        collisionProof: boolean,
        meleeProof: boolean,
        p5: boolean,
        p6: boolean,
        drownProof: boolean): void;
    getBoneIndexByName(boneName: string): number;
    hasClearLosTo(entity: MpEntity | object, traceType: number): boolean;
}