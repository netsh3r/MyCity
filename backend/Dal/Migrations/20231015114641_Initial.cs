using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dal.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "my_city");

            migrationBuilder.CreateTable(
                name: "Point",
                schema: "my_city",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    X = table.Column<string>(type: "text", nullable: false),
                    Y = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Point", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                schema: "my_city",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "my_city",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PointId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Point_PointId",
                        column: x => x.PointId,
                        principalSchema: "my_city",
                        principalTable: "Point",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoutePoint",
                schema: "my_city",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RouteId = table.Column<long>(type: "bigint", nullable: false),
                    RoutePointObj = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutePoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoutePoint_Route_RouteId",
                        column: x => x.RouteId,
                        principalSchema: "my_city",
                        principalTable: "Route",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Location_PointId",
                schema: "my_city",
                table: "Location",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutePoint_RouteId",
                schema: "my_city",
                table: "RoutePoint",
                column: "RouteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location",
                schema: "my_city");

            migrationBuilder.DropTable(
                name: "RoutePoint",
                schema: "my_city");

            migrationBuilder.DropTable(
                name: "Point",
                schema: "my_city");

            migrationBuilder.DropTable(
                name: "Route",
                schema: "my_city");
        }
    }
}
