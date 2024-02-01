using FluentAssertions;
using NUnit.Framework;

namespace csharp.Polymorphism.Strategy.Sulfuras;

[TestFixture]
public class SulfurasUpdateStrategyTestShould
{
    [Test]
    public void NotUpdateAnyItemProperty()
    {
        Item item = new() { Name = "Irrelevant-name", Quality = 80, SellIn = 10 };
        Item expected = new() { Name = "Irrelevant-name", Quality = 80, SellIn = 10 };
        var strategy = new SulfurasUpdateUpdateStrategy();
        
        strategy.UpdateQuality(item);

        item.Should().BeEquivalentTo(expected);
    }
}