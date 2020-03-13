using Microsoft.EntityFrameworkCore.Migrations;

namespace AlbertEinsteinTeste.Migrations
{
    public partial class DelecaoDeCampoEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsultaSituacaoEnum",
                table: "Consulta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsultaSituacaoEnum",
                table: "Consulta",
                nullable: false,
                defaultValue: 0);
        }
    }
}
