using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dal.Migrations
{
    /// <inheritdoc />
    public partial class AddHref : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Location_PointId",
                schema: "my_city",
                table: "Location");

            migrationBuilder.AddColumn<string>(
                name: "Href",
                schema: "my_city",
                table: "Location",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Location_PointId",
                schema: "my_city",
                table: "Location",
                column: "PointId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Location_PointId",
                schema: "my_city",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "Href",
                schema: "my_city",
                table: "Location");

            migrationBuilder.CreateIndex(
                name: "IX_Location_PointId",
                schema: "my_city",
                table: "Location",
                column: "PointId");
        }
    }
}
