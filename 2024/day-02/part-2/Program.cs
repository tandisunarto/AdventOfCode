using System.Text;
using static System.Math;

using StreamReader sr = new StreamReader("data.txt");

// var lines = sr.ReadToEnd().Split("\r\n");


var safeCount = 0;
var count = 0;
while (!sr.EndOfStream)
{
  var line = sr.ReadLine();
  var levels = line?.Split(' ');

  if (levels.Length > 1)
  {
    // bool ascending = false;

    // if (prevLevel == -1) {
    //   ascending = (Int32.Parse(levels[1]) - Int32.Parse(levels[0])) > 0;
    // }

    var safe = true;
    var ignoreUnsafe = true;
    bool ascending = true;
    var prevLevel = 0;
    for(int i = 0; i < levels.Length; i++)
    {
      int currLevel = Int32.Parse(levels[i]);
      int gap = 0;
      if (i == 0)
        ascending = (Int32.Parse(levels[1]) - Int32.Parse(levels[0])) > 0;
      else
      {
        prevLevel = Int32.Parse(levels[i-1]);
        gap = ascending ? currLevel - prevLevel: prevLevel - currLevel;
        safe =  gap > 0 && gap <= 3;
        // Console.WriteLine("{0} {1} GAP:{2} Safe:{3} IgnoreUnsafe:{4}", prevLevel, currLevel, gap, safe, ignoreUnsafe);

        if (!safe)
        {
          if (ignoreUnsafe)
          {
            safe = true;
            levels[i] = 1 == 1 ? levels[i] : levels[i-2];
            ignoreUnsafe = false;
          }
          else
            break;
        }
        else
        {
          // // Console.WriteLine("Safe ? {0} - {1}", safe, l);
          // ignoreUnsafe = true;
        }
      }
    }
    
    if (safe) count++;
    else 
      Console.WriteLine("{0}", line);

  }
}
Console.WriteLine(count);