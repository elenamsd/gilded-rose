using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal.Commands;

namespace csharp.Polymorphism;

[TestFixture]
public class GildedRoseTestShould
{
    private List<Item> items;

    [SetUp]
    public void SetUp()
    {
        items = new List<Item>
        {
            new() { Name = "Aged Brie", SellIn = 2, Quality = 0 },
            new() { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
            new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
            new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
            new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 },
            new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 },
            new() { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
        };
    }
    
    [Test]
    public void UpdateQualityOfGivenItems()
    {
        var expected = new List<Item>         {
            new() { Name = "Aged Brie", SellIn = 1, Quality = 1 },
            new() { Name = "Elixir of the Mongoose", SellIn = 4, Quality = 6 },
            new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
            new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 14, Quality = 21 },
            new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 22 },
            new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 23 },
            new() { Name = "Conjured Mana Cake", SellIn = 2, Quality = 4 }
        };
        var gildedRose = new GildedRose(items);

        gildedRose.UpdateQuality();

        items.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void UpdateQualityOfGivenItemsThroughoutTwoWeeks()
    {
        var expected = new List<Item>         {
            new() { Name = "Aged Brie", SellIn = -12, Quality = 26 },
            new() { Name = "Elixir of the Mongoose", SellIn = -9, Quality = 0 },
            new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
            new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 47 },
            new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -4, Quality = 0 },
            new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -9, Quality = 0 },
            new() { Name = "Conjured Mana Cake", SellIn = -11, Quality = 0 }
        };
        var gildedRose = new GildedRose(items);
        
        for (var day = 0; day < 14; day++)
        { 
            gildedRose.UpdateQuality();
        }
        
        items.Should().BeEquivalentTo(expected);
    }
}