using SD_SE_2.Domain.UI.MenuDirectory;

namespace SD_SE_2.Domain.UI.MenuItems;

public class ExitMenuItem : IMenuItem
{
    public string Title { get; } = "Exit";
    public void Select()
    {
        Environment.Exit(0);
    }
}