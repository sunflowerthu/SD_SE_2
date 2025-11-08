using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.InputOutput;

public abstract class Exporter
{
    public List<string> StringList { get; } = new();
    public abstract void Export(BankAccount account);
    public abstract void Export(Category category);
    public abstract void Export(Operation operation);

    public void ExecuteExport(IEnumerable<IExportable> collection, string path)
    {
        foreach(var entity in collection)
        {
            entity.AcceptExporter(this);
        }

        string data = string.Join('\n', StringList);
        SaveFile(path, data);
    }

    public abstract void SaveFile(string path, string data);
}