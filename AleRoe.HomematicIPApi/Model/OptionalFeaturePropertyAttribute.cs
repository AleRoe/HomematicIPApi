using System;

namespace AleRoe.HomematicIpApi.Model
{
    public sealed class OptionalFeaturePropertyAttribute : Attribute
    {
        public string PropertyName { get; }
        public OptionalFeaturePropertyAttribute(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(propertyName));
            
            this.PropertyName = propertyName;
        }
    }
}