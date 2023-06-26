using System.Text;
using Test.Models;

namespace MonopolyTestApp.DataWorker;

public class GroupLifeWeight : IDataWorker
{
    private const int MeanCharInRow = 120; 
    
    public string GetResult(List<Pallet> pallets)
    {
        StringBuilder stringBuilder = new StringBuilder(pallets.Count * MeanCharInRow);

        stringBuilder.Append("Сгруппированные паллеты по сроку годности, " +
                             "отсортированные по возрастанию срока годности " +
                             "в каждой группе отсортированные паллеты по весу:\n");
        
        IEnumerable<IOrderedEnumerable<Pallet>> result = pallets.GroupBy(p => p.GetExpirationDate())
            .OrderBy(g => g.Key)
            .Select(g => g.OrderBy(p => p.Weight));

        foreach (IOrderedEnumerable<Pallet> orderedPallet in result)
        {
            foreach (var pallet in orderedPallet)
            {
                stringBuilder.Append(pallet);
                stringBuilder.Append('\n');
            }
        }

        return stringBuilder.ToString();
    }
}