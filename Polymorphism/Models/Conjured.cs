using csharp.Polymorphism.Strategy.Conjured;

namespace csharp.polymorphism.Models;
public class Conjured: ItemWrapper
{
    public Conjured() : base(new ConjuredUpdateUpdateStrategy())
    {
    }
    
}