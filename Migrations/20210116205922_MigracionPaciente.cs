using Microsoft.EntityFrameworkCore.Migrations;

namespace Control_Medico_NS.Migrations
{
    public partial class MigracionPaciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PubStrDescripcion",
                table: "Especialidad",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    PubIntIdPaciente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PubStrNombre = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    PubStrSeguro = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    PubStrCodigoPostal = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    PubStrTelefono = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    PubStrDireccion = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    PubStrEmail = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.PubIntIdPaciente);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.AlterColumn<string>(
                name: "PubStrDescripcion",
                table: "Especialidad",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 200);
        }
    }
}
