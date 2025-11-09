using SD_SE_2.BaseCatalogue.Entities;
using SD_SE_2.BaseCatalogue.Facades.Interfaces;
using SD_SE_2.BaseCatalogue.IO.Export;
using SD_SE_2.BaseCatalogue.IO.Import;
using SD_SE_2.BaseCatalogue.Repositories.Interfaces;

namespace SD_SE_2.BaseCatalogue.Facades;

public class DataTransferFacade : IDataTransferFacade
{
    private readonly IAccountRepository _accountRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IOperationRepository _operationRepository;
    private readonly Dictionary<string, Exporter> _exporters;
    private readonly Dictionary<string, Importer> _importers;

    public DataTransferFacade(
        IAccountRepository accountRepository,
        ICategoryRepository categoryRepository,
        IOperationRepository operationRepository,
        IEnumerable<Exporter> exporters,
        IEnumerable<Importer> importers)
    {
        _accountRepository = accountRepository;
        _categoryRepository = categoryRepository;
        _operationRepository = operationRepository;
        _exporters = exporters.ToDictionary(e => e.GetType().Name.Replace("Exporter", "").ToLower());
        _importers = importers.ToDictionary(i => i.GetType().Name.Replace("Importer", "").ToLower());
    }

    public void ExportData(string format, string dataType, string filePath)
    {
        if (!_exporters.TryGetValue(format.ToLower(), out var exporter))
        {
            throw new ArgumentException($"Unsupported export format: {format}. Available: {string.Join(", ", _exporters.Keys)}");
        }

        var data = GetDataForExport(dataType);
        exporter.ExecuteExport(data, filePath);
        Console.WriteLine($"Exported {dataType} to {filePath} in {format} format");
    }

    public void ImportData(string format, string filePath)
    {
        if (!_importers.TryGetValue(format.ToLower(), out var importer))
        {
            throw new ArgumentException($"Unsupported import format: {format}. Available: {string.Join(", ", _importers.Keys)}");
        }

        importer.ExecuteImport(filePath);
        Console.WriteLine($"Imported data from {filePath} in {format} format");
    }

    public List<string> GetSupportedExportFormats() => _exporters.Keys.ToList();
    public List<string> GetSupportedImportFormats() => _importers.Keys.ToList();

    private IEnumerable<IExportable> GetDataForExport(string dataType)
    {
        return dataType.ToLower() switch
        {
            "accounts" => _accountRepository.GetAll(),
            "categories" => _categoryRepository.GetAll(),
            "operations" => _operationRepository.GetAll(),
            "all" => GetAllData(),
            _ => throw new ArgumentException($"Unknown data type: {dataType}")
        };
    }

    private IEnumerable<IExportable> GetAllData()
    {
        return _accountRepository.GetAll()
            .Concat(_categoryRepository.GetAll().Cast<IExportable>())
            .Concat(_operationRepository.GetAll());
    }
}