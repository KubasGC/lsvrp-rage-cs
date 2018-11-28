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
namespace LSVRP.Features.Offers
{
    public enum OfferType
    {
        Unknown,
        SellItem,
        SellCar,
        SellHouse,
        Heal,
        Bus,
        Repair,
        GroupGive,
        Fuel,
        Pain,
        UnblockVeh,
        PdFine,
        VehMod,
        RegisterVehicle,
        DriverLicense,
        IndividualPlate,
        FamilyRegister,
        Cruise,
        Rp,
        BincoCloth,
        GasStation,
        TattooCreate
    }

    public enum OfferPayType
    {
        Cash,
        Card
    }
}