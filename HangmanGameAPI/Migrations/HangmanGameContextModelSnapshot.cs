﻿// <auto-generated />
using HangmanGameAPI.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HangmanGameAPI.Migrations
{
    [DbContext(typeof(HangmanGameContext))]
    partial class HangmanGameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HangmanGameAPI.Entities.Challenge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPlayed")
                        .HasColumnType("bit");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId")
                        .IsUnique();

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Challenges");
                });

            modelBuilder.Entity("HangmanGameAPI.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsWon")
                        .HasColumnType("bit");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("WordId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("WordId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("HangmanGameAPI.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "alexandra@email.com",
                            Password = "alexandra",
                            Username = "alexandra"
                        },
                        new
                        {
                            Id = 2,
                            Email = "yanka@email.com",
                            Password = "yanka",
                            Username = "yanka"
                        });
                });

            modelBuilder.Entity("HangmanGameAPI.Entities.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("HangmanGameAPI.Entities.Challenge", b =>
                {
                    b.HasOne("HangmanGameAPI.Entities.Game", "Game")
                        .WithOne("Challenge")
                        .HasForeignKey("HangmanGameAPI.Entities.Challenge", "GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HangmanGameAPI.Entities.User", "Receiver")
                        .WithMany("ReceivedChallenges")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HangmanGameAPI.Entities.User", "Sender")
                        .WithMany("SentChallenges")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("HangmanGameAPI.Entities.Game", b =>
                {
                    b.HasOne("HangmanGameAPI.Entities.User", "Player")
                        .WithMany("Games")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HangmanGameAPI.Entities.Word", "Word")
                        .WithMany("Games")
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Word");
                });

            modelBuilder.Entity("HangmanGameAPI.Entities.Game", b =>
                {
                    b.Navigation("Challenge")
                        .IsRequired();
                });

            modelBuilder.Entity("HangmanGameAPI.Entities.User", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("ReceivedChallenges");

                    b.Navigation("SentChallenges");
                });

            modelBuilder.Entity("HangmanGameAPI.Entities.Word", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
