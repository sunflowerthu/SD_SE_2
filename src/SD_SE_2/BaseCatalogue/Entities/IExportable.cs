using SD_SE_2.BaseCatalogue.IO.Export;

namespace SD_SE_2.BaseCatalogue.Entities;

public interface IExportable
{
    public void AcceptExporter(Exporter exporter);
}