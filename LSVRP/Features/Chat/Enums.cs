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
namespace LSVRP.Features.Chat
{
    /// <summary>
    /// Typy wiadomości grupowych
    /// </summary>
    public enum GroupMessageType
    {
        Ic,
        Ooc
    }

    /// <summary>
    /// Typy wiadomości lokalnych
    /// </summary>
    public enum LocalMessageType
    {
        Talk,
        Whisper,
        Shout,
        Megaphone
    }
}