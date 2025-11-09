using SD_SE_2.BaseCatalogue.Entities;
using SD_SE_2.BaseCatalogue.Enums;
using SD_SE_2.BaseCatalogue.Repositories.Interfaces;

namespace SD_SE_2.BaseCatalogue.IO.Import;

public class CsvImporter(
    IAccountRepository accountRepository,
    ICategoryRepository categoryRepository,
    IOperationRepository operationRepository) : Importer
{
    protected override void ParseData(string data)
    {
        foreach (string line in data.Split('\n'))
        {
            var parts = line.Split(',');
            if (parts.Length == 0)
            {
                continue;
            }

            string type = parts[0];
            if (type == "BankAccount")
            {
                ParseBankAccount(parts);
            }
            else if (type == "Category")
            {
                ParseCategory(parts);
            }
            else if (type == "Operation")
            {
                ParseOperation(parts);
            }
        }
    }

    private void ParseBankAccount(string[] parts)
    {
        if (parts.Length != 4)
        {
            throw new ArgumentException($"Invalid account data format. Expected 4 parts, got {parts.Length}");
        }

        try
        {
            var account = new BankAccount
            {
                Id = Guid.Parse(parts[1]),
                Name = parts[2].Trim(),
                Balance = decimal.Parse(parts[3]),
            };

            accountRepository.Add(account);
            Console.WriteLine($"[IMPORT] Account imported: {account.Name} ({account.Balance})");
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Failed to parse account data: {string.Join(",", parts)} - {ex.Message}");
        }
    }

    private void ParseCategory(string[] parts)
    {
        if (parts.Length != 4)
        {
            throw new ArgumentException($"Invalid category data format. Expected 3 parts, got {parts.Length}");
        }

        try
        {
            var category = new Category
            {
                Id = Guid.Parse(parts[1]),
                Name = parts[2].Trim(),
                Type = Enum.Parse<CategoryType>(parts[3])
            };

            categoryRepository.Add(category);
            Console.WriteLine($"[IMPORT] Category imported: {category.Name} ({category.Type})");
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Failed to parse category data: {string.Join(",", parts)} - {ex.Message}");
        }
    }

    private void ParseOperation(string[] parts)
    {
        if (parts.Length != 8)
        {
            throw new ArgumentException($"Invalid operation data format. Expected 7 parts, got {parts.Length}");
        }

        try
        {
            var operation = new Operation
            {
                Id = Guid.Parse(parts[1]),
                Date = DateTime.Parse(parts[2]),
                Amount = decimal.Parse(parts[3]),
                Type = Enum.Parse<OperationType>(parts[4]),
                Description = parts[5].Trim(),
                AccountId = Guid.Parse(parts[6]),
                CategoryId = Guid.Parse(parts[7])
            };

            operationRepository.Add(operation);
            Console.WriteLine(
                $"[IMPORT] Operation imported: {operation.Description} ({operation.Amount} {operation.Type})");
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Failed to parse operation data: {string.Join(",", parts)} - {ex.Message}");
        }
    }
}