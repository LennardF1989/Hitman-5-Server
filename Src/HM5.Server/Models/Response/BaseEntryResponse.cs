using HM5.Server.Interfaces;

namespace HM5.Server.Models.Response
{
    public class BaseEntryResponse<T> : BaseResponse<EntryObject<T>>
        where T : IEdmEntity
    {
        //Do nothing
    }
}
