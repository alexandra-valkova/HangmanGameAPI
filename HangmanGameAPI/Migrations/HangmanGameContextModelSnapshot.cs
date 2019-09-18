﻿// <auto-generated />
using HangmanGameAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HangmanGameAPI.Migrations
{
    [DbContext(typeof(HangmanGameContext))]
    partial class HangmanGameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HangmanGameAPI.Models.Challenge", b =>
                {
                    b.Property<int>("GameId");

                    b.Property<bool>("Played");

                    b.Property<int>("ReceiverId");

                    b.Property<int>("SenderId");

                    b.HasKey("GameId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Challenges");
                });

            modelBuilder.Entity("HangmanGameAPI.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlayerId");

                    b.Property<bool>("Won");

                    b.Property<int>("WordId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("WordId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("HangmanGameAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HangmanGameAPI.Models.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("HangmanGameAPI.Models.Challenge", b =>
                {
                    b.HasOne("HangmanGameAPI.Models.Game", "Game")
                        .WithOne("Challenge")
                        .HasForeignKey("HangmanGameAPI.Models.Challenge", "GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HangmanGameAPI.Models.User", "Receiver")
                        .WithMany("ReceivedChallenges")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HangmanGameAPI.Models.User", "Sender")
                        .WithMany("SentChallenges")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HangmanGameAPI.Models.Game", b =>
                {
                    b.HasOne("HangmanGameAPI.Models.User", "Player")
                        .WithMany("Games")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HangmanGameAPI.Models.Word", "Word")
                        .WithMany("Games")
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}