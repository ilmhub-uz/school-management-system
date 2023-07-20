﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SchoolManagement.Services.Sciences.Context;

#nullable disable

namespace SchoolManagement.Services.Sciences.Context.Migrations
{
    [DbContext(typeof(SciencesDbContext))]
    [Migration("20230719153832_InitDb")]
    partial class InitDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SchoolManagement.Services.Sciences.Entities.Science", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("title");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_sciences");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_sciences_name");

                    b.ToTable("sciences", (string)null);
                });

            modelBuilder.Entity("SchoolManagement.Services.Sciences.Entities.Topic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<Guid>("ScienceId")
                        .HasColumnType("uuid")
                        .HasColumnName("science_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("title");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_topics");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_topics_name");

                    b.HasIndex("ScienceId")
                        .HasDatabaseName("ix_topics_science_id");

                    b.ToTable("topics", (string)null);
                });

            modelBuilder.Entity("SchoolManagement.Services.Sciences.Entities.TopicTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("title");

                    b.Property<Guid>("TopicId")
                        .HasColumnType("uuid")
                        .HasColumnName("topic_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_topic_tasks");

                    b.HasIndex("TopicId")
                        .HasDatabaseName("ix_topic_tasks_topic_id");

                    b.ToTable("topic_tasks", (string)null);
                });

            modelBuilder.Entity("SchoolManagement.Services.Sciences.Entities.Topic", b =>
                {
                    b.HasOne("SchoolManagement.Services.Sciences.Entities.Science", "Science")
                        .WithMany("Topics")
                        .HasForeignKey("ScienceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_topics_sciences_science_id");

                    b.Navigation("Science");
                });

            modelBuilder.Entity("SchoolManagement.Services.Sciences.Entities.TopicTask", b =>
                {
                    b.HasOne("SchoolManagement.Services.Sciences.Entities.Topic", "Topic")
                        .WithMany("Tasks")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_topic_tasks_topics_topic_id");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("SchoolManagement.Services.Sciences.Entities.Science", b =>
                {
                    b.Navigation("Topics");
                });

            modelBuilder.Entity("SchoolManagement.Services.Sciences.Entities.Topic", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
