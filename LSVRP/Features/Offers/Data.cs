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
using System.Collections.Generic;
using GTANetworkAPI;

namespace LSVRP.Features.Offers
{
    public class Offer
    {
        public int Id { get; set; }
        public Client Player { get; set; }
        public Client Target { get; set; }
        public OfferType Type { get; set; }
        public uint Price { get; set; }
        public Dictionary<string, object> Data { get; set; }
        public int StartedAt { get; set; }
        public bool SystemOffer { get; set; }

        public void Destroy(string reason = "Wystąpił problem w trakcie realizowania oferty.",
            bool cancelOffer = false)
        {
            Library.DestroyOffer(Id, true, reason, cancelOffer);
        }

        public void Success(bool silent = false)
        {
            Library.DestroyOffer(Id, !silent, "Oferta została zrealizowana pomyślnie.", true);
        }
    }
}