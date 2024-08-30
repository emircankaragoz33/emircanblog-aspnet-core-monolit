using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmircanBlog_Data.Migrations
{
    public partial class mig7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "ImageId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("638faba6-2abf-408e-9ccc-58c2c9a4f8fc"),
                column: "ConcurrencyStamp",
                value: "3938062b-b04f-41ba-9474-4eaef95d8139");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f2b3db2-4450-4155-b3eb-0539523ecbae"),
                column: "ConcurrencyStamp",
                value: "58f1a64b-d7ee-427d-89a0-9efcad767d70");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f9db5f5-b666-4773-97d6-e888a014606b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7b4b3f4f-d2ea-4e76-9a41-49710f748e99", "AQAAAAEAACcQAAAAEEBiuSlzJnWpA9b6xDCrIts2AacK4CTEHStgE5Ub8glVrVPM01vOD7KKnq1f5+hdyw==" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f71f4b9a-aa60-461d-b398-de31001bf214"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 20, 58, 44, 126, DateTimeKind.Local).AddTicks(871));

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "ImageId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("638faba6-2abf-408e-9ccc-58c2c9a4f8fc"),
                column: "ConcurrencyStamp",
                value: "03fefe3e-698b-4618-a194-29e9b514d9b7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f2b3db2-4450-4155-b3eb-0539523ecbae"),
                column: "ConcurrencyStamp",
                value: "7928d7db-4247-4300-beb2-e37a317fa0fc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f9db5f5-b666-4773-97d6-e888a014606b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3ae8af1c-7d25-4044-8639-03950c52007a", "AQAAAAEAACcQAAAAEE3XlPjRXQJwUqNqSrnKvSz2xFp4gDBOSOMpSG9RjFk/WuCKzJa0GdBYt18isfO56A==" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f71f4b9a-aa60-461d-b398-de31001bf214"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 24, 21, 18, 41, 665, DateTimeKind.Local).AddTicks(808));

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }
    }
}
