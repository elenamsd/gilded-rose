namespace csharp.Polymorphism.Strategy.BackstagePass;

public class BackstagePassUpdateQuality : BaseUpdateQuality
{
    public override void UpdateQuality(Item item)
    {
        DecreaseItemSellIn(item);
        
        switch (item.SellIn)
        {
            case >= 10:
                item.Quality += 1;
                break;
            case >= 5 and < 10:
                item.Quality += 2;
                break;
            case < 5:
                item.Quality += 3;
                break;
        }
            
        if (IsQualityGreaterOrEqualToMaxQuality(item)) SetQualityToMaxium(item);
        
        var itemIsNotSellable = !IsItemSellable(item);
        if (itemIsNotSellable) DropQualityToMinimum(item);
    }
}