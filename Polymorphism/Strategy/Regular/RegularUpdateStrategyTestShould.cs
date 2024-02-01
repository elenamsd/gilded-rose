using FluentAssertions;
using NUnit.Framework;

namespace csharp.Polymorphism.Strategy.Regular;

[TestFixture]
public class RegularUpdateStrategyTestShould
{
    [Test]
    public void DecreaseQualityAndSellInOfRegularItem()
    {
        Item item = new() { Name = "Irrelevant-name", Quality = 5, SellIn = 5 };
        Item expected = new() { Name = "Irrelevant-name", Quality = 4, SellIn = 4 };
        var strategy = new RegularUpdateUpdateStrategy();
        
        strategy.UpdateQuality(item);

        item.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void NotAllowItemsWithNegativeQuality()
    {
        Item item = new() { Name = "Irrelevant-name", Quality = 0, SellIn = 0 };
        Item expected = new() { Name = "Irrelevant-name", Quality = 0, SellIn = -1 };
        var strategy = new RegularUpdateUpdateStrategy();
        
        strategy.UpdateQuality(item);

        item.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void DecreaseQualityTwiceFasterWhenSellInIsLowerOrEqualThanZeroDays()
    {
        Item item = new() { Name = "Irrelevant-name", Quality = 4, SellIn = 0 };
        Item expected = new() { Name = "Irrelevant-name", Quality = 2, SellIn =-1  };
        var strategy = new RegularUpdateUpdateStrategy();

        strategy.UpdateQuality(item);

        item.Should().BeEquivalentTo(expected);
    }
}