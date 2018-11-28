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
using LSVRP.Libraries;
using Object = LSVRP.Database.Models.Object;

namespace LSVRP.Features.Objects
{
    public class RemoteEvents : Script
    {
        [RemoteEvent("server.objects.save")]
        public void EventSaveObject(Client player, int remoteId, float pX, float pY, float pZ, float rX, float rY,
            float rZ)
        {
            Object objectData = Library.GetObjectDataByRemoteId(remoteId);
            if (objectData == null)
            {
                Ui.ShowError(player, "Nie znaleziono takiego obiektu.");
                return;
            }

            if (objectData.EditedBy != player)
            {
                Ui.ShowError(player, "Nie Ty edytowałeś ten obiekt.");
                return;
            }

            objectData.EditedBy = null;

            objectData.PosX = pX;
            objectData.PosY = pY;
            objectData.PosZ = pZ;

            objectData.RotX = rX;
            objectData.RotY = rY;
            objectData.RotZ = rZ;

            objectData.ObjectHandle.Position = new Vector3(pX, pY, pZ);
            objectData.ObjectHandle.Rotation = new Vector3(rX, rY, rZ);

            objectData.Save();

            Ui.ShowInfo(player, "Obiekt został edytowany.");
        }

        [RemoteEvent("client.objects.canceledit")]
        public void EventCancelEditObject(Client player, int remoteId)
        {
            Object objectData = Library.GetObjectDataByRemoteId(remoteId);
            if (objectData == null)
            {
                Ui.ShowError(player, "Nie znaleziono takiego obiektu.");
                return;
            }

            if (objectData.EditedBy != player)
            {
                Ui.ShowError(player, "Nie Ty edytowałeś ten obiekt.");
                return;
            }

            objectData.EditedBy = null;
            Ui.ShowInfo(player, "Edycja obiektu została anulowana.");
        }
    }
}