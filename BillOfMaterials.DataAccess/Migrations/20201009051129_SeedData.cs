using Microsoft.EntityFrameworkCore.Migrations;

namespace BillOfMaterials.DataAccess.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // adds sample to database
            migrationBuilder
              .Sql("INSERT [Products] ([Name]) VALUES (N'Vasıta')");

            migrationBuilder
                .Sql("INSERT [Categories]  ([Name], [ParentId], [ProductId]) VALUES (N'Araba', 0, 1)");
            migrationBuilder
                .Sql("INSERT [Categories]  ([Name], [ParentId], [ProductId]) VALUES (N'Suv', 1, NULL)");
            migrationBuilder
                .Sql("INSERT [Categories]  ([Name], [ParentId], [ProductId]) VALUES (N'Ticari', 1, NULL)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
               .Sql("DELETE FROM [Categories];");

            migrationBuilder
               .Sql("DBCC CHECKIDENT('[Categories]', RESEED, 0);"); // resets table identity 

            migrationBuilder
               .Sql("DELETE FROM [Products]");

            migrationBuilder
               .Sql("DBCC CHECKIDENT('[Products]', RESEED, 0);");  // resets table identity
        }
    }
}
