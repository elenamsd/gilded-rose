using System.Collections.Generic;
using csharp.polymorphism.Models;

namespace csharp
{
    public class GildedRose
    {
        private IList<Item> Items;
        
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                
                const string agedBrie = "Aged Brie";
                const string backstagePasses = "Backstage passes to a TAFKAL80ETC concert";
                const string sulfuras = "Sulfuras, Hand of Ragnaros";

                switch (item.Name)
                {
                    case sulfuras:
                        var sulfurasItem = new Sulfuras();
                        sulfurasItem.UpdateQuality();
                        break;
                    case agedBrie:
                        var brie = new AgedBrie
                        {
                            Item = item
                        };
                        brie.UpdateQuality();
                        item.Name = brie.Item.Name;
                        item.SellIn = brie.Item.SellIn;
                        item.Quality = brie.Item.Quality;
                        break;
                    case backstagePasses:
                        var backstagePass = new BackstagePass
                        {
                            Item = item
                        };
                        backstagePass.UpdateQuality();
                        item.Name = backstagePass.Item.Name;
                        item.SellIn = backstagePass.Item.SellIn;
                        item.Quality = backstagePass.Item.Quality;
                        break;
                    default:
                        var regular = new Regular
                        {
                            Item = item
                        };
                        regular.UpdateQuality();
                        item.Name = regular.Item.Name;
                        item.SellIn = regular.Item.SellIn;
                        item.Quality = regular.Item.Quality;
                        break;
                }
            }
        }

        /*private static void HandleRegularItem(Item item)
        {
            if (IsQualityGreaterThanMinimumQuality(item))
            {
                item.Quality -= 1;
            }
                
            DecreaseItemSellIn(item);
                
            if (IsItemSellable(item)) return;
                
            if (!IsQualityGreaterThanMinimumQuality(item)) return;
                    
            item.Quality -= 1;
        }

        private static void HandleBackStagePassCase(Item item)
        {
            if (IsQualityLowerThanMaxQuality(item))
            {
                item.Quality += 1;
                        
                var isItemSellInGreaterThanElevenDays = item.SellIn < 11;
                if (isItemSellInGreaterThanElevenDays && IsQualityLowerThanMaxQuality(item))
                {
                    item.Quality += 1;
                }

                var isItemSellInGreaterThanSixDays = item.SellIn < 6;
                if (isItemSellInGreaterThanSixDays && IsQualityLowerThanMaxQuality(item))
                {
                    item.Quality += 1;
                }
            }

            DecreaseItemSellIn(item);
                    
            if (IsItemSellable(item)) return;
                    
            DropQualityToMinimum(item);
        }

        private static void HandleAgedBrieCase(Item item)
        {
            if (IsQualityLowerThanMaxQuality(item))
            {
                item.Quality += 1;
            }
                    
            DecreaseItemSellIn(item);
                    
            if (IsItemSellable(item)) return;
                    
            if (IsQualityLowerThanMaxQuality(item))
            {
                item.Quality += 1;
            }
        }

        private static void DropQualityToMinimum(Item item)
        {
            item.Quality = MinQuality;
        }

        private static bool IsQualityGreaterThanMinimumQuality(Item item)
        {
            return item.Quality > MinQuality;
        }

        private static bool IsQualityLowerThanMaxQuality(Item item)
        {
            return item.Quality < MaxQuality;
        }

        private static void DecreaseItemSellIn(Item item)
        {
            item.SellIn -= 1;
        }

        private static bool IsItemSellable(Item item)
        {
            return item.SellIn >= 0;
        }*/
    }
}
