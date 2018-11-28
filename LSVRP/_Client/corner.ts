/// <reference path="@types/index.d.ts" />

import * as Ui from "./ui";

let cornerSprite = 51;

class ClientCorner {
    id: number;
    name: string;
    x: number;
    y: number;
    z: number;
    blip: MpBlip;
    marker: MpMarker;


    constructor(id: number, name: string, x: number, y: number, z: number) {
        this.id = id;
        this.x = x;
        this.y = y;
        this.z = z;
        this.name = name;

        this.blip = mp.blips.new(cornerSprite,
            new mp.Vector3(this.x, this.y, this.z),
            {
                alpha: 255,
                name: `Corner: ${this.name}`,
                shortRange: true,
                color: 79,
            });
        this.blip.alpha = 255;
        this.marker = mp.markers.new(1,
            new mp.Vector3(this.x, this.y, this.z - 2.0),
            3.0,
            {
                color: [255, 20, 20, 50]
            });
    }
}

let clientCorners = new Map<number, ClientCorner>();

export function load() {
    mp.events.add("client.corners.togglecornerUI",
        (state: boolean) => {
            if (state) {
                Ui.getUiBrowser().execute(`cornerToggle(true);`);
            } else {
                Ui.getUiBrowser().execute(`cornerToggle(false);`);
            }
        });
    mp.events.add("client.corners.load",
        function(data: string) {
            if (data.length < 5)
                return;
            const cornerData = JSON.parse(data);
            for (let i in cornerData) {
                const json: any = cornerData[i];
                const corner = new ClientCorner(json.Id, json.Name, json.X, json.Y, json.Z);
                clientCorners.set(corner.id, corner);
            }
        });
}