using System.Text;
using System.Text.RegularExpressions;

namespace TestTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку из букв для компрессии:");
            var compressedStr = Compress(Console.ReadLine());
            Console.WriteLine("Результат компрессии:\n" + compressedStr);
            Console.WriteLine("Результат декомпрессии (восстановление сжатой строки):\n" + Decompress(compressedStr));
            Console.WriteLine("Работа программы завершена! Нажмите любую кнопку.");
            Console.ReadKey();
        }

        static string Compress(string decompressedStr)
        {
            var output = new StringBuilder();
            int i = 0, len = decompressedStr.Length;

            while (i < len)
            {
                output.Append(decompressedStr[i]);
                int j = 1;

                while (i + j < len && decompressedStr[i] == decompressedStr[j + i])
                    j++;

                if (j > 1)
                    output.Append(j);

                i += j;
            }

            return output.ToString();
        }

        static string Decompress(string compressedStr)
        {
            var regex = new Regex(@"\w(\d)*");
            var matches = regex.Matches(compressedStr);
            var output = new StringBuilder();

            for(int i = 0; i < matches.Count; i++)
            {
                var val = matches[i].Value;
                output.Append(new String(val[0], val.Length > 1 ? Convert.ToInt32(val.Substring(1)) : 1));
            }

            return output.ToString();
        }
    }
}
