using csharp.Polymorphism.Models;

namespace csharp.Polymorphism.Strategy;

public class RegularUpdateUpdateStrategy : BaseUpdateStrategy
{
    public override void UpdateQuality(Item item)
    {
        DecreaseItemSellIn(item);
        
        if (IsQualityLowerOrEqualToMinimumQuality(item)) return;

        if (IsItemSellable(item)) item.Quality -= 1;
        else item.Quality -= 2;
    }
}