using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTestShould
    {
        [Test]
        public void DecreaseQualityAndSellInOfRegularItem()
        {
            var items = new List<Item> { new Item { Name = "IrrelevantItem", SellIn = 5, Quality = 5 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(4, items[0].SellIn);
            Assert.AreEqual(4, items[0].Quality);
        }       
        
        [Test]
        public void NotAllowItemsWithNegativeQuality()
        {
            var items = new List<Item> { new Item { Name = "IrrelevantItem", SellIn = 0, Quality = 0 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(0, items[0].Quality);
        } 
        
        [Test]
        public void DecreaseQualityTwiceFasterWhenSellInIsZero()
        {
            var items = new List<Item> { new Item { Name = "IrrelevantItem", SellIn = 0, Quality = 4 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(2, items[0].Quality);
        }
        
        [Test]
        public void DecreaseQualityTwiceFasterWhenSellInIsBelowZero()
        {
            var items = new List<Item> { new Item { Name = "IrrelevantItem", SellIn = -1, Quality = 4 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(2, items[0].Quality);
        }
        
        [Test]
        [Ignore("No sabemos si controla que un item tenga una calidad mayor a 50.")]
        public void NotAllowRegularItemsQualityBeGreaterThan50()
        {
            var items = new List<Item> { new Item { Name = "IrrelevantItem", SellIn = 0, Quality = 90 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(50, items[0].Quality);
        }
    }
}
