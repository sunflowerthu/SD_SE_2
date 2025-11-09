using SD_SE_2.Domain.Commands;
using SD_SE_2.Domain.UI.MenuDirectory;

namespace SD_SE_2.BaseCatalogue.UI.MenuItems;

public class UndoLastActionMenuItem(ICommandManager commandManager) : IMenuItem
{
    public string Title { get; } = "Undo last action";
    public void Select()
    {
        try
        {
            commandManager.Undo();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}