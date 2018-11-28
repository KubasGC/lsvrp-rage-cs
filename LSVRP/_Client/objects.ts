enum Axis {
    PosX,
    PosY,
    PosZ,
    RotX,
    RotY,
    RotZ
}

class ObjectEditor {
    static isPlayerEditingObject: boolean = false;
    static editingObject: MpObject = null;
    static oldData: { position: MpVector3, rotation: MpVector3 } = { position: null, rotation: null };
    static newData: { position: MpVector3, rotation: MpVector3 } = { position: null, rotation: null };
    static tempData: { position: MpVector3, rotation: MpVector3 } = { position: null, rotation: null };

    static cursorData: { clicked: boolean, start: [number, number] } = { clicked: false, start: [0, 0] };
    static choosedAxis = Axis.PosX;

    static onObjectEdit(remoteId: number): void {
        if (ObjectEditor.isPlayerEditingObject) return;
        const objectData = getObjectByRemoteId(remoteId);
        if (objectData === null) return;

        ObjectEditor.isPlayerEditingObject = true;
        ObjectEditor.editingObject = objectData;

        ObjectEditor.oldData.position = objectData.position;
        ObjectEditor.oldData.rotation = objectData.getRotation(2);

        ObjectEditor.newData.position = objectData.position;
        ObjectEditor.newData.rotation = objectData.getRotation(2);

        mp.events.add("render", ObjectEditor.render);

    }

    static onJKeyClicked(): void {
        mp.gui.chat.push("J Key clicked");
        ObjectEditor.stopEdit();
        mp.events.callRemote("server.objects.save",
            ObjectEditor.editingObject.remoteId,
            ObjectEditor.newData.position.x,
            ObjectEditor.newData.position.y,
            ObjectEditor.newData.position.z,
            ObjectEditor.newData.rotation.x,
            ObjectEditor.newData.rotation.y,
            ObjectEditor.newData.rotation.z);
    }

    static onKKeyClicked(): void {
        mp.gui.chat.push("K Key clicked");
        ObjectEditor.stopEdit();

        ObjectEditor.editingObject.position = ObjectEditor.oldData.position;
        ObjectEditor.editingObject.setRotation(ObjectEditor.oldData.rotation.x,
            ObjectEditor.oldData.rotation.y,
            ObjectEditor.oldData.rotation.z,
            2,
            true);

        mp.events.callRemote("client.objects.canceledit", ObjectEditor.editingObject.remoteId);
    }

    static stopEdit(): void {
        ObjectEditor.isPlayerEditingObject = false;
        mp.events.remove("render", ObjectEditor.render);
    }

    static getRelativePos(absoluteData: [number, number]): [number, number] {
        const out = mp.game.graphics.getScreenActiveResolution(0, 0);
        return [absoluteData[0] / out.x, absoluteData[1] / out.y];

    }

