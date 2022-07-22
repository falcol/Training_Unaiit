using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_Unaiit.Migrations
{
    public partial class NewKeyss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserGradeTable");

            migrationBuilder.AddColumn<Guid>(
                name: "GradeTableId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_GradeTableId",
                table: "Users",
                column: "GradeTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Grade_GradeTableId",
                table: "Users",
                column: "GradeTableId",
                principalTable: "Grade",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Grade_GradeTableId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_GradeTableId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GradeTableId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "AppUserGradeTable",
                columns: table => new
                {
                    GradesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserGradeTable", x => new { x.GradesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_AppUserGradeTable_Grade_GradesId",
                        column: x => x.GradesId,
                        principalTable: "Grade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserGradeTable_Users_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserGradeTable_StudentsId",
                table: "AppUserGradeTable",
                column: "StudentsId");
        }
    }
}
