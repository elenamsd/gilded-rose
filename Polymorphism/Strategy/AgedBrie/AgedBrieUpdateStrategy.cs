using csharp.Polymorphism.Models;

namespace csharp.Polymorphism.Strategy;

public class AgedBrieUpdateStrategy : BaseStrategy
{
    public override void UpdateQuality(Item item)
    {
        if (IsQualityLowerThanMaxQuality(item))
        {
            item.Quality += 1;
        }
                    
        DecreaseItemSellIn(item);
                    
        if (IsItemSellable(item)) return;
                    
        if (IsQualityLowerThanMaxQuality(item))
        {
            item.Quality += 1;
        }
    }
}