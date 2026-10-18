namespace PracticalWeek6;

public static class Task02
{
    public static Creation Create(string? id, int quantity, decimal price)
    {
        if (string.IsNullOrWhiteSpace(id)) return new Creation.Rejected("id is required");
        if (quantity <= 0) return new Creation.Rejected("quantity must be positive");
        if (price < 0) return new Creation.Rejected("price must be non-negative");
        return new Creation.Created(new Product(id.Trim(), quantity, price));
    }
}
