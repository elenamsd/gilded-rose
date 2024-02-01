using csharp.Polymorphism.Models;

namespace csharp.Polymorphism.Strategy;

public abstract class BaseUpdateStrategy: IUpdateQualityStrategy
{
    private const int MaxQuality = 50;
    private const int MinQuality = 0;
    
    protected static void DropQualityToMinimum(Item item)
    {
        item.Quality = MinQuality;
    }
    
    protected static void SetQualityToMaxium(Item item)
    {
        item.Quality = MaxQuality;
    }

    protected static bool IsQualityLowerOrEqualToMinimumQuality(Item item)
    {
        return item.Quality <= MinQuality;
    }

    protected static bool IsQualityGreaterOrEqualToMaxQuality(Item item)
    {
        return item.Quality >= MaxQuality;
    }

    protected static void DecreaseItemSellIn(Item item)
    {
        item.SellIn -= 1;
    }

    protected static bool IsItemSellable(Item item)
    {
        return item.SellIn >= 0;
    }

    public abstract void UpdateQuality(Item item);
}