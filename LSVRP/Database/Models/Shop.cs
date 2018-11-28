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
using LSVRP.Features.Clothes;

namespace LSVRP.Database.Models
{
    [Table("lsvrp_247_shops")]
    public class Shop
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public ShopTypes ShopType { get; set; }

        [NotMapped] public Vector3 Position => new Vector3(X, Y, Z);
        [NotMapped] public GTANetworkAPI.Blip ShopBlip { get; set; }
        [NotMapped] public Marker ShopMarker { get; set; }

        public void Save()
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                using (Database db = new Database())
                {
                    db.Shops.Update(this);
                    db.SaveChanges();
                }
            });

            /*new Thread(() =>
            {
                using (Database db = new Database())
                {
                    db.Shops.Update(this);
                    db.SaveChanges();
                }
            }).Start();*/
        }
    }
}