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
                values: new object[] { "Категория 3", "Постоянный понимание прогрессивного обучения изменений разработке реализация.", "Лоснящийся Гранитный Ножницы", 54.23m, "Популярное" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Поставленных понимание организационной.", "Фантастический Гранитный Стол", 857.07m, "Популярное" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Участниками выполнять шагов модель определения экономической прогресса.", "Практичный Хлопковый Кошелек", 744.02m, "Рекомендуемое" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 1", "Однако определения с.", "Потрясающий Меховой Кулон", 868.48m, "Новинка" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Деятельности разнообразный материально-технической.", "Интеллектуальный Хлопковый Майка", 443.26m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 1", "Последовательного создание соображения образом проблем воздействия активизации задача воздействия равным.", "Практичный Резиновый Кепка", 42.82m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 1", "Количественный курс участия формированию значительной рост формировании.", "Невероятный Стальной Свитер", 275.63m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 3", "Разнообразный что значительной сущности забывать новая процесс оценить нас по.", "Большой Пластиковый Стол", 276.31m, "Новинка" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Инновационный демократической задача значимость значимость условий кадровой.", "Маленький Пластиковый Шарф", 640.75m, "Популярное" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 3", "Насущным а модели общества влечёт.", "Великолепный Кожанный Кепка", 262.44m, "Новинка" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 2", "Национальный направлений модели.", "Фантастический Гранитный Ножницы", 594.50m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Условий требует материально-технической поставленных мира роль также участниками количественный.", "Лоснящийся Бетонный Компьютер", 979.28m, "Рекомендуемое" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Стороны материально-технической этих различных важную форм активом.", "Фантастический Гранитный Свитер", 346.00m, "Популярное" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 1", "Различных подготовке целесообразности формирования рамки технологий настолько кадровой структура проект.", "Эргономичный Бетонный Ножницы", 767.89m, "Популярное" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 2", "Существующий прогресса прогресса.", "Потрясающий Гранитный Берет", 402.42m, "Популярное" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 1", "Актуальность значительной организационной для высшего повышение.", "Невероятный Кожанный Ножницы", 25.78m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 1", "Намеченных соответствующей информационно-пропогандистское роль массового проблем очевидна степени.", "Эргономичный Резиновый Кулон", 988.29m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Не концепция настолько.", "Великолепный Неодимовый Кошелек", 528.61m, "Рекомендуемое" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 2", "Нами задания социально-экономическое выполнять.", "Большой Меховой Портмоне", 53.91m, "Популярное" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 3", "Проект принимаемых существующий концепция играет.", "Свободный Хлопковый Компьютер", 245.76m, "Новинка" });

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
                values: new object[] { "Категория 1", "Направлений деятельности прежде начало.", "Свободный Бетонный Свитер", 358.60m, "Рекомендуемое" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Богатый значение с выбранный.", "Фантастический Кожанный Стул", 249.42m, "Новинка" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Однако участниками сфера структура количественный нас забывать работы.", "Невероятный Меховой Шарф", 627.97m, "Новинка" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 3", "Оценить существующий напрямую.", "Большой Стальной Майка", 114.49m, "Популярное" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Обеспечивает однако постоянный интересный прогресса общественной сомнений.", "Великолепный Меховой Клатч", 312.02m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 2", "Кадровой влечёт разнообразный предложений значительной задача целесообразности.", "Невероятный Бетонный Куртка", 994.88m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 2", "Общественной а путь.", "Маленький Кожанный Автомобиль", 501.54m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 2", "Ресурсосберегающих новых нас уточнения однако от кругу технологий по.", "Практичный Пластиковый Ботинок", 368.57m, "Популярное" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Же модернизации формировании кадров всего модели высшего и.", "Фантастический Бетонный Компьютер", 118.55m, "Рекомендуемое" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 2", "Вызывает нашей социально-ориентированный занимаемых не проблем сложившаяся образом значение материально-технической.", "Потрясающий Деревянный Берет", 501.52m, "Рекомендуемое" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 3", "Общественной дальнейших очевидна проект рамки.", "Интеллектуальный Хлопковый Компьютер", 476.35m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Современного проверки важные.", "Потрясающий Натуральный Свитер", 985.01m, "Новинка" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Укрепления напрямую формировании сознания анализа изменений укрепления.", "Лоснящийся Бетонный Носки", 475.25m, "Новинка" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 3", "Информационно-пропогандистское процесс процесс особенности плановых обеспечение.", "Большой Резиновый Кепка", 157.84m, "Рекомендуемое" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 1", "Представляет задач определения проверки следует участия новых общественной.", "Потрясающий Деревянный Носки", 264.93m, "Новинка" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 2", "Равным высокотехнологичная активности принимаемых повышение важные эксперимент прогрессивного.", "Большой Резиновый Куртка", 259.08m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 2", "Позволяет собой обеспечение формировании создание.", "Грубый Стальной Компьютер", 15.16m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Позиции определения позиции понимание представляет.", "Свободный Неодимовый Компьютер", 914.69m, "Популярное" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 1", "Также принципов новых.", "Великолепный Натуральный Берет", 462.91m, "Рекомендуемое" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 1", "Качественно концепция массового и создаёт обеспечение.", "Великолепный Меховой Кулон", 37.32m, "Рекомендуемое" });
        }
    }
}
