using System.Collections.Generic;

namespace csharp.Polymorphism;

public class GildedRose
{
    private readonly IList<Item> _items = [];

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }
    
    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            var updateQualityStrategy = UpdateQualityFactory.Create(item.Name);
            
            updateQualityStrategy.UpdateQuality(item);
        }
    }
    
}