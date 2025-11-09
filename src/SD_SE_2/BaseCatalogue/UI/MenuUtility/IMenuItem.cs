namespace SD_SE_2.Domain.UI.MenuDirectory;

public interface IMenuItem
{
    /// <summary>
    /// Заголовок элемента меню.
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Задача, которую выполняет элемент меню.
    /// </summary>
    public void Select();
}