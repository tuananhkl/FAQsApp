using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FAQs.Data.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ab91d6a-fe32-48a5-a197-baf6991aa276", "8e4c740d-9eba-4bb8-aa8c-9f88c92db953", "User", "USER" },
                    { "f8b00223-3aff-48ac-a013-3863fd845564", "45affd92-2b72-45b1-9162-251f949d1cc1", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "FaqTranslations",
                keyColumn: "Id",
                keyValue: new Guid("301ca0ab-3486-41d5-af94-565a105c7ea1"),
                column: "CreatedDate",
                value: new DateTime(2022, 8, 11, 1, 32, 21, 299, DateTimeKind.Utc).AddTicks(8910));

            migrationBuilder.UpdateData(
                table: "FaqTranslations",
                keyColumn: "Id",
                keyValue: new Guid("30f467c3-6b6c-4b73-b8d7-696bd317904b"),
                column: "CreatedDate",
                value: new DateTime(2022, 8, 11, 1, 32, 21, 299, DateTimeKind.Utc).AddTicks(9210));

            migrationBuilder.UpdateData(
                table: "FaqTranslations",
                keyColumn: "Id",
                keyValue: new Guid("8621b5da-0b07-4795-b360-7a898e842037"),
                column: "CreatedDate",
                value: new DateTime(2022, 8, 11, 1, 32, 21, 299, DateTimeKind.Utc).AddTicks(9230));

            migrationBuilder.UpdateData(
                table: "Faqs",
                keyColumn: "Id",
                keyValue: new Guid("22a30b4d-c055-49ab-98bb-5767dd591c43"),
                column: "CreatedDate",
                value: new DateTime(2022, 8, 11, 1, 32, 21, 299, DateTimeKind.Utc).AddTicks(6980));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ab91d6a-fe32-48a5-a197-baf6991aa276");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8b00223-3aff-48ac-a013-3863fd845564");

            migrationBuilder.UpdateData(
                table: "FaqTranslations",
                keyColumn: "Id",
                keyValue: new Guid("301ca0ab-3486-41d5-af94-565a105c7ea1"),
                column: "CreatedDate",
                value: new DateTime(2022, 8, 10, 10, 0, 50, 712, DateTimeKind.Utc).AddTicks(2180));

            migrationBuilder.UpdateData(
                table: "FaqTranslations",
                keyColumn: "Id",
                keyValue: new Guid("30f467c3-6b6c-4b73-b8d7-696bd317904b"),
                column: "CreatedDate",
                value: new DateTime(2022, 8, 10, 10, 0, 50, 712, DateTimeKind.Utc).AddTicks(2480));

            migrationBuilder.UpdateData(
                table: "FaqTranslations",
                keyColumn: "Id",
                keyValue: new Guid("8621b5da-0b07-4795-b360-7a898e842037"),
                column: "CreatedDate",
                value: new DateTime(2022, 8, 10, 10, 0, 50, 712, DateTimeKind.Utc).AddTicks(2590));

            migrationBuilder.UpdateData(
                table: "Faqs",
                keyColumn: "Id",
                keyValue: new Guid("22a30b4d-c055-49ab-98bb-5767dd591c43"),
                column: "CreatedDate",
                value: new DateTime(2022, 8, 10, 10, 0, 50, 712, DateTimeKind.Utc).AddTicks(240));
        }
    }
}
