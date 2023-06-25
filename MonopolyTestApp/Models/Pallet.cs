namespace Test.Models;

public class Pallet : StorageItemBase
{
    private const float PalletStartWeight = 30;
    
    private List<Box> _boxes = new();
    
    public override float Weight
    {
        get
        {
            float weight = PalletStartWeight;
            foreach (Box box in _boxes)
            {
                weight += box.Weight;
            }
            return weight;
        }
    }

    public override float Volume
    {
        get
        {
            float volume = base.Volume;
            
            foreach (Box box in _boxes)
            {
                volume += box.Volume;
            }

            return volume;
        }
    }

    public IEnumerable<Box> GetBoxes => _boxes;

    public Pallet(int id, float width, float height, float depth) : base(id, width, height, depth)
    {
    }
    
    public override string ToString()
    {
        return $"{base.ToString()} Коробок в паллете: {_boxes.Count}; Cрок годности: {GetExpirationDate()}.";
    }
    
    public DateOnly GetExpirationDate()
    {
        DateOnly minExpirationDate = DateOnly.MaxValue;
        foreach (Box box in _boxes)
        {
            if (box.ExpirationDate < minExpirationDate)
            {
                minExpirationDate = box.ExpirationDate;
            }
        }

        return minExpirationDate;
    }

    public bool TryAddBox(Box box)
    {
        if (box.Width <= Width && box.Depth <= Depth)
        {
            _boxes.Add(box);
            return true;
        }

        return false;
    }
}