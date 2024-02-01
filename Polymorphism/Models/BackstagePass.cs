using csharp.Polymorphism.Strategy.BackstagePass;

namespace csharp.polymorphism.Models;

public class BackstagePass:  ItemWrapper
{
    public BackstagePass() : base(new BackstagePassUpdateUpdateStrategy())
    {
    }
}