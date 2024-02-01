using csharp.Polymorphism.Strategy.Sulfuras;

namespace csharp.polymorphism.Models;

public class Sulfuras:  ItemWrapper
{
    public Sulfuras() : base(new SulfurasUpdateUpdateStrategy())
    {
    }
}