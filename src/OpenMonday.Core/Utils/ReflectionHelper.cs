using System.Reflection;

public static class ReflectionHelper
{
    public static T PopulatePropertiesFromDictionary<T, U, V>(
        T item, Dictionary<U, V> buildedDict)
        where T : class, new()
    {
        if (item == null) throw new ArgumentNullException(nameof(item));

        // Ottieni le proprietà pubbliche dell'oggetto tramite reflection
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var kvp in buildedDict)
        {
            // Cerca una proprietà con un nome che corrisponde al nome del TemplateBoardColumnTypeEnum
            var property = properties.FirstOrDefault(p => string.Equals(p.Name, kvp.Key.ToString(), StringComparison.OrdinalIgnoreCase));
            if (property != null && property.CanWrite)
            {
                // Setta il valore della proprietà
                property.SetValue(item, kvp.Value);
            }
        }

        return item;
    }
}