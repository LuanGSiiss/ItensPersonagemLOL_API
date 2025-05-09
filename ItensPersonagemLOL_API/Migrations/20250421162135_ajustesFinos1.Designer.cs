﻿// <auto-generated />
using ItensPersonagemLOL_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ItensPersonagemLOL_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250421162135_ajustesFinos1")]
    partial class ajustesFinos1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ItensPersonagemLOL_API.Model.Atributo", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Codigo"));

                    b.Property<string>("Apresentacao")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Codigo");

                    b.ToTable("Atributo");
                });

            modelBuilder.Entity("ItensPersonagemLOL_API.Model.Classe", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Codigo"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Codigo");

                    b.ToTable("Classe");
                });

            modelBuilder.Entity("ItensPersonagemLOL_API.Model.EfeitoPassivo", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Codigo"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("character varying(800)");

                    b.Property<int>("ItemCodigo")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Codigo");

                    b.HasIndex("ItemCodigo");

                    b.ToTable("EfeitosPassivo");
                });

            modelBuilder.Entity("ItensPersonagemLOL_API.Model.Item", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Codigo"));

                    b.Property<int>("ClasseCodigo")
                        .HasColumnType("integer");

                    b.Property<string>("EfeitoAtivo")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("character varying(800)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Preco")
                        .HasColumnType("integer");

                    b.HasKey("Codigo");

                    b.HasIndex("ClasseCodigo");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("ItensPersonagemLOL_API.Model.ItemAtributo", b =>
                {
                    b.Property<int>("ItemCodigo")
                        .HasColumnType("integer");

                    b.Property<int>("AtributoCodigo")
                        .HasColumnType("integer");

                    b.Property<int>("Valor")
                        .HasColumnType("integer");

                    b.HasKey("ItemCodigo", "AtributoCodigo");

                    b.HasIndex("AtributoCodigo");

                    b.ToTable("ItemAtributos");
                });

            modelBuilder.Entity("ItensPersonagemLOL_API.Model.ItemComponente", b =>
                {
                    b.Property<int>("ItemCodigo")
                        .HasColumnType("integer");

                    b.Property<int>("ComponenteCodigo")
                        .HasColumnType("integer");

                    b.HasKey("ItemCodigo", "ComponenteCodigo");

                    b.HasIndex("ComponenteCodigo");

                    b.ToTable("ItemComponente");
                });

            modelBuilder.Entity("ItensPersonagemLOL_API.Model.Personagem", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Codigo"));

                    b.Property<int>("ClasseCodigo")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Codigo");

                    b.HasIndex("ClasseCodigo");

                    b.ToTable("Personagem");
                });

            modelBuilder.Entity("ItensPersonagemLOL_API.Model.PersonagemItem", b =>
                {
                    b.Property<int>("PersonagemCodigo")
                        .HasColumnType("integer");

                    b.Property<int>("ItemCodigo")
                        .HasColumnType("integer");

                    b.HasKey("PersonagemCodigo", "ItemCodigo");

                    b.HasIndex("ItemCodigo");

                    b.ToTable("PersonagemItens");
                });

            modelBuilder.Entity("ItensPersonagemLOL_API.Model.EfeitoPassivo", b =>
                {
                    b.HasOne("ItensPersonagemLOL_API.Model.Item", "Item")
                        .WithMany("EfeitosPassivo")
                        .HasForeignKey("ItemCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("ItensPersonagemLOL_API.Model.Item", b =>
                {
                    b.HasOne("ItensPersonagemLOL_API.Model.Classe", "Classe")
                        .WithMany("Itens")
                        .HasForeignKey("ClasseCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classe");
                });

            modelBuilder.Entity("ItensPersonagemLOL_API.Model.ItemAtributo", b =>
                {
                    b.HasOne("ItensPersonagemLOL_API.Model.Atributo", "Atributo")
                        .WithMany("ItemAtributos")
                        .HasForeignKey("AtributoCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ItensPersonagemLOL_API.Model.Item", "Item")
                        .WithMany("ItemAtributos")
                        .HasForeignKey("ItemCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Atributo");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("ItensPersonagemLOL_API.Model.ItemComponente", b =>
                {
                    b.HasOne("ItensPersonagemLOL_API.Model.Item", "Componente")
                        .WithMany("UsadoEm")
                        .HasForeignKey("ComponenteCodigo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ItensPersonagemLOL_API.Model.Item", "Item")
                        .WithMany("Componentes")
                        .HasForeignKey("ItemCodigo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Componente");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("ItensPersonagemLOL_API.Model.Personagem", b =>
                {
                    b.HasOne("ItensPersonagemLOL_API.Model.Classe", "Classe")
                        .WithMany("Personagens")
                        .HasForeignKey("ClasseCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classe");
                });

            modelBuilder.Entity("ItensPersonagemLOL_API.Model.PersonagemItem", b =>
                {
                    b.HasOne("ItensPersonagemLOL_API.Model.Item", "Item")
                        .WithMany("PersonagemItens")
                        .HasForeignKey("ItemCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ItensPersonagemLOL_API.Model.Personagem", "Personagem")
                        .WithMany("PersonagemItens")
                        .HasForeignKey("PersonagemCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Personagem");
                });

            modelBuilder.Entity("ItensPersonagemLOL_API.Model.Atributo", b =>
                {
                    b.Navigation("ItemAtributos");
                });

            modelBuilder.Entity("ItensPersonagemLOL_API.Model.Classe", b =>
                {
                    b.Navigation("Itens");

                    b.Navigation("Personagens");
                });

            modelBuilder.Entity("ItensPersonagemLOL_API.Model.Item", b =>
                {
                    b.Navigation("Componentes");

                    b.Navigation("EfeitosPassivo");

                    b.Navigation("ItemAtributos");

                    b.Navigation("PersonagemItens");

                    b.Navigation("UsadoEm");
                });

            modelBuilder.Entity("ItensPersonagemLOL_API.Model.Personagem", b =>
                {
                    b.Navigation("PersonagemItens");
                });
#pragma warning restore 612, 618
        }
    }
}
