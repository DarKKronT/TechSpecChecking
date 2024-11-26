using System.Text;
using TechSpecChecking.Files.Readers;
using Files.Sections.Creators;
using TechSpecChecking.Text.Testers;

namespace TechSpecChecking
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;

            //var filePath = "D:\\KPI\\3\\sem 1\\COURSEWORK\\Docs\\TestDocs\\КП-21 Антонов Євгеній ТЗ на перевірку.pdf";
            //var filePath = "D:\\KPI\\3\\sem 1\\COURSEWORK\\Docs\\TestDocs\\ТЗ шаблон.docx";
            //var filePath = "D:\\KPI\\3\\sem 1\\COURSEWORK\\Docs\\TestDocs\\КП-21 Антонов Євгеній ТЗ на перевірку_removed.pdf";
            var filePath = "D:\\KPI\\3\\sem 1\\COURSEWORK\\Docs\\TestDocs\\ТЗ шаблон for tests.docx";

            var readerFactory = new ReaderFactory(filePath);
            var reader = readerFactory.GetReader();

            reader.ReadFile();
            var text = reader.FileText;

            var contentCreator = new ContentCreator();
            var content = contentCreator.GetContent(text);
            var textAfterContent = contentCreator.GetTextAfterContent(text);

            var sectionCreator = new SectionCreator();
            var sections = sectionCreator.GetSections(textAfterContent);

            /*
            text

            content
            sections
            */    

            new TextTester(text).Test();
            new SectionTester(sections.ToArray()).Test();

            /*
            https://habr.com/ru/articles/341148/
            https://ru.wikipedia.org/wiki/%D0%A0%D0%B0%D1%81%D1%81%D1%82%D0%BE%D1%8F%D0%BD%D0%B8%D0%B5_%D0%9B%D0%B5%D0%B2%D0%B5%D0%BD%D1%88%D1%82%D0%B5%D0%B9%D0%BD%D0%B0
            */

            // Можливі ідеї для ускладнення:

            // Валідація структурованості тексту:
            // Не лише наявність підрозділів, але й перевірка правильного порядку їхнього розташування.
            // Наприклад, заголовок "Найменування" повинен передувати "Галузь застосування".

            // Перевірка стилю та формату:
            // Додати перевірку відповідності стилю (наприклад, наявність заголовків у форматі "H1", підрозділів у форматі "H2").
            // Перевірка довжини речень у тексті, щоб вони не були занадто довгими.

            // Розширена семантична перевірка:
            // Аналіз контексту тексту. Наприклад, для розділу "Галузь застосування" перевірити, чи згадується ключова фраза, пов’язана з цільовою галуззю.
            
            // Статистика аналізу:
            // Підрахунок кількості слів у кожному розділі.
            // Генерація звіту, який покаже детальні результати перевірки.

            // Робота з таблицями та зображеннями:
            // Перевірка наявності таблиць/зображень у відповідних розділах і їхнього правильного опису (наприклад, підписи до таблиць).
            
            // Генерація рекомендацій:
            // Якщо розділ не відповідає вимогам, не лише повертати помилку, а й пропонувати рекомендації, як це виправити.
            
            // Машинне навчання для аналізу:
            // Для ускладнення можна інтегрувати модель машинного навчання, яка допомагатиме аналізувати структуру і зміст тексту (наприклад, виявляти логічні прогалини).
            
            // Перехресна перевірка:
            // Якщо є зв’язок між розділами, перевіряти, чи є посилання з одного розділу на інший (наприклад, "Етапи розроблення" повинні відповідати "Технічним вимогам").
            
            // Масштабованість:
            // Забезпечити підтримку роботи з багатомовними документами (наприклад, англійською).
        }
    }
}