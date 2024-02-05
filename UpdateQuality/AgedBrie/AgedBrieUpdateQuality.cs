namespace csharp.Polymorphism.Strategy.AgedBrie;

public class AgedBrieUpdateQuality : BaseUpdateQuality
{
    public override void UpdateQuality(Item item)
    {
        DecreaseItemSellIn(item);

        if (IsItemSellable(item)) item.Quality += 1;
        else item.Quality += 2;
        
        if (IsQualityGreaterOrEqualToMaxQuality(item)) SetQualityToMaxium(item);
    }
}