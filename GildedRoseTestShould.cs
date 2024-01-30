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
            IList<Item> Items = new List<Item> { new Item { Name = "IrrelevantItem", SellIn = 5, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(4, Items[0].SellIn);
            Assert.AreEqual(4, Items[0].Quality);
        }
    }
}
