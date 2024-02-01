using csharp.Polymorphism.Strategy.Regular;

namespace csharp.polymorphism.Models;

public class Regular: ItemWrapper
{
    public Regular() : base(new RegularUpdateUpdateStrategy()){}
}