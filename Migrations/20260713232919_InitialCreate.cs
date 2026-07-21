using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIwebPET.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Passageiros",
                columns: table => new
                {
                    IdPassagem = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoViagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinoViagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaParceira = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraDecolagem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passageiros", x => x.IdPassagem);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passageiros");
        }
    }
}
