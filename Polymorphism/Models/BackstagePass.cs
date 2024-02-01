using csharp.Polymorphism.Models;
using csharp.Polymorphism.Strategy;

namespace csharp.polymorphism.Models;

public class BackstagePass:  ItemWrapper
{
    public BackstagePass() : base(new BackstagePassUpdateUpdateStrategy())
    {
    }
}