using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class cha1s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Areas_AreaId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_AreaId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Units");

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AreaUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreaUnits_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AreaUnits_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AreaId",
                table: "Locations",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaUnits_AreaId",
                table: "AreaUnits",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaUnits_UnitId",
                table: "AreaUnits",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Areas_AreaId",
                table: "Locations",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Areas_AreaId",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "AreaUnits");

            migrationBuilder.DropIndex(
                name: "IX_Locations_AreaId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Locations");

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "Units",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_AreaId",
                table: "Units",
                column: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Areas_AreaId",
                table: "Units",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id");
        }
    }
}
