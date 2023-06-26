using Test.Models;

namespace MonopolyTestApp.DataWorker;

public interface IDataWorker
{
    public string GetResult(List<Pallet> pallets);
}