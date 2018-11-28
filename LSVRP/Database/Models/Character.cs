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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading;
using GTANetworkAPI;
using LSVRP.Features.Animations;
using LSVRP.Features.Base;
using LSVRP.Features.Groups;
using LSVRP.Features.Items;
using LSVRP.Features.Jobs;
using LSVRP.Libraries;
using LSVRP.Managers;
using LSVRP.New.Enums;
using LSVRP.New.Helpers;
using Newtonsoft.Json;
using Library = LSVRP.Features.Drugs.Library;
using LogType = LSVRP.Modules.LogType;

namespace LSVRP.Database.Models
{
    [Table("lsvrp_characters")]
    public class Character
    {
        [Key] public int Id { get; set; }
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public CharSex Sex { get; set; }
        public int Cash { get; set; }
        public int OnlineTime { get; set; }
        public int AfkTime { get; set; }
        public int BwTime { get; set; }
        [Column("ShortDNA")] public string ShortDna { get; set; }
        [Column("DNA")] public string Dna { get; set; }
        public double Health { get; set; }
        public string DefaultSkinName { get; set; }
        public string SkinName { get; set; }
        [Column("dimension")] public int Dimension { get; set; }
        [Column("lastX")] public float LastX { get; set; }
        [Column("lastY")] public float LastY { get; set; }
        [Column("lastZ")] public float LastZ { get; set; }
        public bool InGame { get; set; }
        public int LoginCount { get; set; }
        public bool Blocked { get; set; }
        [Column("JobID")] public JobType JobId { get; set; }
        [Column("AccountID")] public long AccountId { get; set; }
        public int AccountBalance { get; set; }
        public int MotherSkin { get; set; }
        public int FatherSkin { get; set; }
        public int MotherModel { get; set; }
        public int FatherModel { get; set; }
        public int HairModel { get; set; }
        public int HairColor { get; set; }
        public int Wardrobe { get; set; }
        public int LastLogin { get; set; }
        public string SkinData { get; set; }
        public bool DriverLicense { get; set; }
        public int DriverLicenseDate { get; set; }
        [Column("SSN")] public int Ssn { get; set; }
        [Column("SSNDate")] public int? SsnDate { get; set; }
        public int SpawnType { get; set; }
        public int SpawnInfo { get; set; }
        public int AdminJailTime { get; set; }
        public int? DefaultSpawn { get; set; }
        [Column("OOCBlockTime")] public int OocBlockTime { get; set; }
        public int VehicleBlockTime { get; set; }
        public bool Tutorial { get; set; }
        [Column("detentionDoorId")] public int DetentionDoorId { get; set; }
        [Column("FaceID")] public int FaceId { get; set; }
        public int HairStyle { get; set; }
        public int SkinColor { get; set; }
        public int LastCustomization { get; set; }
        public int LastDoors { get; set; }
        public int FishLimit { get; set; }
        public int LastFishing { get; set; }
        public float NoseTip { get; set; }
        public int MotherId { get; set; }
        public int FatherId { get; set; }
        public int HairId { get; set; }
        public float ShapeMix { get; set; }
        public float SkinMix { get; set; }
        public int Blemishes { get; set; }
        public int FacialHair { get; set; }
        public int EyeBrows { get; set; }
        public int OverlayColor { get; set; }
        public float NoseWidth { get; set; }
        public float NoseHeight { get; set; }
        public float NoseLength { get; set; }
        public float NoseBridge { get; set; }
        public float NoseBridgeShift { get; set; }
        public int ClothSet { get; set; }
        [Column("creator")] public bool Creator { get; set; }
        public int DetentionTime { get; set; }
        public int BlockSpeed { get; set; }
        public int WalkingStyle { get; set; }
        public int Strength { get; set; }

