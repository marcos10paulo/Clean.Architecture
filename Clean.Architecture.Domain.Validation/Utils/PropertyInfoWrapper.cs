using System.Globalization;
using System.Reflection;

namespace Clean.Architecture.Domain.Validation.Utils
{
    public class PropertyInfoWrapper : PropertyInfo
    {
        private readonly Type propertyType;

        public PropertyInfoWrapper(string name, Type propertyType)
        {
            this.propertyType = propertyType;
            this.Name = name;
        }

        public override Type PropertyType => propertyType;
        public override string Name { get; }

        public override PropertyAttributes Attributes => PropertyAttributes.None;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override Type DeclaringType => null;

        public override Type ReflectedType => null;

        public override MethodInfo[] GetAccessors(bool nonPublic)
        {
            return new MethodInfo[0];
        }

        public override object[] GetCustomAttributes(bool inherit)
        {
            return new object[0];
        }

        public override object[] GetCustomAttributes(Type attributeType, bool inherit)
        {
            return new object[0];
        }

        public override MethodInfo GetGetMethod(bool nonPublic)
        {
            return null;
        }

        public override ParameterInfo[] GetIndexParameters()
        {
            return new ParameterInfo[0];
        }

        public override MethodInfo GetSetMethod(bool nonPublic)
        {
            return null;
        }

        public override object GetValue(object obj, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
        {
            // Implement your logic to get the value from the ExpandoObject
            return null;
        }

        public override bool IsDefined(Type attributeType, bool inherit)
        {
            return false;
        }

        public override void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
        {
            // Implement your logic to set the value in the ExpandoObject
        }
    }
}
