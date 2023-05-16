using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mahasiswa",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nama = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    alamat = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    umur = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mahasiswa", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "mahasiswa",
                columns: new[] { "id", "alamat", "created_date", "is_active", "nama", "umur", "updated_date" },
                values: new object[,]
                {
                    { 1, "Dago - Bandung", new DateTime(2023, 5, 16, 2, 27, 22, 572, DateTimeKind.Utc).AddTicks(8742), true, "Arya Santoso", 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Nginden - Surabaya", new DateTime(2023, 5, 16, 2, 27, 22, 572, DateTimeKind.Utc).AddTicks(8750), true, "Astrid Ardia", 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Cicaheum - Bandung", new DateTime(2023, 5, 16, 2, 27, 22, 572, DateTimeKind.Utc).AddTicks(8752), true, "Budi Arga", 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Menteng - Jakarta", new DateTime(2023, 5, 16, 2, 27, 22, 572, DateTimeKind.Utc).AddTicks(8754), true, "Dini Andari", 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Merdeka - Malang", new DateTime(2023, 5, 16, 2, 27, 22, 572, DateTimeKind.Utc).AddTicks(8757), true, "Dwi Ciska", 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Dago - Bandung", new DateTime(2023, 5, 16, 2, 27, 22, 572, DateTimeKind.Utc).AddTicks(8759), true, "Edi Prastowo", 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Setiabudi - Bandung", new DateTime(2023, 5, 16, 2, 27, 22, 572, DateTimeKind.Utc).AddTicks(8761), true, "Eka Sapta", 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Mande - Mataram", new DateTime(2023, 5, 16, 2, 27, 22, 572, DateTimeKind.Utc).AddTicks(8763), true, "Fifin Aliana ", 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Perak - Surabaya", new DateTime(2023, 5, 16, 2, 27, 22, 572, DateTimeKind.Utc).AddTicks(8765), true, "Giri Rekso", 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Antapani - Bandung", new DateTime(2023, 5, 16, 2, 27, 22, 572, DateTimeKind.Utc).AddTicks(8767), true, "Heri Ahmad Surya", 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mahasiswa");
        }
    }
}
