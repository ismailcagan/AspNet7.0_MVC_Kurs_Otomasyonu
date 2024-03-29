﻿// <auto-generated />
using System;
using KursOtomasyonuApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KursOtomasyonuApp.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("KursOtomasyonuApp.Data.Kurs", b =>
                {
                    b.Property<int>("KursId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("KursBaslik")
                        .HasColumnType("TEXT");

                    b.Property<int?>("OgretmenId")
                        .HasColumnType("INTEGER");

                    b.HasKey("KursId");

                    b.HasIndex("OgretmenId");

                    b.ToTable("Kurslar");
                });

            modelBuilder.Entity("KursOtomasyonuApp.Data.KursKayit", b =>
                {
                    b.Property<int>("KayitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("KayitTarihi")
                        .HasColumnType("TEXT");

                    b.Property<int>("KursId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OgrenciId")
                        .HasColumnType("INTEGER");

                    b.HasKey("KayitId");

                    b.HasIndex("KursId");

                    b.HasIndex("OgrenciId");

                    b.ToTable("kursKayits");
                });

            modelBuilder.Entity("KursOtomasyonuApp.Data.Ogrenci", b =>
                {
                    b.Property<int>("OgrenciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EPosta")
                        .HasColumnType("TEXT");

                    b.Property<string>("OgrenciAd")
                        .HasColumnType("TEXT");

                    b.Property<string>("OgrenciSoyAd")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefon")
                        .HasColumnType("TEXT");

                    b.HasKey("OgrenciId");

                    b.ToTable("Ogrencis");
                });

            modelBuilder.Entity("KursOtomasyonuApp.Data.Ogretmen", b =>
                {
                    b.Property<int>("OgretmenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ad")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BaslamaTarihi")
                        .HasColumnType("TEXT");

                    b.Property<string>("EPosta")
                        .HasColumnType("TEXT");

                    b.Property<string>("SoyAd")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefon")
                        .HasColumnType("TEXT");

                    b.HasKey("OgretmenId");

                    b.ToTable("Ogretmenler");
                });

            modelBuilder.Entity("KursOtomasyonuApp.Data.Kurs", b =>
                {
                    b.HasOne("KursOtomasyonuApp.Data.Ogretmen", "Ogretmen")
                        .WithMany("Kurslar")
                        .HasForeignKey("OgretmenId");

                    b.Navigation("Ogretmen");
                });

            modelBuilder.Entity("KursOtomasyonuApp.Data.KursKayit", b =>
                {
                    b.HasOne("KursOtomasyonuApp.Data.Kurs", "Kurs")
                        .WithMany("kursKayitlari")
                        .HasForeignKey("KursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KursOtomasyonuApp.Data.Ogrenci", "Ogrenci")
                        .WithMany("kursKayitlari")
                        .HasForeignKey("OgrenciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kurs");

                    b.Navigation("Ogrenci");
                });

            modelBuilder.Entity("KursOtomasyonuApp.Data.Kurs", b =>
                {
                    b.Navigation("kursKayitlari");
                });

            modelBuilder.Entity("KursOtomasyonuApp.Data.Ogrenci", b =>
                {
                    b.Navigation("kursKayitlari");
                });

            modelBuilder.Entity("KursOtomasyonuApp.Data.Ogretmen", b =>
                {
                    b.Navigation("Kurslar");
                });
#pragma warning restore 612, 618
        }
    }
}
