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

namespace LSVRP.Database.Models
{
    [Table("lsvrp_characters_groups")]
    public class GroupMember
    {
        [Key] public int Id { get; set; }
        [Column("GroupID")] public int GroupId { get; set; }
        [Column("CharacterID")] public int CharacterId { get; set; }
        [Column("RankID")] public int RankId { get; set; }
        public int CreatedAt { get; set; }
        public int Payday { get; set; }
        public int DutyTime { get; set; }
        public int PaydayTimestamp { get; set; }
        public int PaydayAdded { get; set; }
        [Column("paydayDay")] public int PaydayDay { get; set; }

        [NotMapped] public bool Duty { get; set; }
        [NotMapped] public int DutyStartTimestamp { get; set; }
        [NotMapped] public string RankName { get; set; }
        [NotMapped] public List<object> RankPermissions { get; set; }
        [NotMapped] public int LastDutyTime { get; set; }

        public void Save()
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                using (Database db = new Database())
                {
                    db.GroupMembers.Update(this);
                    db.SaveChanges();
                }
            });

            /*new Thread(() =>
            {
                using (Database db = new Database())
                {
                    db.GroupMembers.Update(this);
                    db.SaveChanges();
                }
            }).Start();*/
        }
    }
}