using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace DataEf.Entities;

public partial class AbdulContext : DbContext
{
    public AbdulContext()
    {
    }

    public AbdulContext(DbContextOptions<AbdulContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cert> Certs { get; set; }

    public virtual DbSet<Comp> Comps { get; set; }

    public virtual DbSet<Edu> Edus { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<User> Users { get; set; }

    string conn = File.ReadAllText("/Users/abdulaleem/Documents/Project Dev/01/ConStr.txt");
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(conn);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cert>(entity =>
        {
            entity.HasKey(e => e.CertId).HasName("PK__cert__024B46ECDBB5EA87");

            entity.HasOne(d => d.Us).WithMany(p => p.Certs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usid_cert");
        });

        modelBuilder.Entity<Comp>(entity =>
        {
            entity.HasKey(e => e.CompId).HasName("PK__comp__531653DD8A24CDCE");

            entity.HasOne(d => d.Us).WithMany(p => p.Comps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usid_Comp");
        });

        modelBuilder.Entity<Edu>(entity =>
        {
            entity.HasKey(e => e.EduId).HasName("PK__edu__258337716C9F8D3B");

            entity.HasOne(d => d.Us).WithMany(p => p.Edus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usid_edu");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("PK__skills__FBBA83799DF97334");

            entity.HasOne(d => d.Us).WithMany(p => p.Skills)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usid_skill");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__user__B9BE370F724DEB5E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
