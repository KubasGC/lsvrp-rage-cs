import * as SyncManager from "./syncManager"

export function load(): void {
    mp.events.add("entityStreamIn",
        function(entity: MpPlayer) {
            const entityType = entity.getType();
            const entityLogged = SyncManager.getPlayerData(entity, "player.isLogged");
            if (entityLogged !== undefined && entityLogged) {
                if (entityType == 4) {
                    const hat = SyncManager.getPlayerData(entity, "player.skin.hat");
                    const hatTexture = SyncManager.getPlayerData(entity, "player.skin.hatTexture");
                    const glasses = SyncManager.getPlayerData(entity, "player.skin.glasses");
                    const glassesTexture = SyncManager.getPlayerData(entity, "player.skin.glassesTexture");
                    const ears = SyncManager.getPlayerData(entity, "player.skin.ears");
                    const earsTexture = SyncManager.getPlayerData(entity, "player.skin.earsTexture");

                    if (Number.isInteger(hat) &&
                        Number.isInteger(hatTexture) &&
                        Number.isInteger(glasses) &&
                        Number.isInteger(glassesTexture) &&
                        Number.isInteger(ears) &&
                        Number.isInteger(earsTexture)) {
                        entity.setPropIndex(0, hat, hatTexture, true);
                        entity.setPropIndex(1, glasses, glassesTexture, true);
                        entity.setPropIndex(2, ears, earsTexture, true);
                    }
                }
            }
        });
}