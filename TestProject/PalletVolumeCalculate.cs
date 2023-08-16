using Test.Models;

namespace TestProject;

public class PalletVolumeCalculate
{
    private Pallet _palletFreeVolume50 = new Pallet(0, 10, 0.5f, 10);
    private Pallet _palletWithBoxesVolume50 = new Pallet(0, 10, 0.5f, 10);

    private Box _boxVolume3 = new Box(0, 2, 1.5f, 1, 50);
    private Box _boxVolume5 = new Box(1, 0.5f, 5, 2, 250);

    [Test]
    public void CalculateVolumeFreePallet_50()
    {
        Assert.AreEqual(_palletFreeVolume50.Volume, 50);
    }
    
    [Test]
    public void CalculateVolumePallet_58()
    {
        _palletWithBoxesVolume50.TryAddBox(_boxVolume3);
        _palletWithBoxesVolume50.TryAddBox(_boxVolume5);
        Assert.AreEqual(_palletWithBoxesVolume50.Volume, 58);
    }
}