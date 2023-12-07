TRTriangle a = new(3);
TRTriangle b = new(2);
var c = a + b;
var area = a.GetArea();
var perim = c.GetPerimeter();

TPiramid x = new(3, 5);
x.Input();
x.Print();
Console.WriteLine("Volume of the piramid = {0}", x.GetVolume());