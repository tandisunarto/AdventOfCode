using static System.Math;

using StreamReader sr = new StreamReader("data.txt");

List<long> listA = new();
List<long> listB = new();

var lines = sr.ReadToEnd().Split("\n");
foreach(var line in lines)
{
  var data = line.Split("|");
  listA.Add(Int64.Parse(data[0]));
  listB.Add(Int64.Parse(data[1]));
}

listA.Sort();
listB.Sort();

long totalDistance = 0;
for(int i=0; i<listA.Count; i++)
{
  totalDistance += Abs(listA[i] - listB[i]);
}
Console.WriteLine("Total Distance: {0}", totalDistance.ToString());
