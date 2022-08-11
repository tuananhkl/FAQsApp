using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FAQs.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faqs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Question = table.Column<string>(type: "text", nullable: false),
                    Answer = table.Column<string>(type: "text", nullable: false),
                    Language = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faqs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FaqTranslations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FaqId = table.Column<Guid>(type: "uuid", nullable: false),
                    Question = table.Column<string>(type: "text", nullable: false),
                    Answer = table.Column<string>(type: "text", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaqTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaqTranslations_Faqs_FaqId",
                        column: x => x.FaqId,
                        principalTable: "Faqs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Faqs",
                columns: new[] { "Id", "Answer", "CreatedDate", "Language", "ModifiedDate", "Question" },
                values: new object[] { new Guid("22a30b4d-c055-49ab-98bb-5767dd591c43"), "I'm 23 years old.", new DateTime(2022, 8, 10, 6, 45, 52, 472, DateTimeKind.Utc).AddTicks(2820), "en", null, "How old are you?" });

            migrationBuilder.InsertData(
                table: "FaqTranslations",
                columns: new[] { "Id", "Answer", "CreatedDate", "FaqId", "Language", "ModifiedDate", "Question" },
                values: new object[,]
                {
                    { new Guid("301ca0ab-3486-41d5-af94-565a105c7ea1"), "Toi 23 tuoi", new DateTime(2022, 8, 10, 6, 45, 52, 472, DateTimeKind.Utc).AddTicks(4770), new Guid("22a30b4d-c055-49ab-98bb-5767dd591c43"), "vi", null, "Ban bao nhieu tuoi?" },
                    { new Guid("30f467c3-6b6c-4b73-b8d7-696bd317904b"), "watashi-wa-njusansai-desu.", new DateTime(2022, 8, 10, 6, 45, 52, 472, DateTimeKind.Utc).AddTicks(5100), new Guid("22a30b4d-c055-49ab-98bb-5767dd591c43"), "jp", null, "anata-wa-oikutsu-desu-ka?" },
                    { new Guid("8621b5da-0b07-4795-b360-7a898e842037"), "Wǒ èrshísān suì.", new DateTime(2022, 8, 10, 6, 45, 52, 472, DateTimeKind.Utc).AddTicks(5120), new Guid("22a30b4d-c055-49ab-98bb-5767dd591c43"), "cn", null, "nín duō dà suìshu?" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FaqTranslations_FaqId",
                table: "FaqTranslations",
                column: "FaqId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaqTranslations");

            migrationBuilder.DropTable(
                name: "Faqs");
        }
    }
}
