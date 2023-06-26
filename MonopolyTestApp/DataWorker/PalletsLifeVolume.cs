using System.Text;
using Test.Models;

namespace MonopolyTestApp.DataWorker;

public class PalletsLifeVolume : IDataWorker
{
    private const int OrderTakeCount = 3;
    
    public string GetResult(List<Pallet> pallets)
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append("3 паллеты, которые содержат коробки с наибольшим сроком годности, " +
                             "отсортированные по возрастанию объема:\n");
            
        var sortPallets = pallets.OrderByDescending(p => p.GetExpirationDate())
            .Take(OrderTakeCount).OrderBy(p => p.Volume);

        foreach (var pallet in sortPallets)
        {
            stringBuilder.Append(pallet);
            stringBuilder.Append('\n');
        }
        
        return stringBuilder.ToString();
    }
}