namespace csharp.polymorphism.Models;

public class Regular: ItemWrapper
{
    public override void UpdateQuality()
    {
        if (IsQualityGreaterThanMinimumQuality(Item))
        {
            Item.Quality -= 1;
        }
                
        DecreaseItemSellIn(Item);
                
        if (IsItemSellable(Item)) return;
                
        if (!IsQualityGreaterThanMinimumQuality(Item)) return;
                    
        Item.Quality -= 1;
    }
    
}