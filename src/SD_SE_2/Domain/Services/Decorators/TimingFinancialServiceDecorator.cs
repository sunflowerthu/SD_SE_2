using SD_SE_2.Domain.Entities;
using SD_SE_2.Domain.Services;

public class TimingFinancialServiceDecorator : IFinancialService
{
    private readonly IFinancialService _decorated;

    public TimingFinancialServiceDecorator(IFinancialService decorated)
    {
        _decorated = decorated;
    }

    public void AddOperation(Operation operation)
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        _decorated.AddOperation(operation);
        Console.WriteLine($"[TIMING] AddOperation completed in {stopwatch.ElapsedMilliseconds}ms");
    }

    public void UpdateOperation(Operation operation)
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        _decorated.UpdateOperation(operation);
        Console.WriteLine($"[TIMING] UpdateOperation completed in {stopwatch.ElapsedMilliseconds}ms");
    }

    public void DeleteOperation(Guid operationId)
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        _decorated.DeleteOperation(operationId);
        Console.WriteLine($"[TIMING] DeleteOperation completed in {stopwatch.ElapsedMilliseconds}ms");
    }

    public decimal RecalculateBalance(Guid accountId)
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        var result = _decorated.RecalculateBalance(accountId);
        Console.WriteLine($"[TIMING] RecalculateBalance completed in {stopwatch.ElapsedMilliseconds}ms");
        return result;
    }
}