using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmircanBlog_Data.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("638faba6-2abf-408e-9ccc-58c2c9a4f8fc"),
                column: "ConcurrencyStamp",
                value: "0fc41503-f859-4612-bd50-5a4182c3c62d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f2b3db2-4450-4155-b3eb-0539523ecbae"),
                column: "ConcurrencyStamp",
                value: "f99ffa2a-67fd-4f1e-b668-c44d6fded49a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f9db5f5-b666-4773-97d6-e888a014606b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "92843136-c4d6-4cc9-afc4-84f61732607a", "AQAAAAEAACcQAAAAEPYQGyWxtw6E+FdxKIchibyMXFHLH1HdW/HNt9k/vVvUR86m6sDKnNo4NHbDNhmjTA==" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f71f4b9a-aa60-461d-b398-de31001bf214"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 23, 9, 14, 3, 605, DateTimeKind.Local).AddTicks(4159));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("638faba6-2abf-408e-9ccc-58c2c9a4f8fc"),
                column: "ConcurrencyStamp",
                value: "6405a06a-cf63-42f9-a650-f8a9e230a6b8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f2b3db2-4450-4155-b3eb-0539523ecbae"),
                column: "ConcurrencyStamp",
                value: "69a3220c-657c-46a9-b0d1-19455699b165");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f9db5f5-b666-4773-97d6-e888a014606b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9b00ce16-8ebf-456e-bbf3-70ef72f89d96", "AQAAAAEAACcQAAAAEC9hTRlG7AjKPeLG8wE0NAUOwq6tNnsYrFnMMuAOjXy2UxMosTgzwClBZqANsNblTw==" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f71f4b9a-aa60-461d-b398-de31001bf214"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 22, 17, 5, 45, 313, DateTimeKind.Local).AddTicks(6511));
        }
    }
}
