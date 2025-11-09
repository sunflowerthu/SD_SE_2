using SD_SE_2.BaseCatalogue.Commands.Decorators;
using SD_SE_2.BaseCatalogue.Commands.Interfaces;

namespace SD_SE_2.BaseCatalogue.Commands;

public class CommandManager : ICommandManager
{
    private readonly Stack<ICommand> _undoStack = new();
    private readonly Stack<ICommand> _redoStack = new();
    private readonly bool _enableTiming;
    private readonly bool _enableLogging;

    public CommandManager(bool enableTiming = true, bool enableLogging = true)
    {
        _enableTiming = enableTiming;
        _enableLogging = enableLogging;
    }

    public void ExecuteCommand(ICommand command)
    {
        var decoratedCommand = DecorateCommand(command);
        decoratedCommand.Execute();
        _undoStack.Push(decoratedCommand);
        _redoStack.Clear();
    }

    public void Undo()
    {
        if (_undoStack.Count > 0)
        {
            var command = _undoStack.Pop();
            command.Undo();
            _redoStack.Push(command);
            Console.WriteLine("Command undone");
        }
        else
        {
            Console.WriteLine("Too few commands");
        }
    }

    public void Redo()
    {
        if (_redoStack.Count > 0)
        {
            var command = _redoStack.Pop();
            command.Execute();
            _undoStack.Push(command);
            Console.WriteLine("Command redone");
        }
        else
        {
            Console.WriteLine("Too few commands");
        }
    }

    private ICommand DecorateCommand(ICommand command)
    {
        ICommand decorated = command;

        if (_enableLogging)
        {
            decorated = new LoggingCommandDecorator(decorated);
        }

        if (_enableTiming)
        {
            decorated = new TimingCommandDecorator(decorated);
        }

        return decorated;
    }

    public void PrintStatus()
    {
        Console.WriteLine($"Commands: Undo stack {_undoStack.Count}, Redo stack {_redoStack.Count}");
    }
}