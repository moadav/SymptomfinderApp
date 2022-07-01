using Microsoft.EntityFrameworkCore.Migrations;

namespace Symptomfinder.Migrations
{
    public partial class addedfilters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Selected = table.Column<bool>(type: "bit", nullable: false),
                    SymptomeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filter_Symptome_SymptomeId",
                        column: x => x.SymptomeId,
                        principalTable: "Symptome",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filter_SymptomeId",
                table: "Filter",
                column: "SymptomeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filter");
        }
    }
}
