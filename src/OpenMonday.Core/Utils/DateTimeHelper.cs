public static class DateTimeConverter
{

    public static string ConvertToISO8601DateTimeString(DateTime dateTime)
    {
        return dateTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
    }

    public static DateTime? ConvertFromStringToISO8601DateTime(string? dateTime)
    {
        if (string.IsNullOrEmpty(dateTime))
        {
            return null;
        }

        if (DateTime.TryParseExact(dateTime, "yyyy-MM-ddTHH:mm:ssK", null, System.Globalization.DateTimeStyles.RoundtripKind, out DateTime d))
        {
            return d;
        }
        else
        {
            return null;
        }
    }

    public static DateTime? ToDateTime(DateOnly? date, TimeOnly? time = null)
    {
        if (date == null)
            return null;

        return date.Value.ToDateTime(time ?? TimeOnly.MinValue);
    }

    public static DateOnly? ToDateOnly(DateTime? dateTime)
    {
        if (dateTime == null)
            return null;

        return DateOnly.FromDateTime(dateTime.Value);
    }

}