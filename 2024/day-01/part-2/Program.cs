using static System.Math;

using StreamReader sr = new StreamReader("data.txt");

List<string> listA = new();
List<string> listB = new();

var lines = sr.ReadToEnd().Split("\r\n");
foreach(var line in lines)
{
  var data = line.Split("|");
  listA.Add(data[0].ToString());
  listB.Add(data[1].ToString());
}

long similarityScore = 0;
var listBGroupBy = listB.GroupBy(v => v).ToList();

foreach(var val in listA)
{
  var result = listBGroupBy.Find(v => v.Key.Equals(val));
  similarityScore = similarityScore + (result is null ? 0 : Int64.Parse(val) * result.Count());
}
Console.WriteLine(similarityScore);
