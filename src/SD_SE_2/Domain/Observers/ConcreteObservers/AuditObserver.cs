using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Observers.Interfaces;

public class AuditObserver : IOperationObserver
{
    private readonly List<string> _auditLog = new();

    public void OnOperationAdded(Operation operation)
    {
        var message = $"[AUDIT] {DateTime.Now:yyyy-MM-dd HH:mm} | ADD | " +
                      $"{operation.Type} | {operation.Amount:C} | {operation.Description} | " +
                      $"Account: {operation.AccountId} | Category: {operation.CategoryId}";
        
        _auditLog.Add(message);
        Console.WriteLine(message);
    }

    public void OnOperationUpdated(Operation oldOperation, Operation newOperation)
    {
        var message = $"[AUDIT] {DateTime.Now:yyyy-MM-dd HH:mm} | UPDATE | " +
                      $"{oldOperation.Description} ({oldOperation.Amount:C}) -> " +
                      $"{newOperation.Description} ({newOperation.Amount:C})";
        
        _auditLog.Add(message);
        Console.WriteLine(message);
    }

    public void OnOperationDeleted(Operation operation)
    {
        var message = $"[AUDIT] {DateTime.Now:yyyy-MM-dd HH:mm} | DELETE | " +
                      $"{operation.Type} | {operation.Amount:C} | {operation.Description}";
        
        _auditLog.Add(message);
        Console.WriteLine(message);
    }

    public void OnBalanceRecalculated(Guid accountId, decimal newBalance)
    {
        var message = $"[AUDIT] {DateTime.Now:yyyy-MM-dd HH:mm} | BALANCE_RECALC | " +
                      $"Account: {accountId} | New Balance: {newBalance:C}";
        
        _auditLog.Add(message);
        Console.WriteLine(message);
    }

    public void PrintAuditReport()
    {
        Console.WriteLine("\n=== AUDIT REPORT ===");
        Console.WriteLine($"Total events: {_auditLog.Count}");
        foreach (var entry in _auditLog)
        {
            Console.WriteLine(entry);
        }
    }

    public List<string> GetAuditLog() => _auditLog.ToList();
}