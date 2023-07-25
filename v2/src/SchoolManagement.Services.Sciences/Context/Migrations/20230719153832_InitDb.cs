using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Services.Sciences.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sciences",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    title = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sciences", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "topics",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    title = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    content = table.Column<string>(type: "text", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    science_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_topics", x => x.id);
                    table.ForeignKey(
                        name: "fk_topics_sciences_science_id",
                        column: x => x.science_id,
                        principalTable: "sciences",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "topic_tasks",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    content = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    topic_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_topic_tasks", x => x.id);
                    table.ForeignKey(
                        name: "fk_topic_tasks_topics_topic_id",
                        column: x => x.topic_id,
                        principalTable: "topics",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_sciences_name",
                table: "sciences",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_topic_tasks_topic_id",
                table: "topic_tasks",
                column: "topic_id");

            migrationBuilder.CreateIndex(
                name: "ix_topics_name",
                table: "topics",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_topics_science_id",
                table: "topics",
                column: "science_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "topic_tasks");

            migrationBuilder.DropTable(
                name: "topics");

            migrationBuilder.DropTable(
                name: "sciences");
        }
    }
}
