using FluentAssertions;
using NUnit.Framework;

namespace csharp.Polymorphism.Strategy.BackstagePass;

[TestFixture]
public class BackstagePassUpdateStrategyTestShould
{
    [Test]
    public void IncreaseBackstagePassQualityByOneWhenSellInGreaterThanTenDays()
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 5 };
        var expected = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 14, Quality = 6 };
        var strategy = new BackstagePassUpdateUpdateStrategy();
        
        strategy.UpdateQuality(item);
        
        item.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void IncreaseBackstagePassQualityByTwoWhenSellInLowerOrEqualThanTenDays()
    { 
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 5 };
        var expected = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 7 };
        var strategy = new BackstagePassUpdateUpdateStrategy();
        
        strategy.UpdateQuality(item);
        
        item.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void IncreaseBackstagePassQualityByThreeWhenSellInLowerOrEqualThanFiveDays()
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 5 };
        var expected = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 8 };
        var strategy = new BackstagePassUpdateUpdateStrategy();
        
        strategy.UpdateQuality(item);
        
        item.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void DropBackstagePassQualityToZeroWhenSellInLowerOrEqualThanZeroDays()
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 5 };
        var expected = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 0 };
        var strategy = new BackstagePassUpdateUpdateStrategy();
        
        strategy.UpdateQuality(item);
        
        item.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void NotIncreaseQualityOverMaxQuality()
    {
        Item item = new() { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 50, SellIn = 10 };
        Item expected = new() { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 50, SellIn = 9 };
        var strategy = new BackstagePassUpdateUpdateStrategy();

        strategy.UpdateQuality(item);
        
        item.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void UpdateQualityOverTwoWeeks()
    {
        Item item = new() { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 20, SellIn = 15 };
        Item expected = new() { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 47, SellIn = 1 };
        var strategy = new BackstagePassUpdateUpdateStrategy();

        for (var day = 0; day < 14; day++)
            strategy.UpdateQuality(item);

        item.Should().BeEquivalentTo(expected);
    }
}