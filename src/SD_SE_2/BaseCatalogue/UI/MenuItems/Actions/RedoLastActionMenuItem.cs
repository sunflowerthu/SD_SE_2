using SD_SE_2.BaseCatalogue.Commands.Interfaces;
using SD_SE_2.BaseCatalogue.UI.MenuUtility;

namespace SD_SE_2.BaseCatalogue.UI.MenuItems.Actions;

public class RedoLastActionMenuItem(ICommandManager commandManager) : IMenuItem
{
    public string Title { get; } = "Redo Last Action";
    public void Select()
    {
        try
        {
            commandManager.Redo();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}