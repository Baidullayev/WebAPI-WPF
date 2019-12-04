using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotesApi.Migrations
{
    public partial class AddingTrashedDateOfNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TrashedDate",
                table: "NoteList",
                nullable: true,
                defaultValue: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrashedDate",
                table: "NoteList");
        }
    }
}
