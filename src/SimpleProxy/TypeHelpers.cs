namespace SimpleProxy
{
    using System;

    /// <summary>
    /// Helpers used to identify Types.
    /// </summary>
    public static class TypeHelpers
    {
        /// <summary>
        /// Verifies whether the specified type is a basic .Net type (primitive types and basic structures like <see cref="DateTime"/> or <see cref="Decimal"/>).
        /// </summary>
        /// <param name="type">The type to verify.</param>
        /// <returns>Boolean indicating if type is a basic type.</returns>
        public static bool IsPrimitiveOrBasicStruct(this Type type)
        {
            return type.IsPrimitive || type == typeof(string) || type == typeof(decimal) || type == typeof(DateTime) || type == typeof(TimeSpan);
        }
    }
}
