using System.Collections.Generic;
using NUnit.Framework;

namespace csharp.Polymorphism;

[TestFixture]
public class GildedRoseItemWrapperTestShould
{
    [Test]
    public void DecreaseQualityAndSellInOfRegularItem()
    {
        var items = new List<Item> { new() { Name = "IrrelevantItem", SellIn = 5, Quality = 5 } };
        var app = new GildedRoseItemWrapper(items);
            
        app.UpdateQuality();
            
        Assert.AreEqual(4, items[0].SellIn);
        Assert.AreEqual(4, items[0].Quality);
    }       
    
    
        [Test]
        public void NotAllowItemsWithNegativeQuality()
        {
            var items = new List<Item> { new Item { Name = "IrrelevantItem", SellIn = 0, Quality = 0 } };
            var app = new GildedRoseItemWrapper(items);
            
            app.UpdateQuality();
            
            Assert.AreEqual(0, items[0].Quality);
        } 
        
        [Test]
        public void DecreaseQualityTwiceFasterWhenSellInIsZeroDays()
        {
            var items = new List<Item> { new Item { Name = "IrrelevantItem", SellIn = 0, Quality = 4 } };
            var app = new GildedRoseItemWrapper(items);
            
            app.UpdateQuality();
            
            Assert.AreEqual(2, items[0].Quality);
        }
        
        [Test]
        public void DecreaseQualityTwiceFasterWhenSellInIsBelowZeroDays()
        {
            var items = new List<Item> { new Item { Name = "IrrelevantItem", SellIn = -1, Quality = 4 } };
            var app = new GildedRoseItemWrapper(items);
            
            app.UpdateQuality();
            
            Assert.AreEqual(2, items[0].Quality);
        }
        
        [Test]
        [Ignore("No sabemos si controla que un item tenga una calidad mayor a 50.")]
        public void NotAllowRegularItemsQualityBeGreaterThan50()
        {
            var items = new List<Item> { new Item { Name = "IrrelevantItem", SellIn = 0, Quality = 90 } };
            var app = new GildedRoseItemWrapper(items);
            
            app.UpdateQuality();
            
            Assert.AreEqual(50, items[0].Quality);
        }

        [Test]
        public void IncreaseAgedBrieQualityByOneWhenSellInIsGreaterThanZeroDays()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 } };
            var app = new GildedRoseItemWrapper(items);
            
            app.UpdateQuality();
            
            Assert.AreEqual(11, items[0].Quality);
        }
        
        [Test]
        public void IncreaseAgedBrieQualityByTwoWhenSellInIsBelowOrEqualZeroDays()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 } };
            var app = new GildedRoseItemWrapper(items);
            
            app.UpdateQuality();
            
            Assert.AreEqual(12, items[0].Quality);
        }
        
        [Test]
        public void NotChangeQualityOrSellInOfSulfuras()
        {
            var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            var app = new GildedRoseItemWrapper(items);
            
            app.UpdateQuality();
            
            Assert.AreEqual(80, items[0].Quality);
            Assert.AreEqual(0, items[0].SellIn);
        }
        
        [Test]
        public void IncreaseBackstagePassQualityByOneWhenSellInGreaterThanTenDays()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 5 } };
            var app = new GildedRoseItemWrapper(items);
            
            app.UpdateQuality();
            
            Assert.AreEqual(6, items[0].Quality);
            Assert.AreEqual(14, items[0].SellIn);
        }
        
        [Test]
        public void IncreaseBackstagePassQualityByTwoWhenSellInLowerOrEqualThanTenDays()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 5 } };
            var app = new GildedRoseItemWrapper(items);
            
            app.UpdateQuality();
            
            Assert.AreEqual(7, items[0].Quality);
            Assert.AreEqual(9, items[0].SellIn);
        }
        
        [Test]
        public void IncreaseBackstagePassQualityByThreeWhenSellInLowerOrEqualThanFiveDays()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 5 } };
            var app = new GildedRoseItemWrapper(items);
            
            app.UpdateQuality();
            
            Assert.AreEqual(8, items[0].Quality);
            Assert.AreEqual(4, items[0].SellIn);
        }
        
        [Test]
        public void IncreaseBackstagePassQualityByThreeWhenSellInLowerOrEqualThanFiveDaysTest()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 } };
            var app = new GildedRoseItemWrapper(items);
            
            app.UpdateQuality();
            
            Assert.AreEqual(50, items[0].Quality);
            Assert.AreEqual(4, items[0].SellIn);
        }
        
        [Test]
        public void DropBackstagePassQualityToZeroWhenSellInLowerOrEqualThanZeroDays()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 5 } };
            var app = new GildedRoseItemWrapper(items);
            
            app.UpdateQuality();
            
            Assert.AreEqual(0, items[0].Quality);
            Assert.AreEqual(-1, items[0].SellIn);
        }
        
        [Test]
        public void DecreaseQualityOfConjuredItemsTwiceFaster()
        {
            var items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 4, Quality = 5 } };
            var app = new GildedRoseItemWrapper(items);
            
            app.UpdateQuality();
            
            Assert.AreEqual(3, items[0].Quality);
        }
    
}