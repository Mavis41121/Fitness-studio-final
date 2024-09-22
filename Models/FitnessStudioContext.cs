using Microsoft.EntityFrameworkCore;

namespace MyFitnessStudio.Models
{
    public class FitnessStudioContext : DbContext
    {
        public FitnessStudioContext(DbContextOptions<FitnessStudioContext> options) : base(options)
        {
        }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}