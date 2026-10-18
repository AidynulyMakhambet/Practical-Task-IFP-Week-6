namespace PracticalWeek6;

public record Product(string Id, int Quantity, decimal UnitPrice);
public record Quote(string Id, decimal Cost);

public abstract record Creation
{
    private protected Creation() { }
    public sealed record Created(Product Value) : Creation;
    public sealed record Rejected(string Reason) : Creation;
}

public abstract record Flow
{
    private protected Flow() { }
    public sealed record Pending(string Id) : Flow;
    public sealed record Confirmed(string Id, decimal Total) : Flow;
    public sealed record Cancelled(string Id, string Reason) : Flow;
}

public record Booking(string Id, int Seats);
