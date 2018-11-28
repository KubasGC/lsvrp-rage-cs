/// <reference path="../index.d.ts" />

declare interface MpGuiCursor {
    visible: boolean;
    position: any;

    update(...args: any[]): any;
}