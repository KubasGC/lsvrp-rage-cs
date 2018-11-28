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
namespace LSVRP.Features.Vehicles
{
    public enum OwnerType
    {
        None,
        Player,
        Group
    }

    public enum UiType
    {
        VehicleInfo,
        VehiclesList,
        VehicleOptions,
        VehicleEditAdmin
    }

    public enum ModType
    {
        Spoiler = 0,
        FrontBumper = 1,
        RearBumper = 2,
        SideSkirt = 3,
        Exhaust = 4,
        Frame = 5,
        Grille = 6,
        Hood = 7,
        Fender = 8,
        RightFender = 9,
        Roof = 10,
        Engine = 11,
        Brakes = 12,
        Transmission = 13,
        Horns = 14,
        Suspension = 15,
        Armor = 16,
        Turbo = 18,
        Xenon = 22,
        FrontWheels = 23,
        BackWheels = 24, // only for motorcycles
        PlateHolders = 25,
        TrimDesign = 27,
        Ornaments = 28,
        DialDesign = 30,
        SteeringWheel = 33,
        ShiftLever = 34,
        Plaques = 35,
        Hydraulics = 38,
        Livery = 48,
        Plate = 62,
        Color1 = 66,
        Color2 = 67,
        WindowTint = 69,
        DashboardColor = 74,
        TrimColor = 75
    }
}