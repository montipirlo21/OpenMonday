using System;
using System.Reflection;
using Xunit;

namespace OpenMonday.Tests.Utils
{
    public class ExplicitNullableTests
    {
        private class TestClass
        {
            public string NonNullableString { get; set; } = string.Empty;
            public string? NullableString { get; set; }
            public int NonNullableInt { get; set; }
            public int? NullableInt { get; set; }
        }

        [Theory]
        [InlineData(nameof(TestClass.NonNullableString), false)]
        [InlineData(nameof(TestClass.NullableString), true)]
        [InlineData(nameof(TestClass.NonNullableInt), false)]
        [InlineData(nameof(TestClass.NullableInt), true)]
        public void TestIsExplicitNullable(string propertyName, bool expected)
        {
            // Ottiene il PropertyInfo della proprietà
            PropertyInfo property = typeof(TestClass).GetProperty(propertyName)
                ?? throw new ArgumentException($"Property {propertyName} not found");

            // Verifica se è esplicitamente nullable
            bool result = ReflectionHelper.IsExplicitNullable(property);

            // Confronto con il valore atteso
            Assert.Equal(expected, result);
        }       
    }
}