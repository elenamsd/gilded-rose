using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
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

                var itemIsNotAgedBrie = item.Name != agedBrie;
                var itemIsNotBackstagePasses = item.Name != backstagePasses;
                var itemIsNotSulfuras = item.Name != sulfuras;

                var isNotBackstagePassesAndAgedBrie = itemIsNotAgedBrie && itemIsNotBackstagePasses;

                var isQualityGreaterThanZero = item.Quality > 0;
                var isQualityLowerThanFifty = item.Quality < 50;

                if (isNotBackstagePassesAndAgedBrie)
                {
                    if (isQualityGreaterThanZero)
                    {
                        if (itemIsNotSulfuras)
                        {
                            item.Quality -= 1;
                        }
                    }
                }
                else
                {
                    if (isQualityLowerThanFifty)
                    {
                        item.Quality += 1;

                        if (item.Name == backstagePasses)
                        {
                            var isItemSellInGreaterThanElevenDays = item.SellIn < 11;
                            if (isItemSellInGreaterThanElevenDays)
                            {
                                item.Quality += 1;
                            }

                            var isItemSellInGreaterThanSixDays = item.SellIn < 6;
                            if (isItemSellInGreaterThanSixDays)
                            {
                                item.Quality += 1;
                            }
                        }
                    }
                }

                if (itemIsNotSulfuras)
                {
                    item.SellIn -= 1;
                }

                if (item.SellIn >= 0) continue;
                
                if (itemIsNotAgedBrie)
                {
                    if (itemIsNotBackstagePasses)
                    {
                        if (!isQualityGreaterThanZero) continue;
                        
                        if (itemIsNotSulfuras)
                        {
                            item.Quality -= 1;
                        }
                    }
                    else
                    {
                        item.Quality -= item.Quality;
                    }
                }
                else
                {
                    if (isQualityLowerThanFifty)
                    {
                        item.Quality += 1;
                    }
                }
            }
        }
    }
}
