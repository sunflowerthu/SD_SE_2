using System.ComponentModel.Design;
using SD_SE_2.Domain.Commands;
using SD_SE_2.Domain.UI.MenuDirectory;

namespace SD_SE_2.BaseCatalogue.UI.MenuItems;

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