using HM5.Server.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Attributes
{
    public class NormalizedJsonStringAttribute : ModelBinderAttribute
    {
        public NormalizedJsonStringAttribute(string propertyName = null)
            : base(typeof(NormalizedJsonStringModelBinder))
        {
            Name = propertyName;
        }
    }
}