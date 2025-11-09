namespace SD_SE_2.BaseCatalogue.Commands.Interfaces;

public interface ICommand
{
    void Execute();
    void Undo();
    string Description { get; }
}