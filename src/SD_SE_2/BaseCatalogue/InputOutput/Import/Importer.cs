using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.InputOutput.Import;

public abstract class Importer
{
    public void ExecuteImport(string path)
    {
        var data = ReadFile(path);
        ParseData(data);
    }

    public string ReadFile(string path)
    {
        return File.ReadAllText(path);
    }

    protected abstract void ParseData(string data);
}