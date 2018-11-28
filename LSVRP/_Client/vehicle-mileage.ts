let velocities: Map<number, number> = new Map<number, number>();
let intervalId: number;
export let mileage: number;

export function load() {
    mp.events.add('client.vehicle.mileage.add', addHandler);
    mp.events.add('client.vehicle.mileage.remove', removeHandler);
    mp.events.add('client.vehicle.mileage.forceRequest', forceRequestHandler);
}

function addHandler(...args: any[]) {
    mileage = args[0] || 0;
    intervalId = setInterval(intervalHandler, 100);
}

function removeHandler(...args: any[]) {
    clearInterval(intervalId);
}

function forceRequestHandler(...args: any[]) {
    if (ticksToRequest > 0) {
        // if ticks to request is set to 0 there is no data to send, because a request was sent 2 seconds ago
        sendRequest();
    }
}

var sum = 0;
var ticksToRequest = 10;
var elapsed = 0;

function intervalHandler() {
    const currentVelocity = mp.players.local.vehicle.getSpeed();
    if (currentVelocity > 0) {
        velocities.set(elapsed, currentVelocity)

        if (elapsed >= 2) {
            let approximation = approximateIntegralWithMidpointRule(0, 2, 10, velocities) / 1000;
            if (ticksToRequest-- == 0) {
                sendRequest();
            }

            sum += approximation;
            mileage += approximation;
            velocities.clear();
            elapsed = -0.1;
        }
        elapsed = parseFloat((elapsed + 0.1).toFixed(3));
    }
}

function sendRequest(): void {
    mp.events.callRemote('server.vehicle.mileage', sum);
    sum = 0;
    ticksToRequest = 10;
}

function approximateIntegralWithMidpointRule(from: number, to: number, n: number,
    func: Map<number, number>): number {
    let localSum: number = 0;
    let deltaX: number = (to - from) / n;
    let lastI: number = from;
    for (let i = from; i < to; i += deltaX) {
        if (func.has(parseFloat((0.5 * (lastI + i)).toFixed(3)))) {
            localSum += func.get(parseFloat((0.5 * (lastI + i)).toFixed(3)));
        }
        lastI = i;
    }
    return deltaX * localSum;
}
