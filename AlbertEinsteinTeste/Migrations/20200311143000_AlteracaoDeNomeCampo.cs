using Microsoft.EntityFrameworkCore.Migrations;

namespace AlbertEinsteinTeste.Migrations
{
    public partial class AlteracaoDeNomeCampo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Medico_MedicoId",
                table: "Consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Paciente_PacienteId",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "ConsultaEstado",
                table: "Consulta");

            migrationBuilder.AlterColumn<string>(
                name: "Sintoma",
                table: "Consulta",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "Consulta",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicoId",
                table: "Consulta",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Diagnostico",
                table: "Consulta",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConsultaSituacao",
                table: "Consulta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Medico_MedicoId",
                table: "Consulta",
                column: "MedicoId",
                principalTable: "Medico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Paciente_PacienteId",
                table: "Consulta",
                column: "PacienteId",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Medico_MedicoId",
                table: "Consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Paciente_PacienteId",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "ConsultaSituacao",
                table: "Consulta");

            migrationBuilder.AlterColumn<string>(
                name: "Sintoma",
                table: "Consulta",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "Consulta",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MedicoId",
                table: "Consulta",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Diagnostico",
                table: "Consulta",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "ConsultaEstado",
                table: "Consulta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Medico_MedicoId",
                table: "Consulta",
                column: "MedicoId",
                principalTable: "Medico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Paciente_PacienteId",
                table: "Consulta",
                column: "PacienteId",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
