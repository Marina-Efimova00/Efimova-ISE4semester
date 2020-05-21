using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbstractMebelDatabaseImplement.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mebels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MebelName = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mebels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zagotovkas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZagotovkaName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zagotovkas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MebelId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    Sum = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateImplement = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Mebels_MebelId",
                        column: x => x.MebelId,
                        principalTable: "Mebels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MebelZagotovkas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MebelId = table.Column<int>(nullable: false),
                    ZagotovkaId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MebelZagotovkas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MebelZagotovkas_Mebels_MebelId",
                        column: x => x.MebelId,
                        principalTable: "Mebels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MebelZagotovkas_Zagotovkas_ZagotovkaId",
                        column: x => x.ZagotovkaId,
                        principalTable: "Zagotovkas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MebelZagotovkas_MebelId",
                table: "MebelZagotovkas",
                column: "MebelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MebelZagotovkas_ZagotovkaId",
                table: "MebelZagotovkas",
                column: "ZagotovkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MebelId",
                table: "Orders",
                column: "MebelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MebelZagotovkas");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Zagotovkas");

            migrationBuilder.DropTable(
                name: "Mebels");
        }
    }
}