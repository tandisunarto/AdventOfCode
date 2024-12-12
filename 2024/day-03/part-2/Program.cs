using System.Text.RegularExpressions;

using StreamReader sr = new StreamReader("data.txt");

string lines = sr.ReadToEnd();

var continueRemove = true;
int startIndex = 0;

while (continueRemove)
{
  int dontIndex = lines.IndexOf("don't()", startIndex);
  if (dontIndex <= 0) break;
  int doIndex = lines.IndexOf("do()", dontIndex);

  startIndex = dontIndex;
  continueRemove = dontIndex > 0 && doIndex > 0 && dontIndex < doIndex;
   if (continueRemove)
  {
    lines = lines.Remove(dontIndex, doIndex - dontIndex + 3);
  }
}

MatchCollection matches = Regex.Matches(lines, @"(mul\((\d{1,3}),(\d{1,3})\))");

Int64 sum = 0;
foreach(Match match in matches)
{
  sum += Int64.Parse(match.Groups[2].Value) * Int64.Parse(match.Groups[3].Value);
}
Console.WriteLine("{0}", sum);