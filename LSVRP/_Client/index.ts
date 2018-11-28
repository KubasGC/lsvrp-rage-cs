import * as LoginClass from "./login"
import * as CameraClass from "./cameras"
import * as ItemsClass from "./items"
import * as CefClass from "./cef"
import * as UiClass from "./ui"
import * as NotificationsClass from "./notifications"
import * as VehiclesClass from "./vehicles"
import * as ModalClass from "./modals"
import * as OffersClass from "./offers"
import * as NicknamesClass from "./nicknames"
import * as SyncManager from "./syncManager"
import * as DiscordClass from "./discord"
import * as DialogClass from "./dialogs"
import * as BwClass from "./bw"
import * as MarkersClass from "./markers"
import * as DoorsClass from "./doors"
import * as BusesClass from "./buses"
import * as ZonesClass from "./zones"
import * as WorkshopClass from "./workshops"
import * as GasStationsClass from "./gasstations"
import * as BankClass from "./bank"
import * as AfkClass from "./afk"
import * as MoneyClass from "./money"
import * as ScoreTab from "./scoretab"
import * as DutyClass from "./duty"
import * as SpectatorClass from "./spectate"
import * as FastchoiceClass from "./fastchoice"
import * as PenaltiesClass from "./penalties"
import * as GovernmentClass from "./government"
import * as AnimationsClass from "./animations"
import * as DrunkClass from "./drunk"
import * as RadioClass from "./radio"
import * as SkinClass from "./skins"
import * as TattoosClass from "./tattoos"
import * as CornerClass from "./corner"
import * as DrugsClass from "./drugs"
import * as CharCreator from "./char-creator"
import * as ProgressClass from "./progress"
import * as RopeClass from "./ropes"
import * as ObjectsClass from "./objects"
import * as FlyClass from "./fly";
import * as MugshotClass from "./mugshot";
import * as MileageClass from "./vehicle-mileage";
import * as SpeedometerClass from "./vehicle-speedometer";

let chatActive = true;

mp.events.add("clientStart",
    function () {

        // Ładowanie czatu
        mp.gui.execute("window.location = 'package://LSVRP/Chat/index.html'");

        LoginClass.createEvents();
        MarkersClass.load();
        ModalClass.load();
        MoneyClass.load();
        NicknamesClass.load();
        NotificationsClass.load();
        ObjectsClass.load();
        OffersClass.load();
        PenaltiesClass.load();
        ProgressClass.load();
        RadioClass.load();
        RopeClass.load();
        ScoreTab.load();
        SkinClass.load();
        SpectatorClass.load();
        SyncManager.load();
        TattoosClass.load();
        UiClass.load();
        VehiclesClass.load();
        WorkshopClass.load();
        ZonesClass.load();
        FlyClass.load();
        MugshotClass.load();
        ItemsClass.load();
        GovernmentClass.load();
        GasStationsClass.load();
        FastchoiceClass.load();
        DutyClass.load();
        DrunkClass.load();
        DrugsClass.load();
        DoorsClass.load();
        DiscordClass.load();
        DialogClass.load();
        CornerClass.load();
        CharCreator.load();
        CefClass.load();
        BwClass.load();
        BusesClass.load();
        BankClass.load();
        AnimationsClass.load();
        AfkClass.load();
        MileageClass.load();
        SpeedometerClass.load();

        CameraClass.init();
        CameraClass.createEvents();
        CameraClass.setCamera(new mp.Vector3(300.2, -1486.5, 61.62), new mp.Vector3(286.27, -1620.34, 30.53));

        mp.game.ui.displayRadar(false);
        mp.gui.chat.colors = true;
        mp.nametags.enabled = false;

        mp.keys.bind(0x72 /* KLAWISZ F3 */,
            false,
            function () {
                mp.gui.cursor.visible = !mp.gui.cursor.visible;
            });
        mp.keys.bind(115 /* KLAWISZ F4 */,
            false,
            function () {
                UiClass.getUiBrowser().execute("toggleHelp();");
                mp.gui.cursor.visible = !mp.gui.cursor.visible;
            });
        mp.keys.bind(0x74 /* KLAWISZ F5 */,
            false,
            function () {
                mp.players.local.freezePosition(true);
                mp.events.callRemote("server.resetvw");
                setTimeout(function () {
                    mp.players.local.freezePosition(false);
                },
                    2500);
            });
        mp.keys.bind(0x42,
            false,
            function () {
                if (!CefClass.getChatFocused() && !CefClass.isChatBlocked()) {
                    mp.events.callRemote("server.interactions.buildMenu");
                }
            });
        mp.discord.update("Gra na LSVRP.pl", "Online");

        mp.game.player.disableVehicleRewards();
        mp.game.player.setHealthRechargeMultiplier(0.0);
        mp.game.gameplay.setFadeOutAfterDeath(false);

    });
mp.events.call("clientStart");