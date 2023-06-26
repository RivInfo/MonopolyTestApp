using Test.Models;

namespace Test.DataGenerator;

public class PalletGenerator
{
    private readonly Random _random = new();
    
    public Pallet GeneratePallet()
    {
        Pallet newPallet = new Pallet(_random.Next(PalletParameters.MaxId),
            RandomFloat.GetRandomFloat(PalletParameters.MinWidth, PalletParameters.MaxWidth),
            RandomFloat.GetRandomFloat(PalletParameters.MinHeight, PalletParameters.MaxHeight),
            RandomFloat.GetRandomFloat(PalletParameters.MinDepth, PalletParameters.MaxDepth));
        return newPallet;
    }
}