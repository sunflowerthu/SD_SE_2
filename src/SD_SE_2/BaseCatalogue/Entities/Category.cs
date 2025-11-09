using SD_SE_2.BaseCatalogue.Enums;
using SD_SE_2.BaseCatalogue.IO.Export;
using SD_SE_2.Domain.InputOutput;

namespace SD_SE_2.BaseCatalogue.Entities;

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