namespace SD_SE_2.Domain.Commands;

public interface ICommandManager
{
    void ExecuteCommand(ICommand command);
    void Undo();
    void Redo();
}