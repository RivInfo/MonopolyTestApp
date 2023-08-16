namespace Test.Models;

public class Box : StorageItemBase
{
    private DateOnly _productionDate;
    private DateOnly _expirationDate;

    public DateOnly ProductionDate
    {
        get => _productionDate;
        init
        {
            _productionDate = value;
            if(_expirationDate == DateOnly.MinValue)//?
                _expirationDate = _productionDate.AddDays(100);
        }
    }

    public DateOnly ExpirationDate
    {
        get => _expirationDate;
        init => _expirationDate = value;//?
    }

    public Box(int id, float width, float height, float depth, float weight)
        : base(id, width, height, depth)
    {
        Weight = weight;
    }

    public override string ToString()
    {
        return $"{base.ToString()} " +
               $"Дата производства: {ProductionDate}; Cрок годности: {ExpirationDate}.";
    }
}