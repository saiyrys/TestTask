using TestTask.ApplicationCore.Models;

namespace TestTask.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        public DbSet<Areas> Areas { get; set; }
        public DbSet<Specialization> Specialization { get; set; }
        public DbSet<Cabinets> Cabinets { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Doctors> Doctors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Areas>(entity =>
            {
                entity.HasKey(a => new { a.areasId });
                entity.HasIndex(a => new { a.areasNumber }).IsUnique();
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.HasKey(s => new { s.specializationId });
                entity.HasIndex(s => new { s.specializationName}).IsUnique();
            });

            modelBuilder.Entity<Cabinets>(entity =>
            {
                entity.HasKey(c => new { c.cabinetId });
                entity.HasIndex(c => new { c.cabinetNumber }).IsUnique();
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.HasKey(p => new { p.id });
                entity.HasIndex(p => new { p.firstName, p.lastName, p.middleName });

                entity.HasOne(p => p.areas).WithMany().HasForeignKey(p => p.areasId);
            });

            modelBuilder.Entity<Doctors>(entity =>
            {
                entity.HasKey(d => new { d.id });
                entity.HasIndex(d => new { d.fullName });

                entity.HasOne(d => d.cabinets).WithMany().HasForeignKey(d => d.cabinetsId);
                entity.HasOne(d => d.specialization).WithMany().HasForeignKey(d => d.specializationId);
                entity.HasOne(d => d.areas).WithMany().HasForeignKey(d => d.areasId);
            });
        }
    }
}
