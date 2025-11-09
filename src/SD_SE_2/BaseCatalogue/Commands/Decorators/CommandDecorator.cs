namespace SD_SE_2.Domain.Commands.Decorators;

public abstract class CommandDecorator : ICommand
{
    protected readonly ICommand _decorated;

    protected CommandDecorator(ICommand decorated)
    {
        _decorated = decorated;
    }

    public virtual string Description => _decorated.Description;

    public virtual void Execute()
    {
        _decorated.Execute();
    }

    public virtual void Undo()
    {
        _decorated.Undo();
    }
}