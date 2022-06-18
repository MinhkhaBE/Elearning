﻿// <auto-generated />
using System;
using E_Learning.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace E_Learning.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220617114148_AddDb")]
    partial class AddDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("E_Learning.Data.Account", b =>
                {
                    b.Property<int>("Idaccount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Createdate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Gmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Idaccount");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("E_Learning.Data.Admin", b =>
                {
                    b.Property<int>("Idadmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<int>("Idaccount")
                        .HasColumnType("int");

                    b.Property<string>("Nameadmin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Idadmin");

                    b.HasIndex("Idaccount")
                        .IsUnique();

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("E_Learning.Data.Class", b =>
                {
                    b.Property<int>("Idclass")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Idclassdetail")
                        .HasColumnType("int");

                    b.Property<int>("Idsubject")
                        .HasColumnType("int");

                    b.Property<string>("Nameclass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Semester")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Topic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Idclass");

                    b.HasIndex("Idclassdetail")
                        .IsUnique();

                    b.HasIndex("Idsubject");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("E_Learning.Data.Classdetail", b =>
                {
                    b.Property<int>("Idclassdetail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Lesson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passwordclass")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Schedule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Studytime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Teacher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Idclassdetail");

                    b.ToTable("ClassDetail");
                });

            modelBuilder.Entity("E_Learning.Data.Scorelearning", b =>
                {
                    b.Property<int>("Idscore")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Idstudent")
                        .HasColumnType("int");

                    b.Property<int>("Idsubject")
                        .HasColumnType("int");

                    b.Property<double>("Mediumscore")
                        .HasColumnType("float");

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Score15min")
                        .HasColumnType("float");

                    b.Property<double>("Scorecorfficient2")
                        .HasColumnType("float");

                    b.Property<double>("Scorecorfficient3")
                        .HasColumnType("float");

                    b.Property<double>("Scorediligence")
                        .HasColumnType("float");

                    b.Property<double>("Scoreoral")
                        .HasColumnType("float");

                    b.Property<double>("Totalscore")
                        .HasColumnType("float");

                    b.Property<DateTime>("Updatedate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.HasKey("Idscore");

                    b.HasIndex("Idstudent")
                        .IsUnique();

                    b.HasIndex("Idsubject");

                    b.ToTable("Scorelearning");
                });

            modelBuilder.Entity("E_Learning.Data.Student", b =>
                {
                    b.Property<int>("Idstudent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birth")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ClassIdclass")
                        .HasColumnType("int");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Gmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Idaccount")
                        .HasColumnType("int");

                    b.Property<string>("Namestudent")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Idstudent");

                    b.HasIndex("ClassIdclass");

                    b.HasIndex("Idaccount")
                        .IsUnique();

                    b.ToTable("Student");
                });

            modelBuilder.Entity("E_Learning.Data.Subject", b =>
                {
                    b.Property<int>("Idsubject")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Namesubject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Idsubject");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("E_Learning.Data.Teacher", b =>
                {
                    b.Property<int>("Idteacher")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birth")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Gmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Idaccount")
                        .HasColumnType("int");

                    b.Property<string>("Nameteacher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Idteacher");

                    b.HasIndex("Idaccount")
                        .IsUnique();

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("E_Learning.Data.Test", b =>
                {
                    b.Property<int>("Idtest")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Createdate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<int>("Idsubject")
                        .HasColumnType("int");

                    b.Property<string>("Nametest")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Idtest");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("E_Learning.Data.Admin", b =>
                {
                    b.HasOne("E_Learning.Data.Account", "Account")
                        .WithOne("Admin")
                        .HasForeignKey("E_Learning.Data.Admin", "Idaccount")
                        .HasConstraintName("fk_admin_account")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("E_Learning.Data.Class", b =>
                {
                    b.HasOne("E_Learning.Data.Classdetail", "Classdetail")
                        .WithOne("Class")
                        .HasForeignKey("E_Learning.Data.Class", "Idclassdetail")
                        .HasConstraintName("FK_Class_Classdetail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Learning.Data.Subject", "Subject")
                        .WithMany("Classes")
                        .HasForeignKey("Idsubject")
                        .HasConstraintName("FK_Class_Subject")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classdetail");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("E_Learning.Data.Scorelearning", b =>
                {
                    b.HasOne("E_Learning.Data.Student", "Student")
                        .WithOne("Scorelearning")
                        .HasForeignKey("E_Learning.Data.Scorelearning", "Idstudent")
                        .HasConstraintName("FK_Score_Student")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Learning.Data.Subject", "Subject")
                        .WithMany("Scorelearnings")
                        .HasForeignKey("Idsubject")
                        .HasConstraintName("FK_Score_Subject")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("E_Learning.Data.Student", b =>
                {
                    b.HasOne("E_Learning.Data.Class", null)
                        .WithMany("Students")
                        .HasForeignKey("ClassIdclass");

                    b.HasOne("E_Learning.Data.Account", "Account")
                        .WithOne("Student")
                        .HasForeignKey("E_Learning.Data.Student", "Idaccount")
                        .HasConstraintName("FK_Student_account")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("E_Learning.Data.Teacher", b =>
                {
                    b.HasOne("E_Learning.Data.Account", "Account")
                        .WithOne("Teacher")
                        .HasForeignKey("E_Learning.Data.Teacher", "Idaccount")
                        .HasConstraintName("FK_Teacher_Account")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("E_Learning.Data.Test", b =>
                {
                    b.HasOne("E_Learning.Data.Subject", "Subject")
                        .WithMany("Tests")
                        .HasForeignKey("Idtest")
                        .HasConstraintName("FK_Test_Subject")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("E_Learning.Data.Account", b =>
                {
                    b.Navigation("Admin");

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("E_Learning.Data.Class", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("E_Learning.Data.Classdetail", b =>
                {
                    b.Navigation("Class");
                });

            modelBuilder.Entity("E_Learning.Data.Student", b =>
                {
                    b.Navigation("Scorelearning");
                });

            modelBuilder.Entity("E_Learning.Data.Subject", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("Scorelearnings");

                    b.Navigation("Tests");
                });
#pragma warning restore 612, 618
        }
    }
}
