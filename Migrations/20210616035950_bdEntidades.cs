using Microsoft.EntityFrameworkCore.Migrations;

namespace Evaluacion.Migrations
{
    public partial class bdEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(255)", nullable: true),
                    observacion = table.Column<string>(type: "varchar(500)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "marca",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(255)", nullable: true),
                    observacion = table.Column<string>(type: "varchar(500)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "proveedor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo_identificacion = table.Column<string>(type: "varchar(1)", nullable: false),
                    identificacion = table.Column<string>(type: "varchar(255)", nullable: true),
                    nombre = table.Column<string>(type: "varchar(255)", nullable: true),
                    direccion = table.Column<string>(type: "varchar(500)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    telefono = table.Column<string>(type: "varchar(255)", nullable: true),
                    correo = table.Column<string>(type: "varchar(255)", nullable: true),
                    observacion = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proveedor_id = table.Column<int>(type: "int", nullable: false),
                    categoria_id = table.Column<int>(type: "int", nullable: false),
                    marca_id = table.Column<int>(type: "int", nullable: false),
                    codigo_barras = table.Column<string>(type: "varchar(255)", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(255)", nullable: false),
                    medidas = table.Column<string>(type: "varchar(255)", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    stock = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.id);
                    table.ForeignKey(
                        name: "fk_producto_Categoria",
                        column: x => x.categoria_id,
                        principalTable: "categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_producto_Marca",
                        column: x => x.marca_id,
                        principalTable: "marca",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_producto_proveedor",
                        column: x => x.proveedor_id,
                        principalTable: "proveedor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "historico",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    producto_id = table.Column<int>(type: "int", nullable: false),
                    accion = table.Column<string>(type: "varchar(255)", nullable: true),
                    valor_anterior = table.Column<string>(type: "varchar(1000)", nullable: true),
                    valor_nuevo = table.Column<string>(type: "varchar(1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historico", x => x.id);
                    table.ForeignKey(
                        name: "fk_historico_producto",
                        column: x => x.producto_id,
                        principalTable: "producto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "fk_historico_producto",
                table: "historico",
                column: "producto_id");

            migrationBuilder.CreateIndex(
                name: "fk_producto_categoria",
                table: "producto",
                column: "categoria_id");

            migrationBuilder.CreateIndex(
                name: "fk_producto_marca",
                table: "producto",
                column: "marca_id");

            migrationBuilder.CreateIndex(
                name: "fk_producto_proveedor",
                table: "producto",
                column: "proveedor_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historico");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "categoria");

            migrationBuilder.DropTable(
                name: "marca");

            migrationBuilder.DropTable(
                name: "proveedor");
        }
    }
}
