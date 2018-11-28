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
using LSVRP.Managers;

namespace LSVRP.Features.Offers
{
    public class RemoteEvents : Script
    {
        [RemoteEvent("server.offers.acceptOffer")]
        public void AcceptOffer(Client player, int payType)
        {
            Library.AcceptOffer(Account.GetPlayerData(player), (OfferPayType) payType);
        }

        [RemoteEvent("server.offers.discardOffer")]
        public void DiscardOffer(Client player)
        {
            Library.DiscardOffer(Account.GetPlayerData(player));
        }
    }
}