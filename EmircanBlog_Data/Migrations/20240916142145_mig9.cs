using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmircanBlog_Data.Migrations
{
    public partial class mig9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("638faba6-2abf-408e-9ccc-58c2c9a4f8fc"),
                column: "ConcurrencyStamp",
                value: "935f263a-4098-40f5-be82-c250423a06bd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f2b3db2-4450-4155-b3eb-0539523ecbae"),
                column: "ConcurrencyStamp",
                value: "b4ae1700-58c6-48fa-856d-d07969419717");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f9db5f5-b666-4773-97d6-e888a014606b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8e21a68c-feae-4206-a75f-75d08591af3c", "AQAAAAEAACcQAAAAEB75YDaorVA9l9PNc4ScV6yBxzrmNkqcQdJVMUqhUaE3cvmj/ZGZFTBh5Z7DlJGQsA==" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f71f4b9a-aa60-461d-b398-de31001bf214"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 16, 17, 21, 45, 62, DateTimeKind.Local).AddTicks(4635));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("638faba6-2abf-408e-9ccc-58c2c9a4f8fc"),
                column: "ConcurrencyStamp",
                value: "9fa464cf-a762-43ea-97ce-f2dfa6f5218c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f2b3db2-4450-4155-b3eb-0539523ecbae"),
                column: "ConcurrencyStamp",
                value: "0c1ab6e0-0bea-4d03-8d68-0b5a404890f7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f9db5f5-b666-4773-97d6-e888a014606b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "40285667-b3ba-42b1-9c66-bf3a3beab711", "AQAAAAEAACcQAAAAEC7JtBj5jXbNOaP8k0NnIq1q6YJQFAjDsFtjw/EQfNBqTR5fqaLzrWEc6+j+65WALA==" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f71f4b9a-aa60-461d-b398-de31001bf214"),
                column: "CreatedDate",
                value: new DateTime(2024, 9, 7, 10, 41, 30, 62, DateTimeKind.Local).AddTicks(9480));
        }
    }
}
