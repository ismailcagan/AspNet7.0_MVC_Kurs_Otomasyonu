using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KursOtomasyonuApp.Migrations
{
    /// <inheritdoc />
    public partial class AddTableOgretmen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "KursBaslik",
                table: "Kurslar",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "OgretmenId",
                table: "Kurslar",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "kursKayits",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "Ogretmenler",
                columns: table => new
                {
                    OgretmenId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: true),
                    SoyAd = table.Column<string>(type: "TEXT", nullable: true),
                    EPosta = table.Column<string>(type: "TEXT", nullable: true),
                    Telefon = table.Column<string>(type: "TEXT", nullable: true),
                    BaslamaTarihi = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogretmenler", x => x.OgretmenId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kurslar_OgretmenId",
                table: "Kurslar",
                column: "OgretmenId");

            migrationBuilder.CreateIndex(
                name: "IX_kursKayits_KursId",
                table: "kursKayits",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_kursKayits_OgrenciId",
                table: "kursKayits",
                column: "OgrenciId");

            migrationBuilder.AddForeignKey(
                name: "FK_kursKayits_Kurslar_KursId",
                table: "kursKayits",
                column: "KursId",
                principalTable: "Kurslar",
                principalColumn: "KursId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_kursKayits_Ogrencis_OgrenciId",
                table: "kursKayits",
                column: "OgrenciId",
                principalTable: "Ogrencis",
                principalColumn: "OgrenciId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kurslar_Ogretmenler_OgretmenId",
                table: "Kurslar",
                column: "OgretmenId",
                principalTable: "Ogretmenler",
                principalColumn: "OgretmenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_kursKayits_Kurslar_KursId",
                table: "kursKayits");

            migrationBuilder.DropForeignKey(
                name: "FK_kursKayits_Ogrencis_OgrenciId",
                table: "kursKayits");

            migrationBuilder.DropForeignKey(
                name: "FK_Kurslar_Ogretmenler_OgretmenId",
                table: "Kurslar");

            migrationBuilder.DropTable(
                name: "Ogretmenler");

            migrationBuilder.DropIndex(
                name: "IX_Kurslar_OgretmenId",
                table: "Kurslar");

            migrationBuilder.DropIndex(
                name: "IX_kursKayits_KursId",
                table: "kursKayits");

            migrationBuilder.DropIndex(
                name: "IX_kursKayits_OgrenciId",
                table: "kursKayits");

            migrationBuilder.DropColumn(
                name: "OgretmenId",
                table: "Kurslar");

            migrationBuilder.AlterColumn<string>(
                name: "KursBaslik",
                table: "Kurslar",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "kursKayits",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
