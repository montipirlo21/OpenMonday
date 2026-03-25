using StrawberryShake.Serialization;

public class FlexibleDateSerializer : ScalarSerializer<string, DateOnly>
{
    public FlexibleDateSerializer() : base("Date") { }

    public override DateOnly Parse(string serializedValue)
    {
        if (string.IsNullOrWhiteSpace(serializedValue))
            throw new ArgumentNullException(nameof(serializedValue));

        // Caso 1: formato corretto
        if (DateOnly.TryParse(serializedValue, out var date))
            return date;

        // Caso 2: arriva DateTime → fallback
        if (DateTime.TryParse(serializedValue, out var dateTime))
            return DateOnly.FromDateTime(dateTime);

        throw new FormatException($"Invalid Date format: {serializedValue}");
    }

    protected  override string Format(DateOnly runtimeValue)
        => runtimeValue.ToString("yyyy-MM-dd");
}