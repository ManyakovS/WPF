using System.Data.Entity;

namespace PracticCinema.Models.Data
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Asset> Assets { get; set; }

        public DbSet<Film> Films { get; set; }

        public DbSet<Place> Places { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<CinemaHall> CinemaHalls { get; set; }

        public ApplicationContext() : base("DefaultConnection")
        {
            
        }
    }
}
