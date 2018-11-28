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
using LSVRP.New.Enums;

namespace LSVRP.Features.Items
{
    public class Drugs
    {
        /*public enum DrugType
        {
            None,
            Marijuana,
            Cocaine,
            Amphetamine,
            Lsd,
            Opium,
            Methamphetamine,
            Heroin
        }*/

        public static readonly Dictionary<DrugType, int> DrugMaxPrice = new Dictionary<DrugType, int>
        {
            {DrugType.None, 0},
            {DrugType.Marijuana, 50},
            {DrugType.Cocaine, 300},
            {DrugType.Amphetamine, 100},
            {DrugType.Lsd, 30},
            {DrugType.Opium, 80},
            {DrugType.Methamphetamine, 200},
            {DrugType.Heroin, 120}
        };

        public static int GetDrugMaxPrice(DrugType type)
        {
            return DrugMaxPrice.ContainsKey(type) ? DrugMaxPrice[type] : 0;
        }
    }
}