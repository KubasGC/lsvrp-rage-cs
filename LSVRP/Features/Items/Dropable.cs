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
    public class Dropable
    {
        public enum ItemDroppableObjects
        {
            UndefinedObjectHash = 765087784,
            UndefinedMelee = -1620734287,
            UndefinedGun = 138777325,
            CorpseHash = -935625561,

            GunPistol = 1467525553,
            GunCombatpistol = 403140669,
            GunFlaregun = 1349014803,
            GunStungun = 1609356763,
            GunAppistol = 905830540,
            GunVintagepistol = -1124046276,
            GunPdw = -473574177,
            GunMachinepistol = UndefinedGun,
            GunHeavypistol = 1927398017,
            GunPistol50 = -178484015,
            GunSnspistol = 339962010,
            GunRevolver = UndefinedGun,

            GunBullup = -1288559573,
            GunCombatmg = -739394447,
            GunGusenberg = 574348740,
            GunCompactrifle = UndefinedGun,
            GunMinigun = 422658457,
            GunSmg = -500057996,
            GunMicrosmg = -1056713654,
            GunCompactlauncher = UndefinedGun,
            GunAssaultsmg = -473574177,
            GunMg = -2056364402,
            GunMusket = 1652015642,
            GunCarbinerifle = 1026431720,
            GunAdvancedrifle = -1707584974,
            GunMinismg = UndefinedGun,
            GunAssaultrifle = 273925117,
            GunSpecialcarbine = -1745643757,

            GunPumpshotgun = 689760839,
            GunSawnoffshotgun = -675841386,
            GunHeavyshotgun = -1209868881,
            GunBullupshotgun = -1598212834,
            GunAutoshotgun = UndefinedGun,
            GunDoublebarrelshotgun = UndefinedGun,
            GunAssaultshotgun = 1255410010,

            GunFlare = -1564193152,
            GunPetrolcan = 242383520,
            GunStickybomb = 848107085,
            GunMolotov = -880609331,
            GunSmokegrenade = 1591549914,
            GunGrenade = 290600267,
            GunBzgas = UndefinedGun,
            GunProximitymine = 1876445962,
            GunPipebomb = UndefinedGun,

            GunNightstick = -1634978236,
            GunHammer = 64104227,
            GunGolfclub = -580196246,
            GunBall = -383950123,
            GunWrench = UndefinedMelee,
            GunSnowball = 1297482736,
            GunFireextungisher = -171327159,
            GunHatchet = 1653948529,
            GunBottle = -789123952,
            GunParachute = 643651670,
            GunMachete = -2055486531,
            GunSwitchblade = UndefinedMelee,
            GunKnuckleduster = UndefinedMelee,
            GunBattleaxe = UndefinedMelee,
            GunCrowbar = 1862268168,
            GunFlashlight = 1110740384,
            GunDagger = 601713565,
            GunPoolcue = 1184113278,
            GunBat = 32653987,
            GunKnife = -1982443329,

            GunRailgun = -1876506235,
            GunRpg = -218858073,
            GunFirework = 491091384,

            GunHeavysniper = -746966080,
            GunSniperrifle = 346403307,
            GunMarksmanrifle = -1711248638
        }

        public static readonly Dictionary<int, int> WeaponDroppableObjects = new Dictionary<int, int>
        {
            {0, (int) ItemDroppableObjects.UndefinedMelee},
            {1, (int) ItemDroppableObjects.GunBat},
            {2, (int) ItemDroppableObjects.GunKnife},
            {3, (int) ItemDroppableObjects.GunNightstick},
            {4, (int) ItemDroppableObjects.GunCrowbar},
            {5, (int) ItemDroppableObjects.GunGolfclub},
            {6, (int) ItemDroppableObjects.GunHammer},
            {7, (int) ItemDroppableObjects.GunBottle},
            {8, (int) ItemDroppableObjects.GunDagger},
            {9, (int) ItemDroppableObjects.GunHatchet},
            {10, (int) ItemDroppableObjects.GunKnuckleduster},
            {11, (int) ItemDroppableObjects.GunMachete},
            {12, (int) ItemDroppableObjects.GunFlashlight},
            {13, (int) ItemDroppableObjects.GunSwitchblade},
            {14, (int) ItemDroppableObjects.GunPoolcue},
            {15, (int) ItemDroppableObjects.GunWrench},
            {16, (int) ItemDroppableObjects.GunBattleaxe},
            {17, (int) ItemDroppableObjects.GunPistol},
            {18, (int) ItemDroppableObjects.GunCombatpistol},
            {19, (int) ItemDroppableObjects.GunAppistol},
            {20, (int) ItemDroppableObjects.GunStungun},
            {21, (int) ItemDroppableObjects.GunPistol},
            {22, (int) ItemDroppableObjects.GunSnspistol},
            {23, (int) ItemDroppableObjects.GunHeavypistol},
            {24, (int) ItemDroppableObjects.GunVintagepistol},
            {25, (int) ItemDroppableObjects.GunFlaregun},
            {26, (int) ItemDroppableObjects.GunMachinepistol},
            {27, (int) ItemDroppableObjects.GunRevolver},
            {28, (int) ItemDroppableObjects.GunMicrosmg},
            {29, (int) ItemDroppableObjects.GunSmg},
            {30, (int) ItemDroppableObjects.GunAssaultsmg},
            {31, (int) ItemDroppableObjects.GunPdw},
            {32, (int) ItemDroppableObjects.GunMachinepistol},
            {33, (int) ItemDroppableObjects.GunMinismg},
            {34, (int) ItemDroppableObjects.GunPumpshotgun},
            {35, (int) ItemDroppableObjects.GunSawnoffshotgun},
            {36, (int) ItemDroppableObjects.GunAssaultshotgun},
            {37, (int) ItemDroppableObjects.GunBullupshotgun},
            {38, (int) ItemDroppableObjects.GunMusket},
            {39, (int) ItemDroppableObjects.GunHeavyshotgun},
            {40, (int) ItemDroppableObjects.GunDoublebarrelshotgun},
            {41, (int) ItemDroppableObjects.GunAutoshotgun},
            {42, (int) ItemDroppableObjects.GunAssaultrifle},
            {43, (int) ItemDroppableObjects.GunCarbinerifle},
            {44, (int) ItemDroppableObjects.GunAdvancedrifle},
            {45, (int) ItemDroppableObjects.GunSpecialcarbine},
            {46, (int) ItemDroppableObjects.GunBullup},
            {47, (int) ItemDroppableObjects.GunCompactrifle},
            {48, (int) ItemDroppableObjects.GunMg},
            {49, (int) ItemDroppableObjects.GunCombatmg},
            {50, (int) ItemDroppableObjects.GunGusenberg},
            {51, (int) ItemDroppableObjects.GunSniperrifle},
            {52, (int) ItemDroppableObjects.GunHeavysniper},
            {53, (int) ItemDroppableObjects.GunMarksmanrifle},
            {54, (int) ItemDroppableObjects.GunRpg},
            {55, (int) ItemDroppableObjects.UndefinedGun},
            {56, (int) ItemDroppableObjects.GunMinigun},
            {57, (int) ItemDroppableObjects.GunFirework},
            {58, (int) ItemDroppableObjects.GunRailgun},
            {59, (int) ItemDroppableObjects.UndefinedGun},
            {60, (int) ItemDroppableObjects.GunCompactlauncher},
            {61, (int) ItemDroppableObjects.GunGrenade},
            {62, (int) ItemDroppableObjects.GunBzgas},
            {63, (int) ItemDroppableObjects.GunMolotov},
            {64, (int) ItemDroppableObjects.GunStickybomb},
            {65, (int) ItemDroppableObjects.GunProximitymine},
            {66, (int) ItemDroppableObjects.GunSnowball},
            {67, (int) ItemDroppableObjects.GunPipebomb},
            {68, (int) ItemDroppableObjects.GunPetrolcan},
            {69, (int) ItemDroppableObjects.GunParachute},
            {70, (int) ItemDroppableObjects.GunFireextungisher}
        };

        public static int GetHashFromItem(ItemType itemType, int itemValue)
        {
            if (itemType == ItemType.Weapon)
                return WeaponDroppableObjects.ContainsKey(itemValue)
                    ? WeaponDroppableObjects[itemValue]
                    : (int) ItemDroppableObjects.UndefinedGun;

            return (int) ItemDroppableObjects.UndefinedObjectHash;
        }
    }
}