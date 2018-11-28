/*
* LSVRP C# Engine
* Script dedicated for Role-play server in Grand Theft Auto V game based on the external Multiplayer called Rage Multiplayer.
* @Author: Kubas (Jakub Skakuj)
* @StartDate: Jun 2018
*
* @urls:
* 		@RAGE-MP  	    https://rage.mp
* 		@LSVRP:			https://lsvrp.pl
*
* All Rights Reserved
* Copyright prohibited
*/
namespace LSVRP.Features.Dialogs
{
    /// <summary>
    /// Unikalne identyfikatory dialogów
    /// </summary>
    public enum DialogId
    {
        None,
        AdminReportList,
        AdminReportAction,
        PlayerGroupsList,
        PlayerGroupsOptions,
        CreatePlayerReport,
        AnimationsList,
        VehicleList,
        VehicleOptions,
        VehicleEditAdmin,
        VehicleEditAdminOption,
        ClothSetList,
        ClothSetAction,
        ClothSetEdit,
        ClothSetDelete,

        GroupOrdersList,
        GroupOrdersEnterQuantity,
        GroupOrdersSummary,

        CornerDrugPrice,
        PlayerWalkingStyleChoose,

        ShopListItem,

        CourierAcceptPackage,

        ItemReloadWeapon,
        SelectSpawn,

        BwEnterDescription,

        PenaltyKickText,
        PenaltyKickConfirm,

        PenaltyWarnText,
        PenaltyWarnConfirm,

        AdminGroupRemove,
        AdminGroupRemoveConfirm,

        ItemPickDialog,

        ChooseAdminLevel,
        ItemInfo,

        MugshotTitle,
        MugshotTop,
        MugshotMiddle,
        MugshotBottom,

        InteriorsList,
        InteriorInfo,
        InteriorEdit
    }

    /// <summary>
    /// Typ dialogu
    /// </summary>
    public enum DialogType
    {
        None,
        List,
        EnterText,
        Info
    }

    /// <summary>
    /// Naciśnięty przycisk
    /// </summary>
    public enum DialogButton
    {
        Accept,
        Decline
    }
}