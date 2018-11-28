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
using System;
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Libraries;
using LSVRP.Managers;
using Log = LSVRP.Libraries.Log;

namespace LSVRP.Features.Money
{
    public static class Library
    {
        /// <summary>
        /// Dodaje pieniądze do portfela gracza
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="amount"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static bool GivePlayerWalletCash(Character charData, int amount, string description)
        {
            if (charData == null) return false;
            if (amount <= 0) return false;
            amount = Math.Abs(amount);
            charData.Cash += amount;
            charData.Save();
            NAPI.ClientEvent.TriggerClientEvent(charData.PlayerHandle, "client.money.update", charData.Cash);
            Log.LogPlayer(charData,
                $"Dodano ${amount}. Ilość pieniędzy w portfelu: {charData.Cash}. Opis: {description}.",
                LogType.MoneyAdded);
            return true;
        }

        /// <summary>
        /// Dodaje pieniądze do portfela gracza
        /// </summary>
        /// <param name="player"></param>
        /// <param name="amount"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static bool GivePlayerWalletCash(Client player, int amount, string description)
        {
            return GivePlayerWalletCash(Account.GetPlayerData(player), amount, description);
        }

        /// <summary>
        /// Zabiera pieniądze z portfela gracza
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="amount"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static bool TakePlayerWalletCash(Character charData, int amount, string description)
        {
            if (charData == null) return false;
            if (amount <= 0) return false;
            amount = Math.Abs(amount);
            if (charData.Cash < amount) return false;
            charData.Cash -= amount;
            charData.Save();
            NAPI.ClientEvent.TriggerClientEvent(charData.PlayerHandle, "client.money.update", charData.Cash);
            Log.LogPlayer(charData,
                $"Zabrano ${amount}. Ilość pieniędzy w portfelu: {charData.Cash}. Opis: {description}.",
                LogType.MoneyTook);
            return true;
        }

        /// <summary>
        /// Zabiera pieniądze z portfela gracza
        /// </summary>
        /// <param name="player"></param>
        /// <param name="amount"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static bool TakePlayerWalletCash(Client player, int amount, string description)
        {
            return TakePlayerWalletCash(Account.GetPlayerData(player), amount, description);
        }

        /// <summary>
        /// Zabiera pieniądze z konta bankowego gracza
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="amount"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static bool TakePlayerBankCash(Character charData, int amount, string description)
        {
            if (charData == null) return false;
            if (amount <= 0) return false;
            amount = Math.Abs(amount);
            if (charData.AccountBalance < amount) return false;
            charData.AccountBalance -= amount;
            charData.Save();
            Log.LogPlayer(charData,
                $"Zabrano ${amount} z konta bankowego. Stan konta: ${charData.AccountBalance}. Opis: " +
                $"{Command.UpperFirst(description)}", LogType.MoneyTook);
            return true;
        }

        /// <summary>
        /// Zabiera pieniądze z konta bankowego gracza
        /// </summary>
        /// <param name="player"></param>
        /// <param name="amount"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static bool TakePlayerBankCash(Client player, int amount, string description)
        {
            return TakePlayerBankCash(Account.GetPlayerData(player), amount, description);
        }

        /// <summary>
        /// Dodaje pieniądze na konto bankowe gracza
        /// </summary>
        /// <param name="charData"></param>
        /// <param name="amount"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static bool GivePlayerBankCash(Character charData, int amount, string description)
        {
            if (charData == null) return false;
            if (amount <= 0) return false;
            amount = Math.Abs(amount);
            charData.AccountBalance += amount;
            charData.Save();
            Log.LogPlayer(charData,
                $"Dodano ${amount} na konto bankowe. Stan konta: ${charData.AccountBalance}. Opis: " +
                $"{Command.UpperFirst(description)}", LogType.MoneyTook);
            return true;
        }

        /// <summary>
        /// Dodaje pieniądze na konto bankowe gracza
        /// </summary>
        /// <param name="player"></param>
        /// <param name="amount"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static bool GivePlayerBankCash(Client player, int amount, string description)
        {
            return GivePlayerBankCash(Account.GetPlayerData(player), amount, description);
        }
    }
}