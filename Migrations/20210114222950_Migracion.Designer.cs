﻿// <auto-generated />
using Control_Medico_NS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Control_Medico_NS.Migrations
{
    [DbContext(typeof(ControlMedicoContext))]
    [Migration("20210114222950_Migracion")]
    partial class Migracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Control_Medico_NS.Models.Especialidad", b =>
                {
                    b.Property<int>("PubIntIdEspecialidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PubStrDescripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PubIntIdEspecialidad");

                    b.ToTable("Especialidad");
                });
#pragma warning restore 612, 618
        }
    }
}
