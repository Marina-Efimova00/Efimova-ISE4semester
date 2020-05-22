using Microsoft.EntityFrameworkCore.Migrations;

namespace AbstractMebelDatabaseImplement.Migrations
{
    public partial class Client : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MebelZagotovkas_MebelId",
                table: "MebelZagotovkas");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientFIO = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_MebelZagotovkas_MebelId",
                table: "MebelZagotovkas",
                column: "MebelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ClientId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_MebelZagotovkas_MebelId",
                table: "MebelZagotovkas");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_MebelZagotovkas_MebelId",
                table: "MebelZagotovkas",
                column: "MebelId",
                unique: true);
        }
    }
}