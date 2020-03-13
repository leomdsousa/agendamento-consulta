using Microsoft.EntityFrameworkCore.Migrations;

namespace AlbertEinsteinTeste.Migrations
{
    public partial class RecriacaoDaBase_AjusteCampoNaoObrigatorio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Diagnostico",
                table: "Consulta",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Diagnostico",
                table: "Consulta",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
