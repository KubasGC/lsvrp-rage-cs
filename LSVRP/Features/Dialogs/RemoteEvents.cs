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
using GTANetworkAPI;

namespace LSVRP.Features.Dialogs
{
    public class RemoteEvents : Script
    {
        [RemoteEvent("server.modal.getData")]
        public void GetData(Client player, int dialogId, object data, int dialogType, int dialogButton)
        {
            Library.OnModalGotData(player, (DialogId) dialogId, (DialogType) dialogType, data,
                (DialogButton) dialogButton);
        }
    }
}