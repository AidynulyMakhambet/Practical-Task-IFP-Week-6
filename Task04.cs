namespace PracticalWeek6;

public static class Task04
{
    public static string Describe(Creation creation) => creation switch
    {
        Creation.Created(var product) => $"Created:{product.Id}",
        Creation.Rejected(var reason) => $"Rejected:{reason}",
        _ => throw new ArgumentException("Unknown creation case", nameof(creation))
    };
}
