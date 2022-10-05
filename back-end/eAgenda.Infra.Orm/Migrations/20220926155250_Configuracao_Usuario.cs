using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace eAgenda.Infra.Orm.Migrations
{
    public partial class Configuracao_Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "TBTarefa",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "TBDespesa",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "TBContato",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "TBCompromisso",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "TBCategoria",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TBTarefa_UsuarioId",
                table: "TBTarefa",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TBDespesa_UsuarioId",
                table: "TBDespesa",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TBContato_UsuarioId",
                table: "TBContato",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TBCompromisso_UsuarioId",
                table: "TBCompromisso",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TBCategoria_UsuarioId",
                table: "TBCategoria",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBCategoria_AspNetUsers_UsuarioId",
                table: "TBCategoria",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBCompromisso_AspNetUsers_UsuarioId",
                table: "TBCompromisso",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBContato_AspNetUsers_UsuarioId",
                table: "TBContato",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBDespesa_AspNetUsers_UsuarioId",
                table: "TBDespesa",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBTarefa_AspNetUsers_UsuarioId",
                table: "TBTarefa",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBCategoria_AspNetUsers_UsuarioId",
                table: "TBCategoria");

            migrationBuilder.DropForeignKey(
                name: "FK_TBCompromisso_AspNetUsers_UsuarioId",
                table: "TBCompromisso");

            migrationBuilder.DropForeignKey(
                name: "FK_TBContato_AspNetUsers_UsuarioId",
                table: "TBContato");

            migrationBuilder.DropForeignKey(
                name: "FK_TBDespesa_AspNetUsers_UsuarioId",
                table: "TBDespesa");

            migrationBuilder.DropForeignKey(
                name: "FK_TBTarefa_AspNetUsers_UsuarioId",
                table: "TBTarefa");

            migrationBuilder.DropIndex(
                name: "IX_TBTarefa_UsuarioId",
                table: "TBTarefa");

            migrationBuilder.DropIndex(
                name: "IX_TBDespesa_UsuarioId",
                table: "TBDespesa");

            migrationBuilder.DropIndex(
                name: "IX_TBContato_UsuarioId",
                table: "TBContato");

            migrationBuilder.DropIndex(
                name: "IX_TBCompromisso_UsuarioId",
                table: "TBCompromisso");

            migrationBuilder.DropIndex(
                name: "IX_TBCategoria_UsuarioId",
                table: "TBCategoria");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TBTarefa");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TBDespesa");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TBContato");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TBCompromisso");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TBCategoria");
        }
    }
}
