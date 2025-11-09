using SD_SE_2.BaseCatalogue.Entities;

namespace SD_SE_2.BaseCatalogue.IO.Export;

public class CsvExporter : Exporter
{
    public override void Export(BankAccount account)
    {
        StringList.Add(
            $"BankAccount,{account.Id},{account.Name},{account.IsActive}");
    }

    public override void Export(Category category)
    {
        StringList.Add(
            $"Category,{category.Id},{category.Name},{category.Type}");
    }

    public override void Export(Operation operation)
    {
        StringList.Add(
            $"Operation,{operation.Id},{operation.Name}," +
            $"{operation.Description},{operation.CategoryId}," +
            $"{operation.AccountId},{operation.Amount}");
    }

    public override void SaveFile(string path, string data)
    {
        try
        {
            File.WriteAllText(path, data);
            Console.WriteLine("Saved to file.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("пупупу");
        }
        catch (Exception)
        {
            Console.WriteLine("cringe");
        }
    }
}