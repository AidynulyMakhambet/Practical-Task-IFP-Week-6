namespace PracticalWeek6;

public sealed record QuoteSettings(decimal Base, decimal PerUnit);

public static class Task48
{
    public static Func<int, decimal> CreatePolicy(QuoteSettings settings)
    {
        if (settings.Base < 0 || settings.PerUnit < 0)
            throw new ArgumentOutOfRangeException(nameof(settings));

        var snapshot = settings with { };
        return units => units >= 0
            ? snapshot.Base + snapshot.PerUnit * units
            : throw new ArgumentOutOfRangeException(nameof(units));
    }

    public static (Func<int, decimal> Standard, Func<int, decimal> Express) CreatePolicies(
        QuoteSettings standard, QuoteSettings express) =>
        (CreatePolicy(standard), CreatePolicy(express));
}
