import { mileage } from './vehicle-mileage';
import * as Ui from "./ui";

let intervalId: number;

export function load() {
    mp.events.add("client.vehicle-speedometer.toggle",
        function (state: boolean) {
            const ui = Ui.getUiBrowser();
            const vehicle = mp.players.local.vehicle;
            if (vehicle != null && !mp.game.vehicle.isThisModelABicycle(vehicle.model)) {
                if (state) {
                    ui.execute(`vehicleToggle(true);`);
                    intervalId = setInterval(intervalHandler, 150);
                } else {
                    ui.execute(`vehicleToggle(false);`);
                    clearInterval(intervalId);
                }
            }
        });
    mp.events.add("client.vehicle-speedometer.refresh",
        function (fuelPercentage: number) {
            const ui = Ui.getUiBrowser();
            ui.execute(`vehFuelUpdate(${fuelPercentage});`);
        });
}

function intervalHandler() {
    const player = mp.players.local;
    const vehicle = player.vehicle;
    const ui = Ui.getUiBrowser();
    if (vehicle != null) {
        const speed = Math.round(vehicle.getSpeed() * 3.6).toFixed(0);
        ui.execute(`vehSpeedUpdate(${speed});
                    vehGearUpdate(${vehicle.gear});
                    vehRpmUpdate(${vehicle.rpm * 5});
                    vehDistanceUpdate(${mileage.toFixed(1)});`);
    }
}