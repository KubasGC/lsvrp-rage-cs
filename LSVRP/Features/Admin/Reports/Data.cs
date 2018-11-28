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

namespace LSVRP.Features.Admin.Reports
{
    public class ReportClass
    {
        public int Id { get; set; }
        public Client Sender { get; set; }
        public Client Target { get; set; }
        public string SenderName { get; set; }
        public string TargetName { get; set; }
        public int SendTime { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public Client Admin { get; set; }
    }

    public enum UiType
    {
        ReportsList,
        ReportInfo
    }
}