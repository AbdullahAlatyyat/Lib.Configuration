using System;
using Framework.Configuration.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Framework.Configuration.EF
{
    public partial class ConfigurationContext : DbContext
    {
        public ConfigurationContext()
        {
        }

        public ConfigurationContext(DbContextOptions<ConfigurationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blocks> Blocks { get; set; }
        public virtual DbSet<Configurations> Configurations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationConstants.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blocks>(entity =>
            {
                entity.ToTable("Blocks", "Config");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Configurations>(entity =>
            {
                entity.ToTable("Configurations", "Config");

                entity.Property(e => e.KeyName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.KeyValue)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.Configurations)
                    .HasForeignKey(d => d.BlockId)
                    .HasConstraintName("FK_Configurations_Blocks");
            });
        }
    }
}
