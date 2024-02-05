using FluentAssertions;
using NUnit.Framework;

namespace csharp.Polymorphism.Strategy.Conjured;

[TestFixture]
public class ConjuredUpdateStrategyTestShould
{
    [Test]
    public void DecreaseQualityOfConjuredItemsTwiceFaster()
    {
        Item item = new() { Name = "conjured-irrelevant-name", Quality = 10, SellIn = 10 };
        Item expected = new() { Name = "conjured-irrelevant-name", Quality = 8, SellIn = 9 };
        var strategy = new ConjuredUpdateQuality();
        
        strategy.UpdateQuality(item);

        item.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void DecreaseQualityOfConjuredItemsTwiceFasterWhenSellInDateIsOver()
    {
        Item item = new() { Name = "conjured-irrelevant-name", Quality = 10, SellIn = 0 };
        Item expected = new() { Name = "conjured-irrelevant-name", Quality = 6, SellIn = -1 };
        var strategy = new ConjuredUpdateQuality();
        
        strategy.UpdateQuality(item);

        item.Should().BeEquivalentTo(expected);
    }

}