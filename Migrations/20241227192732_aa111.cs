using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProjesi.Migrations
{
    /// <inheritdoc />
    public partial class aa111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AktifMi",
                table: "Hizmetler");

            migrationBuilder.AddColumn<string>(
                name: "SelectedHizmetIDs",
                table: "Calisanlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedHizmetIDs",
                table: "Calisanlar");

            migrationBuilder.AddColumn<bool>(
                name: "AktifMi",
                table: "Hizmetler",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
