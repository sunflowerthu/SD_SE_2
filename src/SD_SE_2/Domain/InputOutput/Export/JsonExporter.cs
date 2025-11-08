using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.InputOutput;

public class JsonExporter : Exporter
{
    public override void Export(BankAccount account)
    {
        var exportObject = new
        {
            type = "BankAccount",
            data = account
        };
        string json = JsonConvert.SerializeObject(exportObject, Formatting.None);
        StringList.Add(json);
    }

    public override void Export(Category category)
    {
        var exportObject = new
        {
            type = "Category", 
            data = category
        };
        string json = JsonConvert.SerializeObject(exportObject, Formatting.None);
        StringList.Add(json);
    }

    public override void Export(Operation operation)
    {
        var exportObject = new
        {
            type = "Operation",
            data = operation
        };
        string json = JsonConvert.SerializeObject(exportObject, Formatting.None);
        StringList.Add(json);
    }

    public override void SaveFile(string path, string data)
    {
        try
        {
            var jsonLines = data.Split('\n')
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => JObject.Parse(line))
                .ToArray();

            var jsonArray = JArray.FromObject(jsonLines);
            File.WriteAllText(path, jsonArray.ToString(Formatting.Indented));
            
            Console.WriteLine("Saved to file.");
        }
        catch (JsonException)
        {
            Console.WriteLine("Invalid JSON format");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Invalid file path");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }
}