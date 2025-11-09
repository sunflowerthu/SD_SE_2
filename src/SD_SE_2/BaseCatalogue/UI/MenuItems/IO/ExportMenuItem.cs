using SD_SE_2.BaseCatalogue.Facades.Interfaces;
using SD_SE_2.BaseCatalogue.UI.MenuUtility;

namespace SD_SE_2.BaseCatalogue.UI.MenuItems.IO;

public class ExportMenuItem(IDataTransferFacade dataTransferFacade) : IMenuItem
{
    public string Title { get; } = "Export Data";

    public void Select()
    {
        try
        {
            var formats = dataTransferFacade.GetSupportedExportFormats();
            Console.WriteLine("Available export formats: " + string.Join(", ", formats));
            Console.Write("Select format: ");
            var format = Console.ReadLine();

            Console.WriteLine("Select data type:");
            Console.WriteLine("1. Accounts");
            Console.WriteLine("2. Categories"); 
            Console.WriteLine("3. Operations");
            Console.WriteLine("4. All data");
            Console.Write("Enter choice (1-4): ");
            var choice = Console.ReadLine();

            var dataType = choice switch
            {
                "1" => "accounts",
                "2" => "categories",
                "3" => "operations", 
                "4" => "all",
                _ => throw new ArgumentException("Invalid choice")
            };

            Console.Write("Enter file path: ");
            var filePath = Console.ReadLine();

            dataTransferFacade.ExportData(format, dataType, filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during export: {ex.Message}");
        }
    }
}