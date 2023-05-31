﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Repository.DbModels;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(DiaryContext))]
    [Migration("20230531080111_change_group_field")]
    partial class change_group_field
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Repository.DbModels.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("GroupName")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int?>("SchoolId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("PK_dbo.Groups");

                    b.HasIndex(new[] { "SchoolId" }, "IX_SchoolId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Repository.DbModels.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("GroupId")
                        .HasColumnType("integer")
                        .HasColumnName("Group_Id");

                    b.Property<DateTime>("LessonDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("DateOfLesson");

                    b.HasKey("Id")
                        .HasName("PK_dbo.Lessons");

                    b.HasIndex(new[] { "GroupId" }, "IX_Group_Id");

                    b.ToTable("LessonsTbl");
                });

            modelBuilder.Entity("Repository.DbModels.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_dbo.Schools");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("Repository.DbModels.StudentExistance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ExistanceType")
                        .HasColumnType("integer");

                    b.Property<int>("LessonId")
                        .HasColumnType("integer");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("PK_dbo.StudentExistances");

                    b.HasIndex(new[] { "LessonId" }, "IX_LessonId");

                    b.HasIndex(new[] { "StudentId" }, "IX_StudentId");

                    b.ToTable("StudentExistances");
                });

            modelBuilder.Entity("Repository.DbModels.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comments")
                        .HasColumnType("text");

                    b.Property<int?>("EstimatedHours")
                        .HasColumnType("integer");

                    b.Property<int?>("ParentUnitId")
                        .HasColumnType("integer");

                    b.Property<string>("UnitName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id")
                        .HasName("PK_dbo.Units");

                    b.ToTable("Units", (string)null);

                    b.HasAnnotation("SqlServer:IsTemporal", true);
                });

            modelBuilder.Entity("Repository.DbModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("UnitLesson", b =>
                {
                    b.Property<int>("UnitId")
                        .HasColumnType("integer")
                        .HasColumnName("Unit_Id");

                    b.Property<int>("LessonId")
                        .HasColumnType("integer")
                        .HasColumnName("Lesson_Id");

                    b.HasKey("UnitId", "LessonId")
                        .HasName("PK_dbo.UnitLessons");

                    b.HasIndex(new[] { "LessonId" }, "IX_Lesson_Id");

                    b.HasIndex(new[] { "UnitId" }, "IX_Unit_Id");

                    b.ToTable("UnitLessons", (string)null);
                });

            modelBuilder.Entity("Repository.DbModels.Student", b =>
                {
                    b.HasBaseType("Repository.DbModels.User");

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.HasIndex("GroupId");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("Repository.DbModels.Teacher", b =>
                {
                    b.HasBaseType("Repository.DbModels.User");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("Repository.DbModels.Group", b =>
                {
                    b.HasOne("Repository.DbModels.School", "School")
                        .WithMany("Groups")
                        .HasForeignKey("SchoolId")
                        .HasConstraintName("FK_dbo.Groups_dbo.Schools_SchoolId");

                    b.Navigation("School");
                });

            modelBuilder.Entity("Repository.DbModels.Lesson", b =>
                {
                    b.HasOne("Repository.DbModels.Group", "Group")
                        .WithMany("Lessons")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_dbo.Lessons_dbo.Groups_Group_Id");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Repository.DbModels.StudentExistance", b =>
                {
                    b.HasOne("Repository.DbModels.Lesson", "Lesson")
                        .WithMany("StudentExistances")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_dbo.StudentExistances_dbo.Lessons_LessonId");

                    b.HasOne("Repository.DbModels.Student", "Student")
                        .WithMany("StudentExistances")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_dbo.StudentExistances_dbo.Students_StudentId");

                    b.Navigation("Lesson");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("UnitLesson", b =>
                {
                    b.HasOne("Repository.DbModels.Lesson", null)
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_dbo.UnitLessons_dbo.Lessons_Lesson_Id");

                    b.HasOne("Repository.DbModels.Unit", null)
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_dbo.UnitLessons_dbo.Units_Unit_Id");
                });

            modelBuilder.Entity("Repository.DbModels.Student", b =>
                {
                    b.HasOne("Repository.DbModels.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Repository.DbModels.Group", b =>
                {
                    b.Navigation("Lessons");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("Repository.DbModels.Lesson", b =>
                {
                    b.Navigation("StudentExistances");
                });

            modelBuilder.Entity("Repository.DbModels.School", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("Repository.DbModels.Student", b =>
                {
                    b.Navigation("StudentExistances");
                });
#pragma warning restore 612, 618
        }
    }
}
