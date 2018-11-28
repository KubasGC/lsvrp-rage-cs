import * as UiClass from "./ui"
import * as CefClass from "./cef"

export function load(): void {

    mp.events.add("client.workshop.gettune",
        function(vehicleId: number) {
            let vehHandle = getVehicleByRemoteId(vehicleId);
            let data: { data: any, value: number }[] = [];

            try {
                let spoiler = vehHandle.getNumMods(0);
                let fBumper = vehHandle.getNumMods(1);
                let rBumper = vehHandle.getNumMods(2);
                let sSkirt = vehHandle.getNumMods(3);
                let exhaust = vehHandle.getNumMods(4);
                let frame = vehHandle.getNumMods(5);
                let grille = vehHandle.getNumMods(6);
                let hood = vehHandle.getNumMods(7);
                let fender = vehHandle.getNumMods(8);
                let rFender = vehHandle.getNumMods(9);
                let roof = vehHandle.getNumMods(10);
                let engine = vehHandle.getNumMods(11);
                let brakes = vehHandle.getNumMods(12);
                let transmission = vehHandle.getNumMods(13);
                let suspension = vehHandle.getNumMods(15);
                let turbo = vehHandle.getNumMods(18);
                let xenon = vehHandle.getNumMods(22);
                let wheels = vehHandle.getNumMods(23);
                let windows = vehHandle.getNumMods(46);

                //mp.events.callRemote("server.workshop.showtune", spoiler, fBumper, rBumper, sSkirt, exhaust, frame, grille, hood, fender, rFender, roof, engine, brakes, transmission, suspension, turbo, xenon, wheels, windows);
                data.push({ data: `spoiler`, value: spoiler });
                data.push({ data: `fBumper`, value: fBumper });
                data.push({ data: `rBumper`, value: rBumper });
                data.push({ data: `sSkirt`, value: sSkirt });
                data.push({ data: `exhaust`, value: exhaust });
                data.push({ data: `frame`, value: frame });
                data.push({ data: `grille`, value: grille });
                data.push({ data: `hood`, value: hood });
                data.push({ data: `fender`, value: fender });
                data.push({ data: `rFender`, value: rFender });
                data.push({ data: `roof`, value: roof });
                data.push({ data: `engine`, value: engine });
                data.push({ data: `brakes`, value: brakes });
                data.push({ data: `transmission`, value: transmission });
                data.push({ data: `suspension`, value: suspension });
                data.push({ data: `turbo`, value: turbo });
                data.push({ data: `xenon`, value: xenon });
                data.push({ data: `wheels`, value: wheels });
                data.push({ data: `windows`, value: windows });
                UiClass.getUiBrowser().execute(`tuneMenuLoad('${JSON.stringify(data)}');`);
                UiClass.getUiBrowser().execute('tuneMenuToggle(true);');
                mp.gui.cursor.visible = true;
            } catch (err) {
                mp.gui.chat.push(err.message);
            }
        });

    mp.events.add("client.workshop.tune.update",
        function(choosedSpoiler: number,
            choosedFBumper: number,
            choosedRBumper: number,
            choosedSSkirt: number,
            choosedExhaust: number,
            choosedFrame: number,
            choosedGrille: number,
            choosedHood: number,
            choosedFender: number,
            choosedRFender: number,
            choosedRoof: number,
            choosedEngine: number,
            choosedBrakes: number,
            choosedTransmission: number,
            choosedSuspension: number,
            choosedTurbo: number,
            choosedXenon: number,
            choosedWheels: number,
            choosedWindows: number) {
            mp.events.callRemote("server.workshop.tune.update",
                choosedSpoiler,
                choosedFBumper,
                choosedRBumper,
                choosedSSkirt,
                choosedExhaust,
                choosedFrame,
                choosedGrille,
                choosedHood,
                choosedFender,
                choosedRFender,
                choosedRoof,
                choosedEngine,
                choosedBrakes,
                choosedTransmission,
                choosedSuspension,
                choosedTurbo,
                choosedXenon,
                choosedWheels,
                choosedWindows);
        });

    mp.events.add("client.vehPaint.save",
        function(colorOne: number, colorTwo: number) {
            mp.events.callRemote("server.vehPaint.save", colorOne, colorTwo);
            mp.gui.cursor.visible = false;
        });

    mp.events.add("updateVehPaint",
        function(colorOne: number, colorTwo: number) {
            const plr = mp.players.local;
            if (plr.vehicle) {
                plr.vehicle.setColours(colorOne, colorTwo);
            }
        });

    mp.events.add("client.vehPaint.show",
        function(state: boolean) {
            UiClass.getUiBrowser().execute(`toggleVehPainting(${state});`);
            setTimeout(function() { mp.gui.cursor.visible = true; }, 500);
        });


    function getVehicleByRemoteId(remoteId: number): MpVehicle {
        const veh = mp.vehicles.atRemoteId(remoteId);
        if (veh == undefined || veh == null) {
            return null;
        }
        return veh;
    }
}