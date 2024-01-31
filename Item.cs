namespace csharp
{
    public class Item
    {
        public string Name { get; set; } 
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }  
    }

    /*public class RegularItem : Item, IUpdateQuality
    {
        public void UpdateQuality()
        {
            if (IsQualityGreaterThanMinimumQuality(item))
            {
                Quality -= 1;
            }
                
            SellIn -= 1;
                
            if (IsItemSellable(item)) return;
                
            if (!IsQualityGreaterThanMinimumQuality(item)) return;
                    
            Quality -= 1;
            
            throw new System.NotImplementedException();
        }
    }

    public interface IUpdateQuality
    {
        public void UpdateQuality();
    }*/
}
