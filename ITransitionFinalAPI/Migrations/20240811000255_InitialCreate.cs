using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITransitionFinalAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserCollectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSigned = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCollectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSigned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomInt1 = table.Column<int>(type: "int", nullable: true),
                    CustomInt2 = table.Column<int>(type: "int", nullable: true),
                    CustomInt3 = table.Column<int>(type: "int", nullable: true),
                    CustomString1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomString2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomString3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomMultilineText1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomMultilineText2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomMultilineText3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomBoolean1 = table.Column<bool>(type: "bit", nullable: true),
                    CustomBoolean2 = table.Column<bool>(type: "bit", nullable: true),
                    CustomBoolean3 = table.Column<bool>(type: "bit", nullable: true),
                    CustomDate1 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomDate2 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomDate3 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserCollectorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collections_UserCollectors_UserCollectorId",
                        column: x => x.UserCollectorId,
                        principalTable: "UserCollectors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CollectionTag",
                columns: table => new
                {
                    CollectionsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionTag", x => new { x.CollectionsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_CollectionTag_Collections_CollectionsId",
                        column: x => x.CollectionsId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentsInCollections",
                columns: table => new
                {
                    IdCollection = table.Column<int>(type: "int", nullable: false),
                    IdComment = table.Column<int>(type: "int", nullable: false),
                    IdCollectorUser = table.Column<int>(type: "int", nullable: false),
                    UserCollectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentsInCollections", x => new { x.IdCollection, x.IdComment });
                    table.ForeignKey(
                        name: "FK_CommentsInCollections_Collections_IdCollection",
                        column: x => x.IdCollection,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentsInCollections_Comments_IdComment",
                        column: x => x.IdComment,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentsInCollections_UserCollectors_UserCollectorId",
                        column: x => x.UserCollectorId,
                        principalTable: "UserCollectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemsCollections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSigned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsCollections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemsCollections_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LikedCollections",
                columns: table => new
                {
                    IdCollection = table.Column<int>(type: "int", nullable: false),
                    IdUserCollector = table.Column<int>(type: "int", nullable: false),
                    DateRegistred = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedCollections", x => new { x.IdCollection, x.IdUserCollector });
                    table.ForeignKey(
                        name: "FK_LikedCollections_Collections_IdCollection",
                        column: x => x.IdCollection,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikedCollections_UserCollectors_IdUserCollector",
                        column: x => x.IdUserCollector,
                        principalTable: "UserCollectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collections_UserCollectorId",
                table: "Collections",
                column: "UserCollectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionTag_TagsId",
                table: "CollectionTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsInCollections_IdComment",
                table: "CommentsInCollections",
                column: "IdComment");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsInCollections_UserCollectorId",
                table: "CommentsInCollections",
                column: "UserCollectorId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsCollections_CollectionId",
                table: "ItemsCollections",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_LikedCollections_IdUserCollector",
                table: "LikedCollections",
                column: "IdUserCollector");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionTag");

            migrationBuilder.DropTable(
                name: "CommentsInCollections");

            migrationBuilder.DropTable(
                name: "ItemsCollections");

            migrationBuilder.DropTable(
                name: "LikedCollections");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "UserCollectors");
        }
    }
}
