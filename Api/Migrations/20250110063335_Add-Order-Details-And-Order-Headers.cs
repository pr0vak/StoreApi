using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderDetailsAndOrderHeaders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderHeaders",
                columns: table => new
                {
                    OrderHeaderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    CustomerEmail = table.Column<string>(type: "text", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: true),
                    OrderTotalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    OrderDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    TotalCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeaders", x => x.OrderHeaderId);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderHeaderId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ItemName = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderHeaders_OrderHeaderId",
                        column: x => x.OrderHeaderId,
                        principalTable: "OrderHeaders",
                        principalColumn: "OrderHeaderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 1", "Массового соответствующей интересный значительной процесс показывает сомнений кадровой.", "Потрясающий Гранитный Портмоне", 997.18m, "Рекомендуемые" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 2", "Повседневной новая определения в эксперимент массового.", "Эргономичный Хлопковый Компьютер", 829.74m, "Рекомендуемые" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 3", "И выбранный активом другой принципов важную всего организации потребностям.", "Свободный Резиновый Кулон", 303.20m, "Рекомендуемые" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Процесс технологий сущности что.", "Практичный Резиновый Клатч", 751.05m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Анализа общества активом.", "Свободный Стальной Майка", 738.19m, "Популярные" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 1", "Не новых насущным занимаемых соответствующих играет.", "Эргономичный Хлопковый Портмоне", 610.88m, "Новинка" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 2", "Поставленных сложившаяся богатый.", "Свободный Гранитный Стул", 612.49m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Прежде отношении очевидна финансовых существующий широкому соображения массового условий.", "Лоснящийся Гранитный Майка", 999.46m, "Популярные" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 2", "Позиции обществом следует обеспечивает уточнения участия демократической от.", "Эргономичный Гранитный Сабо", 511.28m, "Новинка" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Таким обеспечение системы модели повышение не вызывает проверки проект.", "Грубый Гранитный Майка", 774.65m, "Новинка" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderHeaderId",
                table: "OrderDetails",
                column: "OrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_AppUserId",
                table: "OrderHeaders",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrderHeaders");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 2", "Таким эксперимент прогресса качественно следует.", "Грубый Натуральный Свитер", 412.79m, "Новинка" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 3", "Создание эксперимент всего уровня проблем системы концепция нашей намеченных практика.", "Свободный Хлопковый Автомобиль", 565.76m, "Популярные" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 1", "Участия условий разнообразный.", "Лоснящийся Кожанный Портмоне", 471.09m, "Новинка" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Кругу собой структуры внедрения.", "Эргономичный Деревянный Стол", 904.45m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Изменений кругу же всего социально-экономическое организации модели.", "Практичный Натуральный Автомобиль", 907.23m, "Рекомендуемые" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 2", "Количественный формирования важные материально-технической не поставленных направлений таким вызывает.", "Большой Стальной Ботинок", 229.91m, "Рекомендуемые" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 3", "Актуальность условий массового в создание выполнять.", "Фантастический Меховой Носки", 600.66m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Для эксперимент за новая качественно анализа направлений по повседневная работы.", "Потрясающий Пластиковый Берет", 498.51m, "Рекомендуемые" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 3", "Существующий что важную влечёт потребностям сфера.", "Невероятный Гранитный Плащ", 315.29m, "Популярные" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Новая массового различных отношении создаёт ресурсосберегающих играет постоянный формировании.", "Маленький Хлопковый Плащ", 674.34m, "Популярные" });
        }
    }
}
