﻿// <auto-generated />
using System;
using Job_refugio_bd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Job_refugio_bd.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241030032502_M08-AddDateTimeVagas")]
    partial class M08AddDateTimeVagas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Job_refugio_bd.Models.Candidato", b =>
                {
                    b.Property<int>("IdCandidato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCandidato"));

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConfirmPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nacionalidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCandidato");

                    b.ToTable("Candidato");
                });

            modelBuilder.Entity("Job_refugio_bd.Models.Curriculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CandidatoId")
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CursosComplIdioma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpProf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FormAcad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObjProf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrincRealiza")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResumoQualific")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CandidatoId")
                        .IsUnique();

                    b.ToTable("Curriculo");
                });

            modelBuilder.Entity("Job_refugio_bd.Models.Empregador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cep")
                        .HasColumnType("int");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeEmpresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Empregador");
                });

            modelBuilder.Entity("Job_refugio_bd.Models.Inscrito", b =>
                {
                    b.Property<int>("Idinscricao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idinscricao"));

                    b.Property<int>("CandidatoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataInscricao")
                        .HasColumnType("datetime2");

                    b.Property<string>("StatusInscricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VagaId")
                        .HasColumnType("int");

                    b.HasKey("Idinscricao");

                    b.HasIndex("CandidatoId");

                    b.HasIndex("VagaId");

                    b.ToTable("Inscrito");
                });

            modelBuilder.Entity("Job_refugio_bd.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdCandidato")
                        .HasColumnType("int");

                    b.Property<int?>("IdEmpregador")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdCandidato")
                        .IsUnique()
                        .HasFilter("[IdCandidato] IS NOT NULL");

                    b.HasIndex("IdEmpregador")
                        .IsUnique()
                        .HasFilter("[IdEmpregador] IS NOT NULL");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Job_refugio_bd.Models.Vaga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DataPublicacao")
                        .HasColumnType("date");

                    b.Property<string>("DescVaga")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpregadorId")
                        .HasColumnType("int");

                    b.Property<string>("InfoAdicional")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Local")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetodoContratacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeCargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegimeTrabalho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequisitosQualificacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SobreEmpresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("VagaPCD")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("EmpregadorId");

                    b.ToTable("Vaga");
                });

            modelBuilder.Entity("Job_refugio_bd.Models.Curriculo", b =>
                {
                    b.HasOne("Job_refugio_bd.Models.Candidato", "Candidato")
                        .WithOne("Curriculo")
                        .HasForeignKey("Job_refugio_bd.Models.Curriculo", "CandidatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidato");
                });

            modelBuilder.Entity("Job_refugio_bd.Models.Inscrito", b =>
                {
                    b.HasOne("Job_refugio_bd.Models.Candidato", "Candidato")
                        .WithMany("Inscritos")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Job_refugio_bd.Models.Vaga", "Vaga")
                        .WithMany("Inscritos")
                        .HasForeignKey("VagaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidato");

                    b.Navigation("Vaga");
                });

            modelBuilder.Entity("Job_refugio_bd.Models.Usuario", b =>
                {
                    b.HasOne("Job_refugio_bd.Models.Candidato", "Candidato")
                        .WithOne()
                        .HasForeignKey("Job_refugio_bd.Models.Usuario", "IdCandidato");

                    b.HasOne("Job_refugio_bd.Models.Empregador", "Empregador")
                        .WithOne()
                        .HasForeignKey("Job_refugio_bd.Models.Usuario", "IdEmpregador");

                    b.Navigation("Candidato");

                    b.Navigation("Empregador");
                });

            modelBuilder.Entity("Job_refugio_bd.Models.Vaga", b =>
                {
                    b.HasOne("Job_refugio_bd.Models.Empregador", "Empregador")
                        .WithMany("Vagas")
                        .HasForeignKey("EmpregadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empregador");
                });

            modelBuilder.Entity("Job_refugio_bd.Models.Candidato", b =>
                {
                    b.Navigation("Curriculo");

                    b.Navigation("Inscritos");
                });

            modelBuilder.Entity("Job_refugio_bd.Models.Empregador", b =>
                {
                    b.Navigation("Vagas");
                });

            modelBuilder.Entity("Job_refugio_bd.Models.Vaga", b =>
                {
                    b.Navigation("Inscritos");
                });
#pragma warning restore 612, 618
        }
    }
}
