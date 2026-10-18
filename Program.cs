using PracticalWeek6;

static class Checks
{
    private static int passed;

    private static void Equal<T>(T expected, T actual, string name)
    {
        if (!EqualityComparer<T>.Default.Equals(expected, actual))
            throw new InvalidOperationException($"{name}: expected {expected}, got {actual}");
        passed++;
    }

    private static void True(bool condition, string name)
    {
        if (!condition) throw new InvalidOperationException($"{name}: assertion failed");
        passed++;
    }

    private static void Throws<TException>(Action action, string name)
        where TException : Exception
    {
        try
        {
            action();
        }
        catch (TException)
        {
            passed++;
            return;
        }

        throw new InvalidOperationException($"{name}: expected {typeof(TException).Name}");
    }

    public static void Run()
    {
        True(Task01.Create("P1", 1, 5) is Creation.Created, "01 valid");
        True(Task01.Create("P1", 0, 5) is Creation.Rejected, "01 zero");
        True(Task01.Create("P1", 1, -1) is Creation.Rejected, "01 negative price");

        Equal("P1", ((Creation.Created)Task02.Create(" P1 ", 2, 0)).Value.Id, "02 trim");
        True(Task02.Create(" ", 2, 0) is Creation.Rejected, "02 blank id");

        True(!DateRange.Create(new(2026, 10, 2), new(2026, 10, 1)).Ok, "03 reverse");
        True(DateRange.Create(new(2026, 10, 1), new(2026, 10, 1)).Ok, "03 same day");

        Equal("Rejected:stock", Task04.Describe(new Creation.Rejected("stock")), "04 rejection");
        Equal("Created:P1", Task04.Describe(new Creation.Created(new("P1", 1, 5))), "04 created");

        Equal("Confirmed:B1:20", Task05.Describe(new Flow.Confirmed("B1", 20)), "05 confirmed");
        Equal("Cancelled:B1:late", Task05.Describe(new Flow.Cancelled("B1", "late")), "05 cancelled");

        True(Task06.Find([], "P9") is LookupResult.Missing, "06 missing");
        True(Task06.Find([new Product("P9", 1, 1)], "P9") is LookupResult.Found, "06 found");

        var policy = Task48.CreatePolicy(new QuoteSettings(500, 100));
        Equal(700m, policy(2), "48 stable policy");
        var policies = Task48.CreatePolicies(new QuoteSettings(500, 100), new QuoteSettings(800, 150));
        Equal(1100m, policies.Express(2), "48 express policy");
        var changedSettings = new QuoteSettings(500, 100);
        var stablePolicy = Task48.CreatePolicy(changedSettings);
        changedSettings = changedSettings with { Base = 900 };
        Equal(700m, stablePolicy(2), "48 settings snapshot");
        Throws<ArgumentOutOfRangeException>(() => Task48.CreatePolicy(new QuoteSettings(-1, 100)), "48 negative settings");

        Console.WriteLine($"All checks passed: {passed}");
    }
}

public static class Program
{
    public static void Main() => Checks.Run();
}
