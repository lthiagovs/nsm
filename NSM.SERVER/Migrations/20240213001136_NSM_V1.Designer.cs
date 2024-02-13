﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NSM.SERVER.Database;

#nullable disable

namespace NSM.SERVER.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240213001136_NSM_V1")]
    partial class NSM_V1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("NSM.SERVER.Models.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Chat");
                });

            modelBuilder.Entity("NSM.SERVER.Models.ChatUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChatId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("UserId");

                    b.ToTable("ChatUser");
                });

            modelBuilder.Entity("NSM.SERVER.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChatId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("NSM.SERVER.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("NSM.SERVER.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("NSM.SERVER.Models.ChatUser", b =>
                {
                    b.HasOne("NSM.SERVER.Models.Chat", "ChatKey")
                        .WithMany()
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NSM.SERVER.Models.User", "UserKey")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatKey");

                    b.Navigation("UserKey");
                });

            modelBuilder.Entity("NSM.SERVER.Models.Message", b =>
                {
                    b.HasOne("NSM.SERVER.Models.Chat", "ChatKey")
                        .WithMany()
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatKey");
                });

            modelBuilder.Entity("NSM.SERVER.Models.Notification", b =>
                {
                    b.HasOne("NSM.SERVER.Models.User", "UserKey")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserKey");
                });
#pragma warning restore 612, 618
        }
    }
}
