using Microsoft.EntityFrameworkCore.Migrations;

namespace Control_Medico_NS.Migrations
{
    public partial class MigracionDoctorEspecialidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorEspecialidad",
                columns: table => new
                {
                    PubIntIdDoctor = table.Column<int>(nullable: false),
                    PubIntIdEspecialidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorEspecialidad", x => new { x.PubIntIdDoctor, x.PubIntIdEspecialidad });
                    table.ForeignKey(
                        name: "FK_DoctorEspecialidad_Doctor_PubIntIdDoctor",
                        column: x => x.PubIntIdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "PubIntIdDoctor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorEspecialidad_Especialidad_PubIntIdEspecialidad",
                        column: x => x.PubIntIdEspecialidad,
                        principalTable: "Especialidad",
                        principalColumn: "PubIntIdEspecialidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorEspecialidad_PubIntIdEspecialidad",
                table: "DoctorEspecialidad",
                column: "PubIntIdEspecialidad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorEspecialidad");
        }
    }
}
