using System.Collections.Generic;
using csharp.polymorphism.Models;
using csharp.Polymorphism.Strategy;

namespace csharp.Polymorphism;

public class GildedRoseItemWrapper
{
    private readonly IList<ItemWrapper> _items = [];

    public GildedRoseItemWrapper(IList<Item> items)
    {
        foreach (var item in items)
        {
            if (item.Name.Contains("conjured", System.StringComparison.CurrentCultureIgnoreCase))
            {
                _items.Add(new Conjured() { Item = item });
            }

            else {
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

                _items.Add(itemToAdd);
            }
        }
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            item.UpdateQuality(item.Item);
        }
    }
}