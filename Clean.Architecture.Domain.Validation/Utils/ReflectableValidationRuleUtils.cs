using Clean.Architecture.Domain.Validation.Exceptions;
using System.Collections;
using System.Dynamic;
using System.Reflection;

namespace Clean.Architecture.Domain.Validation.Utils
{
    public static class ReflectableValidationRuleUtils
    {
        private static readonly List<Type> _numericTypes = new ()
        {
            typeof(int),
            typeof(long),
            typeof(float),
            typeof(double),
            typeof(decimal),
            typeof(int?),
            typeof(long?),
            typeof(float?),
            typeof(double?),
            typeof(decimal?),
        };

        public static PropertyInfo GetProp<T>(T entity, string propName)
        {
            PropertyInfo prop = GetProperty(entity, propName);

            if (prop == null)
            {
                throw new UnknownPropertyForValidationException(
                    $"Object of type {typeof(T)} does not contain a property with name {propName}!"
                );
            }

            return prop;
        }

        public static void ValidateNumericType(PropertyInfo prop)
        {
            if (!_numericTypes.Contains(prop.PropertyType))
            {
                throw new InvalidPropertyTypeForValidationRuleException(
                    $"Validation rule only accepts numerical types and the property with name {prop.Name} has type of {prop.PropertyType}!"
                );
            }
        }

        public static void ValidateStringType(PropertyInfo prop)
        {
            if (prop.PropertyType != typeof(string))
            {
                throw new InvalidPropertyTypeForValidationRuleException(
                    $"Validation rule only accepts string type and the property with name {prop.Name} has type of {prop.PropertyType}!"
                );
            }
        }

        public static void ValidateCollectionType(PropertyInfo prop)
        {
            if (typeof(ICollection).IsAssignableFrom(prop.PropertyType))
            {
                throw new InvalidPropertyTypeForValidationRuleException(
                    $"Validation rule only accepts ICollection derived types and the property with name {prop.Name} does not fit in this contraint!"
                );
            }
        }

        public static void ValidateDateTimeType(PropertyInfo prop)
        {
            if (typeof(DateTime) != prop.PropertyType && typeof(DateTime?) != prop.PropertyType)
            {
                throw new InvalidPropertyTypeForValidationRuleException(
                    $"Validation rule only accepts DateTime type and the property with name {prop.Name} has type of {prop.PropertyType}!"
                );
            }
        }

        private static PropertyInfo GetProperty(object entity, string propName)
        {
            if (entity is ExpandoObject expandoObject)
            {
                var dictionary = (IDictionary<string, object>)expandoObject;
                if (dictionary.ContainsKey(propName))
                {
                    var propertyValue = dictionary[propName];
                    var propertyType = propertyValue?.GetType();

                    return new PropertyInfoWrapper(propName, propertyType);
                }
                return null;
            }

            return entity.GetType().GetProperty(propName);
        }
    }
}
