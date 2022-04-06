using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SakhCubaAPI.Migrations
{
    public partial class DecisionAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DecisionId",
                table: "Applications",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Decisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DecisionName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decisions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_DecisionId",
                table: "Applications",
                column: "DecisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Decisions_DecisionId",
                table: "Applications",
                column: "DecisionId",
                principalTable: "Decisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Decisions_DecisionId",
                table: "Applications");

            migrationBuilder.DropTable(
                name: "Decisions");

            migrationBuilder.DropIndex(
                name: "IX_Applications_DecisionId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "DecisionId",
                table: "Applications");
        }
    }
}
