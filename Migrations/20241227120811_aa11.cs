using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProjesi.Migrations
{
    /// <inheritdoc />
    public partial class aa11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hizmetler_Kategori_KategoriID",
                table: "Hizmetler");

            migrationBuilder.DropTable(
                name: "Kategori");

            migrationBuilder.DropIndex(
                name: "IX_Hizmetler_KategoriID",
                table: "Hizmetler");

            migrationBuilder.DropColumn(
                name: "KategoriID",
                table: "Hizmetler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategoriID",
                table: "Hizmetler",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Hizmetler_KategoriID",
                table: "Hizmetler",
                column: "KategoriID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hizmetler_Kategori_KategoriID",
                table: "Hizmetler",
                column: "KategoriID",
                principalTable: "Kategori",
                principalColumn: "KategoriID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
