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
using LSVRP.Features.Interiors;
using LSVRP.Modules;

namespace LSVRP.Database.Models
{
    [Table("lsvrp_interiors")]
    public class Interior
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public OwnerType OwnerType { get; set; }
        public int Owner { get; set; }
        public int Dimension { get; set; }
        public int Created { get; set; }
        public bool ForSale { get; set; }
        public int SalePrice { get; set; }

        public void Save()
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                using (Database db = new Database())
                {
                    db.Interiors.Update(this);
                    db.SaveChanges();
                    Modules.Log.ConsoleLog("INTERIOR", $"Zapisano interior \"{Name}\" (UID: {Id})",
                        LogType.Debug);
                }
            });
            /*new Thread(() =>
            {
                using (Database db = new Database())
                {
                    db.Interiors.Update(this);
                    db.SaveChanges();
                    Modules.Log.ConsoleLog("INTERIOR", $"Zapisano interior \"{Name}\" (UID: {Id})",
                        LogType.Debug);
                }
            }).Start();*/
        }
    }
}