using csharp.Polymorphism.Models;

namespace csharp.Polymorphism.Strategy;

public abstract class BaseStrategy: IUpdateQualityStrategy
{
    private const int MaxQuality = 50;
    private const int MinQuality = 0;
    
    protected static void DropQualityToMinimum(Item item)
    {
        item.Quality = MinQuality;
    }

    protected static bool IsQualityGreaterThanMinimumQuality(Item item)
    {
        return item.Quality > MinQuality;
    }

    protected static bool IsQualityLowerThanMaxQuality(Item item)
    {
        return item.Quality < MaxQuality;
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