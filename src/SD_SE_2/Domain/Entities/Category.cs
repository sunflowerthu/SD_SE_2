using SD_SE_2.Domain.Enums;
using SD_SE_2.Domain.InputOutput;

namespace SD_SE_2.Domain.Entities;

public class Category : Entity, IExportable
{
    public CategoryType Type { get; init; }

    public Category(string name, CategoryType type)
    {
        Type = type;
        Name = name;
    }

    public Category()
    { }


    public void AcceptExporter(Exporter exporter)
    {
        exporter.Export(this);
    }
}