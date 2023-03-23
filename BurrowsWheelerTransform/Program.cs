// See https://aka.ms/new-console-template for more information

using BurrowsWheelerTransform;

Console.WriteLine("Hello, World!");
var transformer = new BWT();
var toTransform = "ananas";
var toDetransform = transformer.Transform(toTransform);
var detransformed = transformer.DeTransform(toDetransform);

Console.WriteLine(toTransform);
Console.WriteLine(toDetransform);
Console.WriteLine(detransformed);