using ModelValidatorDemo.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ModelValidatorDemo.API.Components
{
    public class ModelValidator<T>
    {
        private T _obj;

        public ModelValidator(T obj)
        {
            _obj = obj;
        }

        private Dictionary<string, object> GetPropertyAttributes(PropertyInfo property)
        {
            Dictionary<string, object> attribs = new Dictionary<string, object>();
            foreach (CustomAttributeData attribData in property.GetCustomAttributesData())
            {
                string typeName = attribData.Constructor.DeclaringType.Name;
                if (typeName.EndsWith("Attribute")) typeName = typeName.Substring(0, typeName.Length - 9);
                attribs[typeName] = attribData.NamedArguments[0].TypedValue;
            }
            return attribs;
        }
        private IEnumerable<PropertyInfo> GetProperties()
        {
            var props = typeof(T).GetProperties().Where(
                    prop => Attribute.IsDefined(prop, typeof(APIAttribute)));

            return props;
        }
        public bool IsModelValid()
        {
            var props = GetProperties();
            return props.All(p => p.GetValue(_obj, null) != null);
        }
        public Models.Response ModelErrors()
        {
            Models.Response error = new Models.Response();
            error.StatusCode = 418;

            var dict = new Dictionary<string, string>();
            foreach (var p in GetProperties())
            {
                if (p.GetValue(_obj, null) == null)
                {

                    dict.Add(GetPropertyAttributes(p).FirstOrDefault().Key,
                        GetPropertyAttributes(p).FirstOrDefault()
                                                .Value.ToString().Replace(@"\", "").Replace("\"", ""));
                }
            }
            return error;
        }
    }
}