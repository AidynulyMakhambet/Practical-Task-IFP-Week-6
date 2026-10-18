namespace PracticalWeek6;

public sealed class DateRange
{
    public DateOnly Start { get; }
    public DateOnly End { get; }

    private DateRange(DateOnly start, DateOnly end) => (Start, End) = (start, end);

    public static (bool Ok, DateRange? Value, string Error) Create(DateOnly start, DateOnly end) =>
        start <= end
            ? (true, new DateRange(start, end), "")
            : (false, null, "start must not be after end");
}
