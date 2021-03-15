﻿// <auto-generated />
using System;
using EykoChallenge.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EykoChallenge.Migrations
{
    [DbContext(typeof(DataSourceContext))]
    partial class DataSourceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("EykoChallenge.Models.DataSource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ConfigId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ConfigId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("DataSources");
                });

            modelBuilder.Entity("EykoChallenge.Models.DataSourceConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DataSourceConfigs");

                    b.HasDiscriminator<string>("Discriminator").HasValue("DataSourceConfig");
                });

            modelBuilder.Entity("EykoChallenge.Models.AdoNetSourceConfig", b =>
                {
                    b.HasBaseType("EykoChallenge.Models.DataSourceConfig");

                    b.Property<string>("ConnectionString")
                        .HasColumnType("TEXT");

                    b.Property<string>("TableName")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("AdoNetSourceConfig");
                });

            modelBuilder.Entity("EykoChallenge.Models.AwsS3SourceConfig", b =>
                {
                    b.HasBaseType("EykoChallenge.Models.DataSourceConfig");

                    b.Property<string>("AccountName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Bucket")
                        .HasColumnType("TEXT");

                    b.Property<string>("ObjectKey")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("AwsS3SourceConfig");
                });

            modelBuilder.Entity("EykoChallenge.Models.HttpApiSourceConfig", b =>
                {
                    b.HasBaseType("EykoChallenge.Models.DataSourceConfig");

                    b.Property<string>("HeadersJson")
                        .HasColumnType("TEXT");

                    b.Property<string>("Method")
                        .HasColumnType("TEXT");

                    b.Property<string>("QueryParamsJson")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("HttpApiSourceConfig");
                });

            modelBuilder.Entity("EykoChallenge.Models.DataSource", b =>
                {
                    b.HasOne("EykoChallenge.Models.DataSourceConfig", "Config")
                        .WithMany()
                        .HasForeignKey("ConfigId");

                    b.Navigation("Config");
                });
#pragma warning restore 612, 618
        }
    }
}
