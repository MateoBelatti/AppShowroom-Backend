using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class RemoveVela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Velas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Velas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Aroma = table.Column<string>(type: "text", nullable: false),
                    CantidadCl = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Velas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Velas_Productos_Id",
                        column: x => x.Id,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
