using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlbertEinsteinTeste.Migrations
{
    public partial class RecriacaoDaBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConsultaSituacao",
                table: "Consulta",
                newName: "ConsultaSituacaoId");

            migrationBuilder.AddColumn<int>(
                name: "ConsultaSituacaoEnum",
                table: "Consulta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ConsultaSituacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DescricaoSituacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultaSituacao", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_ConsultaSituacaoId",
                table: "Consulta",
                column: "ConsultaSituacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_ConsultaSituacao_ConsultaSituacaoId",
                table: "Consulta",
                column: "ConsultaSituacaoId",
                principalTable: "ConsultaSituacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_ConsultaSituacao_ConsultaSituacaoId",
                table: "Consulta");

            migrationBuilder.DropTable(
                name: "ConsultaSituacao");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_ConsultaSituacaoId",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "ConsultaSituacaoEnum",
                table: "Consulta");

            migrationBuilder.RenameColumn(
                name: "ConsultaSituacaoId",
                table: "Consulta",
                newName: "ConsultaSituacao");
        }
    }
}
