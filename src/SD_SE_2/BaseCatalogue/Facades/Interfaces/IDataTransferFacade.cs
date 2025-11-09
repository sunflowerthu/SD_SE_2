namespace SD_SE_2.BaseCatalogue.Facades.Interfaces;

public interface IDataTransferFacade
{ 
    void ExportData(string format, string dataType, string filePath); 
    void ImportData(string format, string filePath);
    List<string> GetSupportedExportFormats();
    List<string> GetSupportedImportFormats();
}