using csharp.Polymorphism.Models;

namespace csharp.Polymorphism.Strategy;

public class BackstagePassUpdateStrategy : BaseStrategy
{
    public override void UpdateQuality(Item item)
    {
        if (IsQualityLowerThanMaxQuality(item))
        {
            item.Quality += 1;
                        
            var isItemSellInGreaterThanElevenDays = item.SellIn < 11;
            if (isItemSellInGreaterThanElevenDays && IsQualityLowerThanMaxQuality(item))
            {
                item.Quality += 1;
            }

            var isItemSellInGreaterThanSixDays = item.SellIn < 6;
            if (isItemSellInGreaterThanSixDays && IsQualityLowerThanMaxQuality(item))
            {
                item.Quality += 1;
            }
        }

        DecreaseItemSellIn(item);
                    
        if (IsItemSellable(item)) return;
                    
        DropQualityToMinimum(item);
    }
}