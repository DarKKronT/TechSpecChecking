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

            //var filePath = "D:\\KPI\\3\\sem 1\\COURSEWORK\\Docs\\TestDocs\\ТЗ шаблон for tests.docx";

            var filePath = "D:\\KPI\\3\\sem 1\\COURSEWORK\\Docs\\КП-21_Антонов_Євгеній_Технічне_завдання.docx";

            var readerFactory = new ReaderFactory(filePath);
            var reader = readerFactory.GetReader();

            reader.ReadFile();
            var text = reader.FileText;

            var contentCreator = new ContentCreator();
            var content = contentCreator.GetContent(text);
            var textAfterContent = contentCreator.GetTextAfterContent(text);

            var sectionCreator = new SectionCreator();
            var sections = sectionCreator.GetSections(textAfterContent);

            new TextTester(text).Test();
            new SectionTester(sections.ToArray()).Test();

            // Статистика аналізу:
            // Підрахунок кількості слів у кожному розділі.
            // Генерація звіту, який покаже детальні результати перевірки.

            // Робота з таблицями та зображеннями:
            // Перевірка наявності таблиць/зображень у відповідних розділах і їхнього правильного опису (наприклад, підписи до таблиць).
            
            // Генерація рекомендацій:
            // Якщо розділ не відповідає вимогам, не лише повертати помилку, а й пропонувати рекомендації, як це виправити.
            
            // Масштабованість:
            // Забезпечити підтримку роботи з багатомовними документами (наприклад, англійською).
        }
    }
}