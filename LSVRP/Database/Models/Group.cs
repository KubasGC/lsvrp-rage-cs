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
using LSVRP.Features.Groups;

namespace LSVRP.Database.Models
{
    [Table("lsvrp_groups")]
    public class Group
    {
        [Key] public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int ColorR { get; set; }
        public int ColorG { get; set; }
        public int ColorB { get; set; }
        public GroupType Type { get; set; }
        public double SpawnX { get; set; }
        public double SpawnY { get; set; }
        public double SpawnZ { get; set; }
        public int Status { get; set; }
        [Column("SuperLeaderID")] public int SuperLeaderId { get; set; }
        public int Cash { get; set; }
        public int CreatedAt { get; set; }
        public string Permissions { get; set; }
        public int Donation { get; set; }
        public int SpawnDimension { get; set; }
        public int DefaultRank { get; set; }
        [Column("ordersType")] public int OrdersType { get; set; }

        [NotMapped] public List<object> ListedPermissions { get; set; }
        [NotMapped] public bool ChatDisabled { get; set; }


        public void Save()
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                using (Database db = new Database())
                {
                    db.Groups.Update(this);
                    db.SaveChanges();
                }
            });

            /*new Thread(() =>
            {
                using (Database db = new Database())
                {
                    db.Groups.Update(this);
                    db.SaveChanges();
                }
            }).Start();*/
        }
    }
}