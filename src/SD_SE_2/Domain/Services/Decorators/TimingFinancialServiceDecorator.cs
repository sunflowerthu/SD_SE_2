using SD_SE_2.Domain.Entities;

namespace SD_SE_2.Domain.Services;

public class TimingFinancialServiceDecorator : IFinancialService
{
    private readonly IFinancialService _decorated;
    private readonly Action<string> _logger;

    public TimingFinancialServiceDecorator(IFinancialService decorated, Action<string>? logger = null)
    {
        _decorated = decorated;
        _logger = logger ?? Console.WriteLine;
    }

    public void AddOperation(Operation operation)
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        try
        {
            _decorated.AddOperation(operation);
        }
        finally
        {
            _logger($"[TIMING] AddOperation completed in {stopwatch.ElapsedMilliseconds}ms");
        }
    }

    public void UpdateOperation(Operation operation)
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        try
        {
            _decorated.UpdateOperation(operation);
        }
        finally
        {
            _logger($"[TIMING] UpdateOperation completed in {stopwatch.ElapsedMilliseconds}ms");
        }
    }

    public void DeleteOperation(Guid operationId)
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        try
        {
            _decorated.DeleteOperation(operationId);
        }
        finally
        {
            _logger($"[TIMING] DeleteOperation completed in {stopwatch.ElapsedMilliseconds}ms");
        }
    }

    public decimal RecalculateBalance(Guid accountId)
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        try
        {
            return _decorated.RecalculateBalance(accountId);
        }
        finally
        {
            _logger($"[TIMING] RecalculateBalance completed in {stopwatch.ElapsedMilliseconds}ms");
        }
    }

    public void RecalculateAllBalances()
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        try
        {
            _decorated.RecalculateAllBalances();
        }
        finally
        {
            _logger($"[TIMING] RecalculateAllBalances completed in {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}