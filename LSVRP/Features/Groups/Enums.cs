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
namespace LSVRP.Features.Groups
{
    public enum GroupType
    {
        None, // 0
        Pd, // 1
        Fd, // 2  
        Sn, // 3
        Criminal, // 4
        Gov, // 5   
        Workshop, // 6
        Restaurant, // 7
        Ic, // 8
        Family, // 9  
        Gsm // 10  
    }

    public enum AddToGroupState
    {
        Ok,
        PlayerDoesntExist,
        GroupDoesntExist,
        AlreadyInGroup,
        DbError,
        GlobalAlreadyInGroup,
        GroupsLimitReached
    }

    public enum RemoveFromGroupState
    {
        Ok,
        PlayerDoesntExist,
        GroupDoesntExist,
        NotInGroup,
        ErrorGettingData
    }

    public enum UiType
    {
        GroupMenu,
        GroupOrders
    }
}