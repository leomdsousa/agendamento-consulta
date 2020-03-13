﻿// <auto-generated />
using System;
using AlbertEinsteinTeste.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlbertEinsteinTeste.Migrations
{
    [DbContext(typeof(AlbertEinsteinTesteContext))]
    [Migration("20200311183846_CriacaoDeCampoPacienteId")]
    partial class CriacaoDeCampoPacienteId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AlbertEinsteinTeste.Models.Consulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConsultaSituacao");

                    b.Property<DateTime>("DataConsulta");

                    b.Property<string>("Diagnostico")
                        .IsRequired();

                    b.Property<int>("MedicoId");

                    b.Property<int>("PacienteId");

                    b.Property<string>("Sintoma")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("AlbertEinsteinTeste.Models.Medico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cidade");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Especialidade");

                    b.Property<string>("Estado");

                    b.Property<bool>("Ferias");

                    b.Property<string>("Nome");

                    b.Property<double>("Salario");

                    b.Property<string>("Sexo");

                    b.HasKey("Id");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("AlbertEinsteinTeste.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cidade");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Estado");

                    b.Property<string>("Nome");

                    b.Property<string>("Sexo");

                    b.HasKey("Id");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("AlbertEinsteinTeste.Models.Consulta", b =>
                {
                    b.HasOne("AlbertEinsteinTeste.Models.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AlbertEinsteinTeste.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
