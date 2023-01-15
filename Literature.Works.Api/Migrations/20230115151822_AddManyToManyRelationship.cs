using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Literature.Works.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddManyToManyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Works_WorkId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_WorkId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "WorkId",
                table: "Genres");

            migrationBuilder.CreateTable(
                name: "GenreWork",
                columns: table => new
                {
                    GenresId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorksId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreWork", x => new { x.GenresId, x.WorksId });
                    table.ForeignKey(
                        name: "FK_GenreWork_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreWork_Works_WorksId",
                        column: x => x.WorksId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreWork_WorksId",
                table: "GenreWork",
                column: "WorksId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreWork");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkId",
                table: "Genres",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_WorkId",
                table: "Genres",
                column: "WorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Works_WorkId",
                table: "Genres",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "Id");
        }
    }
}
