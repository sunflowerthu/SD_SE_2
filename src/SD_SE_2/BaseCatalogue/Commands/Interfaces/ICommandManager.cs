namespace SD_SE_2.BaseCatalogue.Commands.Interfaces;

public interface ICommandManager
{
    void ExecuteCommand(ICommand command);
    void Undo();
    void Redo();
}