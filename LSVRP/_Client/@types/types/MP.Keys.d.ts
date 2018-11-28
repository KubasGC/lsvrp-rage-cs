/// <reference path="../index.d.ts" />

declare interface MpKeys {
    bind(keyCode: number, keyHold: boolean, handler: () => void): void;
    isDown(keyCode: number): boolean;
    isUp(keyCode: number): boolean;
}