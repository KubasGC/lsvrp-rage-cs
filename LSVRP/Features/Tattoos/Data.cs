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
using System.Collections.Generic;
using LSVRP.Features.Base;

namespace LSVRP.Features.Tattoos
{
    public static class Data
    {
        public static readonly Dictionary<int, TattooRow> TattoosList = new Dictionary<int, TattooRow>
        {
            {
                1,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_000_M", "Bless The Dead", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                2,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_001_M", "Crackshot", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                3,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_002_M", "Dead Lies", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                4,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_003_M", "Give Nothing Back", BodyPart.Back,
                    CharSex.Male)
            },
            {
                5,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_004_M", "Honor", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                6,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_005_M", "Mutiny", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                7,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_006_M", "Never Surrender", BodyPart.Back,
                    CharSex.Male)
            },
            {
                8,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_007_M", "No Honor Among THIEVES",
                    BodyPart.Chest, CharSex.Male)
            },
            {
                9,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_008_M", "Horrors of The Deep",
                    BodyPart.LeftArm, CharSex.Male)
            },
            {
                10,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_009_M", "Tall Ship Conflict", BodyPart.Back,
                    CharSex.Male)
            },
            {
                11,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_010_M", "See You In Hell", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                12,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_011_M", "Sinner", BodyPart.Head, CharSex.Male)
            },
            {
                13,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_012_M", "Thief", BodyPart.Head, CharSex.Male)
            },
            {
                14,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_013_M", "Torn Wings", BodyPart.Back,
                    CharSex.Male)
            },
            {
                15,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_014_M", "Mermaid's Curse", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                16,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_015_M", "Jolly Roger", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                17,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_016_M", "Skull Compass", BodyPart.Back,
                    CharSex.Male)
            },
            {
                18,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_017_M", "Framed Tall Ship", BodyPart.Back,
                    CharSex.Male)
            },
            {
                19,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_018_M", "Finders Keepers", BodyPart.Back,
                    CharSex.Male)
            },
            {
                20,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_019_M", "Lost At Sea", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                21,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_020_M", "Homeward Bound", BodyPart.RightLeg,
                    CharSex.Male)
            },
            {
                22,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_021_M", "Dead Tales", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                23,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_022_M", "X Marks The Spot", BodyPart.Back,
                    CharSex.Male)
            },
            {
                24,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_023_M", "Stylized Kraken", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                25,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_024_M", "Pirate Captain", BodyPart.Back,
                    CharSex.Male)
            },
            {
                26,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_025_M", "Claimed By The Beast", BodyPart.Back,
                    CharSex.Male)
            },
            {
                27,
                new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_000", "Crossed Arrows", BodyPart.Back, CharSex.Male)
            },
            {
                28,
                new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_001", "Single Arrow", BodyPart.RightArm, CharSex.Male)
            },
            {29, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_002", "Chemistry", BodyPart.Chest, CharSex.Male)},
            {
                30,
                new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_003", "Diamond Sparkle", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {31, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_004", "Bone", BodyPart.RightArm, CharSex.Male)},
            {32, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_005", "Beautiful Eye", BodyPart.Head, CharSex.Male)},
            {
                33,
                new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_006", "Feather Birds", BodyPart.Chest, CharSex.Male)
            },
            {34, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_007", "Bricks", BodyPart.LeftArm, CharSex.Male)},
            {35, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_008", "Cube", BodyPart.RightArm, CharSex.Male)},
            {36, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_009", "Squares", BodyPart.LeftLeg, CharSex.Male)},
            {37, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_010", "Horseshoe", BodyPart.RightArm, CharSex.Male)},
            {38, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_011", "Infinity", BodyPart.Back, CharSex.Male)},
            {39, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_012", "Antlers", BodyPart.Back, CharSex.Male)},
            {40, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_013", "Boombox", BodyPart.Chest, CharSex.Male)},
            {41, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_014", "Spray Can", BodyPart.RightArm, CharSex.Male)},
            {42, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_015", "Mustache", BodyPart.LeftArm, CharSex.Male)},
            {
                43,
                new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_016", "Lightning Bolt", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                44,
                new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_017", "Eye Triangle", BodyPart.RightArm, CharSex.Male)
            },
            {45, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_018", "Origami", BodyPart.RightArm, CharSex.Male)},
            {46, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_019", "Charms", BodyPart.LeftLeg, CharSex.Male)},
            {
                47,
                new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_020", "Geo Pattern", BodyPart.RightArm, CharSex.Male)
            },
            {48, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_021", "Geo Fox", BodyPart.Head, CharSex.Male)},
            {49, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_022", "Pencil", BodyPart.RightArm, CharSex.Male)},
            {50, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_023", "Smiley", BodyPart.RightArm, CharSex.Male)},
            {51, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_024", "Pyramid", BodyPart.Back, CharSex.Male)},
            {
                52,
                new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_025", "Watch Your Step", BodyPart.Back, CharSex.Male)
            },
            {53, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_026", "Pizza", BodyPart.LeftArm, CharSex.Male)},
            {54, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_027", "Padlock", BodyPart.LeftArm, CharSex.Male)},
            {
                55,
                new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_028", "Thorny Rose", BodyPart.LeftArm, CharSex.Male)
            },
            {56, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_029", "Sad", BodyPart.Chest, CharSex.Male)},
            {57, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_030", "Shark Fin", BodyPart.Back, CharSex.Male)},
            {58, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_031", "Skateboard", BodyPart.Back, CharSex.Male)},
            {59, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_032", "Paper Plane", BodyPart.Back, CharSex.Male)},
            {60, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_033", "Stag", BodyPart.Chest, CharSex.Male)},
            {61, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_034", "Stop Sign", BodyPart.LeftArm, CharSex.Male)},
            {62, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_035", "Sewn Heart", BodyPart.Chest, CharSex.Male)},
            {63, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_036", "Shapes", BodyPart.RightArm, CharSex.Male)},
            {64, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_037", "Sunrise", BodyPart.LeftArm, CharSex.Male)},
            {65, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_038", "Grub", BodyPart.RightLeg, CharSex.Male)},
            {66, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_039", "Sleeve", BodyPart.LeftArm, CharSex.Male)},
            {
                67,
                new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_040", "Black Anchor", BodyPart.LeftLeg, CharSex.Male)
            },
            {68, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_041", "Tooth", BodyPart.Back, CharSex.Male)},
            {69, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_042", "Sparkplug", BodyPart.RightLeg, CharSex.Male)},
            {
                70,
                new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_043", "Triangles White", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                71,
                new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_044", "Triangles Black", BodyPart.RightArm,
                    CharSex.Male)
            },
            {72, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_045", "Mesh Band", BodyPart.RightArm, CharSex.Male)},
            {73, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_046", "Triangles", BodyPart.Back, CharSex.Male)},
            {74, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_047", "Cassette", BodyPart.Chest, CharSex.Male)},
            {
                75,
                new TattooRow("mpairraces_overlays", "MP_Airraces_Tattoo_000_M", "Turbulence", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                76,
                new TattooRow("mpairraces_overlays", "MP_Airraces_Tattoo_001_M", "Pilot Skull", BodyPart.Back,
                    CharSex.Male)
            },
            {
                77,
                new TattooRow("mpairraces_overlays", "MP_Airraces_Tattoo_002_M", "Winged Bombshell", BodyPart.Back,
                    CharSex.Male)
            },
            {
                78,
                new TattooRow("mpairraces_overlays", "MP_Airraces_Tattoo_003_M", "Toxic Trails", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                79,
                new TattooRow("mpairraces_overlays", "MP_Airraces_Tattoo_004_M", "Balloon Pioneer", BodyPart.Back,
                    CharSex.Male)
            },
            {
                80,
                new TattooRow("mpairraces_overlays", "MP_Airraces_Tattoo_005_M", "Parachute Belle", BodyPart.Back,
                    CharSex.Male)
            },
            {
                81,
                new TattooRow("mpairraces_overlays", "MP_Airraces_Tattoo_006_M", "Bombs Away", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                82,
                new TattooRow("mpairraces_overlays", "MP_Airraces_Tattoo_007_M", "Eagle Eyes", BodyPart.Back,
                    CharSex.Male)
            },
            {83, new TattooRow("mpbeach_overlays", "MP_Bea_M_Back_000", "Ship Arms", BodyPart.Back, CharSex.Male)},
            {
                84,
                new TattooRow("mpbeach_overlays", "MP_Bea_M_Chest_000", "Tribal Hammerhead", BodyPart.Chest,
                    CharSex.Male)
            },
            {85, new TattooRow("mpbeach_overlays", "MP_Bea_M_Chest_001", "Tribal Shark", BodyPart.Chest, CharSex.Male)},
            {86, new TattooRow("mpbeach_overlays", "MP_Bea_M_Head_000", "Pirate Skull", BodyPart.Head, CharSex.Male)},
            {87, new TattooRow("mpbeach_overlays", "MP_Bea_M_Head_001", "Surf LS", BodyPart.Head, CharSex.Male)},
            {88, new TattooRow("mpbeach_overlays", "MP_Bea_M_Head_002", "Shark", BodyPart.Head, CharSex.Male)},
            {89, new TattooRow("mpbeach_overlays", "MP_Bea_M_Lleg_000", "Tribal Star", BodyPart.LeftLeg, CharSex.Male)},
            {
                90,
                new TattooRow("mpbeach_overlays", "MP_Bea_M_Rleg_000", "Tribal Tiki Tower", BodyPart.RightLeg,
                    CharSex.Male)
            },
            {91, new TattooRow("mpbeach_overlays", "MP_Bea_M_RArm_000", "Tribal Sun", BodyPart.RightArm, CharSex.Male)},
            {92, new TattooRow("mpbeach_overlays", "MP_Bea_M_LArm_000", "Tiki Tower", BodyPart.LeftArm, CharSex.Male)},
            {
                93,
                new TattooRow("mpbeach_overlays", "MP_Bea_M_LArm_001", "Mermaid L.S.", BodyPart.LeftArm, CharSex.Male)
            },
            {94, new TattooRow("mpbeach_overlays", "MP_Bea_M_Neck_000", "Little Fish", BodyPart.Head, CharSex.Male)},
            {95, new TattooRow("mpbeach_overlays", "MP_Bea_M_Neck_001", "Surfs Up", BodyPart.Head, CharSex.Male)},
            {
                96,
                new TattooRow("mpbeach_overlays", "MP_Bea_M_RArm_001", "Vespucci Beauty", BodyPart.RightArm,
                    CharSex.Male)
            },
            {97, new TattooRow("mpbeach_overlays", "MP_Bea_M_Stom_000", "Swordfish", BodyPart.Chest, CharSex.Male)},
            {98, new TattooRow("mpbeach_overlays", "MP_Bea_M_Stom_001", "Wheel", BodyPart.Chest, CharSex.Male)},
            {
                99,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_000_M", "Bullet Proof", BodyPart.Back,
                    CharSex.Male)
            },
            {
                100,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_001_M", "Crossed Weapons", BodyPart.Back,
                    CharSex.Male)
            },
            {
                101,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_002_M", "Granade", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                102,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_003_M", "Lock & Load", BodyPart.Head,
                    CharSex.Male)
            },
            {
                103,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_004_M", "Sidearm", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                104,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_005_M", "Patriot Skull", BodyPart.LeftLeg,
                    CharSex.Male)
            },
            {
                105,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_006_M", "Combat Skull", BodyPart.RightLeg,
                    CharSex.Male)
            },
            {
                106,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_007_M", "Stylized Tiger", BodyPart.LeftLeg,
                    CharSex.Male)
            },
            {
                107,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_008_M", "Bandolier", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                108,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_009_M", "Butterfly Knife", BodyPart.Back,
                    CharSex.Male)
            },
            {
                109,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_010_M", "Cash Money", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                110,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_011_M", "Death Skull", BodyPart.LeftLeg,
                    CharSex.Male)
            },
            {
                111,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_012_M", "Dollar Daggers", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                112,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_013_M", "Wolf Insignia", BodyPart.Back,
                    CharSex.Male)
            },
            {
                113,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_014_M", "Backstabber", BodyPart.Back,
                    CharSex.Male)
            },
            {
                114,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_015_M", "Spiked Skull", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                115,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_016_M", "Blood Money", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                116,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_017_M", "Dog Tags", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                117,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_018_M", "Dual Wield Skull", BodyPart.Back,
                    CharSex.Male)
            },
            {
                118,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_019_M", "Pistol Wings", BodyPart.Back,
                    CharSex.Male)
            },
            {
                119,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_020_M", "Crowned Weapons", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                120,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_021_M", "Have a Nice Day",
                    BodyPart.RightArm, CharSex.Male)
            },
            {
                121,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_022_M", "Explosive Heart", BodyPart.Back,
                    CharSex.Male)
            },
            {
                122,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_023_M", "Rose Revolver", BodyPart.LeftLeg,
                    CharSex.Male)
            },
            {
                123,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_025_M", "Praying Skull", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                124,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_026_M", "Restless Skull",
                    BodyPart.RightLeg, CharSex.Male)
            },
            {
                125,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_027_M", "Serpent Revolver",
                    BodyPart.LeftArm, CharSex.Male)
            },
            {
                126,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_028_M", "Micro SMG Chain", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                127,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_029_M", "Win Some Lose Some",
                    BodyPart.Chest, CharSex.Male)
            },
            {
                128,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_030_M", "Pistol Ace", BodyPart.RightLeg,
                    CharSex.Male)
            },
            {129, new TattooRow("mphipster_overlays", "FM_Hip_M_Tat_048", "Peace", BodyPart.LeftArm, CharSex.Male)},
            {
                130,
                new TattooRow("mpimportexport_overlays", "MP_MP_ImportExport_Tat_000_M", "Block Back", BodyPart.Back,
                    CharSex.Male)
            },
            {
                131,
                new TattooRow("mpimportexport_overlays", "MP_MP_ImportExport_Tat_001_M", "Power Plant", BodyPart.Back,
                    CharSex.Male)
            },
            {
                132,
                new TattooRow("mpimportexport_overlays", "MP_MP_ImportExport_Tat_002_M", "Turned To Death",
                    BodyPart.Back, CharSex.Male)
            },
            {
                133,
                new TattooRow("mpimportexport_overlays", "MP_MP_ImportExport_Tat_003_M", "Mechanical Sleeve",
                    BodyPart.RightArm, CharSex.Male)
            },
            {
                134,
                new TattooRow("mpimportexport_overlays", "MP_MP_ImportExport_Tat_004_M", "Piston Sleeve",
                    BodyPart.LeftArm, CharSex.Male)
            },
            {
                135,
                new TattooRow("mpimportexport_overlays", "MP_MP_ImportExport_Tat_005_M", "Dialed In", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                136,
                new TattooRow("mpimportexport_overlays", "MP_MP_ImportExport_Tat_006_M", "Engulfed Block",
                    BodyPart.RightArm, CharSex.Male)
            },
            {
                137,
                new TattooRow("mpimportexport_overlays", "MP_MP_ImportExport_Tat_007_M", "Drive Forever",
                    BodyPart.RightArm, CharSex.Male)
            },
            {
                138,
                new TattooRow("mpimportexport_overlays", "MP_MP_ImportExport_Tat_008_M", "Scarlett", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                139,
                new TattooRow("mpimportexport_overlays", "MP_MP_ImportExport_Tat_009_M", "Serpents of Destruction",
                    BodyPart.Back, CharSex.Male)
            },
            {
                140,
                new TattooRow("mpimportexport_overlays", "MP_MP_ImportExport_Tat_010_M", "Take The Wheel",
                    BodyPart.Back, CharSex.Male)
            },
            {
                141,
                new TattooRow("mpimportexport_overlays", "MP_MP_ImportExport_Tat_011_M", "Talk Shit Get Hit",
                    BodyPart.Back, CharSex.Male)
            },
            {
                142,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_000_M", "Demon Rider", BodyPart.Chest, CharSex.Male)
            },
            {
                143,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_001_M", "Both Barrels", BodyPart.Chest, CharSex.Male)
            },
            {
                144,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_002_M", "Rose Tribute", BodyPart.LeftLeg,
                    CharSex.Male)
            },
            {
                145,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_003_M", "Web Rider", BodyPart.Chest, CharSex.Male)
            },
            {
                146,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_004_M", "Dragon's Fury", BodyPart.RightLeg,
                    CharSex.Male)
            },
            {
                147,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_005_M", "Made In America", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                148,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_006_M", "Chopper Freedom", BodyPart.Back,
                    CharSex.Male)
            },
            {
                149,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_007_M", "Swooping Eagle", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                150,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_008_M", "Freedom Wheels", BodyPart.Back,
                    CharSex.Male)
            },
            {
                151,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_009_M", "Morbid Arachnid", BodyPart.Head,
                    CharSex.Male)
            },
            {
                152,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_010_M", "Skull Of Taurus", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                153,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_011_M", "R.I.P. My Brothers", BodyPart.Back,
                    CharSex.Male)
            },
            {
                154,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_012_M", "Urban Stunter", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                155,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_013_M", "Demon Crossbones", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                156,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_014_M", "Lady Mortality", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                157,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_015_M", "Ride or Die", BodyPart.LeftLeg,
                    CharSex.Male)
            },
            {
                158,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_016_M", "Macabre Tree", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                159,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_017_M", "Clawed Beast", BodyPart.Back, CharSex.Male)
            },
            {
                160,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_018_M", "Skeletal Chopper", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                161,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_019_M", "Gruesome Talons", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                162,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_020_M", "Cranial Rose", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                163,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_021_M", "Flaming Reaper", BodyPart.Back,
                    CharSex.Male)
            },
            {
                164,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_022_M", "Western Insignia", BodyPart.RightLeg,
                    CharSex.Male)
            },
            {
                165,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_023_M", "Western MC", BodyPart.Chest, CharSex.Male)
            },
            {
                166,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_024_M", "Live to Ride", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                167,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_025_M", "Good Luck", BodyPart.LeftArm, CharSex.Male)
            },
            {
                168,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_026_M", "American Dream", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                169,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_027_M", "Bad Luck", BodyPart.LeftLeg, CharSex.Male)
            },
            {
                170,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_028_M", "Dusk Rider", BodyPart.RightLeg,
                    CharSex.Male)
            },
            {
                171,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_029_M", "Bone Wrench", BodyPart.Chest, CharSex.Male)
            },
            {
                172,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_030_M", "Brothers For Life", BodyPart.Back,
                    CharSex.Male)
            },
            {
                173,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_031_M", "Gear Head", BodyPart.Chest, CharSex.Male)
            },
            {
                174,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_032_M", "Western Eagle", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                175,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_033_M", "Eagle Emblem", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                176,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_034_M", "Brotherhood of Bikes", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                177,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_035_M", "Chain Fist", BodyPart.LeftArm, CharSex.Male)
            },
            {
                178,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_036_M", "Engulfed Skull", BodyPart.LeftLeg,
                    CharSex.Male)
            },
            {
                179,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_037_M", "Scorched Soul", BodyPart.LeftLeg,
                    CharSex.Male)
            },
            {180, new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_038_M", "FTW", BodyPart.Head, CharSex.Male)},
            {
                181,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_039_M", "Gas Guzzler", BodyPart.Chest, CharSex.Male)
            },
            {
                182,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_040_M", "American Made", BodyPart.RightLeg,
                    CharSex.Male)
            },
            {
                183,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_041_M", "No Regrets", BodyPart.Chest, CharSex.Male)
            },
            {
                184,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_042_M", "Grim Rider", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                185,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_043_M", "Ride Forever", BodyPart.Back, CharSex.Male)
            },
            {
                186,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_044_M", "Ride Free", BodyPart.LeftLeg, CharSex.Male)
            },
            {
                187,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_045_M", "Ride Hard Die Fast", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                188,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_046_M", "Skull Chain", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                189,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_047_M", "Snake Bike", BodyPart.RightArm,
                    CharSex.Male)
            },
            {190, new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_048_M", "STFU", BodyPart.LeftLeg, CharSex.Male)},
            {
                191,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_049_M", "These Colors Don't Run", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                192,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_050_M", "Unforgiven", BodyPart.Chest, CharSex.Male)
            },
            {
                193,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_051_M", "Western Stylized", BodyPart.Head,
                    CharSex.Male)
            },
            {
                194,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_052_M", "Biker Mount", BodyPart.Chest, CharSex.Male)
            },
            {
                195,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_053_M", "Muffler Helmet", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {196, new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_054_M", "Mum", BodyPart.RightArm, CharSex.Male)},
            {
                197,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_055_M", "Poison Scorpion", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                198,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_056_M", "Bone Cruiser", BodyPart.LeftLeg,
                    CharSex.Male)
            },
            {
                199,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_057_M", "Laughing Skull", BodyPart.LeftLeg,
                    CharSex.Male)
            },
            {
                200,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_058_M", "Reaper Vulture", BodyPart.Chest,
                    CharSex.Male)
            },
            {201, new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_059_M", "Faggio", BodyPart.Chest, CharSex.Male)},
            {
                202,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_060_M", "We Are The Mods!", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                203,
                new TattooRow("mpbusiness_overlays", "MP_Buis_M_Neck_000", "Cash is King", BodyPart.Head, CharSex.Male)
            },
            {
                204,
                new TattooRow("mpbusiness_overlays", "MP_Buis_M_Neck_001", "Bold Dollar Sign", BodyPart.Head,
                    CharSex.Male)
            },
            {
                205,
                new TattooRow("mpbusiness_overlays", "MP_Buis_M_Neck_002", "Script Dollar Sign", BodyPart.Head,
                    CharSex.Male)
            },
            {206, new TattooRow("mpbusiness_overlays", "MP_Buis_M_Neck_003", "$100", BodyPart.Head, CharSex.Male)},
            {
                207,
                new TattooRow("mpbusiness_overlays", "MP_Buis_M_LeftArm_000", "$100 Bill", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                208,
                new TattooRow("mpbusiness_overlays", "MP_Buis_M_LeftArm_001", "All-Seeing Eye", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                209,
                new TattooRow("mpbusiness_overlays", "MP_Buis_M_RightArm_000", "Dollar Skull", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                210,
                new TattooRow("mpbusiness_overlays", "MP_Buis_M_RightArm_001", "Green", BodyPart.RightArm, CharSex.Male)
            },
            {
                211,
                new TattooRow("mpbusiness_overlays", "MP_Buis_M_Stomach_000", "Refined Hustler", BodyPart.Chest,
                    CharSex.Male)
            },
            {212, new TattooRow("mpbusiness_overlays", "MP_Buis_M_Chest_000", "Rich", BodyPart.Chest, CharSex.Male)},
            {213, new TattooRow("mpbusiness_overlays", "MP_Buis_M_Chest_001", "$$$", BodyPart.Chest, CharSex.Male)},
            {
                214,
                new TattooRow("mpbusiness_overlays", "MP_Buis_M_Back_000", "Makin' Paper", BodyPart.Back, CharSex.Male)
            },
            {215, new TattooRow("mplowrider_overlays", "MP_LR_Tat_001_M", "King Fight", BodyPart.Chest, CharSex.Male)},
            {216, new TattooRow("mplowrider_overlays", "MP_LR_Tat_002_M", "Holy Mary", BodyPart.Chest, CharSex.Male)},
            {217, new TattooRow("mplowrider_overlays", "MP_LR_Tat_004_M", "Gun Mic", BodyPart.Chest, CharSex.Male)},
            {218, new TattooRow("mplowrider_overlays", "MP_LR_Tat_005_M", "No Evil", BodyPart.LeftArm, CharSex.Male)},
            {
                219,
                new TattooRow("mplowrider_overlays", "MP_LR_Tat_007_M", "LS Serpent", BodyPart.LeftLeg, CharSex.Male)
            },
            {220, new TattooRow("mplowrider_overlays", "MP_LR_Tat_009_M", "Amazon", BodyPart.Back, CharSex.Male)},
            {221, new TattooRow("mplowrider_overlays", "MP_LR_Tat_010_M", "Bad Angel", BodyPart.Back, CharSex.Male)},
            {222, new TattooRow("mplowrider_overlays", "MP_LR_Tat_013_M", "Love Gamble", BodyPart.Chest, CharSex.Male)},
            {
                223,
                new TattooRow("mplowrider_overlays", "MP_LR_Tat_014_M", "Love is Blind", BodyPart.Back, CharSex.Male)
            },
            {
                224,
                new TattooRow("mplowrider_overlays", "MP_LR_Tat_015_M", "Seductress", BodyPart.RightArm, CharSex.Male)
            },
            {225, new TattooRow("mplowrider_overlays", "MP_LR_Tat_017_M", "Ink Me", BodyPart.RightLeg, CharSex.Male)},
            {
                226,
                new TattooRow("mplowrider_overlays", "MP_LR_Tat_020_M", "Presidents", BodyPart.LeftLeg, CharSex.Male)
            },
            {227, new TattooRow("mplowrider_overlays", "MP_LR_Tat_021_M", "Sad Angel", BodyPart.Back, CharSex.Male)},
            {
                228,
                new TattooRow("mplowrider_overlays", "MP_LR_Tat_023_M", "Dance of Hearts", BodyPart.RightLeg,
                    CharSex.Male)
            },
            {
                229,
                new TattooRow("mplowrider_overlays", "MP_LR_Tat_026_M", "Royal Takeover", BodyPart.Chest, CharSex.Male)
            },
            {
                230,
                new TattooRow("mplowrider_overlays", "MP_LR_Tat_027_M", "Los Santos Life", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                231,
                new TattooRow("mplowrider_overlays", "MP_LR_Tat_033_M", "City Sorrow", BodyPart.LeftArm, CharSex.Male)
            },
            {232, new TattooRow("mplowrider2_overlays", "MP_LR_Tat_000_M", "SA Assault", BodyPart.Back, CharSex.Male)},
            {
                233,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_003_M", "Lady Vamp", BodyPart.RightArm, CharSex.Male)
            },
            {
                234,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_006_M", "Love Hustle", BodyPart.LeftArm, CharSex.Male)
            },
            {
                235,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_008_M", "Love the Game", BodyPart.Back, CharSex.Male)
            },
            {
                236,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_011_M", "Lady Liberty", BodyPart.Chest, CharSex.Male)
            },
            {237, new TattooRow("mplowrider2_overlays", "MP_LR_Tat_012_M", "Royal Kiss", BodyPart.Chest, CharSex.Male)},
            {238, new TattooRow("mplowrider2_overlays", "MP_LR_Tat_016_M", "Two Face", BodyPart.Chest, CharSex.Male)},
            {
                239,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_018_M", "Skeleton Party", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                240,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_019_M", "Death Behind", BodyPart.Chest, CharSex.Male)
            },
            {
                241,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_022_M", "My Crazy Life", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                242,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_028_M", "Loving Los Muertos", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                243,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_029_M", "Death Us Do Part", BodyPart.LeftLeg,
                    CharSex.Male)
            },
            {
                244,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_030_M", "San Andreas Prayer", BodyPart.RightLeg,
                    CharSex.Male)
            },
            {245, new TattooRow("mplowrider2_overlays", "MP_LR_Tat_031_M", "Dead Pretty", BodyPart.Back, CharSex.Male)},
            {246, new TattooRow("mplowrider2_overlays", "MP_LR_Tat_032_M", "Reign Over", BodyPart.Back, CharSex.Male)},
            {
                247,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_035_M", "Black Tears", BodyPart.RightArm, CharSex.Male)
            },
            {
                248,
                new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_000_M", "Serpent of Death", BodyPart.LeftLeg,
                    CharSex.Male)
            },
            {
                249,
                new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_001_M", "Elaborate Los Muertos", BodyPart.RightLeg,
                    CharSex.Male)
            },
            {
                250,
                new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_003_M", "Abstract Skull", BodyPart.Chest, CharSex.Male)
            },
            {
                251,
                new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_004_M", "Floral Raven", BodyPart.RightArm, CharSex.Male)
            },
            {252, new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_006_M", "Adorned Wolf", BodyPart.Back, CharSex.Male)},
            {
                253,
                new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_007_M", "Eye of the Griffin", BodyPart.Chest,
                    CharSex.Male)
            },
            {254, new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_008_M", "Flying Eye", BodyPart.Chest, CharSex.Male)},
            {
                255,
                new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_009_M", "Floral Symmetry", BodyPart.LeftArm, CharSex.Male)
            },
            {
                256,
                new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_013_M", "Mermaid Harpist", BodyPart.RightArm,
                    CharSex.Male)
            },
            {257, new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_014_M", "Ancient Queen", BodyPart.Chest, CharSex.Male)},
            {
                258,
                new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_015_M", "Smoking Sisters", BodyPart.Chest, CharSex.Male)
            },
            {
                259,
                new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_019_M", "Geisha Bloom", BodyPart.RightArm, CharSex.Male)
            },
            {
                260,
                new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_020_M", "Archangel & Mary", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {261, new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_021_M", "Gabriel", BodyPart.LeftArm, CharSex.Male)},
            {262, new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_024_M", "Feather Mural", BodyPart.Back, CharSex.Male)},
            {263, new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_002_M", "Howler", BodyPart.Chest, CharSex.Male)},
            {
                264,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_005_M", "Fatal Dagger", BodyPart.LeftArm, CharSex.Male)
            },
            {
                265,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_010_M", "Intrometric", BodyPart.RightArm, CharSex.Male)
            },
            {
                266,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_011_M", "Cross Of Roses", BodyPart.LeftLeg, CharSex.Male)
            },
            {
                267,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_012_M", "Geometric Galaxy", BodyPart.Chest, CharSex.Male)
            },
            {
                268,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_016_M", "Egyptian Mural", BodyPart.LeftArm, CharSex.Male)
            },
            {
                269,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_017_M", "Heavenly Deity", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                270,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_018_M", "Divine Goddess", BodyPart.LeftArm, CharSex.Male)
            },
            {271, new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_022_M", "Cloaked Angel", BodyPart.Back, CharSex.Male)},
            {
                272,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_023_M", "Starmetric", BodyPart.RightLeg, CharSex.Male)
            },
            {273, new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_025_M", "Reaper Sway", BodyPart.Chest, CharSex.Male)},
            {
                274,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_026_M", "Floral Paint", BodyPart.RightArm, CharSex.Male)
            },
            {275, new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_027_M", "Cobra Dawn", BodyPart.Chest, CharSex.Male)},
            {
                276,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_028_M", "Python Skull", BodyPart.LeftArm, CharSex.Male)
            },
            {
                277,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_029_M", "Geometric Design", BodyPart.Back, CharSex.Male)
            },
            {
                278,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_030_M", "Geometric Design", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                279,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_031_M", "Geometric Design", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                280,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_Tat_000_M", "Stunt Skull", BodyPart.Head, CharSex.Male)
            },
            {
                281,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_001_M", "8 Eyed Skull", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                282,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_002_M", "Big Cat", BodyPart.LeftArm, CharSex.Male)
            },
            {
                283,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_003_M", "Poison Wrench", BodyPart.RightArm,
                    CharSex.Male)
            },
            {284, new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_004_M", "Scorpion", BodyPart.Head, CharSex.Male)},
            {
                285,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_005_M", "Demon Spark Plug", BodyPart.RightLeg,
                    CharSex.Male)
            },
            {
                286,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_006_M", "Toxic Spider", BodyPart.Head, CharSex.Male)
            },
            {
                287,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_007_M", "Dagger Devil", BodyPart.LeftLeg,
                    CharSex.Male)
            },
            {
                288,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_008_M", "Moonlight Ride", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                289,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_009_M", "Arachnid of Death", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                290,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_010_M", "Grave Vulture", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                291,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_011_M", "Wheels of Death", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                292,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_012_M", "Punk Biker", BodyPart.Head, CharSex.Male)
            },
            {
                293,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_013_M", "Dirt Track Hero", BodyPart.LeftLeg,
                    CharSex.Male)
            },
            {
                294,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_014_M", "Bat Cat of Spades", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                295,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_015_M", "Praying Gloves", BodyPart.RightLeg,
                    CharSex.Male)
            },
            {
                296,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_016_M", "Coffin Racer", BodyPart.RightArm,
                    CharSex.Male)
            },
            {297, new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_017_M", "Bat Whee", BodyPart.Head, CharSex.Male)},
            {
                298,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_018_M", "Vintage Bully", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                299,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_019_M", "Engine Heart", BodyPart.Chest, CharSex.Male)
            },
            {
                300,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_020_M", "Piston Angel", BodyPart.RightLeg,
                    CharSex.Male)
            },
            {
                301,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_021_M", "Golden Cobra", BodyPart.LeftLeg,
                    CharSex.Male)
            },
            {
                302,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_022_M", "Piston Head", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {303, new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_023_M", "Tanked", BodyPart.LeftArm, CharSex.Male)},
            {304, new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_024_M", "Road Kill", BodyPart.Back, CharSex.Male)},
            {
                305,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_025_M", "Speed Freak", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                306,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_026_M", "Winged Wheel", BodyPart.Back, CharSex.Male)
            },
            {
                307,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_027_M", "Punk Road Hog", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                308,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_028_M", "Quad Goblin", BodyPart.LeftLeg,
                    CharSex.Male)
            },
            {
                309,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_029_M", "Majestic Finish", BodyPart.Back,
                    CharSex.Male)
            },
            {
                310,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_030_M", "Man's Ruin", BodyPart.Back, CharSex.Male)
            },
            {
                311,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_031_M", "Stunt Jesus", BodyPart.LeftLeg,
                    CharSex.Male)
            },
            {
                312,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_032_M", "Wheelie Mouse", BodyPart.RightLeg,
                    CharSex.Male)
            },
            {
                313,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_033_M", "Sugar Skull Trucker", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                314,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_034_M", "Feather Road Kill", BodyPart.Back,
                    CharSex.Male)
            },
            {
                315,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_035_M", "Stuntman's End", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                316,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_036_M", "Biker Stallion", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                317,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_037_M", "Big Grills", BodyPart.Back, CharSex.Male)
            },
            {
                318,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_038_M", "One Down Five Up", BodyPart.RightArm,
                    CharSex.Male)
            },
            {319, new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_039_M", "Kaboom", BodyPart.LeftArm, CharSex.Male)},
            {
                320,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_040_M", "Monkey Chopper", BodyPart.Back,
                    CharSex.Male)
            },
            {321, new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_041_M", "Brapp", BodyPart.Back, CharSex.Male)},
            {
                322,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_042_M", "Flaming Quad", BodyPart.Head, CharSex.Male)
            },
            {
                323,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_043_M", "Engine Arm", BodyPart.LeftArm, CharSex.Male)
            },
            {
                324,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_044_M", "Ram Skull", BodyPart.Chest, CharSex.Male)
            },
            {
                325,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_045_M", "Severed Hand", BodyPart.RightLeg,
                    CharSex.Male)
            },
            {
                326,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_046_M", "Full Throttle", BodyPart.Back, CharSex.Male)
            },
            {
                327,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_047_M", "Brake Knife", BodyPart.RightLeg,
                    CharSex.Male)
            },
            {
                328,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_048_M", "Racing Doll", BodyPart.Back, CharSex.Male)
            },
            {
                329,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_049_M", "Seductive Mechanic", BodyPart.RightArm,
                    CharSex.Male)
            },
            {330, new TattooRow("multiplayer_overlays", "FM_Tat_Award_M_000", "Skull", BodyPart.Head, CharSex.Male)},
            {
                331,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_M_001", "Burning Heart", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                332,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_M_002", "Grim Reaper Smoking Gun",
                    BodyPart.RightArm, CharSex.Male)
            },
            {
                333,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_M_003", "Blackjack", BodyPart.Chest, CharSex.Male)
            },
            {334, new TattooRow("multiplayer_overlays", "FM_Tat_Award_M_004", "Hustler", BodyPart.Chest, CharSex.Male)},
            {335, new TattooRow("multiplayer_overlays", "FM_Tat_Award_M_005", "Angel", BodyPart.Back, CharSex.Male)},
            {
                336,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_M_006", "Skull And Sword", BodyPart.RightLeg,
                    CharSex.Male)
            },
            {
                337,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_M_007", "Racing Blonde", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                338,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_M_008", "Los Santos Customs", BodyPart.Back,
                    CharSex.Male)
            },
            {
                339,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_M_009", "Dragon And Dagger", BodyPart.LeftLeg,
                    CharSex.Male)
            },
            {
                340,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_M_010", "Ride or Die", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                341,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_M_011", "Blank Scroll", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                342,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_M_012", "Embellished Scroll", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                343,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_M_013", "Seven Deadly Sins", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                344,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_M_014", "Trust No One", BodyPart.Back, CharSex.Male)
            },
            {
                345,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_M_015", "Racing Brunette", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {346, new TattooRow("multiplayer_overlays", "FM_Tat_Award_M_016", "Clown", BodyPart.Back, CharSex.Male)},
            {
                347,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_M_017", "Clown And Gun", BodyPart.Back,
                    CharSex.Male)
            },
            {
                348,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_M_018", "Clown Dual Wield", BodyPart.Back,
                    CharSex.Male)
            },
            {
                349,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_M_019", "Clown Dual Wield Dollars", BodyPart.Back,
                    CharSex.Male)
            },
            {
                350,
                new TattooRow("multiplayer_overlays", "FM_Tat_M_000", "Brotherhood", BodyPart.RightArm, CharSex.Male)
            },
            {351, new TattooRow("multiplayer_overlays", "FM_Tat_M_001", "Dragons", BodyPart.RightArm, CharSex.Male)},
            {
                352,
                new TattooRow("multiplayer_overlays", "FM_Tat_M_002", "Melting Skull", BodyPart.LeftLeg, CharSex.Male)
            },
            {
                353,
                new TattooRow("multiplayer_overlays", "FM_Tat_M_003", "Dragons And Skull", BodyPart.RightArm,
                    CharSex.Male)
            },
            {354, new TattooRow("multiplayer_overlays", "FM_Tat_M_004", "Faith", BodyPart.Chest, CharSex.Male)},
            {355, new TattooRow("multiplayer_overlays", "FM_Tat_M_005", "Serpents", BodyPart.LeftArm, CharSex.Male)},
            {
                356,
                new TattooRow("multiplayer_overlays", "FM_Tat_M_006", "Oriental Mural", BodyPart.LeftArm, CharSex.Male)
            },
            {
                357,
                new TattooRow("multiplayer_overlays", "FM_Tat_M_007", "The Warrior", BodyPart.RightLeg, CharSex.Male)
            },
            {
                358,
                new TattooRow("multiplayer_overlays", "FM_Tat_M_008", "Dragon Mural", BodyPart.LeftLeg, CharSex.Male)
            },
            {
                359,
                new TattooRow("multiplayer_overlays", "FM_Tat_M_009", "Skull On The Cross", BodyPart.Back, CharSex.Male)
            },
            {360, new TattooRow("multiplayer_overlays", "FM_Tat_M_010", "LS Flames", BodyPart.Chest, CharSex.Male)},
            {361, new TattooRow("multiplayer_overlays", "FM_Tat_M_011", "LS Script", BodyPart.Back, CharSex.Male)},
            {
                362,
                new TattooRow("multiplayer_overlays", "FM_Tat_M_012", "Los Santos Bills", BodyPart.Chest, CharSex.Male)
            },
            {
                363,
                new TattooRow("multiplayer_overlays", "FM_Tat_M_013", "Eagle and Serpent", BodyPart.Back, CharSex.Male)
            },
            {
                364,
                new TattooRow("multiplayer_overlays", "FM_Tat_M_014", "Flower Mural", BodyPart.RightArm, CharSex.Male)
            },
            {
                365,
                new TattooRow("multiplayer_overlays", "FM_Tat_M_015", "Zodiac Skull", BodyPart.LeftArm, CharSex.Male)
            },
            {366, new TattooRow("multiplayer_overlays", "FM_Tat_M_016", "Evil Clown", BodyPart.Back, CharSex.Male)},
            {367, new TattooRow("multiplayer_overlays", "FM_Tat_M_017", "Tribal", BodyPart.RightLeg, CharSex.Male)},
            {
                368,
                new TattooRow("multiplayer_overlays", "FM_Tat_M_018", "Serpent Skull", BodyPart.RightArm, CharSex.Male)
            },
            {
                369,
                new TattooRow("multiplayer_overlays", "FM_Tat_M_019", "The Wages of Sin", BodyPart.Back, CharSex.Male)
            },
            {370, new TattooRow("multiplayer_overlays", "FM_Tat_M_020", "Dragon", BodyPart.Back, CharSex.Male)},
            {
                371,
                new TattooRow("multiplayer_overlays", "FM_Tat_M_021", "Serpent Skull", BodyPart.LeftLeg, CharSex.Male)
            },
            {
                372,
                new TattooRow("multiplayer_overlays", "FM_Tat_M_022", "Fiery Dragon", BodyPart.RightLeg, CharSex.Male)
            },
            {373, new TattooRow("multiplayer_overlays", "FM_Tat_M_023", "Hottie", BodyPart.LeftLeg, CharSex.Male)},
            {374, new TattooRow("multiplayer_overlays", "FM_Tat_M_024", "Flaming Cross", BodyPart.Chest, CharSex.Male)},
            {375, new TattooRow("multiplayer_overlays", "FM_Tat_M_025", "LS Bold", BodyPart.Chest, CharSex.Male)},
            {
                376,
                new TattooRow("multiplayer_overlays", "FM_Tat_M_026", "Smoking Dagger", BodyPart.LeftLeg, CharSex.Male)
            },
            {
                377,
                new TattooRow("multiplayer_overlays", "FM_Tat_M_027", "Virgin Mary", BodyPart.RightArm, CharSex.Male)
            },
            {378, new TattooRow("multiplayer_overlays", "FM_Tat_M_028", "Mermaid", BodyPart.RightArm, CharSex.Male)},
            {379, new TattooRow("multiplayer_overlays", "FM_Tat_M_029", "Trinity Knot", BodyPart.Chest, CharSex.Male)},
            {
                380,
                new TattooRow("multiplayer_overlays", "FM_Tat_M_030", "Lucky Celtic Dogs", BodyPart.Back, CharSex.Male)
            },
            {381, new TattooRow("multiplayer_overlays", "FM_Tat_M_031", "Lady M", BodyPart.LeftArm, CharSex.Male)},
            {382, new TattooRow("multiplayer_overlays", "FM_Tat_M_032", "Faith", BodyPart.LeftLeg, CharSex.Male)},
            {
                383,
                new TattooRow("multiplayer_overlays", "FM_Tat_M_033", "Chinese Dragon", BodyPart.LeftLeg, CharSex.Male)
            },
            {
                384,
                new TattooRow("multiplayer_overlays", "FM_Tat_M_034", "Flaming Shamrock", BodyPart.Chest, CharSex.Male)
            },
            {385, new TattooRow("multiplayer_overlays", "FM_Tat_M_035", "Dragon", BodyPart.LeftLeg, CharSex.Male)},
            {
                386,
                new TattooRow("multiplayer_overlays", "FM_Tat_M_036", "Way of the Gun", BodyPart.Chest, CharSex.Male)
            },
            {387, new TattooRow("multiplayer_overlays", "FM_Tat_M_037", "Grim Reaper", BodyPart.LeftLeg, CharSex.Male)},
            {388, new TattooRow("multiplayer_overlays", "FM_Tat_M_038", "Dagger", BodyPart.RightArm, CharSex.Male)},
            {
                389,
                new TattooRow("multiplayer_overlays", "FM_Tat_M_039", "Broken Skull", BodyPart.RightLeg, CharSex.Male)
            },
            {
                390,
                new TattooRow("multiplayer_overlays", "FM_Tat_M_040", "Flaming Skull", BodyPart.RightLeg, CharSex.Male)
            },
            {391, new TattooRow("multiplayer_overlays", "FM_Tat_M_041", "Dope Skull", BodyPart.LeftArm, CharSex.Male)},
            {
                392,
                new TattooRow("multiplayer_overlays", "FM_Tat_M_042", "Flaming Scorpion", BodyPart.RightLeg,
                    CharSex.Male)
            },
            {393, new TattooRow("multiplayer_overlays", "FM_Tat_M_043", "Indian Ram", BodyPart.RightLeg, CharSex.Male)},
            {394, new TattooRow("multiplayer_overlays", "FM_Tat_M_044", "Stone Cross", BodyPart.Chest, CharSex.Male)},
            {
                395,
                new TattooRow("multiplayer_overlays", "FM_Tat_M_045", "Skulls And Rose", BodyPart.Back, CharSex.Male)
            },
            {396, new TattooRow("multiplayer_overlays", "FM_Tat_M_047", "Lion", BodyPart.RightArm, CharSex.Male)},
            {
                397,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_000", "Skull Rider", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                398,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_001", "Spider Outline", BodyPart.LeftLeg,
                    CharSex.Male)
            },
            {
                399,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_002", "Spider Color", BodyPart.LeftLeg,
                    CharSex.Male)
            },
            {
                400,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_003", "Snake Outline", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                401,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_004", "Snake Shaded", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                402,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_005", "Carp Outline", BodyPart.Back,
                    CharSex.Male)
            },
            {
                403,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_006", "Carp Shaded", BodyPart.Back, CharSex.Male)
            },
            {
                404,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_007", "Los Muertos", BodyPart.Head, CharSex.Male)
            },
            {
                405,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_008", "Death Before Dishonor", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                406,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_009", "Time To Die", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                407,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_017", "Electric Snake", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                408,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_011", "Roaring Tiger", BodyPart.Back,
                    CharSex.Male)
            },
            {
                409,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_012", "8 Ball Skull", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {410, new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_013", "Lizard", BodyPart.Chest, CharSex.Male)},
            {
                411,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_014", "Floral Dagger", BodyPart.RightLeg,
                    CharSex.Male)
            },
            {
                412,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_015", "Japanese Warrior", BodyPart.Back,
                    CharSex.Male)
            },
            {
                413,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_016", "Loose Lips Outline", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                414,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_017", "Loose Lips Color", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                415,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_018", "Royal Dagger Outline", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                416,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_019", "Royal Dagger Color", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                417,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_020", "Time's Up Outline", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                418,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_021", "Time's Up Color", BodyPart.LeftArm,
                    CharSex.Male)
            },
            {
                419,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_022", "You're Next Outline", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                420,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_023", "You're Next Color", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                421,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_024", "Snake Head Outline", BodyPart.Head,
                    CharSex.Male)
            },
            {
                422,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_025", "Snake Head Color", BodyPart.Head,
                    CharSex.Male)
            },
            {
                423,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_026", "Fuck Luck Outline", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                424,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_027", "Fuck Luck Color", BodyPart.RightArm,
                    CharSex.Male)
            },
            {
                425,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_028", "Executioner", BodyPart.Chest,
                    CharSex.Male)
            },
            {
                426,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_M_Tat_029", "Beautiful Death", BodyPart.Head,
                    CharSex.Male)
            },
            {427, new TattooRow("mpbeach_overlays", "MP_Bea_F_Back_000", "Rock Solid", BodyPart.Back, CharSex.Female)},
            {
                428,
                new TattooRow("mpbeach_overlays", "MP_Bea_F_Back_001", "Hibiscus Flower Duo", BodyPart.Back,
                    CharSex.Female)
            },
            {429, new TattooRow("mpbeach_overlays", "MP_Bea_F_Back_002", "Shrimp", BodyPart.Back, CharSex.Female)},
            {430, new TattooRow("mpbeach_overlays", "MP_Bea_F_Chest_000", "Anchor", BodyPart.Chest, CharSex.Female)},
            {431, new TattooRow("mpbeach_overlays", "MP_Bea_F_Chest_001", "Anchor", BodyPart.Chest, CharSex.Female)},
            {
                432,
                new TattooRow("mpbeach_overlays", "MP_Bea_F_Chest_002", "Los Santos Wreath", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                433,
                new TattooRow("mpbeach_overlays", "MP_Bea_F_RSide_000", "Love Dagger", BodyPart.Chest, CharSex.Female)
            },
            {
                434,
                new TattooRow("mpbeach_overlays", "MP_Bea_F_RLeg_000", "School of Fish", BodyPart.RightLeg,
                    CharSex.Female)
            },
            {
                435,
                new TattooRow("mpbeach_overlays", "MP_Bea_F_RArm_001", "Tribal Fish", BodyPart.RightArm, CharSex.Female)
            },
            {
                436,
                new TattooRow("mpbeach_overlays", "MP_Bea_F_Neck_000", "Tribal Butterfly", BodyPart.Head,
                    CharSex.Female)
            },
            {
                437,
                new TattooRow("mpbeach_overlays", "MP_Bea_F_Should_000", "Sea Horses", BodyPart.Back, CharSex.Female)
            },
            {438, new TattooRow("mpbeach_overlays", "MP_Bea_F_Should_001", "Catfish", BodyPart.Back, CharSex.Female)},
            {439, new TattooRow("mpbeach_overlays", "MP_Bea_F_Stom_000", "Swallow", BodyPart.Chest, CharSex.Female)},
            {
                440,
                new TattooRow("mpbeach_overlays", "MP_Bea_F_Stom_001", "Hibiscus Flower", BodyPart.Chest,
                    CharSex.Female)
            },
            {441, new TattooRow("mpbeach_overlays", "MP_Bea_F_Stom_002", "Dolphin", BodyPart.Chest, CharSex.Female)},
            {
                442,
                new TattooRow("mpbeach_overlays", "MP_Bea_F_LArm_000", "Tribal Flower", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {443, new TattooRow("mpbeach_overlays", "MP_Bea_F_LArm_001", "Parrot", BodyPart.LeftArm, CharSex.Female)},
            {
                444,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_000_F", "Demon Rider", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                445,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_001_F", "Both Barrels", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                446,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_002_F", "Rose Tribute", BodyPart.LeftLeg,
                    CharSex.Female)
            },
            {
                447,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_003_F", "Web Rider", BodyPart.Chest, CharSex.Female)
            },
            {
                448,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_004_F", "Dragon's Fury", BodyPart.RightLeg,
                    CharSex.Female)
            },
            {
                449,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_005_F", "Made In America", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                450,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_006_F", "Chopper Freedom", BodyPart.Back,
                    CharSex.Female)
            },
            {
                451,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_007_F", "Swooping Eagle", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                452,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_008_F", "Freedom Wheels", BodyPart.Back,
                    CharSex.Female)
            },
            {
                453,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_009_F", "Morbid Arachnid", BodyPart.Head,
                    CharSex.Female)
            },
            {
                454,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_010_F", "Skull Of Taurus", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                455,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_011_F", "R.I.P. My Brothers", BodyPart.Back,
                    CharSex.Female)
            },
            {
                456,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_012_F", "Urban Stunter", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                457,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_013_F", "Demon Crossbones", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                458,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_014_F", "Lady Mortality", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                459,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_015_F", "Ride or Die", BodyPart.LeftLeg,
                    CharSex.Female)
            },
            {
                460,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_016_F", "Macabre Tree", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                461,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_017_F", "Clawed Beast", BodyPart.Back,
                    CharSex.Female)
            },
            {
                462,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_018_F", "Skeletal Chopper", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                463,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_019_F", "Gruesome Talons", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                464,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_020_F", "Cranial Rose", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                465,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_021_F", "Flaming Reaper", BodyPart.Back,
                    CharSex.Female)
            },
            {
                466,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_022_F", "Western Insignia", BodyPart.RightLeg,
                    CharSex.Female)
            },
            {
                467,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_023_F", "Western MC", BodyPart.Chest, CharSex.Female)
            },
            {
                468,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_024_F", "Live to Ride", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                469,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_025_F", "Good Luck", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                470,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_026_F", "American Dream", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                471,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_027_F", "Bad Luck", BodyPart.LeftLeg, CharSex.Female)
            },
            {
                472,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_028_F", "Dusk Rider", BodyPart.RightLeg,
                    CharSex.Female)
            },
            {
                473,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_029_F", "Bone Wrench", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                474,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_030_F", "Brothers For Life", BodyPart.Back,
                    CharSex.Female)
            },
            {
                475,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_031_F", "Gear Head", BodyPart.Chest, CharSex.Female)
            },
            {
                476,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_032_F", "Western Eagle", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                477,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_033_F", "Eagle Emblem", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                478,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_034_F", "Brotherhood of Bikes", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                479,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_035_F", "Chain Fist", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                480,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_036_F", "Engulfed Skull", BodyPart.LeftLeg,
                    CharSex.Female)
            },
            {
                481,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_037_F", "Scorched Soul", BodyPart.LeftLeg,
                    CharSex.Female)
            },
            {482, new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_038_F", "FTW", BodyPart.Head, CharSex.Female)},
            {
                483,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_039_F", "Gas Guzzler", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                484,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_040_F", "American Made", BodyPart.RightLeg,
                    CharSex.Female)
            },
            {
                485,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_041_F", "No Regrets", BodyPart.Chest, CharSex.Female)
            },
            {
                486,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_042_F", "Grim Rider", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                487,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_043_F", "Ride Forever", BodyPart.Back,
                    CharSex.Female)
            },
            {
                488,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_044_F", "Ride Free", BodyPart.LeftLeg,
                    CharSex.Female)
            },
            {
                489,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_045_F", "Ride Hard Die Fast", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                490,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_046_F", "Skull Chain", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                491,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_047_F", "Snake Bike", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                492,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_048_F", "STFU", BodyPart.RightLeg, CharSex.Female)
            },
            {
                493,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_049_F", "These Colors Don't Run", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                494,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_050_F", "Unforgiven", BodyPart.Chest, CharSex.Female)
            },
            {
                495,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_051_F", "Western Stylized", BodyPart.Head,
                    CharSex.Female)
            },
            {
                496,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_052_F", "Biker Mount", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                497,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_053_F", "Muffler Helmet", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {498, new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_054_F", "Mum", BodyPart.RightArm, CharSex.Female)},
            {
                499,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_055_F", "Poison Scorpion", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                500,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_056_F", "Bone Cruiser", BodyPart.LeftLeg,
                    CharSex.Female)
            },
            {
                501,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_057_F", "Laughing Skull", BodyPart.LeftLeg,
                    CharSex.Female)
            },
            {
                502,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_058_F", "Reaper Vulture", BodyPart.Chest,
                    CharSex.Female)
            },
            {503, new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_059_F", "Faggio", BodyPart.Chest, CharSex.Female)},
            {
                504,
                new TattooRow("mpbiker_overlays", "MP_MP_Biker_Tat_060_F", "We Are The Mods!", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                505,
                new TattooRow("mpbusiness_overlays", "MP_Buis_F_Chest_000", "High Roller", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                506,
                new TattooRow("mpbusiness_overlays", "MP_Buis_F_Chest_001", "Makin' Money", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                507,
                new TattooRow("mpbusiness_overlays", "MP_Buis_F_Chest_002", "Love Money", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                508,
                new TattooRow("mpbusiness_overlays", "MP_Buis_F_Stom_000", "Diamond Back", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                509,
                new TattooRow("mpbusiness_overlays", "MP_Buis_F_Stom_001", "Santo Capra Logo", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                510,
                new TattooRow("mpbusiness_overlays", "MP_Buis_F_Stom_002", "Money Bag", BodyPart.Chest, CharSex.Female)
            },
            {511, new TattooRow("mpbusiness_overlays", "MP_Buis_F_Back_000", "Respect", BodyPart.Back, CharSex.Female)},
            {
                512,
                new TattooRow("mpbusiness_overlays", "MP_Buis_F_Back_001", "Gold Digger", BodyPart.Back, CharSex.Female)
            },
            {
                513,
                new TattooRow("mpbusiness_overlays", "MP_Buis_F_Neck_000", "Val-de-Grace Logo", BodyPart.Head,
                    CharSex.Female)
            },
            {
                514,
                new TattooRow("mpbusiness_overlays", "MP_Buis_F_Neck_001", "Money Rose", BodyPart.Head, CharSex.Female)
            },
            {
                515,
                new TattooRow("mpbusiness_overlays", "MP_Buis_F_RArm_000", "Dollar Sign", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                516,
                new TattooRow("mpbusiness_overlays", "MP_Buis_F_LArm_000", "Greed is Good", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                517,
                new TattooRow("mpbusiness_overlays", "MP_Buis_F_LLeg_000", "Single", BodyPart.LeftLeg, CharSex.Female)
            },
            {
                518,
                new TattooRow("mpbusiness_overlays", "MP_Buis_F_RLeg_000", "Diamond Crown", BodyPart.RightLeg,
                    CharSex.Female)
            },
            {
                519,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_000", "Skull Rider", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                520,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_001", "Spider Outline", BodyPart.LeftLeg,
                    CharSex.Female)
            },
            {
                521,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_002", "Spider Color", BodyPart.LeftLeg,
                    CharSex.Female)
            },
            {
                522,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_003", "Snake Outline", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                523,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_004", "Snake Shaded", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                524,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_005", "Carp Outline", BodyPart.Back,
                    CharSex.Female)
            },
            {
                525,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_006", "Carp Shaded", BodyPart.Back,
                    CharSex.Female)
            },
            {
                526,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_007", "Los Muertos", BodyPart.Head,
                    CharSex.Female)
            },
            {
                527,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_008", "Death Before Dishonor", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                528,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_009", "Time To Die", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                529,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_017", "Electric Snake", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                530,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_011", "Roaring Tiger", BodyPart.Back,
                    CharSex.Female)
            },
            {
                531,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_012", "8 Ball Skull", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                532,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_013", "Lizard", BodyPart.Chest, CharSex.Female)
            },
            {
                533,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_014", "Floral Dagger", BodyPart.RightLeg,
                    CharSex.Female)
            },
            {
                534,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_015", "Japanese Warrior", BodyPart.Back,
                    CharSex.Female)
            },
            {
                535,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_016", "Loose Lips Outline", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                536,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_017", "Loose Lips Color", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                537,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_018", "Royal Dagger Outline", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                538,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_019", "Royal Dagger Color", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                539,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_020", "Time's Up Outline", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                540,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_021", "Time's Up Color", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                541,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_022", "You're Next Outline", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                542,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_023", "You're Next Color", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                543,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_024", "Snake Head Outline", BodyPart.Head,
                    CharSex.Female)
            },
            {
                544,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_025", "Snake Head Color", BodyPart.Head,
                    CharSex.Female)
            },
            {
                545,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_026", "Fuck Luck Outline", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                546,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_027", "Fuck Luck Color", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                547,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_028", "Executioner", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                548,
                new TattooRow("mpchristmas2_overlays", "MP_Xmas2_F_Tat_029", "Beautiful Death", BodyPart.Head,
                    CharSex.Female)
            },
            {
                549,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_000_F", "Bullet Proof", BodyPart.Back,
                    CharSex.Female)
            },
            {
                550,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_001_F", "Crossed Weapons", BodyPart.Back,
                    CharSex.Female)
            },
            {
                551,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_002_F", "Granade", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                552,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_003_F", "Lock & Load", BodyPart.Head,
                    CharSex.Female)
            },
            {
                553,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_004_F", "Sidearm", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                554,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_005_F", "Patriot Skull", BodyPart.LeftLeg,
                    CharSex.Female)
            },
            {
                555,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_006_F", "Combat Skull", BodyPart.RightLeg,
                    CharSex.Female)
            },
            {
                556,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_007_F", "Stylized Tiger", BodyPart.LeftLeg,
                    CharSex.Female)
            },
            {
                557,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_008_F", "Bandolier", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                558,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_009_F", "Butterfly Knife", BodyPart.Back,
                    CharSex.Female)
            },
            {
                559,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_010_F", "Cash Money", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                560,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_011_F", "Death Skull", BodyPart.LeftLeg,
                    CharSex.Female)
            },
            {
                561,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_012_F", "Dollar Daggers", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                562,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_013_F", "Wolf Insignia", BodyPart.Back,
                    CharSex.Female)
            },
            {
                563,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_014_F", "Backstabber", BodyPart.Back,
                    CharSex.Female)
            },
            {
                564,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_015_F", "Spiked Skull", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                565,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_016_F", "Blood Money", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                566,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_017_F", "Dog Tags", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                567,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_018_F", "Dual Wield Skull", BodyPart.Back,
                    CharSex.Female)
            },
            {
                568,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_019_F", "Pistol Wings", BodyPart.Back,
                    CharSex.Female)
            },
            {
                569,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_020_F", "Crowned Weapons", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                570,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_021_F", "Have a Nice Day",
                    BodyPart.RightArm, CharSex.Female)
            },
            {
                571,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_022_F", "Explosive Heart", BodyPart.Back,
                    CharSex.Female)
            },
            {
                572,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_023_F", "Rose Revolver", BodyPart.LeftLeg,
                    CharSex.Female)
            },
            {
                573,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_025_F", "Praying Skull", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                574,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_026_F", "Restless Skull",
                    BodyPart.RightLeg, CharSex.Female)
            },
            {
                575,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_027_F", "Serpent Revolver",
                    BodyPart.LeftArm, CharSex.Female)
            },
            {
                576,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_028_F", "Micro SMG Chain", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                577,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_029_F", "Win Some Lose Some",
                    BodyPart.Chest, CharSex.Female)
            },
            {
                578,
                new TattooRow("mpgunrunning_overlays", "MP_Gunrunning_Tattoo_030_F", "Pistol Ace", BodyPart.RightLeg,
                    CharSex.Female)
            },
            {
                579,
                new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_000", "Crossed Arrows", BodyPart.Back, CharSex.Female)
            },
            {
                580,
                new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_001", "Single Arrow", BodyPart.RightArm,
                    CharSex.Female)
            },
            {581, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_002", "Chemistry", BodyPart.Chest, CharSex.Female)},
            {
                582,
                new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_003", "Diamond Sparkle", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {583, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_004", "Bone", BodyPart.RightArm, CharSex.Female)},
            {
                584,
                new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_005", "Beautiful Eye", BodyPart.Head, CharSex.Female)
            },
            {
                585,
                new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_006", "Feather Birds", BodyPart.Chest, CharSex.Female)
            },
            {586, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_007", "Bricks", BodyPart.LeftArm, CharSex.Female)},
            {587, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_008", "Cube", BodyPart.RightArm, CharSex.Female)},
            {588, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_009", "Squares", BodyPart.LeftLeg, CharSex.Female)},
            {
                589,
                new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_010", "Horseshoe", BodyPart.RightArm, CharSex.Female)
            },
            {590, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_011", "Infinity", BodyPart.Back, CharSex.Female)},
            {591, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_012", "Antlers", BodyPart.Back, CharSex.Female)},
            {592, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_013", "Boombox", BodyPart.Chest, CharSex.Female)},
            {
                593,
                new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_014", "Spray Can", BodyPart.RightArm, CharSex.Female)
            },
            {
                594,
                new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_015", "Mustache", BodyPart.LeftArm, CharSex.Female)
            },
            {
                595,
                new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_016", "Lightning Bolt", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                596,
                new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_017", "Eye Triangle", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                597,
                new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_018", "Origami", BodyPart.RightArm, CharSex.Female)
            },
            {598, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_019", "Charms", BodyPart.LeftLeg, CharSex.Female)},
            {
                599,
                new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_020", "Geo Pattern", BodyPart.RightArm,
                    CharSex.Female)
            },
            {600, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_021", "Geo Fox", BodyPart.Head, CharSex.Female)},
            {601, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_022", "Pencil", BodyPart.RightArm, CharSex.Female)},
            {602, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_023", "Smiley", BodyPart.RightArm, CharSex.Female)},
            {603, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_024", "Pyramid", BodyPart.Back, CharSex.Female)},
            {
                604,
                new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_025", "Watch Your Step", BodyPart.Back,
                    CharSex.Female)
            },
            {605, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_026", "Pizza", BodyPart.LeftArm, CharSex.Female)},
            {606, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_027", "Padlock", BodyPart.LeftArm, CharSex.Female)},
            {
                607,
                new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_028", "Thorny Rose", BodyPart.LeftArm, CharSex.Female)
            },
            {608, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_029", "Sad", BodyPart.Chest, CharSex.Female)},
            {609, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_030", "Shark Fin", BodyPart.Back, CharSex.Female)},
            {610, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_031", "Skateboard", BodyPart.Back, CharSex.Female)},
            {
                611,
                new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_032", "Paper Plane", BodyPart.Back, CharSex.Female)
            },
            {612, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_033", "Stag", BodyPart.Chest, CharSex.Female)},
            {
                613,
                new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_034", "Stop Sign", BodyPart.LeftArm, CharSex.Female)
            },
            {
                614,
                new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_035", "Sewn Heart", BodyPart.Chest, CharSex.Female)
            },
            {615, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_036", "Shapes", BodyPart.RightArm, CharSex.Female)},
            {616, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_037", "Sunrise", BodyPart.LeftArm, CharSex.Female)},
            {617, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_038", "Grub", BodyPart.RightLeg, CharSex.Female)},
            {618, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_039", "Sleeve", BodyPart.LeftArm, CharSex.Female)},
            {
                619,
                new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_040", "Black Anchor", BodyPart.LeftLeg,
                    CharSex.Female)
            },
            {620, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_041", "Tooth", BodyPart.Back, CharSex.Female)},
            {
                621,
                new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_042", "Sparkplug", BodyPart.RightLeg, CharSex.Female)
            },
            {
                622,
                new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_043", "Triangles White", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                623,
                new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_044", "Triangles Black", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                624,
                new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_045", "Mesh Band", BodyPart.RightArm, CharSex.Female)
            },
            {625, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_046", "Triangles", BodyPart.Back, CharSex.Female)},
            {626, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_047", "Cassette", BodyPart.Chest, CharSex.Female)},
            {627, new TattooRow("mphipster_overlays", "FM_Hip_F_Tat_048", "Peace", BodyPart.LeftArm, CharSex.Female)},
            {
                628,
                new TattooRow("mpimportexport_overlays", "MP_MP_ImportExport_Tat_000_F", "Block Back", BodyPart.Back,
                    CharSex.Female)
            },
            {
                629,
                new TattooRow("mpimportexport_overlays", "MP_MP_ImportExport_Tat_001_F", "Power Plant", BodyPart.Back,
                    CharSex.Female)
            },
            {
                630,
                new TattooRow("mpimportexport_overlays", "MP_MP_ImportExport_Tat_002_F", "Turned To Death",
                    BodyPart.Back, CharSex.Female)
            },
            {
                631,
                new TattooRow("mpimportexport_overlays", "MP_MP_ImportExport_Tat_003_F", "Mechanical Sleeve",
                    BodyPart.RightArm, CharSex.Female)
            },
            {
                632,
                new TattooRow("mpimportexport_overlays", "MP_MP_ImportExport_Tat_004_F", "Piston Sleeve",
                    BodyPart.LeftArm, CharSex.Female)
            },
            {
                633,
                new TattooRow("mpimportexport_overlays", "MP_MP_ImportExport_Tat_005_F", "Dialed In", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                634,
                new TattooRow("mpimportexport_overlays", "MP_MP_ImportExport_Tat_006_F", "Engulfed Block",
                    BodyPart.RightArm, CharSex.Female)
            },
            {
                635,
                new TattooRow("mpimportexport_overlays", "MP_MP_ImportExport_Tat_007_F", "Drive Forever",
                    BodyPart.RightArm, CharSex.Female)
            },
            {
                636,
                new TattooRow("mpimportexport_overlays", "MP_MP_ImportExport_Tat_008_F", "Scarlett", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                637,
                new TattooRow("mpimportexport_overlays", "MP_MP_ImportExport_Tat_009_F", "Serpents of Destruction",
                    BodyPart.Back, CharSex.Female)
            },
            {
                638,
                new TattooRow("mpimportexport_overlays", "MP_MP_ImportExport_Tat_010_F", "Take The Wheel",
                    BodyPart.Back, CharSex.Female)
            },
            {
                639,
                new TattooRow("mpimportexport_overlays", "MP_MP_ImportExport_Tat_011_F", "Talk Shit Get Hit",
                    BodyPart.Back, CharSex.Female)
            },
            {
                640,
                new TattooRow("mplowrider_overlays", "MP_LR_Tat_001_F", "King Fight", BodyPart.Chest, CharSex.Female)
            },
            {641, new TattooRow("mplowrider_overlays", "MP_LR_Tat_002_F", "Holy Mary", BodyPart.Chest, CharSex.Female)},
            {642, new TattooRow("mplowrider_overlays", "MP_LR_Tat_004_F", "Gun Mic", BodyPart.Chest, CharSex.Female)},
            {643, new TattooRow("mplowrider_overlays", "MP_LR_Tat_005_F", "No Evil", BodyPart.LeftArm, CharSex.Female)},
            {
                644,
                new TattooRow("mplowrider_overlays", "MP_LR_Tat_007_F", "LS Serpent", BodyPart.LeftLeg, CharSex.Female)
            },
            {645, new TattooRow("mplowrider_overlays", "MP_LR_Tat_009_F", "Amazon", BodyPart.Back, CharSex.Female)},
            {646, new TattooRow("mplowrider_overlays", "MP_LR_Tat_010_F", "Bad Angel", BodyPart.Back, CharSex.Female)},
            {
                647,
                new TattooRow("mplowrider_overlays", "MP_LR_Tat_013_F", "Love Gamble", BodyPart.Chest, CharSex.Female)
            },
            {
                648,
                new TattooRow("mplowrider_overlays", "MP_LR_Tat_014_F", "Love is Blind", BodyPart.Back, CharSex.Female)
            },
            {
                649,
                new TattooRow("mplowrider_overlays", "MP_LR_Tat_015_F", "Seductress", BodyPart.RightArm, CharSex.Female)
            },
            {650, new TattooRow("mplowrider_overlays", "MP_LR_Tat_017_F", "Ink Me", BodyPart.RightLeg, CharSex.Female)},
            {
                651,
                new TattooRow("mplowrider_overlays", "MP_LR_Tat_020_F", "Presidents", BodyPart.LeftLeg, CharSex.Female)
            },
            {652, new TattooRow("mplowrider_overlays", "MP_LR_Tat_021_F", "Sad Angel", BodyPart.Back, CharSex.Female)},
            {
                653,
                new TattooRow("mplowrider_overlays", "MP_LR_Tat_023_F", "Dance of Hearts", BodyPart.RightLeg,
                    CharSex.Female)
            },
            {
                654,
                new TattooRow("mplowrider_overlays", "MP_LR_Tat_026_F", "Royal Takeover", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                655,
                new TattooRow("mplowrider_overlays", "MP_LR_Tat_027_F", "Los Santos Life", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                656,
                new TattooRow("mplowrider_overlays", "MP_LR_Tat_033_F", "City Sorrow", BodyPart.LeftArm, CharSex.Female)
            },
            {
                657,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_000_F", "SA Assault", BodyPart.Back, CharSex.Female)
            },
            {
                658,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_003_F", "Lady Vamp", BodyPart.RightArm, CharSex.Female)
            },
            {
                659,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_006_F", "Love Hustle", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                660,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_008_F", "Love the Game", BodyPart.Back, CharSex.Female)
            },
            {
                661,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_011_F", "Lady Liberty", BodyPart.Chest, CharSex.Female)
            },
            {
                662,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_012_F", "Royal Kiss", BodyPart.Chest, CharSex.Female)
            },
            {663, new TattooRow("mplowrider2_overlays", "MP_LR_Tat_016_F", "Two Face", BodyPart.Chest, CharSex.Female)},
            {
                664,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_018_F", "Skeleton Party", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                665,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_019_F", "Death Behind", BodyPart.Chest, CharSex.Female)
            },
            {
                666,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_022_F", "My Crazy Life", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                667,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_028_F", "Loving Los Muertos", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                668,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_029_F", "Death Us Do Part", BodyPart.LeftLeg,
                    CharSex.Female)
            },
            {
                669,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_030_F", "San Andreas Prayer", BodyPart.RightLeg,
                    CharSex.Female)
            },
            {
                670,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_031_F", "Dead Pretty", BodyPart.Back, CharSex.Female)
            },
            {
                671,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_032_F", "Reign Over", BodyPart.Back, CharSex.Female)
            },
            {
                672,
                new TattooRow("mplowrider2_overlays", "MP_LR_Tat_035_F", "Black Tears", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                673,
                new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_000_F", "Serpent of Death", BodyPart.LeftLeg,
                    CharSex.Female)
            },
            {
                674,
                new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_001_F", "Elaborate Los Muertos", BodyPart.RightLeg,
                    CharSex.Female)
            },
            {
                675,
                new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_003_F", "Abstract Skull", BodyPart.Chest, CharSex.Female)
            },
            {
                676,
                new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_004_F", "Floral Raven", BodyPart.RightArm, CharSex.Female)
            },
            {677, new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_006_F", "Adorned Wolf", BodyPart.Back, CharSex.Female)},
            {
                678,
                new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_007_F", "Eye of the Griffin", BodyPart.Chest,
                    CharSex.Female)
            },
            {679, new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_008_F", "Flying Eye", BodyPart.Chest, CharSex.Female)},
            {
                680,
                new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_009_F", "Floral Symmetry", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                681,
                new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_013_F", "Mermaid Harpist", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                682,
                new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_014_F", "Ancient Queen", BodyPart.Chest, CharSex.Female)
            },
            {
                683,
                new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_015_F", "Smoking Sisters", BodyPart.Chest, CharSex.Female)
            },
            {
                684,
                new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_019_F", "Geisha Bloom", BodyPart.RightArm, CharSex.Female)
            },
            {
                685,
                new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_020_F", "Archangel & Mary", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {686, new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_021_F", "Gabriel", BodyPart.LeftArm, CharSex.Female)},
            {
                687,
                new TattooRow("mpluxe_overlays", "MP_LUXE_TAT_024_F", "Feather Mural", BodyPart.Back, CharSex.Female)
            },
            {688, new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_002_F", "Howler", BodyPart.Chest, CharSex.Female)},
            {
                689,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_005_F", "Fatal Dagger", BodyPart.LeftArm, CharSex.Female)
            },
            {
                690,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_010_F", "Intrometric", BodyPart.RightArm, CharSex.Female)
            },
            {
                691,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_011_F", "Cross Of Roses", BodyPart.LeftLeg,
                    CharSex.Female)
            },
            {
                692,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_012_F", "Geometric Galaxy", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                693,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_016_F", "Egyptian Mural", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                694,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_017_F", "Heavenly Deity", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                695,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_018_F", "Divine Goddess", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                696,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_022_F", "Cloaked Angel", BodyPart.Back, CharSex.Female)
            },
            {
                697,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_023_F", "Starmetric", BodyPart.RightLeg, CharSex.Female)
            },
            {
                698,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_025_F", "Reaper Sway", BodyPart.Chest, CharSex.Female)
            },
            {
                699,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_026_F", "Floral Paint", BodyPart.RightArm,
                    CharSex.Female)
            },
            {700, new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_027_F", "Cobra Dawn", BodyPart.Chest, CharSex.Female)},
            {
                701,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_028_F", "Python Skull", BodyPart.LeftArm, CharSex.Female)
            },
            {
                702,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_029_F", "Geometric Design", BodyPart.Back,
                    CharSex.Female)
            },
            {
                703,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_030_F", "Geometric Design", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                704,
                new TattooRow("mpluxe2_overlays", "MP_LUXE_TAT_031_F", "Geometric Design", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                705,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_000_F", "Bless The Dead", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                706,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_001_F", "Crackshot", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                707,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_002_F", "Dead Lies", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                708,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_003_F", "Give Nothing Back", BodyPart.Back,
                    CharSex.Female)
            },
            {
                709,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_004_F", "Honor", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                710,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_005_F", "Mutiny", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                711,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_006_F", "Never Surrender", BodyPart.Back,
                    CharSex.Female)
            },
            {
                712,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_007_F", "No Honor Among THIEVES",
                    BodyPart.Chest, CharSex.Female)
            },
            {
                713,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_008_F", "Horrors of The Deep",
                    BodyPart.LeftArm, CharSex.Female)
            },
            {
                714,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_009_F", "Tall Ship Conflict", BodyPart.Back,
                    CharSex.Female)
            },
            {
                715,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_010_F", "See You In Hell", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                716,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_011_F", "Sinner", BodyPart.Head,
                    CharSex.Female)
            },
            {
                717,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_012_F", "Thief", BodyPart.Head, CharSex.Female)
            },
            {
                718,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_013_F", "Torn Wings", BodyPart.Back,
                    CharSex.Female)
            },
            {
                719,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_014_F", "Mermaid's Curse", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                720,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_015_F", "Jolly Roger", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                721,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_016_F", "Skull Compass", BodyPart.Back,
                    CharSex.Female)
            },
            {
                722,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_017_F", "Framed Tall Ship", BodyPart.Back,
                    CharSex.Female)
            },
            {
                723,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_018_F", "Finders Keepers", BodyPart.Back,
                    CharSex.Female)
            },
            {
                724,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_019_F", "Lost At Sea", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                725,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_020_F", "Homeward Bound", BodyPart.RightLeg,
                    CharSex.Female)
            },
            {
                726,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_021_F", "Dead Tales", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                727,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_022_F", "X Marks The Spot", BodyPart.Back,
                    CharSex.Female)
            },
            {
                728,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_023_F", "Stylized Kraken", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                729,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_024_F", "Pirate Captain", BodyPart.Back,
                    CharSex.Female)
            },
            {
                730,
                new TattooRow("mpsmuggler_overlays", "MP_Smuggler_Tattoo_025_F", "Claimed By The Beast", BodyPart.Back,
                    CharSex.Female)
            },
            {
                731,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_Tat_000_F", "Stunt Skull", BodyPart.Head, CharSex.Female)
            },
            {
                732,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_001_F", "8 Eyed Skull", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                733,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_002_F", "Big Cat", BodyPart.LeftArm, CharSex.Female)
            },
            {
                734,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_003_F", "Poison Wrench", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                735,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_004_F", "Scorpion", BodyPart.Head, CharSex.Female)
            },
            {
                736,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_005_F", "Demon Spark Plug", BodyPart.RightLeg,
                    CharSex.Female)
            },
            {
                737,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_006_F", "Toxic Spider", BodyPart.Head,
                    CharSex.Female)
            },
            {
                738,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_007_F", "Dagger Devil", BodyPart.LeftLeg,
                    CharSex.Female)
            },
            {
                739,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_008_F", "Moonlight Ride", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                740,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_009_F", "Arachnid of Death", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                741,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_010_F", "Grave Vulture", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                742,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_011_F", "Wheels of Death", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                743,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_012_F", "Punk Biker", BodyPart.Head, CharSex.Female)
            },
            {
                744,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_013_F", "Dirt Track Hero", BodyPart.LeftLeg,
                    CharSex.Female)
            },
            {
                745,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_014_F", "Bat Cat of Spades", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                746,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_015_F", "Praying Gloves", BodyPart.RightLeg,
                    CharSex.Female)
            },
            {
                747,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_016_F", "Coffin Racer", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                748,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_017_F", "Bat Whee", BodyPart.Head, CharSex.Female)
            },
            {
                749,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_018_F", "Vintage Bully", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                750,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_019_F", "Engine Heart", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                751,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_020_F", "Piston Angel", BodyPart.RightLeg,
                    CharSex.Female)
            },
            {
                752,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_021_F", "Golden Cobra", BodyPart.LeftLeg,
                    CharSex.Female)
            },
            {
                753,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_022_F", "Piston Head", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                754,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_023_F", "Tanked", BodyPart.LeftArm, CharSex.Female)
            },
            {
                755,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_024_F", "Road Kill", BodyPart.Back, CharSex.Female)
            },
            {
                756,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_025_F", "Speed Freak", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                757,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_026_F", "Winged Wheel", BodyPart.Back,
                    CharSex.Female)
            },
            {
                758,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_027_F", "Punk Road Hog", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                759,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_028_F", "Quad Goblin", BodyPart.LeftLeg,
                    CharSex.Female)
            },
            {
                760,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_029_F", "Majestic Finish", BodyPart.Back,
                    CharSex.Female)
            },
            {
                761,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_030_F", "Man's Ruin", BodyPart.Back, CharSex.Female)
            },
            {
                762,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_031_F", "Stunt Jesus", BodyPart.LeftLeg,
                    CharSex.Female)
            },
            {
                763,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_032_F", "Wheelie Mouse", BodyPart.RightLeg,
                    CharSex.Female)
            },
            {
                764,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_033_F", "Sugar Skull Trucker", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                765,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_034_F", "Feather Road Kill", BodyPart.Back,
                    CharSex.Female)
            },
            {
                766,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_035_F", "Stuntman's End", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                767,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_036_F", "Biker Stallion", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                768,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_037_F", "Big Grills", BodyPart.Back, CharSex.Female)
            },
            {
                769,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_038_F", "One Down Five Up", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                770,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_039_F", "Kaboom", BodyPart.LeftArm, CharSex.Female)
            },
            {
                771,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_040_F", "Monkey Chopper", BodyPart.Back,
                    CharSex.Female)
            },
            {772, new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_041_F", "Brapp", BodyPart.Back, CharSex.Female)},
            {
                773,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_042_F", "Flaming Quad", BodyPart.Head,
                    CharSex.Female)
            },
            {
                774,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_043_F", "Engine Arm", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                775,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_044_F", "Ram Skull", BodyPart.Chest, CharSex.Female)
            },
            {
                776,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_045_F", "Severed Hand", BodyPart.RightLeg,
                    CharSex.Female)
            },
            {
                777,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_046_F", "Full Throttle", BodyPart.Back,
                    CharSex.Female)
            },
            {
                778,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_047_F", "Brake Knife", BodyPart.RightLeg,
                    CharSex.Female)
            },
            {
                779,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_048_F", "Racing Doll", BodyPart.Back, CharSex.Female)
            },
            {
                780,
                new TattooRow("mpstunt_overlays", "MP_MP_Stunt_tat_049_F", "Seductive Mechanic", BodyPart.RightArm,
                    CharSex.Female)
            },
            {781, new TattooRow("multiplayer_overlays", "FM_Tat_Award_F_000", "Skull", BodyPart.Head, CharSex.Female)},
            {
                782,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_F_001", "Burning Heart", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                783,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_F_002", "Grim Reaper Smoking Gun",
                    BodyPart.RightArm, CharSex.Female)
            },
            {
                784,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_F_003", "Blackjack", BodyPart.Chest, CharSex.Female)
            },
            {
                785,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_F_004", "Hustler", BodyPart.Chest, CharSex.Female)
            },
            {786, new TattooRow("multiplayer_overlays", "FM_Tat_Award_F_005", "Angel", BodyPart.Back, CharSex.Female)},
            {
                787,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_F_006", "Skull And Sword", BodyPart.RightLeg,
                    CharSex.Female)
            },
            {
                788,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_F_007", "Racing Blonde", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                789,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_F_008", "Los Santos Customs", BodyPart.Back,
                    CharSex.Female)
            },
            {
                790,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_F_009", "Dragon And Dagger", BodyPart.LeftLeg,
                    CharSex.Female)
            },
            {
                791,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_F_010", "Ride or Die", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                792,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_F_011", "Blank Scroll", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                793,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_F_012", "Embellished Scroll", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                794,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_F_013", "Seven Deadly Sins", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                795,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_F_014", "Trust No One", BodyPart.Back,
                    CharSex.Female)
            },
            {
                796,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_F_015", "Racing Brunette", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {797, new TattooRow("multiplayer_overlays", "FM_Tat_Award_F_016", "Clown", BodyPart.Back, CharSex.Female)},
            {
                798,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_F_017", "Clown And Gun", BodyPart.Back,
                    CharSex.Female)
            },
            {
                799,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_F_018", "Clown Dual Wield", BodyPart.Back,
                    CharSex.Female)
            },
            {
                800,
                new TattooRow("multiplayer_overlays", "FM_Tat_Award_F_019", "Clown Dual Wield Dollars", BodyPart.Back,
                    CharSex.Female)
            },
            {
                801,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_000", "Brotherhood", BodyPart.RightArm, CharSex.Female)
            },
            {802, new TattooRow("multiplayer_overlays", "FM_Tat_F_001", "Dragons", BodyPart.RightArm, CharSex.Female)},
            {
                803,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_002", "Melting Skull", BodyPart.LeftLeg, CharSex.Female)
            },
            {
                804,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_003", "Dragons And Skull", BodyPart.RightArm,
                    CharSex.Female)
            },
            {805, new TattooRow("multiplayer_overlays", "FM_Tat_F_004", "Faith", BodyPart.Chest, CharSex.Female)},
            {806, new TattooRow("multiplayer_overlays", "FM_Tat_F_005", "Serpents", BodyPart.LeftArm, CharSex.Female)},
            {
                807,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_006", "Oriental Mural", BodyPart.LeftArm,
                    CharSex.Female)
            },
            {
                808,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_007", "The Warrior", BodyPart.RightLeg, CharSex.Female)
            },
            {
                809,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_008", "Dragon Mural", BodyPart.LeftLeg, CharSex.Female)
            },
            {
                810,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_009", "Skull On The Cross", BodyPart.Back,
                    CharSex.Female)
            },
            {811, new TattooRow("multiplayer_overlays", "FM_Tat_F_010", "LS Flames", BodyPart.Chest, CharSex.Female)},
            {812, new TattooRow("multiplayer_overlays", "FM_Tat_F_011", "LS Script", BodyPart.Back, CharSex.Female)},
            {
                813,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_012", "Los Santos Bills", BodyPart.Chest,
                    CharSex.Female)
            },
            {
                814,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_013", "Eagle and Serpent", BodyPart.Back,
                    CharSex.Female)
            },
            {
                815,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_014", "Flower Mural", BodyPart.RightArm, CharSex.Female)
            },
            {
                816,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_015", "Zodiac Skull", BodyPart.LeftArm, CharSex.Female)
            },
            {817, new TattooRow("multiplayer_overlays", "FM_Tat_F_016", "Evil Clown", BodyPart.Back, CharSex.Female)},
            {818, new TattooRow("multiplayer_overlays", "FM_Tat_F_017", "Tribal", BodyPart.RightLeg, CharSex.Female)},
            {
                819,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_018", "Serpent Skull", BodyPart.RightArm,
                    CharSex.Female)
            },
            {
                820,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_019", "The Wages of Sin", BodyPart.Back, CharSex.Female)
            },
            {821, new TattooRow("multiplayer_overlays", "FM_Tat_F_020", "Dragon", BodyPart.Back, CharSex.Female)},
            {
                822,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_021", "Serpent Skull", BodyPart.LeftLeg, CharSex.Female)
            },
            {
                823,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_022", "Fiery Dragon", BodyPart.RightLeg, CharSex.Female)
            },
            {824, new TattooRow("multiplayer_overlays", "FM_Tat_F_023", "Hottie", BodyPart.LeftLeg, CharSex.Female)},
            {
                825,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_024", "Flaming Cross", BodyPart.Chest, CharSex.Female)
            },
            {826, new TattooRow("multiplayer_overlays", "FM_Tat_F_025", "LS Bold", BodyPart.Chest, CharSex.Female)},
            {
                827,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_026", "Smoking Dagger", BodyPart.LeftLeg,
                    CharSex.Female)
            },
            {
                828,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_027", "Virgin Mary", BodyPart.RightArm, CharSex.Female)
            },
            {829, new TattooRow("multiplayer_overlays", "FM_Tat_F_028", "Mermaid", BodyPart.RightArm, CharSex.Female)},
            {
                830,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_029", "Trinity Knot", BodyPart.Chest, CharSex.Female)
            },
            {
                831,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_030", "Lucky Celtic Dogs", BodyPart.Back,
                    CharSex.Female)
            },
            {832, new TattooRow("multiplayer_overlays", "FM_Tat_F_031", "Lady M", BodyPart.LeftArm, CharSex.Female)},
            {833, new TattooRow("multiplayer_overlays", "FM_Tat_F_032", "Faith", BodyPart.LeftLeg, CharSex.Female)},
            {
                834,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_033", "Chinese Dragon", BodyPart.LeftLeg,
                    CharSex.Female)
            },
            {
                835,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_034", "Flaming Shamrock", BodyPart.Chest,
                    CharSex.Female)
            },
            {836, new TattooRow("multiplayer_overlays", "FM_Tat_F_035", "Dragon", BodyPart.LeftLeg, CharSex.Female)},
            {
                837,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_036", "Way of the Gun", BodyPart.Chest, CharSex.Female)
            },
            {
                838,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_037", "Grim Reaper", BodyPart.LeftLeg, CharSex.Female)
            },
            {839, new TattooRow("multiplayer_overlays", "FM_Tat_F_038", "Dagger", BodyPart.RightArm, CharSex.Female)},
            {
                840,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_039", "Broken Skull", BodyPart.RightLeg, CharSex.Female)
            },
            {
                841,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_040", "Flaming Skull", BodyPart.RightLeg,
                    CharSex.Female)
            },
            {
                842,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_041", "Dope Skull", BodyPart.LeftArm, CharSex.Female)
            },
            {
                843,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_042", "Flaming Scorpion", BodyPart.RightLeg,
                    CharSex.Female)
            },
            {
                844,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_043", "Indian Ram", BodyPart.RightLeg, CharSex.Female)
            },
            {845, new TattooRow("multiplayer_overlays", "FM_Tat_F_044", "Stone Cross", BodyPart.Chest, CharSex.Female)},
            {
                846,
                new TattooRow("multiplayer_overlays", "FM_Tat_F_045", "Skulls And Rose", BodyPart.Back, CharSex.Female)
            },
            {847, new TattooRow("multiplayer_overlays", "FM_Tat_F_047", "Lion", BodyPart.RightArm, CharSex.Female)}
        };
    }

    [Serializable]
    public class TattooInfo
    {
        public int Id { get; set; }
        public TattooRow tattoo { get; set; }
    }

    [Serializable]
    public class TattooRow
    {
        public TattooRow(string collection, string hash, string name, BodyPart bodyPart, CharSex sex)
        {
            Collection = collection;
            Hash = hash;
            BodyPart = bodyPart;
            Sex = sex;
            Name = name;
        }

        public string Collection { get; }
        public string Hash { get; }
        public string Name { get; }
        public BodyPart BodyPart { get; }
        public CharSex Sex { get; }
    }

    [Serializable]
    public class Tattoo
    {
        public string Collection { get; set; }
        public string Hash { get; set; }
    }
}