using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Test.Data.Models
{
    public partial class ShivamTestContext : DbContext
    {
        public ShivamTestContext()
        {
        }

        public ShivamTestContext(DbContextOptions<ShivamTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Town> Towns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=SHIVAMPC;Database=Shivam.Test;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Iduser);

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.IdtownBorn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IDTown_born");

                entity.Property(e => e.IdtownLives)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IDTown_lives");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdtownBornNavigation)
                    .WithMany(p => p.PersonIdtownBornNavigations)
                    .HasForeignKey(d => d.IdtownBorn)
                    .HasConstraintName("FK_People_Town");

                entity.HasOne(d => d.IdtownLivesNavigation)
                    .WithMany(p => p.PersonIdtownLivesNavigations)
                    .HasForeignKey(d => d.IdtownLives)
                    .HasConstraintName("FK_People_Town1");
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity.HasKey(e => e.Idtown);

                entity.ToTable("Town");

                entity.Property(e => e.Idtown)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IDTown");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}