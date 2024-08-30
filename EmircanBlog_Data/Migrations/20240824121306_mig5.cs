using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmircanBlog_Data.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BlogUserId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("638faba6-2abf-408e-9ccc-58c2c9a4f8fc"),
                column: "ConcurrencyStamp",
                value: "bf979fdc-207f-43bf-b978-d52b54d3f092");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f2b3db2-4450-4155-b3eb-0539523ecbae"),
                column: "ConcurrencyStamp",
                value: "9391df76-a181-4dc8-9d5c-d1675d959619");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f9db5f5-b666-4773-97d6-e888a014606b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d54cdbb6-6056-44c8-928f-c3165bc82e9c", "AQAAAAEAACcQAAAAENmiayzeTIuaRnQk8xHevBCCk+L2xQDoJAZJpq2AZniQeSk/gdSLYUXQ5qoCdBK3ug==" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f71f4b9a-aa60-461d-b398-de31001bf214"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 24, 15, 13, 6, 106, DateTimeKind.Local).AddTicks(1276));

            migrationBuilder.CreateIndex(
                name: "IX_Categories_BlogUserId",
                table: "Categories",
                column: "BlogUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_BlogUserId",
                table: "Categories",
                column: "BlogUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_BlogUserId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_BlogUserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "BlogUserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("638faba6-2abf-408e-9ccc-58c2c9a4f8fc"),
                column: "ConcurrencyStamp",
                value: "210c5fe4-20c3-428e-91d4-fe5be58d678e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f2b3db2-4450-4155-b3eb-0539523ecbae"),
                column: "ConcurrencyStamp",
                value: "f9c2fb9d-2fce-4101-9aa6-3f872055b79b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f9db5f5-b666-4773-97d6-e888a014606b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a816159f-a1a7-4667-bb52-a164c8e7eff1", "AQAAAAEAACcQAAAAEPsBNs57mqHyhHdBw5LvIn2Fn3EesTGrkaW1fuvM5hOZbmR6+pN437oM1pgdj8V+iA==" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f71f4b9a-aa60-461d-b398-de31001bf214"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 24, 9, 46, 3, 49, DateTimeKind.Local).AddTicks(7493));
        }
    }
}
