using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlotteApplication.Migrations
{
    /// <inheritdoc />
    public partial class FlotteApplicationDataDataSource : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    adminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.adminId);
                });

            migrationBuilder.CreateTable(
                name: "Proprietaire",
                columns: table => new
                {
                    proId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    type = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietaire", x => x.proId);
                });

            migrationBuilder.CreateTable(
                name: "Engin",
                columns: table => new
                {
                    enginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    immatriculation = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    marque = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    couleur = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    categorie = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    ProprietaireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engin", x => x.enginId);
                    table.ForeignKey(
                        name: "FK_Engin_Proprietaire_ProprietaireId",
                        column: x => x.ProprietaireId,
                        principalTable: "Proprietaire",
                        principalColumn: "proId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facture",
                columns: table => new
                {
                    facId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateFacture = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "GETDATE()"),
                    montatTotal = table.Column<float>(type: "real", nullable: false),
                    engId = table.Column<int>(type: "int", nullable: false),
                    quotationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facture", x => x.facId);
                    table.ForeignKey(
                        name: "FK_Facture_Engin_engId",
                        column: x => x.engId,
                        principalTable: "Engin",
                        principalColumn: "enginId");
                });

            migrationBuilder.CreateTable(
                name: "Quotation",
                columns: table => new
                {
                    quoId = table.Column<int>(type: "int", nullable: false),
                    valeurDuVehicule = table.Column<float>(type: "real", nullable: false),
                    tarifDeBase = table.Column<float>(type: "real", nullable: false),
                    reduction = table.Column<float>(type: "real", nullable: false),
                    majoration = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotation", x => x.quoId);
                    table.ForeignKey(
                        name: "FK_Quotation_Facture_quoId",
                        column: x => x.quoId,
                        principalTable: "Facture",
                        principalColumn: "facId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_name",
                table: "Admin",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admin_password",
                table: "Admin",
                column: "password",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Engin_immatriculation",
                table: "Engin",
                column: "immatriculation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Engin_ProprietaireId",
                table: "Engin",
                column: "ProprietaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Facture_engId",
                table: "Facture",
                column: "engId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Quotation");

            migrationBuilder.DropTable(
                name: "Facture");

            migrationBuilder.DropTable(
                name: "Engin");

            migrationBuilder.DropTable(
                name: "Proprietaire");
        }
    }
}
