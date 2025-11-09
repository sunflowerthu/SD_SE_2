namespace SD_SE_2.Domain.Commands;

public interface ICommand
{
    void Execute();
    void Undo();
    string Description { get; }
}