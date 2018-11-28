import * as UiClass from "./ui"
import * as CefClass from "./cef"

let itemVisible: boolean = false;

export function load(): void {
    mp.events.add("client.items.showItems",
        function(playerItems: string) {
            if (itemVisible) {
                itemVisible = false;
                UiClass.getNewUiBrowser().execute("ShowItemsMenu();");
            } else {
                UiClass.getNewUiBrowser()
                    .execute(`LoadItemsData('${encodeURIComponent(playerItems)}'); ShowItemsMenu();`);
                itemVisible = true;
            }
        });

    mp.events.add("client.items.refreshItems",
        function(playerItems: string) {
            UiClass.getNewUiBrowser().execute(`LoadItemsData('${encodeURIComponent(playerItems)}');`);
        });

    mp.events.add("client.items.hideItems",
        function() {
            UiClass.getNewUiBrowser().execute("HideItemsMenu();");
            itemVisible = false;
        });

    mp.keys.bind(0x49 /* KLAWISZ I */,
        false,
        function() {
            if (!CefClass.getChatFocused() && !CefClass.isChatBlocked()) {
                if (!itemVisible) {
                    mp.events.callRemote("server.items.showUi");
                } else {
                    itemVisible = false;
                    UiClass.getNewUiBrowser().execute("HideItemsMenu();");
                }
            }
        });

    mp.events.add("render",
        function() {
            if (!itemVisible) return;

            for (let i = 157; i < 166; i++) {
                mp.game.controls.disableControlAction(2, i, true);
            }
        });

    mp.events.add("playerWeaponShot",
        function(targetPosition: MpVector3, targetEntity: any) {
            mp.events.callRemote("server.items.shotWeapon",
                mp.players.local.weapon.toString(),
                mp.players.local.getAmmoInClip(mp.players.local.weapon));
        });

    mp.events.add("client.items.cigarette",
        function(entity: number, cigarette: number) {
            mp.objects.atRemoteId(cigarette).attachTo(mp.players.atRemoteId(entity).handle,
                mp.players.atRemoteId(entity).getBoneIndex(28422),
                0,
                0,
                0,
                0,
                0,
                0,
                false,
                false,
                false,
                false,
                2,
                true);
        });

    // mp.events.add("render", function() {
    //     if(mp.players.local.getAnimCurrentTime("amb@world_human_smoking@male@male_a@enter", "enter") > 0.9)
    //     {
    //         mp.events.callRemote("server.items.cigarette");
    //     }
    // });
    // cygaro
}