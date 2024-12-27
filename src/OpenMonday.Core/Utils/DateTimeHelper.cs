public static class DateTimeConverter{

    public static string ConvertToISO8601DateTimeString(DateTime dateTime){
        return dateTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
    }

}