using csharp.Polymorphism.Strategy;

namespace csharp.polymorphism.Models;

public class Regular: ItemWrapper
{
    public Regular() : base(new RegularUpdateStrategy()){}
}