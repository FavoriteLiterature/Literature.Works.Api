﻿// <auto-generated />
using System;
using Literature.Works.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Literature.Works.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GenreWork", b =>
                {
                    b.Property<Guid>("GenresId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WorksId")
                        .HasColumnType("uuid");

                    b.HasKey("GenresId", "WorksId");

                    b.HasIndex("WorksId");

                    b.ToTable("GenreWork");
                });

            modelBuilder.Entity("Literature.Works.Api.Entities.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AttachmentTypeName")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("FileId")
                        .HasColumnType("uuid");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("WorkId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AttachmentTypeName");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("Literature.Works.Api.Entities.AttachmentType", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.ToTable("AttachmentTypes");
                });

            modelBuilder.Entity("Literature.Works.Api.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PublicEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Literature.Works.Api.Entities.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Literature.Works.Api.Entities.Work", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float?>("Rating")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("GenreWork", b =>
                {
                    b.HasOne("Literature.Works.Api.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Literature.Works.Api.Entities.Work", null)
                        .WithMany()
                        .HasForeignKey("WorksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Literature.Works.Api.Entities.Attachment", b =>
                {
                    b.HasOne("Literature.Works.Api.Entities.AttachmentType", null)
                        .WithMany("Attachments")
                        .HasForeignKey("AttachmentTypeName");
                });

            modelBuilder.Entity("Literature.Works.Api.Entities.Work", b =>
                {
                    b.HasOne("Literature.Works.Api.Entities.Author", null)
                        .WithMany("Works")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Literature.Works.Api.Entities.AttachmentType", b =>
                {
                    b.Navigation("Attachments");
                });

            modelBuilder.Entity("Literature.Works.Api.Entities.Author", b =>
                {
                    b.Navigation("Works");
                });
#pragma warning restore 612, 618
        }
    }
}
