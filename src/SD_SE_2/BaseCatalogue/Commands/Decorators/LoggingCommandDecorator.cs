using SD_SE_2.BaseCatalogue.Commands.Interfaces;

namespace SD_SE_2.BaseCatalogue.Commands.Decorators;

public class LoggingCommandDecorator(ICommand decorated) : CommandDecorator(decorated)
{
    public override void Execute()
    {
        Console.WriteLine($"[LOG] Executing: {Decorated.Description}");
        Decorated.Execute();
        Console.WriteLine($"[LOG] Completed: {Decorated.Description}");
    }

    public override void Undo()
    {
        Console.WriteLine($"[LOG] Undoing: {Decorated.Description}");
        Decorated.Undo();
        Console.WriteLine($"[LOG] Undone: {Decorated.Description}");
    }
}