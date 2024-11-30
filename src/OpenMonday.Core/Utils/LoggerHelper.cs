public class LoggerHelper
{
    // Metodo per loggare messaggi generali
    public static void Log(string message)
    {
        Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] INFO: {message}");
    }

    // Metodo per loggare messaggi di errore
    public static void LogError(string message)
    {
        Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR: {message}");
    }

    // Metodo per loggare eccezioni e stack traces
    public static void LogException(Exception ex)
    {
        Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] EXCEPTION: {ex.Message}");
        Console.WriteLine($"Stack Trace: {ex.StackTrace}");
    }
}
