using SD_SE_2.BaseCatalogue.Commands.Interfaces;

namespace SD_SE_2.BaseCatalogue.Commands.Decorators;

public class TimingCommandDecorator(ICommand decorated) : CommandDecorator(decorated)
{
    public override void Execute()
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        try
        {
            Decorated.Execute();
        }
        finally
        {
            Console.WriteLine($"[TIMING] {Decorated.Description} executed in {stopwatch.ElapsedMilliseconds}ms");
        }
    }

    public override void Undo()
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        try
        {
            Decorated.Undo();
        }
        finally
        {
            Console.WriteLine($"[TIMING] {Decorated.Description} undone in {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}