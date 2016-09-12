using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StaffSkills.Domain.Model.Entities;

namespace StaffSkills.Domain.Model
{
    public partial class StaffSkillsContext : DbContext
    {
        public StaffSkillsContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\v13.0;Database=staffskills_db;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Employee_PositionId");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Skill)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Skill_PositionId");
            });
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
    }
}