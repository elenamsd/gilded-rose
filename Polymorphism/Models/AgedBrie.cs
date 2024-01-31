using csharp.Polymorphism.Models;
using csharp.Polymorphism.Strategy;

namespace csharp.polymorphism.Models;

public class AgedBrie:  ItemWrapper
{
    public AgedBrie() : base(new AgedBrieUpdateStrategy())
    { }
}