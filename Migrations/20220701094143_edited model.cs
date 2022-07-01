using Microsoft.EntityFrameworkCore.Migrations;

namespace Symptomfinder.Migrations
{
    public partial class editedmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filter_Symptome_SymptomeId",
                table: "Filter");

            migrationBuilder.DropIndex(
                name: "IX_Filter_SymptomeId",
                table: "Filter");

            migrationBuilder.DropColumn(
                name: "SymptomeId",
                table: "Filter");

            migrationBuilder.InsertData(
                table: "Filter",
                columns: new[] { "Id", "Name", "Selected" },
                values: new object[,]
                {
                    { 1078, "headache", false },
                    { 1079, "dizziness", false },
                    { 1080, "weakness", false },
                    { 1081, "stomach", false },
                    { 1082, "vomiting", false },
                    { 1083, "chest", false },
                    { 1084, "confusion", false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Filter",
                keyColumn: "Id",
                keyValue: 1078);

            migrationBuilder.DeleteData(
                table: "Filter",
                keyColumn: "Id",
                keyValue: 1079);

            migrationBuilder.DeleteData(
                table: "Filter",
                keyColumn: "Id",
                keyValue: 1080);

            migrationBuilder.DeleteData(
                table: "Filter",
                keyColumn: "Id",
                keyValue: 1081);

            migrationBuilder.DeleteData(
                table: "Filter",
                keyColumn: "Id",
                keyValue: 1082);

            migrationBuilder.DeleteData(
                table: "Filter",
                keyColumn: "Id",
                keyValue: 1083);

            migrationBuilder.DeleteData(
                table: "Filter",
                keyColumn: "Id",
                keyValue: 1084);

            migrationBuilder.AddColumn<int>(
                name: "SymptomeId",
                table: "Filter",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Filter_SymptomeId",
                table: "Filter",
                column: "SymptomeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filter_Symptome_SymptomeId",
                table: "Filter",
                column: "SymptomeId",
                principalTable: "Symptome",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
