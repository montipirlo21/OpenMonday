using System.Reflection;

public static class ReflectionHelper
{
    public static T PopulatePropertiesFromDictionary<T, U, V>(
        T item, Dictionary<U, V> buildedDict)
        where T : class, new()
    {
        if (item == null) throw new ArgumentNullException(nameof(item));

        // Find the property with the specified name
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var kvp in buildedDict)
        {
            // Find property by name
            var property = properties.FirstOrDefault(p => string.Equals(p.Name, kvp.Key.ToString(), StringComparison.OrdinalIgnoreCase));
            if (property != null && property.CanWrite)
            {
                // Set the property value
                property.SetValue(item, kvp.Value);
            }
        }

        return item;
    }

    public static Type GetPropertyType<T>(string propertyName)
    {
        // Get the type of the generic parameter T
        var type = typeof(T);

        // Find the property with the specified name
        var property = type.GetProperty(propertyName);

        if (property == null)
        {
            throw new ArgumentException($"The property '{propertyName}' does not exist on type '{type.Name}'.");
        }

        // Return the type of the property
        return property.PropertyType;
    }
}