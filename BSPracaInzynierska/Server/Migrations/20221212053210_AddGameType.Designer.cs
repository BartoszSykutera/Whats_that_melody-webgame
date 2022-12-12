﻿// <auto-generated />
using System;
using BSPracaInzynierska.Server.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BSPracaInzynierska.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221212053210_AddGameType")]
    partial class AddGameType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BSPracaInzynierska.Shared.LeaderBoard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PlaylistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("gameType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("playerTime")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PlaylistId");

                    b.HasIndex("UserId");

                    b.ToTable("LeaderBoard");
                });

            modelBuilder.Entity("BSPracaInzynierska.Shared.MultiGame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GameCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfTracks")
                        .HasColumnType("int");

                    b.Property<Guid>("PlaylistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserHost")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("gameTime")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PlaylistId");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("BSPracaInzynierska.Shared.MusicPlaylist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfTracks")
                        .HasColumnType("int");

                    b.Property<string>("PlaylistName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("blindGuessSongs")
                        .HasColumnType("int");

                    b.Property<int>("blindGuessTime")
                        .HasColumnType("int");

                    b.Property<long>("favourites")
                        .HasColumnType("bigint");

                    b.Property<int>("lightningRoundSongs")
                        .HasColumnType("int");

                    b.Property<int>("lightningRoundTime")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("MusicPlaylists");
                });

            modelBuilder.Entity("BSPracaInzynierska.Shared.Song", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PlaylistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("SongDuration")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YTChanelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YTVideoTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YTVidoeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlaylistId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("BSPracaInzynierska.Shared.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("currentGameId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("currentGameId");

                    b.ToTable("Uzytkownicy");

                    b.HasData(
                        new
                        {
                            Id = new Guid("98d2e1e9-73af-4bb7-a91d-e90531310bd5"),
                            Email = "admin",
                            PasswordHash = new byte[] { 96, 148, 174, 107, 202, 163, 130, 14, 200, 120, 16, 189, 124, 36, 127, 175, 19, 125, 19, 81, 2, 14, 120, 69, 55, 27, 96, 29, 99, 96, 95, 64, 101, 145, 132, 182, 185, 186, 6, 18, 88, 216, 71, 80, 50, 179, 187, 81, 35, 134, 100, 100, 0, 112, 204, 146, 211, 226, 47, 177, 126, 143, 254, 230 },
                            PasswordSalt = new byte[] { 134, 81, 31, 246, 235, 31, 136, 163, 149, 84, 130, 133, 223, 172, 185, 194, 183, 210, 167, 111, 201, 144, 169, 196, 30, 18, 86, 43, 53, 246, 73, 75, 59, 190, 36, 83, 124, 42, 59, 209, 172, 131, 9, 91, 120, 26, 68, 51, 88, 35, 212, 149, 63, 175, 18, 228, 84, 181, 196, 221, 107, 220, 215, 33, 0, 119, 72, 223, 56, 178, 32, 27, 204, 151, 172, 70, 70, 132, 151, 213, 209, 241, 4, 42, 128, 43, 59, 82, 150, 241, 130, 105, 71, 54, 172, 244, 92, 219, 9, 124, 101, 172, 23, 172, 86, 210, 19, 112, 66, 22, 0, 210, 143, 181, 69, 252, 219, 74, 187, 127, 88, 79, 72, 179, 234, 99, 234, 15 },
                            Role = "Admin",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("MusicPlaylistUser", b =>
                {
                    b.Property<Guid>("FavouritePlaylistsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersFavouritesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FavouritePlaylistsId", "UsersFavouritesId");

                    b.HasIndex("UsersFavouritesId");

                    b.ToTable("MusicPlaylistUser");
                });

            modelBuilder.Entity("BSPracaInzynierska.Shared.LeaderBoard", b =>
                {
                    b.HasOne("BSPracaInzynierska.Shared.MusicPlaylist", "Playlist")
                        .WithMany("LeaderBoards")
                        .HasForeignKey("PlaylistId");

                    b.HasOne("BSPracaInzynierska.Shared.User", "Player")
                        .WithMany("Leaders")
                        .HasForeignKey("UserId");

                    b.Navigation("Player");

                    b.Navigation("Playlist");
                });

            modelBuilder.Entity("BSPracaInzynierska.Shared.MultiGame", b =>
                {
                    b.HasOne("BSPracaInzynierska.Shared.MusicPlaylist", "Playlist")
                        .WithMany("CurrentGames")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Playlist");
                });

            modelBuilder.Entity("BSPracaInzynierska.Shared.MusicPlaylist", b =>
                {
                    b.HasOne("BSPracaInzynierska.Shared.User", "Creator")
                        .WithMany("MusicPlaylists")
                        .HasForeignKey("UserId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("BSPracaInzynierska.Shared.Song", b =>
                {
                    b.HasOne("BSPracaInzynierska.Shared.MusicPlaylist", "Playlist")
                        .WithMany("Songs")
                        .HasForeignKey("PlaylistId");

                    b.Navigation("Playlist");
                });

            modelBuilder.Entity("BSPracaInzynierska.Shared.User", b =>
                {
                    b.HasOne("BSPracaInzynierska.Shared.MultiGame", "CurrentGame")
                        .WithMany("Players")
                        .HasForeignKey("currentGameId");

                    b.Navigation("CurrentGame");
                });

            modelBuilder.Entity("MusicPlaylistUser", b =>
                {
                    b.HasOne("BSPracaInzynierska.Shared.MusicPlaylist", null)
                        .WithMany()
                        .HasForeignKey("FavouritePlaylistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BSPracaInzynierska.Shared.User", null)
                        .WithMany()
                        .HasForeignKey("UsersFavouritesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BSPracaInzynierska.Shared.MultiGame", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("BSPracaInzynierska.Shared.MusicPlaylist", b =>
                {
                    b.Navigation("CurrentGames");

                    b.Navigation("LeaderBoards");

                    b.Navigation("Songs");
                });

            modelBuilder.Entity("BSPracaInzynierska.Shared.User", b =>
                {
                    b.Navigation("Leaders");

                    b.Navigation("MusicPlaylists");
                });
#pragma warning restore 612, 618
        }
    }
}