using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoEscolar.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    id = table.Column<decimal>(nullable: false),
                    codigo = table.Column<string>(nullable: true),
                    nome = table.Column<string>(nullable: true),
                    morada = table.Column<string>(nullable: true),
                    telefone = table.Column<string>(nullable: true),
                    celular = table.Column<string>(nullable: true),
                    dataAniversario = table.Column<DateTime>(nullable: false),
                    localNascimento = table.Column<string>(nullable: true),
                    sexo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Anos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ano = table.Column<decimal>(nullable: true),
                    ESTADO = table.Column<int>(nullable: true),
                    INICIO = table.Column<DateTime>(nullable: true),
                    FIM = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nivel",
                columns: table => new
                {
                    codigo = table.Column<string>(maxLength: 20, nullable: false),
                    desc = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nivel", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "TabelaHorarios",
                columns: table => new
                {
                    ID = table.Column<decimal>(nullable: false),
                    Entrada = table.Column<string>(nullable: true),
                    Saida = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaHorarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Aluno_Efectividade",
                columns: table => new
                {
                    Id = table.Column<decimal>(nullable: false),
                    Mes = table.Column<int>(nullable: true),
                    Dia = table.Column<decimal>(nullable: true),
                    Presenca = table.Column<int>(nullable: true),
                    Objservacao = table.Column<string>(nullable: true),
                    Aluno_Id = table.Column<decimal>(nullable: true),
                    Classe_Id = table.Column<decimal>(nullable: true),
                    Ano_Id = table.Column<decimal>(nullable: true),
                    Anoid = table.Column<int>(nullable: true),
                    Alunoid = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno_Efectividade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aluno_Efectividade_Aluno_Alunoid",
                        column: x => x.Alunoid,
                        principalTable: "Aluno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aluno_Efectividade_Anos_Anoid",
                        column: x => x.Anoid,
                        principalTable: "Anos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classe",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    desc = table.Column<string>(maxLength: 20, nullable: true),
                    nivelCode = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classe", x => x.id);
                    table.ForeignKey(
                        name: "FK_Classe_Nivel_nivelCode",
                        column: x => x.nivelCode,
                        principalTable: "Nivel",
                        principalColumn: "codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnoLectivo",
                columns: table => new
                {
                    ID = table.Column<decimal>(nullable: false),
                    Ano_Id = table.Column<decimal>(nullable: true),
                    Classe_Id = table.Column<decimal>(nullable: true),
                    Anosid = table.Column<int>(nullable: true),
                    Classeid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnoLectivo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AnoLectivo_Anos_Anosid",
                        column: x => x.Anosid,
                        principalTable: "Anos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnoLectivo_Classe_Classeid",
                        column: x => x.Classeid,
                        principalTable: "Classe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Disciplina",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    desc = table.Column<string>(maxLength: 20, nullable: true),
                    classe_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplina", x => x.id);
                    table.ForeignKey(
                        name: "FK_Disciplina_Classe_classe_id",
                        column: x => x.classe_id,
                        principalTable: "Classe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    desc = table.Column<string>(maxLength: 20, nullable: true),
                    classeId = table.Column<int>(nullable: false),
                    AnoLectivoId = table.Column<int>(nullable: true),
                    HorarioId = table.Column<int>(nullable: true),
                    AnoLectivoID = table.Column<decimal>(nullable: true),
                    TabelaHorariosID = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Turmas_AnoLectivo_AnoLectivoID",
                        column: x => x.AnoLectivoID,
                        principalTable: "AnoLectivo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turmas_TabelaHorarios_TabelaHorariosID",
                        column: x => x.TabelaHorariosID,
                        principalTable: "TabelaHorarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turmas_Classe_classeId",
                        column: x => x.classeId,
                        principalTable: "Classe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoAnoLectivo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_Aluno = table.Column<decimal>(nullable: false),
                    Id_AnoLectivo = table.Column<decimal>(nullable: false),
                    Id_Turma = table.Column<decimal>(nullable: true),
                    AnoLectivoID = table.Column<decimal>(nullable: true),
                    Alunoid = table.Column<decimal>(nullable: true),
                    Turmasid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoAnoLectivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunoAnoLectivo_Aluno_Alunoid",
                        column: x => x.Alunoid,
                        principalTable: "Aluno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlunoAnoLectivo_AnoLectivo_AnoLectivoID",
                        column: x => x.AnoLectivoID,
                        principalTable: "AnoLectivo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlunoAnoLectivo_Turmas_Turmasid",
                        column: x => x.Turmasid,
                        principalTable: "Turmas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_Efectividade_Alunoid",
                table: "Aluno_Efectividade",
                column: "Alunoid");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_Efectividade_Anoid",
                table: "Aluno_Efectividade",
                column: "Anoid");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoAnoLectivo_Alunoid",
                table: "AlunoAnoLectivo",
                column: "Alunoid");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoAnoLectivo_AnoLectivoID",
                table: "AlunoAnoLectivo",
                column: "AnoLectivoID");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoAnoLectivo_Turmasid",
                table: "AlunoAnoLectivo",
                column: "Turmasid");

            migrationBuilder.CreateIndex(
                name: "IX_AnoLectivo_Anosid",
                table: "AnoLectivo",
                column: "Anosid");

            migrationBuilder.CreateIndex(
                name: "IX_AnoLectivo_Classeid",
                table: "AnoLectivo",
                column: "Classeid");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Classe_nivelCode",
                table: "Classe",
                column: "nivelCode");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_classe_id",
                table: "Disciplina",
                column: "classe_id");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_AnoLectivoID",
                table: "Turmas",
                column: "AnoLectivoID");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_TabelaHorariosID",
                table: "Turmas",
                column: "TabelaHorariosID");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_classeId",
                table: "Turmas",
                column: "classeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno_Efectividade");

            migrationBuilder.DropTable(
                name: "AlunoAnoLectivo");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Disciplina");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AnoLectivo");

            migrationBuilder.DropTable(
                name: "TabelaHorarios");

            migrationBuilder.DropTable(
                name: "Anos");

            migrationBuilder.DropTable(
                name: "Classe");

            migrationBuilder.DropTable(
                name: "Nivel");
        }
    }
}
