using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MicroServiceShop.Cargo.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cargo");

            migrationBuilder.CreateTable(
                name: "CargoCompany",
                schema: "cargo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CargoDetail",
                schema: "cargo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sender = table.Column<string>(type: "text", nullable: false),
                    Customer = table.Column<string>(type: "text", nullable: false),
                    Barcode = table.Column<int>(type: "integer", nullable: false),
                    CargoCompanyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CargoDetail_CargoCompany_CargoCompanyId",
                        column: x => x.CargoCompanyId,
                        principalSchema: "cargo",
                        principalTable: "CargoCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CargoDetail_CargoCompanyId",
                schema: "cargo",
                table: "CargoDetail",
                column: "CargoCompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CargoDetail",
                schema: "cargo");

            migrationBuilder.DropTable(
                name: "CargoCompany",
                schema: "cargo");
        }
    }
}
