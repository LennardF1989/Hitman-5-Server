using HM5.Server.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Attributes
{
    public class SplitNormalizedStringAttribute : ModelBinderAttribute
    {
        public SplitNormalizedStringAttribute(string propertyName = null)
            : base(typeof(SplitNormalizedStringModelBinder))
        {
            Name = propertyName;
        }
    }
}