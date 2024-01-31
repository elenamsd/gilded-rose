using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace csharp.Polymorphism;

[TestFixture]
public class GildedRoseTestShould
{
    [Test]
    public void DecreaseQualityAndSellInOfRegularItem()
    {
        var items = new List<Item> { new() { Name = "IrrelevantItem", SellIn = 5, Quality = 5 } };
        var expected = new List<Item> { new() { Name = "IrrelevantItem", SellIn = 4, Quality = 4 } };
        var app = new GildedRose(items);

        app.UpdateQuality();
        
        items.Should().BeEquivalentTo(expected);
    }       
    
    
    [Test]
    public void NotAllowItemsWithNegativeQuality()
    {
        var items = new List<Item> { new Item { Name = "IrrelevantItem", SellIn = 0, Quality = 0 } };
        var expected = new List<Item> { new Item { Name = "IrrelevantItem", SellIn = -1, Quality = 0 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        items.Should().BeEquivalentTo(expected);
    } 
    
    [Test]
    public void DecreaseQualityTwiceFasterWhenSellInIsZeroDays()
    {
        var items = new List<Item> { new Item { Name = "IrrelevantItem", SellIn = 0, Quality = 4 } };
        var expected = new List<Item> { new Item { Name = "IrrelevantItem", SellIn = -1, Quality = 2 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        items.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void DecreaseQualityTwiceFasterWhenSellInIsBelowZeroDays()
    {
        var items = new List<Item> { new Item { Name = "IrrelevantItem", SellIn = -1, Quality = 4 } };
        var expected = new List<Item> { new Item { Name = "IrrelevantItem", SellIn = -2, Quality = 2 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        items.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    [Ignore("No sabemos si controla que un item tenga una calidad mayor a 50.")]
    public void NotAllowRegularItemsQualityBeGreaterThan50()
    {
        var items = new List<Item> { new Item { Name = "IrrelevantItem", SellIn = 0, Quality = 90 } };
        var expected = new List<Item> { new Item { Name = "IrrelevantItem", SellIn = -1, Quality = 50 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        items.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void IncreaseAgedBrieQualityByOneWhenSellInIsGreaterThanZeroDays()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 } };
        var expected = new List<Item> { new Item { Name = "Aged Brie", SellIn = 4, Quality = 11 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        items.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void IncreaseAgedBrieQualityByTwoWhenSellInIsBelowOrEqualZeroDays()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 } };
        var expected = new List<Item> { new Item { Name = "Aged Brie", SellIn = -1, Quality = 12 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        items.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void NotChangeQualityOrSellInOfSulfuras()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
        var expected = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        items.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void IncreaseBackstagePassQualityByOneWhenSellInGreaterThanTenDays()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 5 } };
        var expected = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 14, Quality = 6 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        items.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void IncreaseBackstagePassQualityByTwoWhenSellInLowerOrEqualThanTenDays()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 5 } };
        var expected = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 7 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        items.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void IncreaseBackstagePassQualityByThreeWhenSellInLowerOrEqualThanFiveDays()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 5 } };
        var expected = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 8 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        items.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void IncreaseBackstagePassQualityByThreeWhenSellInLowerOrEqualThanFiveDaysTest()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 } };
        var expected = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 50 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        items.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void DropBackstagePassQualityToZeroWhenSellInLowerOrEqualThanZeroDays()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 5 } };
        var expected = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 0 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        items.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void DecreaseQualityOfConjuredItemsTwiceFaster()
    {
        var items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 4, Quality = 5 } };
        var expected = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 3 } };
        var app = new GildedRose(items);
        
        app.UpdateQuality();
        
        items.Should().BeEquivalentTo(expected);
    }
    
}