using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Trabjobs.Models;

public partial class DreamDbaseContext : DbContext
{

    public DreamDbaseContext(DbContextOptions<DreamDbaseContext> options) : base(options)
    {

    }

    public virtual DbSet<Empleo> Empleos { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<LoginEmpresa> LoginEmpresas { get; set; }

    public virtual DbSet<LoginUsuario> LoginUsuarios { get; set; }

    public virtual DbSet<PostulacionesEmpleo> PostulacionesEmpleos { get; set; }

    public virtual DbSet<RolesEmpresa> RolesEmpresas { get; set; }

    public virtual DbSet<RolesUsuario> RolesUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleo>(entity =>
        {
            entity.HasKey(e => e.IdEmpleo).HasName("PK__Empleos__DAE0224234E359B6");

            entity.Property(e => e.IdEmpleo).HasColumnName("id_Empleo");
            entity.Property(e => e.DescripcionEmpleo).HasColumnName("descripcion_Empleo");
            entity.Property(e => e.FechaPublicacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_Publicacion");
            entity.Property(e => e.SalarioEmpleo)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("salario_Empleo");
            entity.Property(e => e.TituloEmpleo)
                .HasMaxLength(100)
                .HasColumnName("titulo_Empleo");
            entity.Property(e => e.UbicacionEmpleo)
                .HasMaxLength(100)
                .HasColumnName("ubicacion_Empleo");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa).HasName("PK__Empresas__DE87A153F8C71D07");

            entity.Property(e => e.IdEmpresa).HasColumnName("id_Empresa");
            entity.Property(e => e.ContraseñaEmpresa)
                .HasMaxLength(100)
                .HasColumnName("contraseña_Empresa");
            entity.Property(e => e.CorreoEmpresa)
                .HasMaxLength(100)
                .HasColumnName("correo_Empresa");
            entity.Property(e => e.LocacionEmpresa)
                .HasMaxLength(100)
                .HasColumnName("locacion_Empresa");
            entity.Property(e => e.NombreEmpresa)
                .HasMaxLength(100)
                .HasColumnName("nombre_Empresa");
            entity.Property(e => e.TelefonoEmpresa)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono_Empresa");

            entity.HasOne(d => d.RolEmpresa).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.RolEmpresaId)
                .HasConstraintName("FK__Empresas__RolEmp__5070F446");
        });

        modelBuilder.Entity<LoginEmpresa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Login_Em__3214EC0701394EF5");

            entity.ToTable("Login_Empresas");

            entity.Property(e => e.ContraseñaEmpresa)
                .HasMaxLength(100)
                .HasColumnName("contraseña_Empresa");
            entity.Property(e => e.CorreoEmpresa)
                .HasMaxLength(100)
                .HasColumnName("correo_Empresa");

            entity.HasOne(d => d.Empresa).WithMany(p => p.LoginEmpresas)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK__Login_Emp__Empre__5CD6CB2B");
        });

        modelBuilder.Entity<LoginUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Login_Us__3214EC07A0684174");

            entity.ToTable("Login_Usuarios");

            entity.Property(e => e.ContraseñaUsuarios)
                .HasMaxLength(255)
                .HasColumnName("contraseña_Usuarios");
            entity.Property(e => e.CorreoUsuarios)
                .HasMaxLength(100)
                .HasColumnName("correo_Usuarios");

            entity.HasOne(d => d.Usuario).WithMany(p => p.LoginUsuarios)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Login_Usu__Usuar__5FB337D6");
        });

        modelBuilder.Entity<PostulacionesEmpleo>(entity =>
        {
            entity.HasKey(e => e.IdPostulacion).HasName("PK__Postulac__70E2666282756634");

            entity.Property(e => e.IdPostulacion).HasColumnName("id_Postulacion");
            entity.Property(e => e.FechaPostulacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_Postulacion");
            entity.Property(e => e.IdEmpleo).HasColumnName("id_Empleo");
            entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");

            entity.HasOne(d => d.IdEmpleoNavigation).WithMany(p => p.PostulacionesEmpleos)
                .HasForeignKey(d => d.IdEmpleo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PostulacionesEmpleos_Empleos");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.PostulacionesEmpleos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PostulacionesEmpleos_Usuarios");
        });

        modelBuilder.Entity<RolesEmpresa>(entity =>
        {
            entity.HasKey(e => e.IdRolesEmpresa).HasName("PK__RolesEmp__9B018372282A9DB0");

            entity.ToTable("RolesEmpresa");

            entity.Property(e => e.IdRolesEmpresa)
                .ValueGeneratedNever()
                .HasColumnName("id_RolesEmpresa");
            entity.Property(e => e.NombreEmpresa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_Empresa");
        });

        modelBuilder.Entity<RolesUsuario>(entity =>
        {
            entity.HasKey(e => e.IdRolesUsuario).HasName("PK__RolesUsu__FEB1C9D76A2F98DA");

            entity.Property(e => e.IdRolesUsuario)
                .ValueGeneratedNever()
                .HasColumnName("id_RolesUsuario");
            entity.Property(e => e.NombreRolesUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_RolesUsuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__8E901EAA60EF88F6");

            entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");
            entity.Property(e => e.ApellidoUsuarios)
                .HasMaxLength(100)
                .HasColumnName("apellido_Usuarios");
            entity.Property(e => e.ContraseñaUsuarios)
                .HasMaxLength(255)
                .HasColumnName("contraseña_Usuarios");
            entity.Property(e => e.CorreoUsuarios)
                .HasMaxLength(100)
                .HasColumnName("correo_Usuarios");
            entity.Property(e => e.NombreUsuarios)
                .HasMaxLength(100)
                .HasColumnName("nombre_Usuarios");
            entity.Property(e => e.TelefonoUsuarios)
                .HasMaxLength(20)
                .HasColumnName("telefono_Usuarios");

            entity.HasOne(d => d.RolUsuario).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolUsuarioId)
                .HasConstraintName("FK__Usuarios__RolUsu__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
