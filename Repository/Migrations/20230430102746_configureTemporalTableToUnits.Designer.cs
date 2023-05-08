﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.DbModels;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(DiaryContext))]
    [Migration("20230430102746_configureTemporalTableToUnits")]
    partial class configureTemporalTableToUnits
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Repository.DbModels.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SchoolId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_dbo.Groups");

                    b.HasIndex(new[] { "SchoolId" }, "IX_SchoolId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Repository.DbModels.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int")
                        .HasColumnName("Group_Id");

                    b.HasKey("Id")
                        .HasName("PK_dbo.Lessons");

                    b.HasIndex(new[] { "GroupId" }, "IX_Group_Id");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("Repository.DbModels.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_dbo.Schools");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("Repository.DbModels.StudentExistance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExistanceType")
                        .HasColumnType("int");

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

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
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EstimatedHours")
                        .HasColumnType("int");

                    b.Property<int?>("ParentUnitId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.Property<string>("UnitName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_dbo.Units");

                    b.ToTable("Units", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("UnitsHistory");
                                ttb
                                    .HasPeriodStart("PeriodStart")
                                    .HasColumnName("PeriodStart");
                                ttb
                                    .HasPeriodEnd("PeriodEnd")
                                    .HasColumnName("PeriodEnd");
                            }));
                });

            modelBuilder.Entity("Repository.DbModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("UnitLesson", b =>
                {
                    b.Property<int>("UnitId")
                        .HasColumnType("int")
                        .HasColumnName("Unit_Id");

                    b.Property<int>("LessonId")
                        .HasColumnType("int")
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
                        .HasColumnType("int");

                    b.HasIndex("GroupId");

                    b.HasDiscriminator().HasValue("Student");
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
