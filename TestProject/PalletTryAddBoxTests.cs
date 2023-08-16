using Test.Models;

namespace TestProject;

public class PalletTryAddBoxTests
{
    private Pallet _pallet = new Pallet(0, 10, 0.5f, 10);

    private Box _boxInPalletTrue = new Box(0, 10, 10, 10, 50);
    private Box _boxInPalletFalse = new Box(1, 10, 10, 20, 250);

    [Test]
    public void TryAddBox_ReturnTrue()
    {
        bool result = _pallet.TryAddBox(_boxInPalletTrue);
        Assert.IsTrue(result, "Коробка должна была добавиться");
    }
    
    [Test]
    public void TryAddBox_ReturnFalse()
    {
        bool result = _pallet.TryAddBox(_boxInPalletFalse);
        Assert.IsFalse(result, "Коробка не должна была добавляться");
    }
}