using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProjesi.Migrations
{
    /// <inheritdoc />
    public partial class neww : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calisan_Hizmetler");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalisanHizmet");

            migrationBuilder.CreateTable(
                name: "Calisan_Hizmetler",
                columns: table => new
                {
                    CalisanID = table.Column<int>(type: "int", nullable: false),
                    HizmetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calisan_Hizmetler", x => new { x.CalisanID, x.HizmetID });
                    table.ForeignKey(
                        name: "FK_Calisan_Hizmetler_Calisanlar_CalisanID",
                        column: x => x.CalisanID,
                        principalTable: "Calisanlar",
                        principalColumn: "CalisanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calisan_Hizmetler_Hizmetler_HizmetID",
                        column: x => x.HizmetID,
                        principalTable: "Hizmetler",
                        principalColumn: "HizmetID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calisan_Hizmetler_HizmetID",
                table: "Calisan_Hizmetler",
                column: "HizmetID");
        }
    }
}
