using csharp.Polymorphism.Models;
using csharp.Polymorphism.Strategy;

namespace csharp.polymorphism.Models;

public class Sulfuras:  ItemWrapper
{
    public Sulfuras() : base(new SulfurasUpdateStrategy())
    {
    }
}