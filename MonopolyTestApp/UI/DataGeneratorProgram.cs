using Test.Models;
using Test.DataGenerator;

namespace Test.UI;

public class DataGeneratorProgram
{
    private const int BoxDefaultCount = 20;
    private const int PalletDefaultCount = 10;

    private const string FastGenerationMenuCommand = "1";
    private const string SettingGenerationMenuCommand = "2";
    private const string ExitMenuCommand = "E";

    public event Action<List<Pallet>> DataGenerated;

    public void Start()
    {
        Console.WriteLine("Меню генератора данных");

        string consoleRead = "";

        do
        {
            MenuRender();
            consoleRead = Console.ReadLine();
            if (consoleRead == FastGenerationMenuCommand)
            {
                FastGeneration();
                break;
            }

            if (consoleRead == SettingGenerationMenuCommand)
            {
                SettingGeneration();
                break;
            }
        } while (consoleRead != "E");
    }

    private void FastGeneration()
    {
        DataGenerate(PalletDefaultCount, BoxDefaultCount);
    }

    private void SettingGeneration()
    {
        int palletCount;
        int boxCount;
        do
        {
            palletCount = IntInputElement("Введите количество генерируемых паллет:");
        } while (palletCount == -1);
        
        do
        {
            boxCount = IntInputElement("Введите количество генерируемых коробок для каждой паллеты:");
        } while (boxCount == -1);

        DataGenerate(palletCount, boxCount);
    }

    private void DataGenerate(int palletCount, int boxInPalletCount)
    {
        if (palletCount <= 0 || boxInPalletCount <= 0)
            throw new ArgumentException("palletCount или boxInPalletCount <= 0");
        
        List<Pallet> pallets = new List<Pallet>(palletCount);

        PalletGenerator palletGenerator = new();
        BoxGenerator boxGenerator = new();

        for (int i = 0; i < palletCount; i++)
        {
            pallets.Add(palletGenerator.GeneratePallet());

            for (int j = 0; j < boxInPalletCount; j++)
            {
                pallets[i].TryAddBox(boxGenerator.GenerateBox());
            }

            if (pallets[i].GetBoxes.Count != boxInPalletCount)
            {
                Console.WriteLine($"В паллету {pallets[i].Id} не подошло по размеру" +
                                  $" {boxInPalletCount - pallets[i].GetBoxes.Count} коробок.");
            }
        }

        Console.WriteLine("Генерация данных завершена");
        Console.WriteLine();
        
        DataGenerated?.Invoke(pallets);
    }

    private int IntInputElement(string elementForNeed)
    {
        Console.WriteLine(elementForNeed);

        string consoleRead = Console.ReadLine();
        if (int.TryParse(consoleRead, out int result))
        {
            if (result > 0)
            {
                return result;
            }
        }
        Console.WriteLine("Значение меньше 0 или не является целым числом");
        return -1;
    }

    private void MenuRender()
    {
        Console.WriteLine($"{FastGenerationMenuCommand} - Быстрая генерация {PalletDefaultCount} паллет " +
                          $"по {BoxDefaultCount} коробок;");
        Console.WriteLine($"{SettingGenerationMenuCommand} - Настраиваемая генерация;");
        Console.WriteLine($"{ExitMenuCommand} - Выход.");
    }
}