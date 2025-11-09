using SD_SE_2.BaseCatalogue.Commands.Interfaces;

namespace SD_SE_2.BaseCatalogue.Commands.Decorators;

public abstract class CommandDecorator : ICommand
{
    protected readonly ICommand Decorated;

    protected CommandDecorator(ICommand decorated)
    {
        Decorated = decorated;
    }

    public virtual string Description => Decorated.Description;

    public virtual void Execute()
    {
        Decorated.Execute();
    }

    public virtual void Undo()
    {
        Decorated.Undo();
    }
}