    static render(): void {
        if (!ObjectEditor.isPlayerEditingObject || ObjectEditor.editingObject === null) return;

        for (let i = 157; i < 166; i++) {
            mp.game.controls.disableControlAction(2, i, true);
        }

        // ON LPM CLICKED
        if (mp.keys.isDown(0x01)) {
            if (!ObjectEditor.cursorData.clicked) {
                ObjectEditor.cursorData.clicked = true;
                ObjectEditor.cursorData.start = ObjectEditor.getRelativePos(mp.gui.cursor.position);

                ObjectEditor.tempData.position = new mp.Vector3(0, 0, 0);
                ObjectEditor.tempData.rotation = new mp.Vector3(0, 0, 0);
            }

            let mouseRelativePos = ObjectEditor.getRelativePos(mp.gui.cursor.position);
            let vector = mouseRelativePos[0] - ObjectEditor.cursorData.start[0];

            if (ObjectEditor.choosedAxis === Axis.PosX) {
                let velocityX = ObjectEditor.getVelocityAngleZtoX(ObjectEditor.newData.rotation.z, 10 * vector);
                ObjectEditor.tempData.position.x = velocityX[0];
                ObjectEditor.tempData.position.y = velocityX[1];
            } else if (ObjectEditor.choosedAxis === Axis.PosY) {
                let velocityX = ObjectEditor.getVelocityAngleZtoY(-ObjectEditor.newData.rotation.z, 10 * vector);
                ObjectEditor.tempData.position.x = velocityX[0];
                ObjectEditor.tempData.position.y = velocityX[1];
            } else if (ObjectEditor.choosedAxis === Axis.PosZ) {
                ObjectEditor.tempData.position.z = 5 * vector;
            } else if (ObjectEditor.choosedAxis === Axis.RotZ) {
                ObjectEditor.tempData.rotation.z = 120 * vector;
                if (ObjectEditor.tempData.rotation.z > 360) ObjectEditor.tempData.rotation.z -= 360;
                if (ObjectEditor.tempData.rotation.z < 0) ObjectEditor.tempData.rotation.z += 360;
            }
        } else {
            if (ObjectEditor.cursorData.clicked) {
                ObjectEditor.cursorData.clicked = false;

                ObjectEditor.newData.position.x += ObjectEditor.tempData.position.x;
                ObjectEditor.newData.position.y += ObjectEditor.tempData.position.y;
                ObjectEditor.newData.position.z += ObjectEditor.tempData.position.z;

                ObjectEditor.newData.rotation.x += ObjectEditor.tempData.rotation.x;
                ObjectEditor.newData.rotation.y += ObjectEditor.tempData.rotation.y;
                ObjectEditor.newData.rotation.z += ObjectEditor.tempData.rotation.z;


            }
        }

        if (!ObjectEditor.cursorData.clicked) {
            if (mp.keys.isDown(0x31)) ObjectEditor.choosedAxis = Axis.PosX;
            if (mp.keys.isDown(0x32)) ObjectEditor.choosedAxis = Axis.PosY;
            if (mp.keys.isDown(0x33)) ObjectEditor.choosedAxis = Axis.PosZ;
            if (mp.keys.isDown(0x34)) ObjectEditor.choosedAxis = Axis.RotZ;

            if (mp.keys.isDown(0x4A)) { // J KEY
                ObjectEditor.onJKeyClicked();
                return;
            }

            if (mp.keys.isDown(0x4B)) { // K KEY
                ObjectEditor.onKKeyClicked();
                return;
            }
        }

        if (ObjectEditor.cursorData.clicked) {

            let tempPos = new mp.Vector3(
                ObjectEditor.newData.position.x + ObjectEditor.tempData.position.x,
                ObjectEditor.newData.position.y + ObjectEditor.tempData.position.y,
                ObjectEditor.newData.position.z + ObjectEditor.tempData.position.z
            );

            // Rysowanie
            let velocityYPaint =
                ObjectEditor.getVelocityAngleZtoY(-(ObjectEditor.newData.rotation.z + ObjectEditor.tempData.rotation.z),
                    1);
            mp.game.graphics.drawLine(tempPos.x,
                tempPos.y,
                tempPos.z,
                tempPos.x + velocityYPaint[0],
                tempPos.y + velocityYPaint[1],
                tempPos.z,
                0,
                255,
                0,
                ObjectEditor.choosedAxis === Axis.PosY ? 255 : 50);
            mp.game.graphics.drawLine(tempPos.x,
                tempPos.y,
                tempPos.z,
                tempPos.x - velocityYPaint[0],
                tempPos.y - velocityYPaint[1],
                tempPos.z,
                0,
                255,
                0,
                ObjectEditor.choosedAxis === Axis.PosY ? 255 : 50);

            // Rysowanie
            let velocityXPaint =
                ObjectEditor.getVelocityAngleZtoX(ObjectEditor.newData.rotation.z + ObjectEditor.tempData.rotation.z,
                    1);
            mp.game.graphics.drawLine(tempPos.x,
                tempPos.y,
                tempPos.z,
                tempPos.x + velocityXPaint[0],
                tempPos.y + velocityXPaint[1],
                tempPos.z,
                255,
                0,
                0,
                ObjectEditor.choosedAxis === Axis.PosX ? 255 : 50);
            mp.game.graphics.drawLine(tempPos.x,
                tempPos.y,
                tempPos.z,
                tempPos.x - velocityXPaint[0],
                tempPos.y - velocityXPaint[1],
                tempPos.z,
                255,
                0,
                0,
                ObjectEditor.choosedAxis === Axis.PosX ? 255 : 50);

            // Rysowanie
            mp.game.graphics.drawLine(tempPos.x,
                tempPos.y,
                tempPos.z,
                tempPos.x,
                tempPos.y,
                tempPos.z + 2,
                0,
                0,
                255,
                ObjectEditor.choosedAxis === Axis.PosZ ? 255 : 50);
            mp.game.graphics.drawLine(tempPos.x,
                tempPos.y,
                tempPos.z,
                tempPos.x,
                tempPos.y,
                tempPos.z - 2,
                0,
                0,
                255,
                Axis.PosZ ? 255 : 50);

            ObjectEditor.editingObject.position = tempPos;

            ObjectEditor.editingObject.setRotation(
                ObjectEditor.newData.rotation.x + ObjectEditor.tempData.rotation.x,
                ObjectEditor.newData.rotation.y + ObjectEditor.tempData.rotation.y,
                ObjectEditor.newData.rotation.z + ObjectEditor.tempData.rotation.z,
                2,
                true);
        } else {
            // Rysowanie
            let velocityYPaint = ObjectEditor.getVelocityAngleZtoY(-ObjectEditor.newData.rotation.z, 1);
            mp.game.graphics.drawLine(ObjectEditor.newData.position.x,
                ObjectEditor.newData.position.y,
                ObjectEditor.newData.position.z,
                ObjectEditor.newData.position.x + velocityYPaint[0],
                ObjectEditor.newData.position.y + velocityYPaint[1],
                ObjectEditor.newData.position.z,
                0,
                255,
                0,
                ObjectEditor.choosedAxis === Axis.PosY ? 255 : 50);
            mp.game.graphics.drawLine(ObjectEditor.newData.position.x,
                ObjectEditor.newData.position.y,
                ObjectEditor.newData.position.z,
                ObjectEditor.newData.position.x - velocityYPaint[0],
                ObjectEditor.newData.position.y - velocityYPaint[1],
                ObjectEditor.newData.position.z,
                0,
                255,
                0,
                ObjectEditor.choosedAxis === Axis.PosY ? 255 : 50);

            // Rysowanie
            let velocityXPaint = ObjectEditor.getVelocityAngleZtoX(ObjectEditor.newData.rotation.z, 1);
            mp.game.graphics.drawLine(ObjectEditor.newData.position.x,
                ObjectEditor.newData.position.y,
                ObjectEditor.newData.position.z,
                ObjectEditor.newData.position.x + velocityXPaint[0],
                ObjectEditor.newData.position.y + velocityXPaint[1],
                ObjectEditor.newData.position.z,
                255,
                0,
                0,
                ObjectEditor.choosedAxis === Axis.PosX ? 255 : 50);
            mp.game.graphics.drawLine(ObjectEditor.newData.position.x,
                ObjectEditor.newData.position.y,
                ObjectEditor.newData.position.z,
                ObjectEditor.newData.position.x - velocityXPaint[0],
                ObjectEditor.newData.position.y - velocityXPaint[1],
                ObjectEditor.newData.position.z,
                255,
                0,
                0,
                ObjectEditor.choosedAxis === Axis.PosX ? 255 : 50);

            // Rysowanie
            mp.game.graphics.drawLine(ObjectEditor.newData.position.x,
                ObjectEditor.newData.position.y,
                ObjectEditor.newData.position.z,
                ObjectEditor.newData.position.x,
                ObjectEditor.newData.position.y,
                ObjectEditor.newData.position.z + 2,
                0,
                0,
                255,
                ObjectEditor.choosedAxis === Axis.PosZ ? 255 : 50);
            mp.game.graphics.drawLine(ObjectEditor.newData.position.x,
                ObjectEditor.newData.position.y,
                ObjectEditor.newData.position.z,
                ObjectEditor.newData.position.x,
                ObjectEditor.newData.position.y,
                ObjectEditor.newData.position.z - 2,
                0,
                0,
                255,
                Axis.PosZ ? 255 : 50);

            ObjectEditor.editingObject.position = ObjectEditor.newData.position;
            ObjectEditor.editingObject.setRotation(ObjectEditor.newData.rotation.x,
                ObjectEditor.newData.rotation.y,
                ObjectEditor.newData.rotation.z,
                2,
                true);
        }


    }

    static getRadians(degrees: number): number {
        return degrees * Math.PI / 180;
    }

    static getVelocityAngleZtoX(angle: number, distance: number = 1.0): [number, number] {
        const x = Math.cos(ObjectEditor.getRadians(angle)) * distance;
        const y = Math.sin(ObjectEditor.getRadians(angle)) * distance;
        return [x, y];
    }

    static getVelocityAngleZtoY(angle: number, distance: number = 1.0): [number, number] {
        const x = Math.sin(ObjectEditor.getRadians(angle)) * distance;
        const y = Math.cos(ObjectEditor.getRadians(angle)) * distance;
        return [x, y];
    }
}


export function load(): void {
    mp.events.add("client.objects.edit", ObjectEditor.onObjectEdit);
}

export function getObjectByRemoteId(remoteId: number): MpObject {
    const obj = mp.objects.atRemoteId(remoteId);
    if (obj === undefined || obj === null) return null;
    return obj;
}