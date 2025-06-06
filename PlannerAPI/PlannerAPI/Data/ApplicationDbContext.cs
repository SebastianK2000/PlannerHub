using Microsoft.EntityFrameworkCore;

namespace PlannerAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Accommodation> Accommodation { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<TeamMember> TeamMember { get; set; }
        public DbSet<Trip> Trip { get; set; }
        public DbSet<TripUser> TripUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relacje TripUser
            modelBuilder.Entity<TripUser>()
                .HasOne(tu => tu.User)
                .WithMany()
                .HasForeignKey(tu => tu.IDuser);

            modelBuilder.Entity<TripUser>()
                .HasOne(tu => tu.Trip)
                .WithMany()
                .HasForeignKey(tu => tu.IDtrip);

            // Relacjwe TeamMember
            modelBuilder.Entity<TeamMember>()
                .HasOne(tm => tm.User)
                .WithMany()
                .HasForeignKey(tm => tm.IDuser);

            modelBuilder.Entity<TeamMember>()
                .HasOne(t => t.Team)
                .WithMany()
                .HasForeignKey(t => t.TeamId);

            // Konfiguracja pól decimal, by uniknąć ostrzeżeń i przycięć
            modelBuilder.Entity<Accommodation>()
                .Property(a => a.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Booking>()
                .Property(b => b.TotalPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");
        }
    }
}
