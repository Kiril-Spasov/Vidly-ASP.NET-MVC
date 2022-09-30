using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Data.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9a3e2fbe-8203-4b54-b12b-951264c8b84b', N'guest@vidly.com', N'GUEST@VIDLY.COM', N'guest@vidly.com', N'GUEST@VIDLY.COM', 1, N'AQAAAAEAACcQAAAAEPE4nSFzzWdZZskhT074aUnxpbIUVOeRxqdQV9s9LPzpGh3jMNU4Z9vo8qMlpobfnA==', N'3HUGOG57U6SDQARXCAXDE65CY6E6X3F2', N'd6d58e60-ae25-4a8d-90c5-5c2970e41a65', NULL, 0, 0, NULL, 1, 0)" +
                "INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'e2dab2ce-50d0-4a43-a8dc-2a94eb8f9833', N'admin@vidly.com', N'ADMIN@VIDLY.COM', N'admin@vidly.com', N'ADMIN@VIDLY.COM', 1, N'AQAAAAEAACcQAAAAELwPJXpsyP4S4+b/itWrYNSbjTI+iE3JlRxMlZZvzVGtlqdijZnD+McNt2infqZbrA==', N'NKLDR2Y6DWXX2RRLEPITQZ4W6WUO64YB', N'b168eed0-fc8c-4724-abb1-0d731a746c1b', NULL, 0, 0, NULL, 1, 0)" +
                "INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'216b6f25-22cd-489c-9371-289cf8422195', N'CanManageMovie', N'CANMANAGEMOVIE', N'455d9649-8593-4170-896c-879f407f8e03')" +
                "INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e2dab2ce-50d0-4a43-a8dc-2a94eb8f9833', N'216b6f25-22cd-489c-9371-289cf8422195')"   
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
