using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;

namespace HM5.Server.Models
{
    [EdmEntity("UserTokenData")]
    public class UserTokenData : IEdmEntity
    {
        [EdmProperty("TokenId", EdmTypes.Int32, false)]
        public int TokenId { get; set; }

        [EdmProperty("SubId", EdmTypes.Int32, false)]
        public int SubId { get; set; }

        [EdmProperty("Level", EdmTypes.Int32, false)]
        public int Level { get; set; }
    }
}
