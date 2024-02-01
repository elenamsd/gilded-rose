using FluentAssertions;
using NUnit.Framework;

namespace csharp.Polymorphism.Strategy;

[TestFixture]
public class ConjuredUpdateStrategyTestShould
{
    [Test]
    public void DecreaseQualityOfConjuredItemsTwiceFaster()
    {
        Item item = new() { Name = "conjured-irrelevant-name", Quality = 10, SellIn = 10 };
        Item expected = new() { Name = "conjured-irrelevant-name", Quality = 8, SellIn = 9 };
        var conjuredUpdateStrategy = new ConjuredUpdateStrategy();
        
        conjuredUpdateStrategy.UpdateQuality(item);

        item.Should().BeEquivalentTo(expected);
    }

}