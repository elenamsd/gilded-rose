using csharp.Polymorphism.Models;

namespace csharp.Polymorphism.Strategy;

public class ConjuredUpdateStrategy : BaseStrategy
{
    public override void UpdateQuality(Item item)
    {
        if (IsQualityGreaterThanMinimumQuality(item))
        {
            item.Quality -= 2;
        }
                
        DecreaseItemSellIn(item);
                
        if (IsItemSellable(item)) return;
                
        if (!IsQualityGreaterThanMinimumQuality(item)) return;
                    
        item.Quality -= 2;
    }
}