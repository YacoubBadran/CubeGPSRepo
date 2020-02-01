using Microsoft.EntityFrameworkCore.Migrations;

namespace CubeGPS.Repository.Migrations
{
    public partial class InitializeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShapeType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShapeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shape",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shape", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shape_ShapeType",
                        column: x => x.TypeId,
                        principalTable: "ShapeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Circle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShapeId = table.Column<int>(nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(11, 8)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(10, 8)", nullable: false),
                    Radius = table.Column<decimal>(type: "decimal(11, 8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Circle_Shape",
                        column: x => x.ShapeId,
                        principalTable: "Shape",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IrregularShape",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShapeId = table.Column<int>(nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(11, 8)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(10, 8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IrregularShape", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IrregularShape_Shape",
                        column: x => x.ShapeId,
                        principalTable: "Shape",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rectangle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShapeId = table.Column<int>(nullable: false),
                    Longitude1 = table.Column<decimal>(type: "decimal(11, 8)", nullable: false),
                    Latitude1 = table.Column<decimal>(type: "decimal(10, 8)", nullable: false),
                    Longitude2 = table.Column<decimal>(type: "decimal(11, 8)", nullable: false),
                    Latitude2 = table.Column<decimal>(type: "decimal(10, 8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rectangle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rectangle_Shape",
                        column: x => x.ShapeId,
                        principalTable: "Shape",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Circle_ShapeId",
                table: "Circle",
                column: "ShapeId");

            migrationBuilder.CreateIndex(
                name: "IX_IrregularShape_ShapeId",
                table: "IrregularShape",
                column: "ShapeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rectangle_ShapeId",
                table: "Rectangle",
                column: "ShapeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shape_TypeId",
                table: "Shape",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Circle");

            migrationBuilder.DropTable(
                name: "IrregularShape");

            migrationBuilder.DropTable(
                name: "Rectangle");

            migrationBuilder.DropTable(
                name: "Shape");

            migrationBuilder.DropTable(
                name: "ShapeType");
        }
    }
}
