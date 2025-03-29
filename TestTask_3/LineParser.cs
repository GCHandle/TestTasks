using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;

namespace TestTask_3
{
    internal static class LineParser
    {
        public static void ParseFile(string inputFilePath, string outputFilePath, string errorFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);

            foreach(var line in lines)
            {
                StringBuilder sb = ParseLine(line);
                StreamWriter sw;

                if(sb == null)
                {
                    sw = new StreamWriter(errorFilePath, true);
                    sw.WriteLine(line);
                }

                else
                {
                    sw = new StreamWriter(outputFilePath, true);
                    sw.WriteLine(sb);
                }

                sw.Dispose();
            }
        }

        public static StringBuilder ParseLine(string input)
        {
            var output = new StringBuilder();
            var match = regs.Match(input);

            if (!match.Success && !((match = regs2.Match(input)).Success))
                return null;

            var strs = match.Value.Split(new[] { '|', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!DateTime.TryParse(strs[0] + " " + strs[1], out DateTime dt))
                return null;

            output.Append(dt.ToString("dd-mm-yyyy"));
            output.Append('\t');
            output.Append(strs[1]);
            output.Append('\t');
            output.Append(strs[2] == "INFORMATION" || strs[2] == "WARNING" ? strs[2].Substring(0, 4) : strs[2]);
            output.Append('\t');
            output.Append(strs.Length < 5 ? "DEFAULT" : strs[4]);
            output.Append('\t');
            output.Append(match.Length == input.Length ? "" : input.Substring(match.Length));
            return output;
        }

        static Regex regs = new Regex
            (@"^(\d{2}.\d{2}.\d{4}) \d{2}:\d{2}:\d{2}.\d{3}( ){1,2}(INFO|WARN|ERROR|DEBUG|INFORMATION|WARNING)(( ){1,2})");

        static Regex regs2 = new Regex
            (@"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}.\d{4}[|] ?(INFO|WARN|ERROR|DEBUG|INFORMATION|WARNING)([|]\w*[|](\w|\p{P})*[|] ?)");
    }
}
