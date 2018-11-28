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
namespace LSVRP.Features.Drugs
{
    public static class Data
    {
        /// <summary>
        /// Teksty obcych dla kokainy.
        /// </summary>
        public static readonly string[] CocaineStrangerTexts =
        {
            "Ty tam!",
            "Zabije Cię!",
            "Kim jesteś?",
            "Co tu robisz?",
            "Chodź do mnie!"
        };

        /// <summary>
        /// Akcje do dla marihuany.
        /// </summary>
        public static readonly string[] MarihuannaDoActions =
        {
            "Gracz odczuwa chęć zapalenia cannabisu.",
            "Gracz staje się lekko nerwowy i drażliwy."
        };

        /// <summary>
        /// Kolejne akcje do dla marihuany.
        /// </summary>
        public static readonly string[] MarihuannaDoActions1 =
        {
            "Gracz ma wrażenie, że ktoś go śledzi.",
            "Gracz odczuwa suchość i dyskomfort w ustach z powodu niskiej produkcji śliny."
        };
    }
}