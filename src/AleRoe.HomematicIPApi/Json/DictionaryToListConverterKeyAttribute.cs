using System;

namespace AleRoe.HomematicIpApi.Json
{
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class)]
    public class DictionaryToListConverterKeyAttribute : Attribute
    {
        public string Value { get; set; }

        public DictionaryToListConverterKeyAttribute(string value)
        {
            this.Value = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
