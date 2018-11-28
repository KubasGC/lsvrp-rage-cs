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

namespace LSVRP.Database.Models
{
    [Table("lsvrp_corners")]
    public class Corner
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public int Owner { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public int Dimension { get; set; }
        public bool HighRisk { get; set; }

        [NotMapped] public int DrugsSold { get; set; }


        public Vector3 GetPosition()
        {
            return new Vector3(X, Y, Z);
        }

        public void Save()
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                using (Database db = new Database())
                {
                    db.Corners.Update(this);
                    db.SaveChanges();
                }
            });
            /*new Thread(() =>
            {
                using (Database db = new Database())
                {
                    db.Corners.Update(this);
                    db.SaveChanges();
                }
            }).Start();*/
        }
    }
}