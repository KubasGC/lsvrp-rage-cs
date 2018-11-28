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
using LSVRP.Libraries;

namespace LSVRP.Database.Models
{
    [Table("lsvrp_houses")]
    public class House
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public int Dimension { get; set; }
        public int Price { get; set; }
        public int BoughtTimestamp { get; set; }

        [NotMapped] public Interior InteriorData { get; set; }


        /// <summary>
        /// Zapisuje dane o mieszkaniu.
        /// </summary>
        public void Save()
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                using (Database db = new Database())
                {
                    db.Houses.Update(this);
                    db.SaveChanges();
                }
            });
            /*new Thread(() =>
            {
                using (Database db = new Database())
                {
                    db.Houses.Update(this);
                    db.SaveChanges();
                }
            }).Start();*/
        }

        /// <summary>
        /// Ustawia timestamp zakupienia mieszkania.
        /// </summary>
        public void SetTimestamp()
        {
            BoughtTimestamp = Global.GetTimestamp();
        }


        /// <summary>
        /// Ładuje dane interioru.
        /// </summary>
        public void LoadInteriorData()
        {
            InteriorData = Library.GetInteriorDataByDim(Dimension);
        }
    }
}