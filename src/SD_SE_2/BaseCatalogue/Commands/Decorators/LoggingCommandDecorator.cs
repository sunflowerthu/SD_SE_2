namespace SD_SE_2.Domain.Commands.Decorators;

public class LoggingCommandDecorator : CommandDecorator
{
    public LoggingCommandDecorator(ICommand decorated) : base(decorated) { }

    public override void Execute()
    {
        Console.WriteLine($"[LOG] Executing: {_decorated.Description}");
        _decorated.Execute();
        Console.WriteLine($"[LOG] Completed: {_decorated.Description}");
    }

    public override void Undo()
    {
        Console.WriteLine($"[LOG] Undoing: {_decorated.Description}");
        _decorated.Undo();
        Console.WriteLine($"[LOG] Undone: {_decorated.Description}");
    }
}