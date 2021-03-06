// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hotel.Models.dbModels;

namespace hotel.Migrations
{
    [DbContext(typeof(hotelContext))]
    [Migration("20220520005204_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("hotel.Models.dbModels.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ApellidoM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApellidoP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("hotel.Models.dbModels.Habitacione", b =>
                {
                    b.Property<int>("IdHabitacion")
                        .HasColumnType("int")
                        .HasColumnName("idHabitacion");

                    b.Property<bool>("Disponibilidad")
                        .HasColumnType("bit")
                        .HasColumnName("disponibilidad");

                    b.Property<int>("TipoHabitacion")
                        .HasColumnType("int")
                        .HasColumnName("tipoHabitacion");

                    b.HasKey("IdHabitacion");

                    b.HasIndex("TipoHabitacion");

                    b.ToTable("habitaciones");
                });

            modelBuilder.Entity("hotel.Models.dbModels.MetodoPago", b =>
                {
                    b.Property<int>("IdMetodoPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idMetodoPago")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.HasKey("IdMetodoPago");

                    b.ToTable("metodoPago");
                });

            modelBuilder.Entity("hotel.Models.dbModels.ReservacionHabitacion", b =>
                {
                    b.Property<int>("IdReservacion")
                        .HasColumnType("int")
                        .HasColumnName("idReservacion");

                    b.Property<int>("IdHabitacion")
                        .HasColumnType("int")
                        .HasColumnName("idHabitacion");

                    b.HasKey("IdReservacion", "IdHabitacion");

                    b.HasIndex("IdHabitacion");

                    b.ToTable("reservacion_habitacion");
                });

            modelBuilder.Entity("hotel.Models.dbModels.Reservacione", b =>
                {
                    b.Property<int>("IdReservacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idReservacion")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadPersonas")
                        .HasColumnType("int")
                        .HasColumnName("cantidadPersonas");

                    b.Property<double>("CostoTotal")
                        .HasColumnType("float")
                        .HasColumnName("costoTotal");

                    b.Property<string>("Detalles")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("detalles");

                    b.Property<DateTime>("FechaLlegada")
                        .HasColumnType("datetime")
                        .HasColumnName("fechaLlegada");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("datetime")
                        .HasColumnName("fechaSalida");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("idUsuario");

                    b.Property<int>("MetodoPago")
                        .HasColumnType("int")
                        .HasColumnName("metodoPago");

                    b.HasKey("IdReservacion");

                    b.HasIndex("IdUsuario");

                    b.HasIndex("MetodoPago");

                    b.ToTable("reservaciones");
                });

            modelBuilder.Entity("hotel.Models.dbModels.Reseña", b =>
                {
                    b.Property<int>("IdReseña")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int>("Puntuacion")
                        .HasColumnType("int")
                        .HasColumnName("puntuacion");

                    b.Property<string>("Reseña1")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("reseña");

                    b.Property<int>("TipoHabitacion")
                        .HasColumnType("int")
                        .HasColumnName("tipoHabitacion");

                    b.HasKey("IdReseña");

                    b.HasIndex("IdUsuario");

                    b.HasIndex("TipoHabitacion");

                    b.ToTable("reseñas");
                });

            modelBuilder.Entity("hotel.Models.dbModels.TipoHabitacion", b =>
                {
                    b.Property<int>("IdTipoHabitacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idTipoHabitacion")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Costo")
                        .HasColumnType("float")
                        .HasColumnName("costo");

                    b.Property<double>("CostoExPersona")
                        .HasColumnType("float")
                        .HasColumnName("costoExPersona");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("descripcion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.Property<string>("RutaImg")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("rutaImg");

                    b.HasKey("IdTipoHabitacion");

                    b.ToTable("tipoHabitacion");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("hotel.Models.dbModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("hotel.Models.dbModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hotel.Models.dbModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("hotel.Models.dbModels.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("hotel.Models.dbModels.Habitacione", b =>
                {
                    b.HasOne("hotel.Models.dbModels.TipoHabitacion", "TipoHabitacionNavigation")
                        .WithMany("Habitaciones")
                        .HasForeignKey("TipoHabitacion")
                        .HasConstraintName("FK_habitaciones_tipoHabitacion")
                        .IsRequired();

                    b.Navigation("TipoHabitacionNavigation");
                });

            modelBuilder.Entity("hotel.Models.dbModels.ReservacionHabitacion", b =>
                {
                    b.HasOne("hotel.Models.dbModels.Habitacione", "IdHabitacionNavigation")
                        .WithMany("ReservacionHabitacions")
                        .HasForeignKey("IdHabitacion")
                        .HasConstraintName("FK_reservacion_habitacion_habitaciones")
                        .IsRequired();

                    b.HasOne("hotel.Models.dbModels.Reservacione", "IdReservacionNavigation")
                        .WithMany("ReservacionHabitacions")
                        .HasForeignKey("IdReservacion")
                        .HasConstraintName("FK_reservacion_habitacion_reservaciones")
                        .IsRequired();

                    b.Navigation("IdHabitacionNavigation");

                    b.Navigation("IdReservacionNavigation");
                });

            modelBuilder.Entity("hotel.Models.dbModels.Reservacione", b =>
                {
                    b.HasOne("hotel.Models.dbModels.ApplicationUser", "IdUsuarioNavigation")
                        .WithMany("Reservaciones")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK_reservaciones_usuarios")
                        .IsRequired();

                    b.HasOne("hotel.Models.dbModels.MetodoPago", "MetodoPagoNavigation")
                        .WithMany("Reservaciones")
                        .HasForeignKey("MetodoPago")
                        .HasConstraintName("FK_reservaciones_metodoPago")
                        .IsRequired();

                    b.Navigation("IdUsuarioNavigation");

                    b.Navigation("MetodoPagoNavigation");
                });

            modelBuilder.Entity("hotel.Models.dbModels.Reseña", b =>
                {
                    b.HasOne("hotel.Models.dbModels.ApplicationUser", "IdUsuarioNavigation")
                        .WithMany("Reseñas")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK_reseñas_usuarios")
                        .IsRequired();

                    b.HasOne("hotel.Models.dbModels.TipoHabitacion", "TipoHabitacionNavigation")
                        .WithMany("Reseñas")
                        .HasForeignKey("TipoHabitacion")
                        .HasConstraintName("FK_reseñas_tipoHabitacion")
                        .IsRequired();

                    b.Navigation("IdUsuarioNavigation");

                    b.Navigation("TipoHabitacionNavigation");
                });

            modelBuilder.Entity("hotel.Models.dbModels.ApplicationUser", b =>
                {
                    b.Navigation("Reseñas");

                    b.Navigation("Reservaciones");
                });

            modelBuilder.Entity("hotel.Models.dbModels.Habitacione", b =>
                {
                    b.Navigation("ReservacionHabitacions");
                });

            modelBuilder.Entity("hotel.Models.dbModels.MetodoPago", b =>
                {
                    b.Navigation("Reservaciones");
                });

            modelBuilder.Entity("hotel.Models.dbModels.Reservacione", b =>
                {
                    b.Navigation("ReservacionHabitacions");
                });

            modelBuilder.Entity("hotel.Models.dbModels.TipoHabitacion", b =>
                {
                    b.Navigation("Habitaciones");

                    b.Navigation("Reseñas");
                });
#pragma warning restore 612, 618
        }
    }
}
