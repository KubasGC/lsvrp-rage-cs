class MarkerData {
    name: string;
    pos: MpVector3;
    scale: number;
    withBlip: boolean;

    markerHandle: MpMarker;
    blipHandle: MpBlip;

    isCrossedByPlayer: boolean;
}

let markersData: MarkerData[] = [];

export function load(): void {
    mp.events.add("client.markers.createMarker", createMarker);
    mp.events.add("client.markers.destroyMarker", destroyMarker);
    mp.events.add("render", checkMarkerCollisions);
}

function getDistanceBetweenPositions(posFirst: MpVector3, posSecond: MpVector3): number {
    const distance = Math.sqrt(Math.pow(posFirst.x - posSecond.x, 2) +
        Math.pow(posFirst.y - posSecond.y, 2) +
        Math.pow(posFirst.z - posSecond.z, 2));
    return distance;
}

function checkMarkerCollisions(): void {
    const localPlayerPosition = mp.players.local.position;
    for (let i = 0; i < markersData.length; i++) {
        const distance = getDistanceBetweenPositions(localPlayerPosition, markersData[i].pos) +
            (markersData[i].scale / 2);
        if (distance <= markersData[i].scale) {
            if (!markersData[i].isCrossedByPlayer) {
                markersData[i].isCrossedByPlayer = true;
                mp.events.callRemote("server.events.OnMarkerEnter", markersData[i].name);
            }
        } else {
            if (markersData[i].isCrossedByPlayer) {
                markersData[i].isCrossedByPlayer = false;
                mp.events.callRemote("server.events.OnMarkerLeave", markersData[i].name);
            }
        }
    }
}

function getMarkerByName(name: string): MarkerData {
    for (let i = 0; i < markersData.length; i++) {
        if (markersData[i].name == name) {
            return markersData[i];
        }
    }
    return null;
}

function destroyMarker(name: string): void {
    const markerData = getMarkerByName(name);
    if (markerData != null) {
        if (markerData.markerHandle != null) {
            markerData.markerHandle.destroy();
        }
        if (markerData.withBlip && markerData.blipHandle != null) {
            markerData.blipHandle.destroy();
        }
        const index = markersData.indexOf(markerData);
        if (index > -1) {
            markersData.splice(index, 1);
        }
    }
}

function createMarker(name: string,
    x: number,
    y: number,
    z: number,
    r: number,
    g: number,
    b: number,
    a: number,
    scale: number,
    withBlip: boolean,
    blipColor: number): void {
    const newMarker = new MarkerData();
    newMarker.name = name;
    newMarker.pos = new mp.Vector3(x, y, z);
    newMarker.scale = scale;
    newMarker.withBlip = withBlip;
    newMarker.isCrossedByPlayer = false;

    newMarker.markerHandle = mp.markers.new(1,
        newMarker.pos,
        scale,
        {
            color: [r, g, b, a]
        });
    if (withBlip) {
        newMarker.blipHandle = mp.blips.new(1,
            newMarker.pos,
            {
                color: blipColor
            });
        newMarker.blipHandle.setRoute(true);
        // newMarker.blipHandle.setColor(blipColor);
    }
    markersData.push(newMarker);
}