using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiApi.Migrations
{
    /// <inheritdoc />
    public partial class localconnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "blog",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(55)", unicode: false, maxLength: 55, nullable: true),
                    author = table.Column<string>(type: "varchar(55)", unicode: false, maxLength: 55, nullable: true),
                    url = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    likes = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__blog__3213E83FB399F40B", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blog");
        }
    }
}
