using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Food_Order_System.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblCategory",
                columns: table => new
                {
                    Category_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCategory", x => x.Category_ID);
                });

            migrationBuilder.CreateTable(
                name: "TblItem",
                columns: table => new
                {
                    Item_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item_Price = table.Column<int>(type: "int", nullable: false),
                    Item_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblItem", x => x.Item_ID);
                });

            migrationBuilder.CreateTable(
                name: "TblOwner",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblOwner", x => x.Email);
                });

            migrationBuilder.InsertData(
                table: "TblCategory",
                columns: new[] { "Category_ID", "Category_Name" },
                values: new object[,]
                {
                    { 1, "Veg" },
                    { 2, "Non-Veg" }
                });

            migrationBuilder.InsertData(
                table: "TblOwner",
                columns: new[] { "Email", "Password" },
                values: new object[] { "dtm2024@gmail.com", "12345" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblCategory");

            migrationBuilder.DropTable(
                name: "TblItem");

            migrationBuilder.DropTable(
                name: "TblOwner");
        }
    }
}
