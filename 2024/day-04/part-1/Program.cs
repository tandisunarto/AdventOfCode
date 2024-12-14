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
    col = dataRow[row].IndexOf("X", col);
    if (col >= 0)
    {
      count += MatchedWord(row, col);
    }
    // Console.WriteLine("{0} {1}", row, col);
  } while (col >= 0);
}
Console.WriteLine("TOTAL {0}", count);

int MatchedWord(int row, int col)
{
  bool pass = false;
  int count = 0;
  
  if (row >= 3)
  {
    // up
    for(var i = 1; i<=toMatch.Length; i++)
    {
      pass = dataRow[row-i][col] == toMatch[i-1];
      if (!pass) break;
    } 
  }
  if (pass) 
  {
    // Console.WriteLine("UP - {0} {1}", row, col);
    count++;
  }

  pass = false;
  if (row < dataRow.Count() - 3)
  {
    // down
    for(var i = 1; i<=toMatch.Length; i++)
    {
      pass = dataRow[row+i][col] == toMatch[i-1];
      if (!pass) break;
    } 
  }
  if (pass) 
  {
    // Console.WriteLine("DOWN - {0} {1}", row, col);
    count++;
  }

  pass = false;
  if (col < dataRow[row].Length - 3)
  {
    // right
    for(var i = 1; i<=toMatch.Length; i++)
    {
      pass = dataRow[row][col+i] == toMatch[i-1];
      if (!pass) break;
    }
  }
  if (pass) {
    // Console.WriteLine("RIGHT - {0} {1}", row, col);
    count++;
  }

  pass = false;
  if (col >= 3)
  {
    // left
    for(var i = 1; i<=toMatch.Length; i++)
    {
      pass = dataRow[row][col-i] == toMatch[i-1];
      if (!pass) break;
    }
  }
  if (pass) {
    // Console.WriteLine("LEFT - {0} {1}", row, col);
    count++;
  }

  pass = false;
  if (col >= 3 && row >= 3)
  {
    // left up
    for(var i = 1; i<=toMatch.Length; i++)
    {
      pass = dataRow[row-i][col-i] == toMatch[i-1];
      if (!pass) break;
    }
  }
  if (pass) {
    // Console.WriteLine("LEFT UP - {0} {1}", row, col);
    count++;
  }

  pass = false;
  if (col >= 3 && row < dataRow.Count() - 3)
  {
    // left down
    for(var i = 1; i<=toMatch.Length; i++)
    {
      pass = dataRow[row+i][col-i] == toMatch[i-1];
      if (!pass) break;
    }
  }
  if (pass) {
    // Console.WriteLine("LEFT DOWN - {0} {1}", row, col);
    count++;
  }

  pass = false;
  if (col < dataRow[row].Length - 3 && row < dataRow.Count() - 3)
  {
    // right down
    Console.WriteLine("{0} {1}", row, col);
    for(var i = 1; i<=toMatch.Length; i++)
    {
      pass = dataRow[row+i][col+i] == toMatch[i-1];
      if (!pass) break;
    }
  }
  if (pass) {
    // Console.WriteLine("RIGHT DOWN- {0} {1}", row, col);
    count++;
  }

  pass = false;
  if (row >= 3 && col < dataRow[row].Length - 3)
  {
    // right up
    for(var i = 1; i<=toMatch.Length; i++)
    {
      pass = dataRow[row-i][col+i] == toMatch[i-1];
      if (!pass) break;
    }
  }
  if (pass) {
    // Console.WriteLine("RIGHT UP - {0} {1}", row, col);
    count++;
  }


  return count;
}