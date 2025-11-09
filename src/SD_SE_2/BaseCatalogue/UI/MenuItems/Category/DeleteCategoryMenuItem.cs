using SD_SE_2.Domain.UI.MenuDirectory;
using SD_SE_2.Facades;

namespace SD_SE_2.Domain.UI.MenuItems;

public class DeleteCategoryMenuItem(ICategoryFacade categoryFacade) : IMenuItem
{
    public string Title { get; } = "Delete Category";

    public void Select()
    {
        try
        {
            Console.WriteLine("Enter category ID to delete: ");
            Guid categoryId = Guid.Parse(Console.ReadLine());

            categoryFacade.DeleteCategory(categoryId);
            Console.WriteLine("Category deletion command executed!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid category ID format.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting category: {ex.Message}");
        }
    }
}