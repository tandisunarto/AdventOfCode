using System.Text.RegularExpressions;
using System.Text;
using static System.Math;

using StreamReader sr = new StreamReader("data.txt");

var lines = sr.ReadToEnd();

// Console.WriteLine(lines);
MatchCollection matches = Regex.Matches(lines, @"(mul\((\d{1,3}),(\d{1,3})\))");

Int64 sum = 0;
foreach(Match match in matches)
{
  sum += Int64.Parse(match.Groups[2].Value) * Int64.Parse(match.Groups[3].Value);
}
Console.WriteLine("{0}", sum);