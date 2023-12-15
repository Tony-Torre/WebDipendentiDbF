using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebDipendentiDbF.Models;

namespace WebDipendentiDbF.Models;

public partial class DatabaseDipendentiContext : DbContext
{
    public DatabaseDipendentiContext()
    {
    }

    public DatabaseDipendentiContext(DbContextOptions<DatabaseDipendentiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnagraficaGenerale> AnagraficaGenerales { get; set; }

    public virtual DbSet<MyUser> MyUser { get; set; }

    public virtual DbSet<AttivitaDipendente> AttivitaDipendentes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=DatabaseDipendenti;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnagraficaGenerale>(entity =>
        {
            entity.HasKey(e => e.Matricola).HasName("PK_AnagraficaGenerale_1");

            entity.ToTable("AnagraficaGenerale");

            entity.Property(e => e.Matricola)
                .HasMaxLength(4)
                .IsFixedLength();
            entity.Property(e => e.Cap)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CAP");
            entity.Property(e => e.Citta).HasMaxLength(50);
            entity.Property(e => e.Indirizzo).HasMaxLength(50);
            entity.Property(e => e.Nominativo).HasMaxLength(50);
            entity.Property(e => e.Provincia).HasMaxLength(4);
            entity.Property(e => e.Reparto).HasMaxLength(50);
            entity.Property(e => e.Ruolo).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(50);
        });

        modelBuilder.Entity<AttivitaDipendente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AttivitàDipendente");

            entity.ToTable("AttivitaDipendente");

            entity.Property(e => e.Attivita).HasMaxLength(50);
            entity.Property(e => e.DataAttivita).HasColumnType("datetime");
            entity.Property(e => e.Matricola)
                .HasMaxLength(4)
                .IsFixedLength();
            entity.Property(e => e.Ore).HasColumnType("numeric(10, 2)");

            entity.HasOne(d => d.MatricolaNavigation).WithMany(p => p.AttivitaDipendentes)
                .HasForeignKey(d => d.Matricola)
                .HasConstraintName("FK_AttivitàDipendente_AnagraficaGenerale_AnagMatricola_Matricola");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<WebDipendentiDbF.Models.MyUser> Registration { get; set; } = default!;
}
