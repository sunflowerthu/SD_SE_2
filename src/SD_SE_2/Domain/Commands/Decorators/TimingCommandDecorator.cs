namespace SD_SE_2.Domain.Commands.Decorators;

public class TimingCommandDecorator : CommandDecorator
{
    public TimingCommandDecorator(ICommand decorated) : base(decorated) { }

    public override void Execute()
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        try
        {
            _decorated.Execute();
        }
        finally
        {
            Console.WriteLine($"[TIMING] {_decorated.Description} executed in {stopwatch.ElapsedMilliseconds}ms");
        }
    }

    public override void Undo()
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        try
        {
            _decorated.Undo();
        }
        finally
        {
            Console.WriteLine($"[TIMING] {_decorated.Description} undone in {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}