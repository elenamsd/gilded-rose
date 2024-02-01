using csharp.Polymorphism.Models;

namespace csharp.Polymorphism.Strategy;

public class ConjuredUpdateUpdateStrategy : BaseUpdateStrategy
{
    public override void UpdateQuality(Item item)
    {
        DecreaseItemSellIn(item);
            
        if (IsQualityLowerOrEqualToMinimumQuality(item)) return;
            
        if (IsItemSellable(item))
        {
            item.Quality -= 2;
        }
        else
        {
            item.Quality -= 4;
        }
    }
}