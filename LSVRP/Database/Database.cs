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
using LSVRP.Database.Models;
using LSVRP.Managers;
using Microsoft.EntityFrameworkCore;

// ReSharper disable UnassignedGetOnlyAutoProperty
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace LSVRP.Database
{
    public class Database : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupRank> GroupRanks { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<GroupDuty> GroupDuties { get; set; }
        public DbSet<GroupProduct> GroupProducts { get; set; }
        public DbSet<GroupAccountLog> GroupAccountLogs { get; set; }
        public DbSet<ForumMember> ForumMembers { get; set; }
        public DbSet<LoginLog> LoginLogs { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Ban> Bans { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<AdminDuty> AdminDuties { get; set; }
        public DbSet<Blip> Blips { get; set; }
        public DbSet<Animation> Animations { get; set; }
        public DbSet<Interior> Interiors { get; set; }
        public DbSet<InteriorDoor> InteriorDoors { get; set; }
        public DbSet<ClothSet> ClothSets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPending> OrdersPendings { get; set; }
        public DbSet<Corner> Corners { get; set; }
        public DbSet<WalkingStyle> WalkingStyles { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopProduct> ShopProducts { get; set; }
        public DbSet<VehicleMod> VehicleMods { get; set; }
        public DbSet<Tattoo> Tattoos { get; set; }
        public DbSet<CharacterDrugAddictions> CharactersDrugAddictions { get; set; }
        public DbSet<DrugEffect> DrugEffects { get; set; }
        public DbSet<Body> Bodies { get; set; }
        public DbSet<VehicleFuel> VehiclesFuel { get; set; }
        public DbSet<Penalty> Penalties { get; set; }
        public DbSet<Object> Objects { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<CharacterLook> CharactersLook { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Configuration configuration = Configuration.Get();
            optionsBuilder.UseMySQL(
                $"server={configuration.DatabaseHost};database={configuration.DatabaseDb};user={configuration.DatabaseUser};password={configuration.DatabasePass};port={configuration.DatabasePort};sslmode=none;Max Pool Size=50;");
        }
    }
}