using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestSearchApplication.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TAB",
                columns: table => new
                {
                    MNO = table.Column<int>(type: "integer", nullable: false),
                    ID = table.Column<int>(type: "integer", nullable: true)
                        .Annotation("Jet:Identity", "1, 1"),
                    MH_Nass = table.Column<string>(type: "longchar", nullable: true),
                    NASSX = table.Column<string>(type: "longchar", nullable: true),
                    MUSNAD = table.Column<int>(type: "integer", nullable: true),
                    MTN = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "No"),
                    Tmam = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "No")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey", x => x.MNO);
                });

            migrationBuilder.CreateTable(
                name: "b010105",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: true),
                    Tno = table.Column<double>(type: "double", nullable: true),
                    MNO = table.Column<int>(type: "integer", nullable: true),
                    nass = table.Column<string>(type: "longchar", nullable: true),
                    NASSX = table.Column<string>(type: "longchar", nullable: true),
                    part = table.Column<int>(type: "integer", nullable: true),
                    page = table.Column<int>(type: "integer", nullable: true),
                    Hno = table.Column<int>(type: "integer", nullable: true),
                    TabNo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "TABb010105",
                        column: x => x.MNO,
                        principalTable: "TAB",
                        principalColumn: "MNO");
                });

            migrationBuilder.CreateIndex(
                name: "MNO",
                table: "b010105",
                column: "MNO");

            migrationBuilder.CreateIndex(
                name: "Tno",
                table: "b010105",
                column: "Tno");

            migrationBuilder.CreateIndex(
                name: "ID",
                table: "TAB",
                column: "ID",
                unique: true,
                filter: "IGNORE NULL");

            migrationBuilder.CreateIndex(
                name: "MNO",
                table: "TAB",
                column: "MNO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "MUSNAD",
                table: "TAB",
                column: "MUSNAD");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "b010105");

            migrationBuilder.DropTable(
                name: "TAB");
        }
    }
}
