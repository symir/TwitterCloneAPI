﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TwitterCloneAPI.Data;

namespace TwitterCloneAPI.Migrations
{
    [DbContext(typeof(TwitterContext))]
    [Migration("20210729223827_expand-userModel")]
    partial class expanduserModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TwitterCloneAPI.Models.Tweet", b =>
                {
                    b.Property<int>("TweetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasMaxLength(280)
                        .HasColumnType("nvarchar(280)");

                    b.Property<int>("LikeCounter")
                        .HasColumnType("int");

                    b.Property<int?>("ReplyId")
                        .HasColumnType("int");

                    b.Property<int?>("RetweetId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TweetId");

                    b.HasIndex("UserId");

                    b.ToTable("Tweets");
                });

            modelBuilder.Entity("TwitterCloneAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Avatar")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TwitterCloneAPI.Models.Tweet", b =>
                {
                    b.HasOne("TwitterCloneAPI.Models.User", "User")
                        .WithMany("Tweets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TwitterCloneAPI.Models.User", b =>
                {
                    b.Navigation("Tweets");
                });
#pragma warning restore 612, 618
        }
    }
}
