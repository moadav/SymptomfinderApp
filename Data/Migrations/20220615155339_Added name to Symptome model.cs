﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Symptomfinder.Data.Migrations
{
    public partial class AddednametoSymptomemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Symptome",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Symptome");
        }
    }
}
