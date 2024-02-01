using csharp.Polymorphism.Strategy;

namespace csharp.polymorphism.Models;
public class Conjured: ItemWrapper
{
    public Conjured() : base(new ConjuredUpdateUpdateStrategy())
    {
    }
    
}