        [NotMapped] public Client PlayerHandle { get; set; }
        [NotMapped] public int ServerId { get; set; }
        [NotMapped] public string GlobalName { get; set; }
        [NotMapped] public int AdminLevel { get; set; }
        [NotMapped] public List<object> AdminPerm { get; set; }
        [NotMapped] public bool Spawned { get; set; }
        [NotMapped] public bool HasAdminDuty { get; set; }
        [NotMapped] public bool HasMask { get; set; }
        [NotMapped] public bool HasCustomName { get; set; }
        [NotMapped] public string CustomName { get; set; }
        [NotMapped] public Client LastWhisper { get; set; }
        [NotMapped] public bool WhisperBlock { get; set; }
        [NotMapped] public List<GroupMember> Groups { get; set; }
        [NotMapped] public bool EmergencyBlip { get; set; }
        [NotMapped] public int VisualPoints { get; set; }
        [NotMapped] public int DonateTime { get; set; }
        [NotMapped] public CuffData Cuff { get; set; }
        [NotMapped] public bool RadioBlock { get; set; }
        [NotMapped] public bool HasInvisibleEnabled { get; set; }
        [NotMapped] public Dictionary<Account.ServerData, object> ServerData { get; set; }
        [NotMapped] public string WalkingStyleAnim { get; set; }
        [NotMapped] public bool IsCrouching { get; set; }
        [NotMapped] public int LastCrouchChange { get; set; }
        [NotMapped] public List<Features.Tattoos.Tattoo> Tattoos { get; set; }
        [NotMapped] public List<int> SyncedTattoos { get; set; }
        [NotMapped] public Item UsedWeapon { get; set; }
        [NotMapped] public CharacterDrugAddictions DrugAddictions { get; set; }
        [NotMapped] public int CornerId { get; set; }
        [NotMapped] public Dictionary<int, ComponentVariation> ComponentVariations { get; set; }
        [NotMapped] public CharacterLook SkinLook { get; set; }
        [NotMapped] public AnimPlayer AnimPlayer { get; set; }
        [NotMapped] public bool IsFlying { get; set; }
        [NotMapped] public System.Timers.Timer VehicleTimer { get; set; }

        public void LoadSkin()
        {
            using (Database db = new Database())
            {
                SkinLook = db.CharactersLook.FirstOrDefault(t => t.CharId == Id);
            }
        }

        public void Save()
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                LastX = PlayerHandle.Position.X;
                LastY = PlayerHandle.Position.Y;
                LastZ = PlayerHandle.Position.Z;

