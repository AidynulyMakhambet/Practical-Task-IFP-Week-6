namespace PracticalWeek6;

public static class Task01
{
    public static Creation Create(string id, int quantity, decimal price) =>
        quantity is < 1 or > 100 ? new Creation.Rejected("quantity must be between 1 and 100")
        : price < 0 ? new Creation.Rejected("price must be non-negative")
        : new Creation.Created(new Product(id, quantity, price));
}
