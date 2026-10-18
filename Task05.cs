namespace PracticalWeek6;

public static class Task05
{
    public static string Describe(Flow state) => state switch
    {
        Flow.Pending(var id) => $"Pending:{id}",
        Flow.Confirmed(var id, var total) => $"Confirmed:{id}:{total}",
        Flow.Cancelled(var id, var reason) => $"Cancelled:{id}:{reason}",
        _ => throw new ArgumentException("Unknown flow case", nameof(state))
    };
}
