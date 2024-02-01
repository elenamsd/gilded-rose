using FluentAssertions;
using NUnit.Framework;

namespace csharp.Polymorphism.Strategy.AgedBrie;

[TestFixture]
public class AgedBrieStrategyTestShould
{
    [Test]
    public void IncreaseQualityByOneWhenItGetsOlder()
    {
        Item item = new() { Name = "Aged Brie", Quality = 30, SellIn = 10 };
        Item expected = new() { Name = "Aged Brie", Quality = 31, SellIn = 9 };
        var strategy = new AgedBrieUpdateUpdateStrategy();

        strategy.UpdateQuality(item);

        item.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void IncreaseQualityByTwoWhenSellInDatePassed()
    {
        Item item = new() { Name = "Aged Brie", Quality = 30, SellIn = 10 };
        Item expected = new() { Name = "Aged Brie", Quality = 31, SellIn = 9 };
        var strategy = new AgedBrieUpdateUpdateStrategy();

        strategy.UpdateQuality(item);

        item.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void NotIncreaseQualityOverMaxQuality()
    {
        Item item = new() { Name = "Aged Brie", Quality = 50, SellIn = 10 };
        Item expected = new() { Name = "Aged Brie", Quality = 50, SellIn = 9 };
        var strategy = new AgedBrieUpdateUpdateStrategy();

        strategy.UpdateQuality(item);
        
        item.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void NotIncreaseQualityOverMaxQualityWhenSellInDatePassed()
    {
        Item item = new() { Name = "Aged Brie", Quality = 49, SellIn = -1 };
        Item expected = new() { Name = "Aged Brie", Quality = 50, SellIn = -2 };
        var strategy = new AgedBrieUpdateUpdateStrategy();

        strategy.UpdateQuality(item);
        
        item.Should().BeEquivalentTo(expected);
    }
}