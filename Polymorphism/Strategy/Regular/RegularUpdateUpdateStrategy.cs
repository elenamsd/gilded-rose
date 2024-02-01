using csharp.Polymorphism.Models;

namespace csharp.Polymorphism.Strategy;

public class RegularUpdateUpdateStrategy : BaseUpdateStrategy
{
    public override void UpdateQuality(Item item)
    {
        if (IsQualityGreaterThanMinimumQuality(item))
        {
            item.Quality -= 1;
        }

        DecreaseItemSellIn(item);

        if (!IsItemSellable(item) && IsQualityGreaterThanMinimumQuality(item))
        {
            item.Quality -= 1;
        }
    }
}