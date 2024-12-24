using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebProjesi.Migrations
{
    /// <inheritdoc />
    public partial class new1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Calisanlar",
                columns: new[] { "CalisanID", "Ad", "BaslangicSaati", "BitisSaati" },
                values: new object[,]
                {
                    { 1, "Ahmet", new TimeSpan(0, 9, 0, 0, 0), new TimeSpan(0, 18, 0, 0, 0) },
                    { 2, "Mehmet", new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 19, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Hizmetler",
                columns: new[] { "HizmetID", "HizmetAdi", "Sure", "Ucret" },
                values: new object[,]
                {
                    { 1, "Saç Kesimi", 30, 50m },
                    { 2, "Sakal Tıraşı", 20, 30m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Calisanlar",
                keyColumn: "CalisanID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Calisanlar",
                keyColumn: "CalisanID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hizmetler",
                keyColumn: "HizmetID",
                keyValue: 2);
        }
    }
}
