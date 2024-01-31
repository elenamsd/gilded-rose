namespace csharp.polymorphism.Models;

public class AgedBrie:  ItemWrapper
{
    public override void UpdateQuality()
    {
        if (IsQualityLowerThanMaxQuality(Item))
        {
            Item.Quality += 1;
        }
                    
        DecreaseItemSellIn(Item);
                    
        if (IsItemSellable(Item)) return;
                    
        if (IsQualityLowerThanMaxQuality(Item))
        {
            Item.Quality += 1;
        }
    }
}