using csharp.Polymorphism.Models;
using csharp.Polymorphism.Strategy.AgedBrie;
using csharp.Polymorphism.Strategy.BackstagePass;
using csharp.Polymorphism.Strategy.Conjured;
using csharp.Polymorphism.Strategy.Regular;
using csharp.Polymorphism.Strategy.Sulfuras;
using NUnit.Framework;

namespace csharp.Polymorphism;

public static class UpdateQualityFactory
{
    public static IUpdateQuality Create(string itemName)
    {
        const string agedBrie = "Aged Brie";
        const string backstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        const string sulfuras = "Sulfuras, Hand of Ragnaros";
        const string conjured = "Conjured";
        
        if (itemName.Contains(agedBrie))
        {
            return new AgedBrieUpdateQuality();
        }
        
        if (itemName.Contains(backstagePasses))
        {
            return new BackstagePassUpdateQuality();
        }
        
        if (itemName.Contains(sulfuras))
        {
            return new SulfurasUpdateQuality();
        }

        if (itemName.Contains(conjured))
        {
            return new ConjuredUpdateQuality();
        }

        return new RegularUpdateQuality();
    }
}