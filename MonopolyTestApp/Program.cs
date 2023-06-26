using MonopolyTestApp.DataWorker;
using Test.Models;
using Test.UI;

IDataWorker groupLifeWeight = new GroupLifeWeight();
IDataWorker palletsLifeVolume = new PalletsLifeVolume();

DataGeneratorProgram dataGeneratorProgram = new();

dataGeneratorProgram.DataGenerated += OnDataGenerated;

string consoleLine;

do
{
    dataGeneratorProgram.Start();
    
    MainMenu.MainMenuRender();
    consoleLine = Console.ReadLine();
} while (consoleLine != MainMenu.ProgramExitKey);

dataGeneratorProgram.DataGenerated -= OnDataGenerated;

void OnDataGenerated(List<Pallet> pallets)
{
    Console.WriteLine(groupLifeWeight.GetResult(pallets));

    Console.WriteLine();

    Console.WriteLine(palletsLifeVolume.GetResult(pallets));
}