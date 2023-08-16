using Test.Models;

namespace Test.DataGenerator;

public class BoxGenerator
{
    private readonly Random _random = new();

    public Box GenerateBox()
    {
        Box newBox = new Box(_random.Next(BoxParameters.MaxId),
            RandomFloat.GetRandomFloat(BoxParameters.MinWidth, BoxParameters.MaxWidth), 
            RandomFloat.GetRandomFloat(BoxParameters.MinHeight, BoxParameters.MaxHeight), 
            RandomFloat.GetRandomFloat(BoxParameters.MinDepth, BoxParameters.MaxDepth), 
            RandomFloat.GetRandomFloat(BoxParameters.MinWeight, BoxParameters.MaxWeight))
        {
            ExpirationDate = new DateOnly(_random.Next(BoxParameters.MinYear, BoxParameters.MaxYear),
                    _random.Next(BoxParameters.MinMonth,BoxParameters.MaxMonth),1)
                .AddDays(_random.Next(0,BoxParameters.MaxAddDays))
        };
        
        return newBox;
    }
}