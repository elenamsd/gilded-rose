using csharp.Polymorphism.Models;

namespace csharp.polymorphism.Models;

public abstract class ItemWrapper: IUpdateQualityStrategy
{
    public Item Item { get; init; }
    private IUpdateQualityStrategy _updateStrategy;

    protected ItemWrapper(IUpdateQualityStrategy updateStrategy)
    {
        _updateStrategy = updateStrategy;
    }

    public virtual void UpdateQuality(Item item)
    {
        _updateStrategy?.UpdateQuality(item);
    }
}