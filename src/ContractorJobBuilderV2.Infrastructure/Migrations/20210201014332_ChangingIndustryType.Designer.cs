﻿// <auto-generated />
using System;
using ContractorJobBuilderV2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContractorJobBuilderV2.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210201014332_ChangingIndustryType")]
    partial class ChangingIndustryType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ContractorJobBuilderV2.Core.Aggregates.Industry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Industries");
                });

            modelBuilder.Entity("ContractorJobBuilderV2.Core.Aggregates.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("IndustryType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("ContractorJobBuilderV2.Core.Aggregates.JobTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("JobId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("JobTasks");
                });

            modelBuilder.Entity("ContractorJobBuilderV2.Core.Entities.JobTaskItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("JobTaskId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("JobTaskId");

                    b.ToTable("JobTaskItem");
                });

            modelBuilder.Entity("ContractorJobBuilderV2.Core.Entities.JobTaskItem", b =>
                {
                    b.HasOne("ContractorJobBuilderV2.Core.Aggregates.JobTask", null)
                        .WithMany("JobTaskItems")
                        .HasForeignKey("JobTaskId");
                });

            modelBuilder.Entity("ContractorJobBuilderV2.Core.Aggregates.JobTask", b =>
                {
                    b.Navigation("JobTaskItems");
                });
#pragma warning restore 612, 618
        }
    }
}
