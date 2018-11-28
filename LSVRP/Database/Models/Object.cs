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
    [Table("lsvrp_objects")]
    public class Object
    {
        [Key] public int Id { get; set; }
        public int Model { get; set; }
        [Column("Doors")] public int DoorId { get; set; }
        [Column("VirtualWorld")] public int Dimension { get; set; }
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }
        public float RotX { get; set; }
        public float RotY { get; set; }
        public float RotZ { get; set; }
        public int Alpha { get; set; }

        [NotMapped] public GTANetworkAPI.Object ObjectHandle { get; set; }
        [NotMapped] public Client EditedBy { get; set; }

        public void Create()
        {
            if (ObjectHandle != null && NAPI.Entity.DoesEntityExist(ObjectHandle)) ObjectHandle.Delete();
            ObjectHandle = NAPI.Object.CreateObject(Model, GetPos(), GetRot(), (byte) Alpha, (uint) Dimension);
        }

        /// <summary>
        /// Zwraca pozycję obiektu w wektorze.
        /// </summary>
        /// <returns></returns>
        public Vector3 GetPos()
        {
            return new Vector3(PosX, PosY, PosZ);
        }

        /// <summary>
        /// Zwraca rotację obiektu w wektorze.
        /// </summary>
        /// <returns></returns>
        public Vector3 GetRot()
        {
            return new Vector3(RotX, RotY, RotZ);
        }


        /// <summary>
        /// Zapisuje informacje o obiekcie do bazy danych.
        /// </summary>
        public void Save()
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                using (Database db = new Database())
                {
                    db.Objects.Update(this);
                    db.SaveChanges();
                }
            });
            /*new Thread(() =>
            {
                using (Database db = new Database())
                {
                    db.Objects.Update(this);
                    db.SaveChanges();
                }
            }).Start();*/
        }
    }
}