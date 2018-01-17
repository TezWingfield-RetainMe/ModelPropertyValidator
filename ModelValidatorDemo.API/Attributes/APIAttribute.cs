using System;

namespace ModelValidatorDemo.API.Attributes
{
    public sealed class APIAttribute : Attribute
    {
        //Testing Staging Branch
        public string Required { get; set; }

    }
}