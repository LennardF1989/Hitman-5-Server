using HM5.Server.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Attributes
{
    public class NormalizedStringAttribute : ModelBinderAttribute
    {
        public NormalizedStringAttribute(string propertyName = null)
            : base(typeof(NormalizedStringModelBinder))
        {
            Name = propertyName;
        }
    }
}