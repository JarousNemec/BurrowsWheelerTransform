// See https://aka.ms/new-console-template for more information

using BurrowsWheelerTransform;

var transformer = new Bwt();
var toTransform = new List<string>(){"ananas","banana","pineapple","bananaapple","applebanana"};
var toDetransform = new List<string>();
foreach (var transform in toTransform)
{
    toDetransform.Add(transformer.Transform(transform));
}

var result = new List<string>();
foreach (var detransform in toDetransform)
{
    result.Add(transformer.DeTransform(detransform));
}

for (var i = 0; i < result.Count; i++)
{
    Console.WriteLine(toTransform[i]);
    Console.WriteLine(toDetransform[i]);
    Console.WriteLine(result[i]);
    Console.WriteLine("-------------------------------------");
}