using csharp.Polymorphism.Strategy.AgedBrie;

namespace csharp.polymorphism.Models;

public class AgedBrie:  ItemWrapper
{
    public AgedBrie() : base(new AgedBrieUpdateUpdateStrategy())
    { }
}