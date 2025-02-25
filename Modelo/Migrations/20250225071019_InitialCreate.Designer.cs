﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Modelo;

#nullable disable

namespace Modelo.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20250225071019_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ComponenteUsuario", b =>
                {
                    b.Property<int>("PerfilComponenteId")
                        .HasColumnType("int");

                    b.Property<int>("UsuariosUsuarioId")
                        .HasColumnType("int");

                    b.HasKey("PerfilComponenteId", "UsuariosUsuarioId");

                    b.HasIndex("UsuariosUsuarioId");

                    b.ToTable("ComponenteUsuario");
                });

            modelBuilder.Entity("Entidades.AuditoriaCliente", b =>
                {
                    b.Property<int>("AuditoriaClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuditoriaClienteId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<long>("DNI")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("FechaAuditoria")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreyApellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoMovimiento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("AuditoriaClienteId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("AuditoriaClientes");
                });

            modelBuilder.Entity("Entidades.AuditoriaSesion", b =>
                {
                    b.Property<int>("AuditoriaSesionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuditoriaSesionId"));

                    b.Property<DateTime?>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("AuditoriaSesionId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("AuditoriasSesion");
                });

            modelBuilder.Entity("Entidades.DetalleNotaCompra", b =>
                {
                    b.Property<int>("DetalleNotaCompraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleNotaCompraId"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("NotaCompraId")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DetalleNotaCompraId");

                    b.HasIndex("NotaCompraId");

                    b.HasIndex("ProductoId");

                    b.ToTable("DetallesNotaCompra");
                });

            modelBuilder.Entity("Entidades.DetalleNotaVenta", b =>
                {
                    b.Property<int>("DetalleNotaVentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleNotaVentaId"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("NotaVentaId")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DetalleNotaVentaId");

                    b.HasIndex("NotaVentaId");

                    b.HasIndex("ProductoId");

                    b.ToTable("DetallesNotaVenta");
                });

            modelBuilder.Entity("Entidades.NotaCompra", b =>
                {
                    b.Property<int>("NotaCompraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotaCompraId"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("NroNotaCompra")
                        .HasColumnType("int");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("int");

                    b.Property<int>("tipoMedioPago")
                        .HasColumnType("int");

                    b.HasKey("NotaCompraId");

                    b.HasIndex("ProveedorId");

                    b.ToTable("NotasCompra");
                });

            modelBuilder.Entity("Entidades.NotaVenta", b =>
                {
                    b.Property<int>("NotaVentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotaVentaId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("NroNotaVenta")
                        .HasColumnType("int");

                    b.Property<int>("estadosNotaVenta")
                        .HasColumnType("int");

                    b.Property<int>("tipoMedioPago")
                        .HasColumnType("int");

                    b.HasKey("NotaVentaId");

                    b.HasIndex("ClienteId");

                    b.ToTable("NotasVenta");
                });

            modelBuilder.Entity("Entidades.Persona", b =>
                {
                    b.Property<int>("PersonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonaId"));

                    b.Property<long>("DNI")
                        .HasColumnType("bigint");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Domicilio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreyApellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonaId");

                    b.ToTable("Personas");

                    b.HasDiscriminator().HasValue("Persona");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Entidades.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductoId"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ProductoId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Entidades.Seguridad.Componente", b =>
                {
                    b.Property<int>("ComponenteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComponenteId"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int?>("GrupoComponenteId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ComponenteId");

                    b.HasIndex("GrupoComponenteId");

                    b.ToTable("Componentes");

                    b.HasDiscriminator().HasValue("Componente");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Entidades.Seguridad.EstadoGrupo", b =>
                {
                    b.Property<int>("EstadoGrupoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoGrupoId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoGrupoId");

                    b.ToTable("EstadoGrupos");
                });

            modelBuilder.Entity("Entidades.Seguridad.EstadoUsuario", b =>
                {
                    b.Property<int>("EstadoUsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoUsuarioId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoUsuarioId");

                    b.ToTable("EstadoUsuarios");
                });

            modelBuilder.Entity("Entidades.Seguridad.Formulario", b =>
                {
                    b.Property<int>("FormularioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FormularioId"));

                    b.Property<int>("ModuloId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FormularioId");

                    b.HasIndex("ModuloId");

                    b.ToTable("Formularios");
                });

            modelBuilder.Entity("Entidades.Seguridad.Modulo", b =>
                {
                    b.Property<int>("ModuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModuloId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ModuloId");

                    b.ToTable("Modulos");
                });

            modelBuilder.Entity("Entidades.Seguridad.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoUsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreyApellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.HasIndex("EstadoUsuarioId");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator().HasValue("Usuario");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Entidades.Cliente", b =>
                {
                    b.HasBaseType("Entidades.Persona");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("CantidadNotasVenta")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("Entidades.Proveedor", b =>
                {
                    b.HasBaseType("Entidades.Persona");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("CUIT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CantidadNotasCompra")
                        .HasColumnType("int");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("int");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Personas", t =>
                        {
                            t.Property("Activo")
                                .HasColumnName("Proveedor_Activo");

                            t.Property("RazonSocial")
                                .HasColumnName("Proveedor_RazonSocial");
                        });

                    b.HasDiscriminator().HasValue("Proveedor");
                });

            modelBuilder.Entity("Entidades.Seguridad.Accion", b =>
                {
                    b.HasBaseType("Entidades.Seguridad.Componente");

                    b.Property<int>("AccionId")
                        .HasColumnType("int");

                    b.Property<bool>("Asignada")
                        .HasColumnType("bit");

                    b.Property<int>("FormularioId")
                        .HasColumnType("int");

                    b.HasIndex("FormularioId");

                    b.HasDiscriminator().HasValue("Accion");
                });

            modelBuilder.Entity("Entidades.Seguridad.Grupo", b =>
                {
                    b.HasBaseType("Entidades.Seguridad.Componente");

                    b.Property<bool>("Asignado")
                        .HasColumnType("bit");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoGrupoId")
                        .HasColumnType("int");

                    b.Property<int>("GrupoId")
                        .HasColumnType("int");

                    b.HasIndex("EstadoGrupoId");

                    b.HasDiscriminator().HasValue("Grupo");
                });

            modelBuilder.Entity("Entidades.Seguridad.Administrador", b =>
                {
                    b.HasBaseType("Entidades.Seguridad.Usuario");

                    b.Property<int>("AdministradorId")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Administrador");
                });

            modelBuilder.Entity("ComponenteUsuario", b =>
                {
                    b.HasOne("Entidades.Seguridad.Componente", null)
                        .WithMany()
                        .HasForeignKey("PerfilComponenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Seguridad.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UsuariosUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entidades.AuditoriaCliente", b =>
                {
                    b.HasOne("Entidades.Seguridad.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Entidades.AuditoriaSesion", b =>
                {
                    b.HasOne("Entidades.Seguridad.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Entidades.DetalleNotaCompra", b =>
                {
                    b.HasOne("Entidades.NotaCompra", "NotaCompra")
                        .WithMany("DetallesNotaCompra")
                        .HasForeignKey("NotaCompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Producto", "Producto")
                        .WithMany("DetallesNotaCompra")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NotaCompra");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Entidades.DetalleNotaVenta", b =>
                {
                    b.HasOne("Entidades.NotaVenta", "NotaVenta")
                        .WithMany("DetallesNotaVenta")
                        .HasForeignKey("NotaVentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Producto", "Producto")
                        .WithMany("DetallesNotaVenta")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NotaVenta");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Entidades.NotaCompra", b =>
                {
                    b.HasOne("Entidades.Proveedor", "Proveedor")
                        .WithMany("NotasCompra")
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("Entidades.NotaVenta", b =>
                {
                    b.HasOne("Entidades.Cliente", "Cliente")
                        .WithMany("NotasVenta")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Entidades.Seguridad.Componente", b =>
                {
                    b.HasOne("Entidades.Seguridad.Grupo", null)
                        .WithMany("Hijos")
                        .HasForeignKey("GrupoComponenteId");
                });

            modelBuilder.Entity("Entidades.Seguridad.Formulario", b =>
                {
                    b.HasOne("Entidades.Seguridad.Modulo", "Modulo")
                        .WithMany("Formularios")
                        .HasForeignKey("ModuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modulo");
                });

            modelBuilder.Entity("Entidades.Seguridad.Usuario", b =>
                {
                    b.HasOne("Entidades.Seguridad.EstadoUsuario", "EstadoUsuario")
                        .WithMany("Usuarios")
                        .HasForeignKey("EstadoUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoUsuario");
                });

            modelBuilder.Entity("Entidades.Seguridad.Accion", b =>
                {
                    b.HasOne("Entidades.Seguridad.Formulario", "Formulario")
                        .WithMany("Acciones")
                        .HasForeignKey("FormularioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Formulario");
                });

            modelBuilder.Entity("Entidades.Seguridad.Grupo", b =>
                {
                    b.HasOne("Entidades.Seguridad.EstadoGrupo", "EstadoGrupo")
                        .WithMany("Grupos")
                        .HasForeignKey("EstadoGrupoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoGrupo");
                });

            modelBuilder.Entity("Entidades.NotaCompra", b =>
                {
                    b.Navigation("DetallesNotaCompra");
                });

            modelBuilder.Entity("Entidades.NotaVenta", b =>
                {
                    b.Navigation("DetallesNotaVenta");
                });

            modelBuilder.Entity("Entidades.Producto", b =>
                {
                    b.Navigation("DetallesNotaCompra");

                    b.Navigation("DetallesNotaVenta");
                });

            modelBuilder.Entity("Entidades.Seguridad.EstadoGrupo", b =>
                {
                    b.Navigation("Grupos");
                });

            modelBuilder.Entity("Entidades.Seguridad.EstadoUsuario", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Entidades.Seguridad.Formulario", b =>
                {
                    b.Navigation("Acciones");
                });

            modelBuilder.Entity("Entidades.Seguridad.Modulo", b =>
                {
                    b.Navigation("Formularios");
                });

            modelBuilder.Entity("Entidades.Cliente", b =>
                {
                    b.Navigation("NotasVenta");
                });

            modelBuilder.Entity("Entidades.Proveedor", b =>
                {
                    b.Navigation("NotasCompra");
                });

            modelBuilder.Entity("Entidades.Seguridad.Grupo", b =>
                {
                    b.Navigation("Hijos");
                });
#pragma warning restore 612, 618
        }
    }
}
