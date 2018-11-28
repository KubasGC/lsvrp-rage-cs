export function isPlayerDriver(): boolean {
    const vehicle = mp.players.local.vehicle;
    const plr = mp.players.local;
    if (vehicle != null) {
        if (vehicle.getPedInSeat(-1) == plr.handle) {
            return true;
        }
        return false;
    }
    return false;
}