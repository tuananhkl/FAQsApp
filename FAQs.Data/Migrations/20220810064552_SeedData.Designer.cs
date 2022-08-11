﻿// <auto-generated />
using System;
using FAQs.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FAQs.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220810064552_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FAQs.Data.Entities.Faq", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Faqs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("22a30b4d-c055-49ab-98bb-5767dd591c43"),
                            Answer = "I'm 23 years old.",
                            CreatedDate = new DateTime(2022, 8, 10, 6, 45, 52, 472, DateTimeKind.Utc).AddTicks(2820),
                            Language = "en",
                            Question = "How old are you?"
                        });
                });

            modelBuilder.Entity("FAQs.Data.Entities.FaqTranslation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("FaqId")
                        .HasColumnType("uuid");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FaqId");

                    b.ToTable("FaqTranslations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("301ca0ab-3486-41d5-af94-565a105c7ea1"),
                            Answer = "Toi 23 tuoi",
                            CreatedDate = new DateTime(2022, 8, 10, 6, 45, 52, 472, DateTimeKind.Utc).AddTicks(4770),
                            FaqId = new Guid("22a30b4d-c055-49ab-98bb-5767dd591c43"),
                            Language = "vi",
                            Question = "Ban bao nhieu tuoi?"
                        },
                        new
                        {
                            Id = new Guid("30f467c3-6b6c-4b73-b8d7-696bd317904b"),
                            Answer = "watashi-wa-njusansai-desu.",
                            CreatedDate = new DateTime(2022, 8, 10, 6, 45, 52, 472, DateTimeKind.Utc).AddTicks(5100),
                            FaqId = new Guid("22a30b4d-c055-49ab-98bb-5767dd591c43"),
                            Language = "jp",
                            Question = "anata-wa-oikutsu-desu-ka?"
                        },
                        new
                        {
                            Id = new Guid("8621b5da-0b07-4795-b360-7a898e842037"),
                            Answer = "Wǒ èrshísān suì.",
                            CreatedDate = new DateTime(2022, 8, 10, 6, 45, 52, 472, DateTimeKind.Utc).AddTicks(5120),
                            FaqId = new Guid("22a30b4d-c055-49ab-98bb-5767dd591c43"),
                            Language = "cn",
                            Question = "nín duō dà suìshu?"
                        });
                });

            modelBuilder.Entity("FAQs.Data.Entities.FaqTranslation", b =>
                {
                    b.HasOne("FAQs.Data.Entities.Faq", "Faq")
                        .WithMany("FaqTranslations")
                        .HasForeignKey("FaqId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faq");
                });

            modelBuilder.Entity("FAQs.Data.Entities.Faq", b =>
                {
                    b.Navigation("FaqTranslations");
                });
#pragma warning restore 612, 618
        }
    }
}
