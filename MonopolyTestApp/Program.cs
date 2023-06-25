using Test.Models;

Box box = new Box(0, 1, 1.5f, 1, 1, "asd")
{
    ExpirationDate = DateOnly.FromDateTime(DateTime.Today)
};

Pallet pallet = new Pallet(0, 2, 1, 3);

pallet.TryAddBox(box);

Console.WriteLine(box);
Console.WriteLine(pallet);