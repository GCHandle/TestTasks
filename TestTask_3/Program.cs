using System.Text;

namespace TestTask_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Примеры:");
            //Console.WriteLine(LineParser.ParseLine(Example4));
            Console.WriteLine("Укажите полный путь файла с логами в старом формате:");
            string oldFile = Console.ReadLine();
            Console.WriteLine("Укажите полный путь файла с логами в новом формате (может быть создан):");
            string newFile = Console.ReadLine();
            Console.WriteLine("Укажите папку для файла ошибок (может быть создана):");
            string errorFile = Console.ReadLine();
            errorFile += (errorFile.Last() != '\\') ? @"\problems.txt" : "problems.txt";
            LineParser.ParseFile(oldFile, newFile, errorFile);
            Console.WriteLine("Готово! Нажмите любую кнопку.");
            Console.ReadKey();
        }

    }
}
