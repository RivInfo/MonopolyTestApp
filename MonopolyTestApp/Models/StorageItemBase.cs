namespace Test.Models;

public abstract class StorageItemBase
{
    public readonly int Id;

    public float Width { get; protected init; }
    public float Height { get; protected init; }
    public float Depth { get; protected init; }
    public virtual float Weight { get; protected init; }

    public virtual float Volume => Width * Height * Depth;

    protected StorageItemBase(int id, float width, float height, float depth)
    {
        Id = id;
        Width = width;
        Height = height;
        Depth = depth;
    }
    
    public override string ToString()
    {
        return $"Id: {Id:D5} Объём: {Volume:000.0000};";
    }
}