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

namespace LSVRP.Features.Interiors
{
    public class RemoteEvents : Script
    {
        [RemoteEvent("server.interiors.tryEnterToInterior")]
        public void Event_TryEnterToInterior(Client player)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            DoorInfo nearestDoor = Library.GetNearestDoor(charData);
            if (nearestDoor == null) return;

            // Przetrzymywanie
            if (charData.DetentionDoorId != 0)
            {
                if (charData.DetentionTime > Global.GetTimestamp())
                {
                    Ui.ShowWarning(player, "Twoja postać jest przetrzymywana, nie możesz przejść przez drzwi.");
                    return;
                }

                charData.DetentionDoorId = 0;
                charData.DetentionTime = 0;
                charData.Save();
            }

            if (player.IsInVehicle)
            {
                Ui.ShowInfo(player, "Aby skorzystać z przejazdu pojazdem użyj komendy /przejazd.");
                return;
            }

            if (nearestDoor.DoorData.Locked)
            {
                Ui.ShowInfo(player, "Drzwi są zamknięte.");
                return;
            }


            if (nearestDoor.DoorType == DoorType.Out)
                if ((int) Math.Floor(nearestDoor.DoorData.InX) == 0)
                {
                    Ui.ShowInfo(player, "Drzwi nie mają ustawionego wejścia.");
                    return;
                }

            NAPI.ClientEvent.TriggerClientEvent(player, "client.doors.fadeOut");
        }

        [RemoteEvent("server.interiors.enterInterior")]
        public void Event_EnterInterior(Client player)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            DoorInfo nearestDoor = Library.GetNearestDoor(charData);
            if (nearestDoor == null) return;

            if (nearestDoor.DoorType == DoorType.Out)
            {
                if ((int) Math.Floor(nearestDoor.DoorData.InX) == 0)
                {
                    Ui.ShowInfo(player, "Drzwi nie mają ustawionego wejścia.");
                    return;
                }

                if (!player.IsInVehicle)
                {
                    player.Dimension = (uint) nearestDoor.DoorData.InDim;
                    player.Position = new Vector3(nearestDoor.DoorData.InX, nearestDoor.DoorData.InY,
                        nearestDoor.DoorData.InZ);
                    player.Rotation = new Vector3(0, 0, nearestDoor.DoorData.InAngle);
                }
            }
            else if (nearestDoor.DoorType == DoorType.In)
            {
                if (!player.IsInVehicle)
                {
                    player.Dimension = (uint) nearestDoor.DoorData.OutDim;
                    player.Position = new Vector3(nearestDoor.DoorData.OutX, nearestDoor.DoorData.OutY,
                        nearestDoor.DoorData.OutZ);
                    player.Rotation = new Vector3(0, 0, nearestDoor.DoorData.OutAngle);
                }
            }

            NAPI.ClientEvent.TriggerClientEvent(player, "client.doors.fadeIn");
        }

        [RemoteEvent("server.interiors.createNew")]
        public void Event_CreateNew(Client player)
        {
        }

        [RemoteEvent("server.interiors.editInPos")]
        public void Event_EditInPos(Client player)
        {
        }

        [RemoteEvent("server.interiors.editOutPos")]
        public void Event_EditOutPos(Client player)
        {
        }

        [RemoteEvent("server.interiors.addNewDoors")]
        public void Event_AddNewDoors(Client player)
        {
        }
    }
}