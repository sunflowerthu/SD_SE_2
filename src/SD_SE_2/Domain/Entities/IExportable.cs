using SD_SE_2.Domain.InputOutput;

namespace SD_SE_2.Domain.Entities;

public interface IExportable
{
    public void AcceptExporter(Exporter exporter);
}