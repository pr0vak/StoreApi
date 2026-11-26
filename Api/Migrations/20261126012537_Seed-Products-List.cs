using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductsList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Image", "Name", "Price", "SpecialTag" },
                values: new object[,]
                {
                    { 1, "Категория 2", "За прогрессивного место современного различных забывать этих.", "https://devtool.tech/api/placeholder/200/200", "Лоснящийся Гранитный Кулон", 412.09m, "Рекомендуемый" },
                    { 2, "Категория 1", "Проверки правительством сомнений задания задания выполнять.", "https://devtool.tech/api/placeholder/200/200", "Большой Меховой Ножницы", 97.85m, "Популярный" },
                    { 3, "Категория 3", "Управление принципов процесс.", "https://devtool.tech/api/placeholder/200/200", "Потрясающий Неодимовый Ботинок", 764.03m, "Популярный" },
                    { 4, "Категория 1", "Работы порядка влечёт социально-экономическое значительной социально-ориентированный.", "https://devtool.tech/api/placeholder/200/200", "Великолепный Резиновый Ботинок", 801.10m, "Новинка" },
                    { 5, "Категория 2", "Роль забывать административных способствует зависит высокотехнологичная.", "https://devtool.tech/api/placeholder/200/200", "Практичный Пластиковый Сабо", 165.58m, "Популярный" },
                    { 6, "Категория 1", "По стороны а повышению также не.", "https://devtool.tech/api/placeholder/200/200", "Маленький Пластиковый Кулон", 887.99m, "Новинка" },
                    { 7, "Категория 1", "Особенности путь внедрения развития систему влечёт путь требует внедрения модели.", "https://devtool.tech/api/placeholder/200/200", "Фантастический Резиновый Свитер", 867.16m, "Рекомендуемый" },
                    { 8, "Категория 2", "Формированию прежде принципов.", "https://devtool.tech/api/placeholder/200/200", "Невероятный Неодимовый Компьютер", 847.01m, "Рекомендуемый" },
                    { 9, "Категория 2", "Качественно качества место нашей поэтапного качества роль консультация высокотехнологичная.", "https://devtool.tech/api/placeholder/200/200", "Практичный Пластиковый Кулон", 564.86m, "Рекомендуемый" },
                    { 10, "Категория 2", "Принимаемых рост социально-ориентированный системы модели обеспечение проблем интересный повседневной нами.", "https://devtool.tech/api/placeholder/200/200", "Эргономичный Меховой Берет", 473.53m, "Новинка" },
                    { 11, "Категория 2", "Выбранный общества общества актуальность высокотехнологичная в вызывает проблем насущным.", "https://devtool.tech/api/placeholder/200/200", "Потрясающий Кожанный Ножницы", 158.28m, "Новинка" },
                    { 12, "Категория 3", "Инновационный идейные формировании организационной.", "https://devtool.tech/api/placeholder/200/200", "Лоснящийся Гранитный Свитер", 833.66m, "Рекомендуемый" },
                    { 13, "Категория 1", "Нами забывать прежде уточнения.", "https://devtool.tech/api/placeholder/200/200", "Практичный Меховой Компьютер", 108.46m, "Новинка" },
                    { 14, "Категория 2", "Кадров важную роль.", "https://devtool.tech/api/placeholder/200/200", "Большой Неодимовый Майка", 878.40m, "Рекомендуемый" },
                    { 15, "Категория 3", "Различных в способствует количественный понимание прогресса гражданского предложений выбранный начало.", "https://devtool.tech/api/placeholder/200/200", "Интеллектуальный Гранитный Майка", 484.54m, "Новинка" },
                    { 16, "Категория 3", "Различных изменений социально-экономическое задача прогресса гражданского разнообразный а создаёт повышению.", "https://devtool.tech/api/placeholder/200/200", "Фантастический Резиновый Берет", 834.48m, "Новинка" },
                    { 17, "Категория 3", "Путь принципов повышение инновационный концепция выполнять по вызывает плановых.", "https://devtool.tech/api/placeholder/200/200", "Большой Гранитный Свитер", 832.45m, "Популярный" },
                    { 18, "Категория 3", "Настолько структура за гражданского в широким шагов.", "https://devtool.tech/api/placeholder/200/200", "Невероятный Стальной Клатч", 678.33m, "Рекомендуемый" },
                    { 19, "Категория 3", "Соответствующих общественной высшего зависит оценить следует общественной формировании.", "https://devtool.tech/api/placeholder/200/200", "Маленький Гранитный Кошелек", 810.04m, "Рекомендуемый" },
                    { 20, "Категория 1", "Поставленных внедрения формировании повышению.", "https://devtool.tech/api/placeholder/200/200", "Потрясающий Хлопковый Плащ", 901.33m, "Рекомендуемый" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
