﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Student.API.Context;

#nullable disable

namespace Student.API.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    [Migration("20230719121812_AddColumn_CreatedAt")]
    partial class AddColumn_CreatedAt
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Student.API.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("students", (string)null);
                });

            modelBuilder.Entity("Student.API.Entities.StudentAttendance", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TopicId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Attend")
                        .HasColumnType("boolean");

                    b.HasKey("StudentId", "TopicId");

                    b.ToTable("student_attendances", (string)null);
                });

            modelBuilder.Entity("Student.API.Entities.StudentScience", b =>
                {
                    b.Property<Guid>("ScienceId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ScienceId");

                    b.ToTable("student_sciences", (string)null);
                });

            modelBuilder.Entity("Student.API.Entities.StudentTaskResult", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TaskId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("StudentId", "TaskId");

                    b.ToTable("student_task_results", (string)null);
                });

            modelBuilder.Entity("Student.API.Entities.StudentAttendance", b =>
                {
                    b.HasOne("Student.API.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Student.API.Entities.StudentScience", b =>
                {
                    b.HasOne("Student.API.Entities.Student", "Student")
                        .WithMany("StudentSciences")
                        .HasForeignKey("ScienceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Student.API.Entities.StudentTaskResult", b =>
                {
                    b.HasOne("Student.API.Entities.Student", "Student")
                        .WithMany("TasksResults")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Student.API.Entities.Student", b =>
                {
                    b.Navigation("StudentSciences");

                    b.Navigation("TasksResults");
                });
#pragma warning restore 612, 618
        }
    }
}
