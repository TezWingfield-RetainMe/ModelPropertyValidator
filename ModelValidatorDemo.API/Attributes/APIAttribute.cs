using System;

namespace ModelValidatorDemo.API.Attributes
{
    public sealed class APIAttribute : Attribute
    {
        public string Required { get; set; }
    }
}