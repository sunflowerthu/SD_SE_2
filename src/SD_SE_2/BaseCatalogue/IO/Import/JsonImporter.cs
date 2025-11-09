using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Repositories;

namespace SD_SE_2.Domain.InputOutput.Import;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class JsonImporter(
    IAccountRepository accountRepository,
    ICategoryRepository categoryRepository,
    IOperationRepository operationRepository) : Importer
{
    protected override void ParseData(string data)
    {
        try
        {
            var jsonArray = JArray.Parse(data);
            
            foreach (var item in jsonArray)
            {
                try
                {
                    string objectType = item["type"]?.ToString();
                    var objectData = item["data"];

                    switch (objectType)
                    {
                        case "BankAccount":
                            var account = objectData.ToObject<BankAccount>();
                            ParseBankAccount(account);
                            break;
                        case "Category":
                            var category = objectData.ToObject<Category>();
                            ParseCategory(category);
                            break;
                        case "Operation":
                            var operation = objectData.ToObject<Operation>();
                            ParseOperation(operation);
                            break;
                        default:
                            Console.WriteLine($"[IMPORT WARNING] Unknown object type: {objectType}");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[IMPORT WARNING] Failed to parse object: {item} - {ex.Message}");
                }
            }
        }
        catch (JsonException ex)
        {
            throw new ArgumentException($"Invalid JSON format: {ex.Message}");
        }
    }

    private void ParseBankAccount(BankAccount account)
    {
        try
        {
            accountRepository.Add(account);
            Console.WriteLine($"[IMPORT] Account imported: {account.Name} ({account.Balance})");
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Failed to parse account: {account.Name} - {ex.Message}");
        }
    }

    private void ParseCategory(Category category)
    {
        try
        {
            categoryRepository.Add(category);
            Console.WriteLine($"[IMPORT] Category imported: {category.Name} ({category.Type})");
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Failed to parse category: {category.Name} - {ex.Message}");
        }
    }

    private void ParseOperation(Operation operation)
    {
        try
        {
            operationRepository.Add(operation);
            Console.WriteLine($"[IMPORT] Operation imported: {operation.Description} ({operation.Amount} {operation.Type})");
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Failed to parse operation: {operation.Description} - {ex.Message}");
        }
    }
}