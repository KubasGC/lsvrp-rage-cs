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
using LSVRP.Features.Items;
using LSVRP.Libraries;
using LSVRP.New.Enums;
using LogType = LSVRP.Modules.LogType;

namespace LSVRP.Database.Models
{
    [Table("lsvrp_items")]
    public class Item
    {
        [Key] public int Id { get; set; }
        [StringLength(255)] public string Name { get; set; }
        public OwnerType OwnerType { get; set; }
        public int Owner { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double RotZ { get; set; }
        public int Dimension { get; set; }
        public ItemType Type { get; set; }
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public string Value3 { get; set; }
        [Column("Used")] private bool UsedMapped { get; set; }

        [NotMapped]
        public bool Used
        {
            get => UsedMapped;
            set
            {
                UsedMapped = value;
                SetLastUsed();
            }
        }

        public int FlagType { get; set; }
        public int Flag { get; set; }
        public int LastUsed { get; set; }


        [NotMapped] public GTANetworkAPI.Object ObjectHandle { get; set; }

        /// <summary>
        /// Zapisuje informacje o przedmiocie do bazy danych
        /// </summary>
        public void Save()
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                using (Database db = new Database())
                {
                    db.Items.Update(this);
                    db.SaveChanges();
                    Modules.Log.ConsoleLog("ITEMS", $"Zapis przedmiotu o ID {Id}.", LogType.Debug);
                }
            });
            /*new Thread(() =>
            {
                using (Database db = new Database())
                {
                    db.Items.Update(this);
                    db.SaveChanges();
                    Modules.Log.ConsoleLog("ITEMS", $"Zapis przedmiotu o ID {Id}.", LogType.Debug);
                }
            }).Start();*/
        }

        /// <summary>
        /// Ustawia wartość LastUsed na CURRENT_TIMESTAMP
        /// </summary>
        public void SetLastUsed()
        {
            LastUsed = Global.GetTimestamp();
        }
    }
}