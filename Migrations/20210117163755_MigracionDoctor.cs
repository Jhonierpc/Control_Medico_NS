using Microsoft.EntityFrameworkCore.Migrations;

namespace Control_Medico_NS.Migrations
{
    public partial class MigracionDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    PubIntIdDoctor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PubStrNombre = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    PubStrCredencial = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    PubStrHospital = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    PubStrTelefono = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    PubStrEmail = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.PubIntIdDoctor);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctor");
        }
    }
}
