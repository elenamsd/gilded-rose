using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;

        private const int MaxQuality = 50;
        private const int MinQuality = 0;
        
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
                        break;
                    case agedBrie:
                        HandleAgedBrieCase(item);
                        break;
                    case backstagePasses:
                        HandleBackStagePassCase(item);
                        break;
                    default:
                        HandleRegularItem(item);
                        break;
                }
            }
        }

        private static void HandleRegularItem(Item item)
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
        }
    }
}
