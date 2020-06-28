using BatailleNavaleApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BatailleNavaleApp.Contexts
{
    public class BattleShipGameContext : DbContext
    {
        public DbSet<BoardCell> BoardCells { get; set; }
        public DbSet<BoardCoordinates> BoardCoordinates { get; set; }
        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<BattleShipGame> BattleShipGames { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=BattleShipGame.db");
            base.OnConfiguring(optionsBuilder);
        }


    }
}
