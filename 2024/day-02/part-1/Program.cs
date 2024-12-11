using System.Text;
using static System.Math;

using StreamReader sr = new StreamReader("data.txt");

// var lines = sr.ReadToEnd().Split("\r\n");


var safeCount = 0;
var index = 0;
var count = 0;
while (!sr.EndOfStream)
{
  var line = sr.ReadLine();
  var levels = line?.Split(' ');

  if (levels.Length > 1)
  {
    var prevLevel = -1;
    var safe = true;
    bool ascending = false;

    if (prevLevel == -1) {
      ascending = (Int32.Parse(levels[1]) - Int32.Parse(levels[0])) > 0;
    }

    foreach(var l in levels)
    {    
      int level = Int32.Parse(l);
      if (prevLevel != -1)
      {
        var diff = ascending ? level - prevLevel: prevLevel - level;
        safe =  diff > 0 && diff <= 3;
      }
      prevLevel = level;
      if (!safe) break;
    }

    index++;
    if (safe){
      count++;
    }
  }
}
Console.WriteLine(count);