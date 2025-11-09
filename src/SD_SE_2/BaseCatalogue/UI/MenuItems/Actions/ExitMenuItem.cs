using SD_SE_2.BaseCatalogue.UI.MenuUtility;

namespace SD_SE_2.BaseCatalogue.UI.MenuItems.Actions;

public class ExitMenuItem : IMenuItem
{
    public string Title { get; } = "Exit";
    public void Select()
    {
        Environment.Exit(0);
    }
}