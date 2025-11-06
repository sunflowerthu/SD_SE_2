using SD_SE_2.Domain.Commands.Decorators;

namespace SD_SE_2.Domain.Commands;

public class CommandManager
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
        }
    }

    public void Redo()
    {
        if (_redoStack.Count > 0)
        {
            var command = _redoStack.Pop();
            command.Execute();
            _undoStack.Push(command);
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