using SD_SE_2.BaseCatalogue.Facades;
using SD_SE_2.Domain.UI.MenuDirectory;

namespace SD_SE_2.Domain.UI.MenuItems;

public class ImportMenuItem(DataTransferFacade dataTransferFacade) : IMenuItem
{
    public string Title { get; } = "Import Data";

    public void Select()
    {
        try
        {
            var formats = dataTransferFacade.GetSupportedImportFormats();
            Console.WriteLine("Available import formats: " + string.Join(", ", formats));
            Console.Write("Select format: ");
            var format = Console.ReadLine();

            Console.Write("Enter file path: ");
            var filePath = Console.ReadLine();

            dataTransferFacade.ImportData(format, filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during import: {ex.Message}");
        }
    }
}