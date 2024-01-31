namespace csharp.polymorphism.Models;

public class Conjured: ItemWrapper
{
    public override void UpdateQuality()
    {
        if (IsQualityGreaterThanMinimumQuality(Item))
        {
            Item.Quality -= 2;
        }
                
        DecreaseItemSellIn(Item);
                
        if (IsItemSellable(Item)) return;
                
        if (!IsQualityGreaterThanMinimumQuality(Item)) return;
                    
        Item.Quality -= 2;
    }
    
}