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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using GTANetworkAPI;
using LSVRP.Modules;

namespace LSVRP.Database.Models
{
    [Table("lsvrp_interiors_doors")]
    public class InteriorDoor
    {
        [Key] public int Id { get; set; }
        [Column("ParentID")] public int ParentId { get; set; }
        public string Name { get; set; }
        public float OutX { get; set; }
        public float OutY { get; set; }
        public float OutZ { get; set; }
        public float OutAngle { get; set; }
        public int OutDim { get; set; }
        public float InX { get; set; }
        public float InY { get; set; }
        public float InZ { get; set; }
        public float InAngle { get; set; }
        public int InDim { get; set; }
        public bool Locked { get; set; }
        public int Created { get; set; }
        public int Blip { get; set; }
        public int Vehicles { get; set; }

        [NotMapped] public Marker MarkerOut { get; set; }
        [NotMapped] public Marker MarkerIn { get; set; }
        [NotMapped] public GTANetworkAPI.Blip BlipHandle { get; set; }
        [NotMapped] public TextLabel LabelOut { get; set; }

        public void Save()
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                using (Database db = new Database())
                {
                    db.InteriorDoors.Update(this);
                    db.SaveChanges();
                    Modules.Log.ConsoleLog("INTERIOR-DOOR",
                        $"Zapisano drzwi interioru \"{Name}\" (UID: {Id}) (ParentId: {ParentId})", LogType.Debug);
                }
            });
            /*new Thread(() =>
            {
                using (Database db = new Database())
                {
                    db.InteriorDoors.Update(this);
                    db.SaveChanges();
                    Modules.Log.ConsoleLog("INTERIOR-DOOR",
                        $"Zapisano drzwi interioru \"{Name}\" (UID: {Id}) (ParentId: {ParentId})", LogType.Debug);
                }
            }).Start();*/
        }
    }
}