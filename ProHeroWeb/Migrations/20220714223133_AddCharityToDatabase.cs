using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProHeroWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddCharityToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Charities",
                columns: table => new
                {
                    CharityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Organizer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmallDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LargeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonationPlan = table.Column<float>(type: "real", nullable: false),
                    Donated = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charities", x => x.CharityId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Charities");
        }
    }
}
