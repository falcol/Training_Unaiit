using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_Unaiit.Migrations
{
    public partial class News : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            for (int i = 0; i < 100; i++)
            {
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
                    },
                    values: new object[] {
                        Guid.NewGuid().ToString(),
                        $"User{i}",
                        $"falcol{i}@gmail.com",
                        Guid.NewGuid().ToString(),
                        false,
                        false,
                        false,
                        false,
                        0,
                        "homeaddress",
                        "",
                        0,
                        "01/01/2020",
                        $"name{i}",
                    });
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