                SaveDrugs();
                using (Database db = new Database())
                {
                    db.Characters.Update(this);
                    db.SaveChanges();
                    Modules.Log.ConsoleLog("CHARACTER", $"Zapisano gracza {Player.GetPlayerDebugName(this)}",
                        LogType.Debug);
                }
            });

            /*new Thread(() =>
            {
                LastX = PlayerHandle.Position.X;
                LastY = PlayerHandle.Position.Y;
                LastZ = PlayerHandle.Position.Z;

                SaveDrugs();
                using (Database db = new Database())
                {
                    db.Characters.Update(this);
                    db.SaveChanges();
                    Modules.Log.ConsoleLog("CHARACTER", $"Zapisano gracza {Player.GetPlayerDebugName(this)}",
                        LogType.Debug);
                }
            }).Start();*/
        }

        public async void SaveAsync()
        {
            LastX = PlayerHandle.Position.X;
            LastY = PlayerHandle.Position.Y;
            LastZ = PlayerHandle.Position.Z;

            using (Database db = new Database())
            {
                db.Characters.Update(this);
                await db.SaveChangesAsync();
                Modules.Log.ConsoleLog("CHARACTER", $"Zapisano gracza {Player.GetPlayerDebugName(this)}",
                    LogType.Debug);
            }
        }

        /// <summary>
        /// Laduje uzależnienia gracza od narkotyków z bazy danych.
        /// </summary>
        public void LoadDrugs()
        {
            using (Database db = new Database())
            {
                DrugAddictions = db.CharactersDrugAddictions.FirstOrDefault(t => t.CharId == Id);
                if (DrugAddictions == null)
                {
                    DrugAddictions = new CharacterDrugAddictions
                    {
                        CharId = Id,
                        Amphetamine = 0,
                        Cocaine = 0,
                        Hash = 0,
                        Heroin = 0,
                        Lsd = 0,
                        Marijuana = 0,
                        MetaAmphetamine = 0,
                        Opium = 0
                    };

                    db.CharactersDrugAddictions.Add(DrugAddictions);
                    db.SaveChanges();
                }
            }
        }

        public void DoDrugEffects()
        {
            Library.StopAllEffectsForPlayer(PlayerHandle);

            // Uruchamianie efektów marihuanny.
            if (DrugAddictions.MarijuanaTime > 0)
            {
                Library.StartEffectForPlayer(PlayerHandle, 20);
                Library.StartEffectForPlayer(PlayerHandle, 15);
            }

            // Uruchamianie efektów kokainy.
            if (DrugAddictions.CocaineTime > 0)
            {
                Library.StartEffectForPlayer(PlayerHandle, 25);
                Library.StartEffectForPlayer(PlayerHandle, 4);
            }

            // Uruchamianie efektów LSD.
            if (DrugAddictions.LsdTime > 0)
            {
                Library.StartEffectForPlayer(PlayerHandle, 21);
                Library.StartEffectForPlayer(PlayerHandle, 22);
            }

            // Uruchamianie efektów opium.
            if (DrugAddictions.OpiumTime > 0) Library.StartEffectForPlayer(PlayerHandle, 14);

            // Uruchamianie efektów amfetaminy.
            if (DrugAddictions.AmphetamineTime > 0) Library.StartEffectForPlayer(PlayerHandle, 7);

            // Uruchamianie efektów metaamfetaminy.
            if (DrugAddictions.MetaAmphetamineTime > 0) Library.StartEffectForPlayer(PlayerHandle, 12);
        }

        /// <summary>
        /// Zapisuje aktualne uzależnienie narkotykami.
        /// </summary>
        public void SaveDrugs()
        {
            if (DrugAddictions == null) return;
            using (Database db = new Database())
            {
                db.CharactersDrugAddictions.Update(DrugAddictions);
                db.SaveChanges();
            }
        }

        public string GetBlendSync()
        {
            return JsonConvert.SerializeObject(new List<float>
            {
                SkinLook.Father,
                SkinLook.Mother,
                SkinLook.SkinMix,
                SkinLook.ColorMix,
                SkinLook.Beard,
                SkinLook.BeardColor,
                SkinLook.Hair,
                SkinLook.HairColor,
                SkinLook.Eyebrows,
                SkinLook.EyebrowsColor,
                SkinLook.Scars,
                SkinLook.Aging,
                SkinLook.Makeup,
                SkinLook.Blush,
                SkinLook.BlushColor,
                SkinLook.Complexion,
                SkinLook.Burns,
                SkinLook.Lipstick,
                SkinLook.LipstickColor,
                SkinLook.Freckles,
                SkinLook.Chesthair,
                SkinLook.ChesthairColor,
                SkinLook.NoseWidth,
                SkinLook.NoseHeight,
                SkinLook.NoseLength,
                SkinLook.NoseBridge,
                SkinLook.NoseEnd,
                SkinLook.NoseShift,
                SkinLook.EyebrowsHeight,
                SkinLook.EyebrowsWidth,
                SkinLook.BoneHeight,
                SkinLook.BoneWidth,
                SkinLook.CheeksWidth,
                SkinLook.EyesWidth,
                SkinLook.LipsWidth,
                SkinLook.JawWidth,
                SkinLook.JawHeight,
                SkinLook.ChinLength,
                SkinLook.ChinPosition,
                SkinLook.ChinWidth,
                SkinLook.ChinShape,
                SkinLook.NeckLength,

                ComponentVariations[3].Drawable, // TorsoId
                ComponentVariations[4].Drawable, // Legs
                ComponentVariations[4].Texture, // LegsTexture
                ComponentVariations[6].Drawable, // Boots
                ComponentVariations[6].Texture, // BootsTexture
                ComponentVariations[7].Drawable, // Accessories
                ComponentVariations[7].Texture, // AccessoriesTexture
                ComponentVariations[8].Drawable, // Undershirt
                ComponentVariations[8].Texture, // UndershirtTexture
                ComponentVariations[11].Drawable, // Tops
                ComponentVariations[11].Texture // TopsTexture
            });
        }

        public void SendInfo(string message)
        {
            Ui.ShowInfo(PlayerHandle, message);
        }

        public void SendWarning(string message)
        {
            Ui.ShowWarning(PlayerHandle, message);
        }

        public void SendError(string message)
        {
            Ui.ShowError(PlayerHandle, message);
        }

        public void SendUsage(string message)
        {
            Ui.ShowUsage(PlayerHandle, message);
        }

        public int GetUsedGuns()
        {
            return this.GetPlayerUsedWeaponsCount();
        }

        public void SendActionMessage(string message, bool system = false)
        {
            Features.Chat.Library.SendPlayerMeMessage(this, message, system);
        }
        
        public bool HasItemType(ItemType itemType)
        {
            return ItemsHelper.DoesCharacterHasItemType(this, itemType);
        }
        
        public bool HasItemTypeUsed(ItemType itemType)
        {
            return ItemsHelper.DoesCharacterHasItemTypeUsed(this, itemType);
        }
    }
}