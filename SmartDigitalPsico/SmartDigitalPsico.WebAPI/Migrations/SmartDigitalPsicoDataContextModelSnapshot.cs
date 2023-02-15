﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartDigitalPsico.Data.Context;

#nullable disable

namespace SmartDigitalPsico.WebAPI.Migrations
{
    [DbContext(typeof(SmartDigitalPsicoDataContext))]
    partial class SmartDigitalPsicoDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RoleGroupUser", b =>
                {
                    b.Property<long>("RoleGroupsId")
                        .HasColumnType("bigint");

                    b.Property<long>("UsersId")
                        .HasColumnType("bigint");

                    b.HasKey("RoleGroupsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleGroupUser", "dbo");
                });

            modelBuilder.Entity("SmartDigitalPsico.Model.Entity.Domains.Gender", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Description");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("char(5)")
                        .HasColumnName("Language");

                    b.HasKey("Id");

                    b.ToTable("Genders", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Masculino",
                            Language = "pt-BR"
                        },
                        new
                        {
                            Id = 2L,
                            Description = "Feminino",
                            Language = "pt-BR"
                        });
                });

            modelBuilder.Entity("SmartDigitalPsico.Model.Entity.Domains.Office", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Description");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("char(5)")
                        .HasColumnName("Language");

                    b.HasKey("Id");

                    b.ToTable("Officies", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Psicólogo",
                            Language = "pt-BR"
                        },
                        new
                        {
                            Id = 2L,
                            Description = "Psicóloga",
                            Language = "pt-BR"
                        },
                        new
                        {
                            Id = 3L,
                            Description = "Clínico",
                            Language = "pt-BR"
                        });
                });

            modelBuilder.Entity("SmartDigitalPsico.Model.Entity.Domains.RoleGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Description");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("char(5)")
                        .HasColumnName("Language");

                    b.HasKey("Id");

                    b.ToTable("RoleGroups", "dbo");
                });

            modelBuilder.Entity("SmartDigitalPsico.Model.Entity.Domains.Specialty", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Description");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("char(5)")
                        .HasColumnName("Language");

                    b.Property<long?>("MedicalId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MedicalId");

                    b.ToTable("Specialties", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Psicologia Clínica",
                            Language = "pt-BR"
                        },
                        new
                        {
                            Id = 2L,
                            Description = "Psicologia Social",
                            Language = "pt-BR"
                        },
                        new
                        {
                            Id = 3L,
                            Description = "Psicologia educacional",
                            Language = "pt-BR"
                        },
                        new
                        {
                            Id = 4L,
                            Description = "Psicologia Esportiva ",
                            Language = "pt-BR"
                        },
                        new
                        {
                            Id = 5L,
                            Description = "Psicologia organizacional",
                            Language = "pt-BR"
                        },
                        new
                        {
                            Id = 6L,
                            Description = "Psicologia hospitalar",
                            Language = "pt-BR"
                        },
                        new
                        {
                            Id = 7L,
                            Description = "Psicologia do trânsito",
                            Language = "pt-BR"
                        });
                });

            modelBuilder.Entity("SmartDigitalPsico.Model.Entity.Principals.Medical", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Accreditation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Accreditation");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateCreated");

                    b.Property<DateTime>("DateLasAcess")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateLastAcess");

                    b.Property<DateTime>("DateModify")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateModify");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Email");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit")
                        .HasColumnName("Enable");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Name");

                    b.Property<long>("OfficeId")
                        .HasColumnType("bigint");

                    b.Property<int>("TypeAccreditation")
                        .HasColumnType("int")
                        .HasColumnName("TypeAccreditation");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.HasIndex("UserId");

                    b.ToTable("Medical", "dbo");
                });

            modelBuilder.Entity("SmartDigitalPsico.Model.Entity.Principals.Patient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateOfBirth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Email");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit")
                        .HasColumnName("Enable");

                    b.Property<long>("GenderId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Name");

                    b.Property<string>("Profession")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Profession");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Patient", "dbo");
                });

            modelBuilder.Entity("SmartDigitalPsico.Model.Entity.Principals.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateCreated");

                    b.Property<DateTime>("DateLasAcess")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateLastAcess");

                    b.Property<DateTime>("DateModify")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateModify");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Email");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit")
                        .HasColumnName("Enable");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Name");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PasswordHash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PasswordSalt");

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Admin")
                        .HasColumnName("Role");

                    b.HasKey("Id");

                    b.ToTable("User", "dbo");
                });

            modelBuilder.Entity("RoleGroupUser", b =>
                {
                    b.HasOne("SmartDigitalPsico.Model.Entity.Domains.RoleGroup", null)
                        .WithMany()
                        .HasForeignKey("RoleGroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartDigitalPsico.Model.Entity.Principals.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartDigitalPsico.Model.Entity.Domains.Specialty", b =>
                {
                    b.HasOne("SmartDigitalPsico.Model.Entity.Principals.Medical", null)
                        .WithMany("Specialties")
                        .HasForeignKey("MedicalId");
                });

            modelBuilder.Entity("SmartDigitalPsico.Model.Entity.Principals.Medical", b =>
                {
                    b.HasOne("SmartDigitalPsico.Model.Entity.Domains.Office", "Office")
                        .WithMany()
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartDigitalPsico.Model.Entity.Principals.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Office");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartDigitalPsico.Model.Entity.Principals.Patient", b =>
                {
                    b.HasOne("SmartDigitalPsico.Model.Entity.Domains.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("SmartDigitalPsico.Model.Entity.Principals.Medical", b =>
                {
                    b.Navigation("Specialties");
                });
#pragma warning restore 612, 618
        }
    }
}
