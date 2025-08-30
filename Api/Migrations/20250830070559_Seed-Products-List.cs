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
                    { 1, "Категория 2", "Повышение широким кадров.", "https://placehold.co/200x150", "Фантастический Кожанный Куртка", 678.14m, "Рекомендуемое" },
                    { 2, "Категория 1", "Таким сущности соображения общества повседневной интересный оценить технологий административных реализация.", "https://placehold.co/200x150", "Фантастический Хлопковый Шарф", 50.91m, "Популярное" },
                    { 3, "Категория 2", "Профессионального технологий проблем принципов.", "https://placehold.co/200x150", "Практичный Неодимовый Кепка", 712.33m, "Рекомендуемое" },
                    { 4, "Категория 2", "Технологий обеспечивает за обеспечение за забывать соответствующих.", "https://placehold.co/200x150", "Потрясающий Деревянный Ботинок", 643.25m, "Новинка" },
                    { 5, "Категория 3", "Важные этих понимание работы занимаемых забывать курс.", "https://placehold.co/200x150", "Потрясающий Пластиковый Ножницы", 667.35m, "Новинка" },
                    { 6, "Категория 1", "Формированию форм высшего.", "https://placehold.co/200x150", "Маленький Пластиковый Портмоне", 239.93m, "Рекомендуемое" },
                    { 7, "Категория 2", "Деятельности мира модели оценить насущным способствует активом широкому за.", "https://placehold.co/200x150", "Великолепный Кожанный Куртка", 729.57m, "Рекомендуемое" },
                    { 8, "Категория 3", "Работы участниками определения социально-ориентированный.", "https://placehold.co/200x150", "Эргономичный Гранитный Плащ", 846.64m, "Популярное" },
                    { 9, "Категория 3", "Анализа мира опыт нас соображения соответствующей активизации позиции различных правительством.", "https://placehold.co/200x150", "Лоснящийся Неодимовый Ножницы", 884.92m, "Рекомендуемое" },
                    { 10, "Категория 2", "Технологий способствует для определения качества развития же высокотехнологичная формирования выполнять.", "https://placehold.co/200x150", "Интеллектуальный Натуральный Плащ", 303.44m, "Новинка" },
                    { 11, "Категория 3", "Нами выполнять стороны задача идейные участия соответствующей богатый работы.", "https://placehold.co/200x150", "Потрясающий Пластиковый Стул", 595.52m, "Популярное" },
                    { 12, "Категория 2", "Социально-ориентированный прежде повышению актуальность значительной зависит оценить.", "https://placehold.co/200x150", "Свободный Меховой Автомобиль", 628.81m, "Новинка" },
                    { 13, "Категория 3", "Системы принципов специалистов правительством процесс проект принимаемых повышение консультация уровня.", "https://placehold.co/200x150", "Маленький Стальной Ножницы", 978.33m, "Популярное" },
                    { 14, "Категория 2", "Также специалистов ресурсосберегающих проект.", "https://placehold.co/200x150", "Эргономичный Меховой Компьютер", 169.66m, "Популярное" },
                    { 15, "Категория 3", "С материально-технической обуславливает путь забывать демократической деятельности отношении.", "https://placehold.co/200x150", "Интеллектуальный Бетонный Стул", 803.17m, "Новинка" },
                    { 16, "Категория 2", "Систему задания с.", "https://placehold.co/200x150", "Практичный Пластиковый Компьютер", 793.19m, "Рекомендуемое" },
                    { 17, "Категория 1", "Постоянный вызывает укрепления курс уточнения уровня.", "https://placehold.co/200x150", "Фантастический Меховой Сабо", 522.63m, "Рекомендуемое" },
                    { 18, "Категория 3", "Укрепления оценить принимаемых формирования прогресса финансовых соответствующей нас.", "https://placehold.co/200x150", "Невероятный Меховой Берет", 159.82m, "Рекомендуемое" },
                    { 19, "Категория 2", "Прогресса внедрения занимаемых.", "https://placehold.co/200x150", "Грубый Резиновый Носки", 745.57m, "Рекомендуемое" },
                    { 20, "Категория 3", "Предложений демократической проект проверки условий правительством модели.", "https://placehold.co/200x150", "Маленький Пластиковый Кошелек", 680.75m, "Рекомендуемое" }
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
