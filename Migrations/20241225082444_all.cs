using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProjesi.Migrations
{
    /// <inheritdoc />
    public partial class all : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalisanHizmet");

            migrationBuilder.RenameColumn(
                name: "Ad",
                table: "Calisanlar",
                newName: "Ad_Soyad");

            migrationBuilder.AlterColumn<string>(
                name: "HizmetAdi",
                table: "Hizmetler",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "Hizmetler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "AktifMi",
                table: "Hizmetler",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Hizmetler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "KategoriID",
                table: "Hizmetler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Calisan_Resmi",
                table: "Calisanlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CalisanHizmetler",
                columns: table => new
                {
                    CalisanID = table.Column<int>(type: "int", nullable: false),
                    HizmetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalisanHizmetler", x => new { x.CalisanID, x.HizmetID });
                    table.ForeignKey(
                        name: "FK_CalisanHizmetler_Calisanlar_CalisanID",
                        column: x => x.CalisanID,
                        principalTable: "Calisanlar",
                        principalColumn: "CalisanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalisanHizmetler_Hizmetler_HizmetID",
                        column: x => x.HizmetID,
                        principalTable: "Hizmetler",
                        principalColumn: "HizmetID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.KategoriID);
                });

            migrationBuilder.CreateTable(
                name: "Randevular",
                columns: table => new
                {
                    RandevuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalisanID = table.Column<int>(type: "int", nullable: false),
                    HizmetID = table.Column<int>(type: "int", nullable: false),
                    MusteriAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RandevuTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Notlar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ucret = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevular", x => x.RandevuID);
                    table.ForeignKey(
                        name: "FK_Randevular_Calisanlar_CalisanID",
                        column: x => x.CalisanID,
                        principalTable: "Calisanlar",
                        principalColumn: "CalisanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevular_Hizmetler_HizmetID",
                        column: x => x.HizmetID,
                        principalTable: "Hizmetler",
                        principalColumn: "HizmetID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hizmetler_KategoriID",
                table: "Hizmetler",
                column: "KategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_CalisanHizmetler_HizmetID",
                table: "CalisanHizmetler",
                column: "HizmetID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_CalisanID",
                table: "Randevular",
                column: "CalisanID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_HizmetID",
                table: "Randevular",
                column: "HizmetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hizmetler_Kategori_KategoriID",
                table: "Hizmetler",
                column: "KategoriID",
                principalTable: "Kategori",
                principalColumn: "KategoriID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hizmetler_Kategori_KategoriID",
                table: "Hizmetler");

            migrationBuilder.DropTable(
                name: "CalisanHizmetler");

            migrationBuilder.DropTable(
                name: "Kategori");

            migrationBuilder.DropTable(
                name: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Hizmetler_KategoriID",
                table: "Hizmetler");

            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "Hizmetler");

            migrationBuilder.DropColumn(
                name: "AktifMi",
                table: "Hizmetler");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Hizmetler");

            migrationBuilder.DropColumn(
                name: "KategoriID",
                table: "Hizmetler");

            migrationBuilder.DropColumn(
                name: "Calisan_Resmi",
                table: "Calisanlar");

            migrationBuilder.RenameColumn(
                name: "Ad_Soyad",
                table: "Calisanlar",
                newName: "Ad");

            migrationBuilder.AlterColumn<string>(
                name: "HizmetAdi",
                table: "Hizmetler",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "CalisanHizmet",
                columns: table => new
                {
                    CalisanID = table.Column<int>(type: "int", nullable: false),
                    HizmetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalisanHizmet", x => new { x.CalisanID, x.HizmetID });
                    table.ForeignKey(
                        name: "FK_CalisanHizmet_Calisanlar_CalisanID",
                        column: x => x.CalisanID,
                        principalTable: "Calisanlar",
                        principalColumn: "CalisanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalisanHizmet_Hizmetler_HizmetID",
                        column: x => x.HizmetID,
                        principalTable: "Hizmetler",
                        principalColumn: "HizmetID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalisanHizmet_HizmetID",
                table: "CalisanHizmet",
                column: "HizmetID");
        }
    }
}
