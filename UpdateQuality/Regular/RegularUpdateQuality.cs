namespace csharp.Polymorphism.Strategy.Regular;

public class RegularUpdateQuality : BaseUpdateQuality
{
    public override void UpdateQuality(Item item)
    {
        DecreaseItemSellIn(item);
        
        if (IsQualityLowerOrEqualToMinimumQuality(item)) return;

        if (IsItemSellable(item)) item.Quality -= 1;
        else item.Quality -= 2;
    }
}