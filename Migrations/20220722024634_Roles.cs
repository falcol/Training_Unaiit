using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_Unaiit.Migrations
{
    public partial class Roles : Migration
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
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculty_School_SchoolId",
                table: "Faculty",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "Id");

            migrationBuilder.InsertData(
                   "Roles",
                   columns: new[] {
                       "Id",
                       "ConcurrencyStamp",
                       "Name",
                       "NormalizedName"
                   },
                   values: new object[] {
                       "0c00ae63-00a7-463c-98b7-9464e1a5c027",
                       Guid.NewGuid().ToString(),
                       "Admin",
                       "ADMIN"
                   });

            migrationBuilder.InsertData(
                   "Roles",
                   columns: new[] {
                       "Id",
                       "ConcurrencyStamp",
                       "Name",
                       "NormalizedName"
                   },
                   values: new object[] {
                       Guid.NewGuid().ToString(),
                       Guid.NewGuid().ToString(),
                       "Student",
                       "STUDENT"
                   });

            migrationBuilder.InsertData(
                   "Roles",
                   columns: new[] {
                       "Id",
                       "ConcurrencyStamp",
                       "Name",
                       "NormalizedName"
                   },
                   values: new object[] {
                       Guid.NewGuid().ToString(),
                       Guid.NewGuid().ToString(),
                       "Teacher",
                       "TEACHER"
                   });

            migrationBuilder.InsertData(
                   "Users",
                   columns: new[] {
                        "Id",
                        "UserName",
                        "Email",
                        "SecurityStamp",
                        "EmailConfirmed",
                        "PhoneNumberConfirmed",
                        "TwoFactorEnabled",
                        "LockoutEnabled",
                        "AccessFailedCount",
                        "HomeAddress",
                        "DeletedAt",
                        "type",
                        "BirthDate",
                        "Name",
                        "PasswordHash"
                   },
                   values: new object[] {
                        "1043278e-7c6a-4590-b2fc-cafeaf30b6a7",
                        $"Test@gmail.com",
                        $"Test@gmail.com",
                        Guid.NewGuid().ToString(),
                        false,
                        false,
                        false,
                        true,
                        0,
                        "homeaddress",
                        "",
                        0,
                        "01/01/2020",
                        $"name",
                        "AQAAAAEAACcQAAAAEBy+RFcaWxBTS9uZvNbEGTYapEUjl5WT3xnYcRBcw3sGWCavYhVIfAlQNrhxseGk/Q=="
                   });
            
            migrationBuilder.InsertData(
                "UserRoles",
                columns: new[] {
                    "UserId",
                    "RoleId"
                },
                values: new object[] {
                    "1043278e-7c6a-4590-b2fc-cafeaf30b6a7",
                    "0c00ae63-00a7-463c-98b7-9464e1a5c027"
                });
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
    }
}
