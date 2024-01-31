namespace csharp.polymorphism.Models;

public class BackstagePass:  ItemWrapper
{
    public override void UpdateQuality()
    {
        if (IsQualityLowerThanMaxQuality(Item))
        {
            Item.Quality += 1;
                        
            var isItemSellInGreaterThanElevenDays = Item.SellIn < 11;
            if (isItemSellInGreaterThanElevenDays && IsQualityLowerThanMaxQuality(Item))
            {
                Item.Quality += 1;
            }

            var isItemSellInGreaterThanSixDays = Item.SellIn < 6;
            if (isItemSellInGreaterThanSixDays && IsQualityLowerThanMaxQuality(Item))
            {
                Item.Quality += 1;
            }
        }

        DecreaseItemSellIn(Item);
                    
        if (IsItemSellable(Item)) return;
                    
        DropQualityToMinimum(Item);
    }
}