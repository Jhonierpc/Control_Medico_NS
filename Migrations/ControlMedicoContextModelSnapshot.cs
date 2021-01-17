﻿// <auto-generated />
using Control_Medico_NS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Control_Medico_NS.Migrations
{
    [DbContext(typeof(ControlMedicoContext))]
    partial class ControlMedicoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Control_Medico_NS.Models.Doctor", b =>
                {
                    b.Property<int>("PubIntIdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PubStrCredencial")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("PubStrEmail")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("PubStrHospital")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("PubStrNombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("PubStrTelefono")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("PubIntIdDoctor");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("Control_Medico_NS.Models.DoctorEspecialidad", b =>
                {
                    b.Property<int>("PubIntIdDoctor")
                        .HasColumnType("int");

                    b.Property<int>("PubIntIdEspecialidad")
                        .HasColumnType("int");

                    b.HasKey("PubIntIdDoctor", "PubIntIdEspecialidad");

                    b.HasIndex("PubIntIdEspecialidad");

                    b.ToTable("DoctorEspecialidad");
                });

            modelBuilder.Entity("Control_Medico_NS.Models.Especialidad", b =>
                {
                    b.Property<int>("PubIntIdEspecialidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PubStrDescripcion")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("PubIntIdEspecialidad");

                    b.ToTable("Especialidad");
                });

            modelBuilder.Entity("Control_Medico_NS.Models.Paciente", b =>
                {
                    b.Property<int>("PubIntIdPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PubStrCodigoPostal")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<string>("PubStrDireccion")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("PubStrEmail")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("PubStrNombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("PubStrSeguro")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("PubStrTelefono")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("PubIntIdPaciente");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("Control_Medico_NS.Models.DoctorEspecialidad", b =>
                {
                    b.HasOne("Control_Medico_NS.Models.Doctor", "Doctor")
                        .WithMany("DoctorEspecialidad")
                        .HasForeignKey("PubIntIdDoctor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Control_Medico_NS.Models.Especialidad", "Especialidad")
                        .WithMany("DoctorEspecialidad")
                        .HasForeignKey("PubIntIdEspecialidad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
