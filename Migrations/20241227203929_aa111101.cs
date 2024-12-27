using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProjesi.Migrations
{
    /// <inheritdoc />
    public partial class aa111101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedHizmetIDs",
                table: "Calisanlar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SelectedHizmetIDs",
                table: "Calisanlar",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
