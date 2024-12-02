public static class EnumHelper
{
    public static TTarget ConvertEnum<TSource, TTarget>(TSource source) 
        where TSource : Enum 
        where TTarget : Enum
    {
        // Verifica se il valore esiste nell'enum di destinazione
        if (!Enum.IsDefined(typeof(TSource), source))
        {
            throw new ArgumentException($"Value '{source}' is not defined in {typeof(TSource).Name}");
        }

        // Prova a convertire il valore dell'enum sorgente nell'enum target
        if (Enum.TryParse(typeof(TTarget), source.ToString(), out var target) && Enum.IsDefined(typeof(TTarget), target))
        {
            return (TTarget)target;
        }
        
        throw new ArgumentException($"Cannot convert {source} to {typeof(TTarget)}");
    }
}
