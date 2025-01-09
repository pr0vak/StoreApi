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
                    { 1, "Категория 1", "Порядка зависит повседневная рост представляет позиции поставленных мира нас.1", "https://dummyimage.com/100x100/fff/aaa", "Интеллектуальный Натуральный Компьютер1", 530.23m, "Популярные" },
                    { 2, "Категория 1", "Значимость прогресса стороны.1", "https://dummyimage.com/100x100/fff/aaa", "Практичный Бетонный Кошелек1", 651.03m, "Рекомендуемые" },
                    { 3, "Категория 2", "Общества системы соответствующей нашей соответствующей другой внедрения.1", "https://dummyimage.com/100x100/fff/aaa", "Интеллектуальный Кожанный Стол1", 641.40m, "Популярные" },
                    { 4, "Категория 2", "Подготовке способствует существующий высшего роль концепция и подготовке.1", "https://dummyimage.com/100x100/fff/aaa", "Грубый Натуральный Стул1", 132.88m, "Популярные" },
                    { 5, "Категория 1", "Систему процесс высокотехнологичная структура кадровой массового повышению структура работы.1", "https://dummyimage.com/100x100/fff/aaa", "Свободный Пластиковый Кошелек1", 274.37m, "Рекомендуемые" },
                    { 6, "Категория 1", "Насущным укрепления и намеченных предпосылки правительством место в широким и.1", "https://dummyimage.com/100x100/fff/aaa", "Невероятный Меховой Стол1", 465.71m, "Популярные" },
                    { 7, "Категория 1", "Шагов значение национальный.1", "https://dummyimage.com/100x100/fff/aaa", "Свободный Пластиковый Кепка1", 318.82m, "Рекомендуемые" },
                    { 8, "Категория 2", "Новых играет обеспечение играет правительством требует концепция участия требует.1", "https://dummyimage.com/100x100/fff/aaa", "Эргономичный Пластиковый Ботинок1", 379.19m, "Рекомендуемые" },
                    { 9, "Категория 3", "Образом задача проверки материально-технической предложений же.1", "https://dummyimage.com/100x100/fff/aaa", "Большой Натуральный Кошелек1", 199.82m, "Популярные" },
                    { 10, "Категория 3", "Национальный повышению модель участниками целесообразности.1", "https://dummyimage.com/100x100/fff/aaa", "Маленький Хлопковый Майка1", 482.21m, "Рекомендуемые" }
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
        }
    }
}
