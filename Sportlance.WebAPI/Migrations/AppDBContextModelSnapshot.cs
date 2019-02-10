﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Sportlance.WebAPI.Core;
using Sportlance.WebAPI.Entities;
using System;

namespace Sportlance.WebAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sportlance.WebAPI.Entities.Feedback", b =>
                {
                    b.Property<long>("TrainingId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<byte?>("Score");

                    b.HasKey("TrainingId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("Sportlance.WebAPI.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreateDate");

                    b.Property<long>("CustomerId");

                    b.Property<string>("Description");

                    b.Property<long?>("ExecutorId");

                    b.Property<bool>("IsPaid");

                    b.Property<int>("Status");

                    b.Property<DateTimeOffset>("UpdateDate");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ExecutorId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Sportlance.WebAPI.Entities.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Sportlance.WebAPI.Entities.Sport", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Sports");
                });

            modelBuilder.Entity("Sportlance.WebAPI.Entities.Team", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("About");

                    b.Property<string>("Address");

                    b.Property<long>("AuthorId");

                    b.Property<string>("BackgroundUrl");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<string>("Latitude");

                    b.Property<string>("Longitude");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PhotoUrl");

                    b.Property<int>("Status");

                    b.Property<string>("SubTitle");

                    b.Property<string>("Title");

                    b.Property<short>("Zoom");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Sportlance.WebAPI.Entities.TeamPhoto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PhotoUrl");

                    b.Property<long>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamPhoto");
                });

            modelBuilder.Entity("Sportlance.WebAPI.Entities.TeamService", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Duration");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<long>("Price");

                    b.Property<long>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamService");
                });

            modelBuilder.Entity("Sportlance.WebAPI.Entities.Trainer", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<string>("About");

                    b.Property<string>("BackgroundUrl");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<double>("Price");

                    b.Property<int>("Status");

                    b.Property<string>("Title");

                    b.HasKey("UserId");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("Sportlance.WebAPI.Entities.TrainerSport", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("SportId");

                    b.Property<long>("TrainerId");

                    b.HasKey("Id");

                    b.HasIndex("SportId");

                    b.HasIndex("TrainerId");

                    b.ToTable("TrainerSports");
                });

            modelBuilder.Entity("Sportlance.WebAPI.Entities.TrainerTeam", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("TeamId");

                    b.Property<long>("TrainerId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.HasIndex("TrainerId");

                    b.ToTable("TrainerTeams");
                });

            modelBuilder.Entity("Sportlance.WebAPI.Entities.Training", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ClientId");

                    b.Property<DateTime?>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<long>("TrainerSportId");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("TrainerSportId");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("Sportlance.WebAPI.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("InviteLink");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsEmailConfirm");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("PasswordHash")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<string>("PhotoUrl");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Phone");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Sportlance.WebAPI.Entities.UserRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("RoleId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Sportlance.WebAPI.Entities.Feedback", b =>
                {
                    b.HasOne("Sportlance.WebAPI.Entities.Training")
                        .WithOne("Feedback")
                        .HasForeignKey("Sportlance.WebAPI.Entities.Feedback", "TrainingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Sportlance.WebAPI.Entities.Order", b =>
                {
                    b.HasOne("Sportlance.WebAPI.Entities.User", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Sportlance.WebAPI.Entities.User", "Executor")
                        .WithMany()
                        .HasForeignKey("ExecutorId");
                });

            modelBuilder.Entity("Sportlance.WebAPI.Entities.Team", b =>
                {
                    b.HasOne("Sportlance.WebAPI.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Sportlance.WebAPI.Entities.TeamPhoto", b =>
                {
                    b.HasOne("Sportlance.WebAPI.Entities.Team", "Team")
                        .WithMany("TeamPhotos")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Sportlance.WebAPI.Entities.TeamService", b =>
                {
                    b.HasOne("Sportlance.WebAPI.Entities.Team", "Team")
                        .WithMany("Services")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Sportlance.WebAPI.Entities.Trainer", b =>
                {
                    b.HasOne("Sportlance.WebAPI.Entities.User", "User")
                        .WithOne()
                        .HasForeignKey("Sportlance.WebAPI.Entities.Trainer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Sportlance.WebAPI.Entities.TrainerSport", b =>
                {
                    b.HasOne("Sportlance.WebAPI.Entities.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Sportlance.WebAPI.Entities.Trainer")
                        .WithMany("TrainerSports")
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Sportlance.WebAPI.Entities.TrainerTeam", b =>
                {
                    b.HasOne("Sportlance.WebAPI.Entities.Team", "Team")
                        .WithMany("TrainerTeams")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Sportlance.WebAPI.Entities.Trainer", "Trainer")
                        .WithMany("TrainerTeams")
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Sportlance.WebAPI.Entities.Training", b =>
                {
                    b.HasOne("Sportlance.WebAPI.Entities.User", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Sportlance.WebAPI.Entities.TrainerSport", "TrainerSport")
                        .WithMany("Trainings")
                        .HasForeignKey("TrainerSportId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Sportlance.WebAPI.Entities.UserRole", b =>
                {
                    b.HasOne("Sportlance.WebAPI.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Sportlance.WebAPI.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
