namespace PracticalWeek6;

public abstract record LookupResult
{
    private protected LookupResult() { }
    public sealed record Found(Product Value) : LookupResult;
    public sealed record Missing(string Id) : LookupResult;
}

public static class Task06
{
    public static LookupResult Find(IEnumerable<Product> products, string id) =>
        products.FirstOrDefault(product => string.Equals(product.Id, id, StringComparison.Ordinal)) is { } product
            ? new LookupResult.Found(product)
            : new LookupResult.Missing(id);
}
