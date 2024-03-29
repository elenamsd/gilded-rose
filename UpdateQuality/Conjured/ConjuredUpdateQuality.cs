namespace csharp.Polymorphism.Strategy.Conjured;

public class ConjuredUpdateQuality : BaseUpdateQuality
{
    public override void UpdateQuality(Item item)
    {
        DecreaseItemSellIn(item);
            
        if (IsQualityLowerOrEqualToMinimumQuality(item)) return;
            
        if (IsItemSellable(item)) item.Quality -= 2;
        else item.Quality -= 4;
    }
}