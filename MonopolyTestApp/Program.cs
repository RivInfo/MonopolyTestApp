using MonopolyTestApp.DataWorker;
using Test.Models;
using Test.UI;

IDataWorker groupLifeWeight = new GroupLifeWeight();
IDataWorker palletsLifeVolume = new PalletsLifeVolume();

DataGeneratorProgram dataGeneratorProgram = new();

dataGeneratorProgram.DataGenerated += OnDataGenerated;

dataGeneratorProgram.Start();

void OnDataGenerated(List<Pallet> pallets)
{
    
    Console.WriteLine(groupLifeWeight.GetResult(pallets));
    
    Console.WriteLine();
    
    Console.WriteLine(palletsLifeVolume.GetResult(pallets));
    // foreach (var pallet in pallets)
    // {
    //     Console.WriteLine(pallet);
    // }
}

/*Box box = new Box(0, 1, 1.5f, 1, 1, "asd")
{
    ExpirationDate = DateOnly.FromDateTime(DateTime.Today)
};

Pallet pallet = new Pallet(0, 2, 1, 3);

pallet.TryAddBox(box);

Console.WriteLine(box);
Console.WriteLine(pallet);*/