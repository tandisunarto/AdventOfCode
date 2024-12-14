using System.Text.RegularExpressions;
using System.Text;
using static System.Math;

using StreamReader sr = new StreamReader("data.txt");
const string toMatch = "MAS";

List<string> dataRow = new();

while(!sr.EndOfStream)
{
    string line = sr.ReadLine();
    dataRow.Add(line);
}

int count = 0;
for(int row = 0; row < dataRow.Count; row++)
{
  int col = -1;
  do
  {
    col++;
    col = dataRow[row].IndexOf("A", col);
    if (col >= 0)
    {      
      if (MatchedWord(row, col)) count++;
    }
    else
      break;
  } while (col >= 0);
}
Console.WriteLine("TOTAL {0}", count);

bool MatchedWord(int row, int col)
{
  bool pass = false;
  int count = 0;

  if (row > 0 && row < dataRow.Count() - 1 && col > 0 && col < dataRow[row].Length - 1)
  {
    pass = (
        ((dataRow[row-1][col-1] == 'M' && dataRow[row+1][col+1] == 'S') || (dataRow[row-1][col-1] == 'S' && dataRow[row+1][col+1] == 'M')) &&
        ((dataRow[row+1][col-1] == 'M' && dataRow[row-1][col+1] == 'S') || (dataRow[row+1][col-1] == 'S' && dataRow[row-1][col+1] == 'M'))
    ) ? true : false;
  }
  Console.WriteLine("{0} {1}: {2}", row, col, pass);
  return pass;
}