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
using System.Threading;
using System.Timers;
using LSVRP.Features.Vehicles;
using LSVRP.Modules;
using Newtonsoft.Json;

namespace LSVRP.Database.Models
{
    [Table("lsvrp_vehicles")]
    public class Vehicle
    {
        [Key] public int Id { get; set; }
        public long VehicleHash { get; set; }
        public string Name { get; set; }
        public OwnerType OwnerType { get; set; }
        public int Owner { get; set; }
        [Column("dimension")] public int Dimension { get; set; }
        [Column("plate")] public string NumberPlate { get; set; }
        [Column("spawned")] public bool Spawned { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        [Column("RX")] public float Rx { get; set; }
        [Column("RY")] public float Ry { get; set; }
        [Column("RZ")] public float Rz { get; set; }
        [Column("closed")] public bool Closed { get; set; }
        public double MaxFuel { get; set; }
        public double Fuel { get; set; }
        public int Livery { get; set; }
        public string Extras { get; set; }
        public double FuelMultiplier { get; set; }
        public float Health { get; set; }
        public bool Blocked { get; set; }
        public int BlockValue { get; set; }
        public string Modifications { get; set; }
        public double Mileage { get; set; }
        [Column("color1")] public int FirstColor { get; set; }
        [Column("color2")] public int SecondColor { get; set; }
        public int AssigningId { get; set; }
        public int Cruise { get; set; }
        public int PlateType { get; set; }

        [NotMapped] public GTANetworkAPI.Vehicle VehicleHandle { get; set; }
        [NotMapped] public bool Engine { get; set; }
        [NotMapped] public bool EngineToggle { get; set; }
        [NotMapped] public bool SirenSound { get; set; }
        [NotMapped] public bool LeftIndicator { get; set; }
        [NotMapped] public bool RightIndicator { get; set; }
        [NotMapped] public bool Hood { get; set; }
        [NotMapped] public bool Trunk { get; set; }
        [NotMapped] public Dictionary<int, bool> MappedExtras { get; set; }

        [NotMapped] public Dictionary<string, double> TestHandling { get; set; }
        [NotMapped] public string VehicleDescription { get; set; }


        public void Save()
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                using (Database db = new Database())
                {
                    if (MappedExtras == null) MappedExtras = new Dictionary<int, bool>();
                    Extras = JsonConvert.SerializeObject(MappedExtras, Formatting.None);

                    db.Vehicles.Update(this);
                    db.SaveChanges();
                    Modules.Log.ConsoleLog("VEHICLES", $"Zapisano pojazd o ID {Id}",
                        LogType.Debug);
                }
            });
            /*new Thread(() =>
            {
                using (Database db = new Database())
                {
                    if (MappedExtras == null) MappedExtras = new Dictionary<int, bool>();
                    Extras = JsonConvert.SerializeObject(MappedExtras, Formatting.None);

                    db.Vehicles.Update(this);
                    db.SaveChanges();
                    Modules.Log.ConsoleLog("VEHICLES", $"Zapisano pojazd o ID {Id}",
                        LogType.Debug);
                }
            }).Start();*/
        }

        public void RebuildExtras()
        {
            Library.ReloadVehicleExtra(this);
        }
    }
}