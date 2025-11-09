using SD_SE_2.BaseCatalogue.Commands.Interfaces;
using SD_SE_2.BaseCatalogue.UI.MenuUtility;

namespace SD_SE_2.BaseCatalogue.UI.MenuItems.Actions;

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