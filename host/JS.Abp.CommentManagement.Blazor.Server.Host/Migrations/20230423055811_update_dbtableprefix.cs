using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JS.Abp.CommentManagement.Blazor.Server.Host.Migrations
{
    /// <inheritdoc />
    public partial class updatedbtableprefix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentManagementComments",
                table: "CommentManagementComments");

            migrationBuilder.RenameTable(
                name: "CommentManagementComments",
                newName: "AbpComments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbpComments",
                table: "AbpComments",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AbpComments",
                table: "AbpComments");

            migrationBuilder.RenameTable(
                name: "AbpComments",
                newName: "CommentManagementComments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentManagementComments",
                table: "CommentManagementComments",
                column: "Id");
        }
    }
}
