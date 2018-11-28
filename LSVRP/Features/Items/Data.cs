///*
//* LSVRP C# Engine
//* Script dedicated for Role-play server in Grand Theft Auto V game based on the external Multiplayer called Rage Multiplayer.
//* @Author: Kubas (Jakub Skakuj)
//* @StartDate: Jun 2018
//*
//* @urls:
//* 		@RAGE-MP  	    https://rage.mp
//* 		@LSVRP:			https://lsvrp.pl
//*
//* All Rights Reserved
//* Copyright prohibited
//*/
//using System;
//using System.Collections.Generic;
//using GTANetworkAPI;
//
//namespace LSVRP.Features.Items
//{
//    /*public static class Data
//    {
//        public static readonly Dictionary<int, WeaponHash> WeaponHashes = new Dictionary<int, WeaponHash>
//        {
//            {1, WeaponHash.Bat},
//            {2, WeaponHash.Knife},
//            {3, WeaponHash.Nightstick},
//            {4, WeaponHash.Crowbar},
//            {5, WeaponHash.GolfClub},
//            {6, WeaponHash.Hammer},
//            {7, WeaponHash.Bottle},
//            {8, WeaponHash.Dagger},
//            {9, WeaponHash.Hatchet},
//            {10, WeaponHash.KnuckleDuster},
//            {11, WeaponHash.Machete},
//            {12, WeaponHash.Flashlight},
//            {13, WeaponHash.SwitchBlade},
//            {14, WeaponHash.PoolCue},
//            {15, WeaponHash.Wrench},
//            {16, WeaponHash.BattleAxe},
//            {17, WeaponHash.Pistol},
//            {18, WeaponHash.CombatPistol},
//            {19, WeaponHash.APPistol},
//            {20, WeaponHash.StunGun},
//            {21, WeaponHash.Pistol50},
//            {22, WeaponHash.SNSPistol},
//            {23, WeaponHash.HeavyPistol},
//            {24, WeaponHash.VintagePistol},
//            {25, WeaponHash.FlareGun},
//            {26, WeaponHash.MarksmanPistol},
//            {27, WeaponHash.Revolver},
//            {28, WeaponHash.MicroSMG},
//            {29, WeaponHash.SMG},
//            {30, WeaponHash.AssaultSMG},
//            {31, WeaponHash.CombatPDW},
//            {32, WeaponHash.MachinePistol},
//            {33, WeaponHash.MiniSMG},
//            {34, WeaponHash.PumpShotgun},
//            {35, WeaponHash.SawnOffShotgun},
//            {36, WeaponHash.AssaultShotgun},
//            {37, WeaponHash.BullpupShotgun},
//            {38, WeaponHash.Musket},
//            {39, WeaponHash.HeavyShotgun},
//            {40, WeaponHash.DoubleBarrelShotgun},
//            {41, WeaponHash.AssaultShotgun},
//            {42, WeaponHash.AssaultRifle},
//            {43, WeaponHash.CarbineRifle},
//            {44, WeaponHash.AdvancedRifle},
//            {45, WeaponHash.SpecialCarbine},
//            {46, WeaponHash.BullpupRifle},
//            {47, WeaponHash.CompactRifle},
//            {48, WeaponHash.MG},
//            {49, WeaponHash.CombatMG},
//            {50, WeaponHash.Gusenberg},
//            {51, WeaponHash.SniperRifle},
//            {52, WeaponHash.HeavySniper},
//            {53, WeaponHash.MarksmanRifle},
//            {54, WeaponHash.RPG},
//            {55, WeaponHash.GrenadeLauncher},
//            {56, WeaponHash.Minigun},
//            {57, WeaponHash.Firework},
//            {58, WeaponHash.Railgun},
//            {59, WeaponHash.HomingLauncher},
//            {60, WeaponHash.CompactGrenadeLauncher},
//            {61, WeaponHash.Grenade},
//            {62, WeaponHash.BZGas},
//            {63, WeaponHash.Molotov},
//            {64, WeaponHash.StickyBomb},
//            {65, WeaponHash.ProximityMine},
//            {66, WeaponHash.Snowball},
//            {67, WeaponHash.PipeBomb},
//            {68, WeaponHash.PetrolCan},
//            {69, WeaponHash.Parachute},
//            {70, WeaponHash.FireExtinguisher}
//        };
//
//        public static readonly Dictionary<ItemType, string> ItemTypesName = new Dictionary<ItemType, string>
//        {
//            {ItemType.Alcohol, "Alkohol"},
//            {ItemType.Ammo, "Amunicja"},
//            {ItemType.Armor, "Kamizelka kuloodporna"},
//            {ItemType.Body, "Zwłoki"},
//            {ItemType.Canister, "Kanister"},
//            {ItemType.Carmod, "Część tuningowa"},
//            {ItemType.Cigarette, "Papierosy"},
//            {ItemType.Cruise, "Tempomat"},
//            {ItemType.Cube, "Kostka do gry"},
//            {ItemType.Drink, "Napój"},
//            {ItemType.Drugs, "Narkotyk"},
//            {ItemType.Food, "Jedzenie"},
//            {ItemType.Mask, "Maska"},
//            {ItemType.Medicine, "Lek"},
//            {ItemType.Megaphone, "Megafon"},
//            {ItemType.Paint, "Lakier"},
//            {ItemType.Phone, "Telefon"},
//            {ItemType.PlayingCards, "Karty do gry"},
//            {ItemType.Skin, "Skin"},
//            {ItemType.Weapon, "Broń"}
//        };
//    }*/
//
//    /*[Serializable]
//    public class ClientItem
//    {
//        public ClientItem(int itemId, string itemName, bool itemUsed)
//        {
//            Id = itemId;
//            Name = itemName;
//            Used = itemUsed;
//        }
//
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public bool Used { get; set; }
//    }*/
//}