﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Timesheet_API.Models.Data;

#nullable disable

namespace Timesheet_API.Models.Migrations
{
    [DbContext(typeof(timesheet_dbContext))]
    [Migration("20220317130954_ChangedPropertiesForUserProject")]
    partial class ChangedPropertiesForUserProject
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Timesheet_API.Models.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("CATEGORY_NAME");

                    b.HasKey("Id");

                    b.ToTable("CATEGORY", "timesheet");
                });

            modelBuilder.Entity("Timesheet_API.Models.Models.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("ClientAddress")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("CLIENT_ADDRESS");

                    b.Property<string>("ClientCity")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("CLIENT_CITY");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("CLIENT_NAME");

                    b.Property<string>("ClientZipCode")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("CLIENT_ZIP_CODE");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("COUNTRY_ID");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CountryId" }, "IX_CLIENT_COUNTRY_ID");

                    b.ToTable("CLIENT", "timesheet");
                });

            modelBuilder.Entity("Timesheet_API.Models.Models.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("COUNTRY_NAME");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("COUNTRY", "timesheet");
                });

            modelBuilder.Entity("Timesheet_API.Models.Models.LeadProject", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("USER_TABLE_ID");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PROJECT_ID");

                    b.Property<Guid>("UserTableId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "ProjectId");

                    b.ToTable("LEAD_PROJECT", "timesheet");
                });

            modelBuilder.Entity("Timesheet_API.Models.Models.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CLIENT_ID");

                    b.Property<string>("ProjectDescription")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("PROJECT_DESCRIPTION");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("PROJECT_NAME");

                    b.Property<string>("ProjectStatus")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("PROJECT_STATUS");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ClientId" }, "IX_PROJECT_CLIENT_ID");

                    b.ToTable("PROJECT", "timesheet");
                });

            modelBuilder.Entity("Timesheet_API.Models.Models.ProjectTask", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CATEGORY_ID");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PROJECT_ID");

                    b.Property<DateTime>("TaskDate")
                        .HasColumnType("date")
                        .HasColumnName("TASK_DATE");

                    b.Property<string>("TaskDescription")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("TASK_DESCRIPTION");

                    b.Property<decimal?>("TaskOvertime")
                        .HasColumnType("numeric(4,2)")
                        .HasColumnName("TASK_OVERTIME");

                    b.Property<decimal>("TaskTime")
                        .HasColumnType("numeric(4,2)")
                        .HasColumnName("TASK_TIME");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("USER_TABLE_ID");

                    b.Property<int>("UserTableId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "ProjectId");

                    b.HasIndex(new[] { "CategoryId" }, "IX_TASK_TABLE_CATEGORY_ID");

                    b.HasIndex(new[] { "UserTableId", "ProjectId" }, "IX_TASK_TABLE_USER_TABLE_ID_PROJECT_ID")
                        .HasDatabaseName("IX_TASK_TABLE_USER_TABLE_ID_PROJECT_ID1");

                    b.ToTable("TASK_TABLE", "timesheet");
                });

            modelBuilder.Entity("Timesheet_API.Models.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ROLE_NAME");

                    b.HasKey("Id");

                    b.ToTable("ROLE_TABLE", "timesheet");
                });

            modelBuilder.Entity("Timesheet_API.Models.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("FIRST_NAME");

                    b.Property<int>("HoursPerWeek")
                        .HasColumnType("int")
                        .HasColumnName("HOURS_PER_WEEK");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("LAST_NAME");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ROLE_ID");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("USER_PASSWORD");

                    b.Property<string>("UserStatus")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("USER_STATUS");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("USERNAME");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "RoleId" }, "IX_USER_TABLE_ROLE_ID");

                    b.ToTable("USER_TABLE", "timesheet");
                });

            modelBuilder.Entity("Timesheet_API.Models.Models.UserProject", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("USER_TABLE_ID");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PROJECT_ID");

                    b.Property<Guid>("UserTableId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "ProjectId");

                    b.HasIndex(new[] { "ProjectId" }, "IX_USER_PROJECT_PROJECT_ID");

                    b.ToTable("USER_PROJECT", "timesheet");
                });

            modelBuilder.Entity("Timesheet_API.Models.Models.Client", b =>
                {
                    b.HasOne("Timesheet_API.Models.Models.Country", "Country")
                        .WithMany("Clients")
                        .HasForeignKey("CountryId")
                        .IsRequired()
                        .HasConstraintName("FK_CLIENT_COUNTRY");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Timesheet_API.Models.Models.LeadProject", b =>
                {
                    b.HasOne("Timesheet_API.Models.Models.UserProject", "UserProject")
                        .WithOne("LeadProject")
                        .HasForeignKey("Timesheet_API.Models.Models.LeadProject", "UserId", "ProjectId")
                        .IsRequired()
                        .HasConstraintName("FK_LEAD_PROJECT_USER_PROJECT");

                    b.Navigation("UserProject");
                });

            modelBuilder.Entity("Timesheet_API.Models.Models.Project", b =>
                {
                    b.HasOne("Timesheet_API.Models.Models.Client", "Client")
                        .WithMany("Projects")
                        .HasForeignKey("ClientId")
                        .IsRequired()
                        .HasConstraintName("FK_PROJECT_CLIENT");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Timesheet_API.Models.Models.ProjectTask", b =>
                {
                    b.HasOne("Timesheet_API.Models.Models.Category", "Category")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK_TASK_CATEGORY");

                    b.HasOne("Timesheet_API.Models.Models.UserProject", "UserProject")
                        .WithMany("Tasks")
                        .HasForeignKey("UserId", "ProjectId")
                        .IsRequired()
                        .HasConstraintName("FK_TASK_USER_PROJECT");

                    b.Navigation("Category");

                    b.Navigation("UserProject");
                });

            modelBuilder.Entity("Timesheet_API.Models.Models.User", b =>
                {
                    b.HasOne("Timesheet_API.Models.Models.Role", "Role")
                        .WithMany("UserTables")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_USER_ROLE");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Timesheet_API.Models.Models.UserProject", b =>
                {
                    b.HasOne("Timesheet_API.Models.Models.Project", "Project")
                        .WithMany("UserProjects")
                        .HasForeignKey("ProjectId")
                        .IsRequired()
                        .HasConstraintName("FK_USER_PROJECT_PROJECT");

                    b.HasOne("Timesheet_API.Models.Models.User", "User")
                        .WithMany("UserProjects")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_USER_PROJECT_USER_TABLE");

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Timesheet_API.Models.Models.Category", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Timesheet_API.Models.Models.Client", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Timesheet_API.Models.Models.Country", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("Timesheet_API.Models.Models.Project", b =>
                {
                    b.Navigation("UserProjects");
                });

            modelBuilder.Entity("Timesheet_API.Models.Models.Role", b =>
                {
                    b.Navigation("UserTables");
                });

            modelBuilder.Entity("Timesheet_API.Models.Models.User", b =>
                {
                    b.Navigation("UserProjects");
                });

            modelBuilder.Entity("Timesheet_API.Models.Models.UserProject", b =>
                {
                    b.Navigation("LeadProject")
                        .IsRequired();

                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
