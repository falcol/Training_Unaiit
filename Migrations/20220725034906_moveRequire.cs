﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_Unaiit.Migrations
{
    public partial class moveRequire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Faculty_FacultyId",
                table: "Grade");

            migrationBuilder.AlterColumn<Guid>(
                name: "FacultyId",
                table: "Grade",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Faculty_FacultyId",
                table: "Grade",
                column: "FacultyId",
                principalTable: "Faculty",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Faculty_FacultyId",
                table: "Grade");

            migrationBuilder.AlterColumn<Guid>(
                name: "FacultyId",
                table: "Grade",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Faculty_FacultyId",
                table: "Grade",
                column: "FacultyId",
                principalTable: "Faculty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
