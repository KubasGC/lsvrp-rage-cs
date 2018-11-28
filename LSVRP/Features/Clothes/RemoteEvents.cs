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
using System.Linq;
using GTANetworkAPI;
using LSVRP.Database.Models;
using LSVRP.Features.Base;
using LSVRP.Features.Offers;
using LSVRP.Libraries;
using LSVRP.Managers;

namespace LSVRP.Features.Clothes
{
    public class RemoteEvents : Script
    {
        [RemoteEvent("server.creator.saveFace")]
        public void SaveFace(Client player, int mother, int father, float skinMix, float colorMix, int beard,
            int beardColor, int eyeBrows, int eyeBrowsColor, int scars, int aging, int makeUp, int blush,
            int blushColor, int complexion, int burns, int lips, int lipsColor, int freckles, int bodyHair,
            int bodyHairColor, float noseWidth, float noseHeight, float noseLength, float noseBridge, float noseEnd,
            float noseShift, float eyeBrowsHeight, float eyeBrowsWidth, float boneHeight, float boneWidth,
            float cheeksWidth, float eyesWidth, float lipsWidth, float jawWidth, float jawHeight, float chinLength,
            float chinPosition, float chinWidth, float chinShape, float neckLength, int hair, int hairColor)
        {
            using (Database.Database db = new Database.Database())
            {
                Character charData = Account.GetPlayerData(player);
                if (charData == null) return;

                charData.SkinLook = new CharacterLook();

                charData.SkinLook.Mother = mother;
                charData.SkinLook.Father = father;
                charData.SkinLook.SkinMix = skinMix;
                charData.SkinLook.ColorMix = colorMix;
                charData.SkinLook.Beard = beard;
                charData.SkinLook.BeardColor = beardColor;
                charData.SkinLook.Eyebrows = eyeBrows;
                charData.SkinLook.EyebrowsColor = eyeBrowsColor;
                charData.SkinLook.Scars = scars;
                charData.SkinLook.Aging = aging;
                charData.SkinLook.Makeup = makeUp;
                charData.SkinLook.Blush = blush;
                charData.SkinLook.BlushColor = blushColor;
                charData.SkinLook.Complexion = complexion;
                charData.SkinLook.Burns = burns;
                charData.SkinLook.Lipstick = lips;
                charData.SkinLook.LipstickColor = lipsColor;
                charData.SkinLook.Freckles = freckles;
                charData.SkinLook.Chesthair = bodyHair;
                charData.SkinLook.ChesthairColor = bodyHairColor;
                charData.SkinLook.NoseWidth = noseWidth;
                charData.SkinLook.NoseHeight = noseHeight;
                charData.SkinLook.NoseLength = noseLength;
                charData.SkinLook.NoseBridge = noseBridge;
                charData.SkinLook.NoseEnd = noseEnd;
                charData.SkinLook.NoseShift = noseShift;
                charData.SkinLook.EyebrowsHeight = eyeBrowsHeight;
                charData.SkinLook.EyebrowsWidth = eyeBrowsWidth;
                charData.SkinLook.BoneHeight = boneHeight;
                charData.SkinLook.BoneWidth = boneWidth;
                charData.SkinLook.CheeksWidth = cheeksWidth;
                charData.SkinLook.EyesWidth = eyesWidth;
                charData.SkinLook.LipsWidth = lipsWidth;
                charData.SkinLook.JawWidth = jawWidth;
                charData.SkinLook.JawHeight = jawHeight;
                charData.SkinLook.ChinLength = chinLength;
                charData.SkinLook.ChinPosition = chinPosition;
                charData.SkinLook.ChinWidth = chinWidth;
                charData.SkinLook.ChinShape = chinShape;
                charData.SkinLook.NeckLength = neckLength;
                charData.SkinLook.CharId = charData.Id;
                charData.SkinLook.Hair = hair;
                charData.SkinLook.HairColor = hairColor;

                IQueryable<CharacterLook> characterLooks = db.CharactersLook.Where(t => t.CharId == charData.Id);
                if (characterLooks.Any())
                    foreach (CharacterLook entry in characterLooks.ToList())
                        db.CharactersLook.Remove(entry);

                db.CharactersLook.Add(charData.SkinLook);
                db.SaveChanges();

                Player.SendFormattedChatMessage(charData.PlayerHandle, "Zapisano wygląd postaci.",
                    Constants.ColorPictonBlue);
                NAPI.ClientEvent.TriggerClientEvent(charData.PlayerHandle, "client.charCreator.toggle", false);
                Player.SpawnPlayer(charData.PlayerHandle);
            }
        }

        [RemoteEvent("server.creator.saveBinco")]
        public void SaveBinco(Client player, int torso, int legs, int legsColor, int boots, int bootsColor, int
            undershirt, int undershirtColor, int top, int topColor)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            NAPI.ClientEvent.TriggerClientEvent(player, "client.charBinco.toggle", false,
                charData.Sex == CharSex.Male ? 0 : 1);

            ClothSet clothSet = new ClothSet
            {
                CharId = charData.Id,
                Name = "Ubranie",
                TorsoId = torso,
                Legs = legs,
                LegsTexture = legsColor,
                Boots = boots,
                BootsTexture = bootsColor,
                Undershirt = undershirt,
                UndershirtTexture = undershirtColor,
                Tops = top,
                TopsTexture = topColor
            };


            Dictionary<string, object> offerData = new Dictionary<string, object>
            {
                {"clothSet", clothSet}
            };

            Offers.Library.CreateOffer(null, charData.PlayerHandle, OfferType.BincoCloth, 1000, offerData,
                "Zestaw ubrań", true);
            Sync.Library.SyncPlayerForPlayer(charData.PlayerHandle);
        }

        [RemoteEvent("server.creator.cancel")]
        public void CreatorCancel(Client player, int creatorType)
        {
            Character charData = Account.GetPlayerData(player);
            if (charData == null) return;

            if (creatorType == 0) // Tworzenie mordy
            {
            }
            else if (creatorType == 1) // Tworzenie ubrania
            {
                Ui.ShowInfo(player, "Przerwałeś tworzenie ubrania w kreatorze.");
                Sync.Library.SyncPlayerForPlayer(player);
            }
        }
    }
}