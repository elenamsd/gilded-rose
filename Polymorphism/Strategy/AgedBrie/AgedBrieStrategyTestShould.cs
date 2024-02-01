using FluentAssertions;
using NUnit.Framework;

namespace csharp.Polymorphism.Strategy;

[TestFixture]
public class AgedBrieStrategyTestShould
{
    [Test]
    public void IncreaseQualityByOneWhenItGetsOlder()
    {
        Item item = new() { Name = "Irrelevant-name", Quality = 30, SellIn = 10 };
        Item expected = new() { Name = "Irrelevant-name", Quality = 31, SellIn = 9 };
        var agedBrieUpdateStrategy = new AgedBrieUpdateStrategy();

        agedBrieUpdateStrategy.UpdateQuality(item);

        item.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void IncreaseQualityByTwoWhenSellInDatePassed()
    {
        Item item = new() { Name = "Irrelevant-name", Quality = 30, SellIn = 10 };
        Item expected = new() { Name = "Irrelevant-name", Quality = 31, SellIn = 9 };
        var agedBrieUpdateStrategy = new AgedBrieUpdateStrategy();

        agedBrieUpdateStrategy.UpdateQuality(item);

        item.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void NotIncreaseQualityOverMaxQuality()
    {
        Item item = new() { Name = "Irrelevant-name", Quality = 50, SellIn = 10 };
        Item expected = new() { Name = "Irrelevant-name", Quality = 50, SellIn = 9 };
        var agedBrieUpdateStrategy = new AgedBrieUpdateStrategy();

        agedBrieUpdateStrategy.UpdateQuality(item);
        
        item.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void NotIncreaseQualityOverMaxQualityWhenSellInDatePassed()
    {
        Item item = new() { Name = "Irrelevant-name", Quality = 49, SellIn = -1 };
        Item expected = new() { Name = "Irrelevant-name", Quality = 50, SellIn = -2 };
        var agedBrieUpdateStrategy = new AgedBrieUpdateStrategy();

        agedBrieUpdateStrategy.UpdateQuality(item);
        
        item.Should().BeEquivalentTo(expected);
    }
}