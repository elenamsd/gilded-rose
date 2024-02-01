using System.Collections.Generic;
using csharp.polymorphism.Models;
using csharp.Polymorphism.Strategy;

namespace csharp.Polymorphism;

public class GildedRose
{
    private readonly IList<ItemWrapper> _items = [];

    public GildedRose(IList<Item> items)
    {
        InitializeWrappedItemsFrom(items);
    }
    
    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            item.UpdateQuality(item.Item);
        }
    }

    private void InitializeWrappedItemsFrom(IList<Item> items)
    {
        foreach (var item in items)
        {
            bool isConjuredItem = item.Name.Contains("conjured", System.StringComparison.CurrentCultureIgnoreCase);
            
            if (isConjuredItem)
            {
                _items.Add(new Conjured() { Item = item });
                continue;
            }
          
            var itemToAdd = CreateWrappedItemFromItem(item);

            _items.Add(itemToAdd);
            
        }
    }
    
    private static ItemWrapper CreateWrappedItemFromItem(Item item)
    {
        const string agedBrie = "Aged Brie";
        const string backstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        const string sulfuras = "Sulfuras, Hand of Ragnaros";
        ItemWrapper itemToAdd = item.Name switch
        {
            sulfuras => new Sulfuras(),
            agedBrie => new AgedBrie() { Item = item },
            backstagePasses => new BackstagePass() { Item = item },
            _ => new Regular { Item = item }
        };
        return itemToAdd;
    }
}