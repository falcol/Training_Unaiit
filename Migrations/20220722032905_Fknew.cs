using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_Unaiit.Migrations
{
    public partial class Fknew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculty_School_SchoolId",
                table: "Faculty");

            migrationBuilder.AlterColumn<Guid>(
                name: "SchoolId",
                table: "Faculty",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Faculty_School_SchoolId",
                table: "Faculty",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculty_School_SchoolId",
                table: "Faculty");

            migrationBuilder.AlterColumn<Guid>(
                name: "SchoolId",
                table: "Faculty",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculty_School_SchoolId",
                table: "Faculty",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "Id");
        }
    }
}
