using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AddShoppingCartsAndCartItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 1", "Направлений деятельности прежде начало.", "Свободный Бетонный Свитер", 358.60m });

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
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 1", "Однако участниками сфера структура количественный нас забывать работы.", "Невероятный Меховой Шарф", 627.97m, "Новинка" });

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
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Общественной а путь.", "Маленький Кожанный Автомобиль", 501.54m, "Новинка" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 2", "Ресурсосберегающих новых нас уточнения однако от кругу технологий по.", "Практичный Пластиковый Ботинок", 368.57m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 1", "Же модернизации формировании кадров всего модели высшего и.", "Фантастический Бетонный Компьютер", 118.55m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Вызывает нашей социально-ориентированный занимаемых не проблем сложившаяся образом значение материально-технической.", "Потрясающий Деревянный Берет", 501.52m, "Рекомендуемое" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Общественной дальнейших очевидна проект рамки.", "Интеллектуальный Хлопковый Компьютер", 476.35m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 1", "Современного проверки важные.", "Потрясающий Натуральный Свитер", 985.01m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 2", "Укрепления напрямую формировании сознания анализа изменений укрепления.", "Лоснящийся Бетонный Носки", 475.25m, "Новинка" });

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
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 1", "Представляет задач определения проверки следует участия новых общественной.", "Потрясающий Деревянный Носки", 264.93m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Равным высокотехнологичная активности принимаемых повышение важные эксперимент прогрессивного.", "Большой Резиновый Куртка", 259.08m, "Популярное" });

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
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 1", "Также принципов новых.", "Великолепный Натуральный Берет", 462.91m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 1", "Качественно концепция массового и создаёт обеспечение.", "Великолепный Меховой Кулон", 37.32m });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ShoppingCartId",
                table: "CartItems",
                column: "ShoppingCartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 2", "Повышение широким кадров.", "Фантастический Кожанный Куртка", 678.14m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Таким сущности соображения общества повседневной интересный оценить технологий административных реализация.", "Фантастический Хлопковый Шарф", 50.91m, "Популярное" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 2", "Профессионального технологий проблем принципов.", "Практичный Неодимовый Кепка", 712.33m, "Рекомендуемое" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 2", "Технологий обеспечивает за обеспечение за забывать соответствующих.", "Потрясающий Деревянный Ботинок", 643.25m, "Новинка" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Важные этих понимание работы занимаемых забывать курс.", "Потрясающий Пластиковый Ножницы", 667.35m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 1", "Формированию форм высшего.", "Маленький Пластиковый Портмоне", 239.93m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Деятельности мира модели оценить насущным способствует активом широкому за.", "Великолепный Кожанный Куртка", 729.57m, "Рекомендуемое" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 3", "Работы участниками определения социально-ориентированный.", "Эргономичный Гранитный Плащ", 846.64m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 3", "Анализа мира опыт нас соображения соответствующей активизации позиции различных правительством.", "Лоснящийся Неодимовый Ножницы", 884.92m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Технологий способствует для определения качества развития же высокотехнологичная формирования выполнять.", "Интеллектуальный Натуральный Плащ", 303.44m, "Новинка" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Нами выполнять стороны задача идейные участия соответствующей богатый работы.", "Потрясающий Пластиковый Стул", 595.52m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 2", "Социально-ориентированный прежде повышению актуальность значительной зависит оценить.", "Свободный Меховой Автомобиль", 628.81m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 3", "Системы принципов специалистов правительством процесс проект принимаемых повышение консультация уровня.", "Маленький Стальной Ножницы", 978.33m, "Популярное" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Category", "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Категория 2", "Также специалистов ресурсосберегающих проект.", "Эргономичный Меховой Компьютер", 169.66m, "Популярное" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 3", "С материально-технической обуславливает путь забывать демократической деятельности отношении.", "Интеллектуальный Бетонный Стул", 803.17m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Систему задания с.", "Практичный Пластиковый Компьютер", 793.19m, "Рекомендуемое" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 1", "Постоянный вызывает укрепления курс уточнения уровня.", "Фантастический Меховой Сабо", 522.63m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Description", "Name", "Price", "SpecialTag" },
                values: new object[] { "Укрепления оценить принимаемых формирования прогресса финансовых соответствующей нас.", "Невероятный Меховой Берет", 159.82m, "Рекомендуемое" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 2", "Прогресса внедрения занимаемых.", "Грубый Резиновый Носки", 745.57m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Category", "Description", "Name", "Price" },
                values: new object[] { "Категория 3", "Предложений демократической проект проверки условий правительством модели.", "Маленький Пластиковый Кошелек", 680.75m });
        }
    }
}
