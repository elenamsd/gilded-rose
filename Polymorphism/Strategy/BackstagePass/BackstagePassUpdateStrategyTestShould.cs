using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace csharp.Polymorphism.Strategy;

[TestFixture]
public class BackstagePassUpdateStrategyTestShould
{
    [Test]
    public void IncreaseBackstagePassQualityByOneWhenSellInGreaterThanTenDays()
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 5 };
        var expected = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 14, Quality = 6 };
        var backstagePassUpdateStrategy = new BackstagePassUpdateStrategy();
        
        backstagePassUpdateStrategy.UpdateQuality(item);
        
        item.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void IncreaseBackstagePassQualityByTwoWhenSellInLowerOrEqualThanTenDays()
    { 
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 5 };
        var expected = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 7 };

        var backstagePassUpdateStrategy = new BackstagePassUpdateStrategy();
        
        backstagePassUpdateStrategy.UpdateQuality(item);
        
        item.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void IncreaseBackstagePassQualityByThreeWhenSellInLowerOrEqualThanFiveDays()
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 5 };
        var expected = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 8 };
        
        var backstagePassUpdateStrategy = new BackstagePassUpdateStrategy();
        
        backstagePassUpdateStrategy.UpdateQuality(item);
        
        item.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void DropBackstagePassQualityToZeroWhenSellInLowerOrEqualThanZeroDays()
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 5 };
        var expected = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 0 };

        var backstagePassUpdateStrategy = new BackstagePassUpdateStrategy();
        
        backstagePassUpdateStrategy.UpdateQuality(item);
        
        item.Should().BeEquivalentTo(expected);
    }
}