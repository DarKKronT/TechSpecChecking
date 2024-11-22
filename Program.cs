using System.Text;
using TechSpecChecking.Files.Readers;

namespace TechSpecChecking
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;

            var filePath = "D:\\KPI\\3\\sem 1\\COURSEWORK\\Docs\\TestDocs\\КП-21 Антонов Євгеній ТЗ на перевірку.pdf";

            var readerFactory = new ReaderFactory(filePath);
            var reader = readerFactory.GetReader();

            reader.ReadFile();
            System.Console.WriteLine(reader.FileText);
        }
    }
}