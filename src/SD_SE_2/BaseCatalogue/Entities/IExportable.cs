using SD_SE_2.BaseCatalogue.IO.Export;
using SD_SE_2.Domain.InputOutput;

namespace SD_SE_2.BaseCatalogue.Entities;

public interface IExportable
{
    public void AcceptExporter(Exporter exporter);
}