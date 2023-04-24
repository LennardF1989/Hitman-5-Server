using HM5.Server.Interfaces;
using HM5.Server.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace HM5.Server.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly ISimpleLogger Logger;

        protected BaseController(ISimpleLogger simpleLogger)
        {
            Logger = simpleLogger;
        }

        protected JsonResult JsonGenericResponse<T>(T data)
        {
            return Json(new BaseResponse<T>
            {
                Data = data
            });
        }

        /**
         * NOTE: Even though it is not constrained, only use primitive values for the generic!
         */
        protected JsonResult JsonOperationValueResponse<T>(T data)
        {
            return Json(new BaseOperationValueResponse<T>
            {
                Data = new SingleOperationValue<T>
                {
                    Key = data
                }
            });
        }

        /**
         * NOTE: Even though it is not constrained, only use primitive values for the generic!
         */
        protected JsonResult JsonOperationListResponse<T>(List<T> data)
        {
            return Json(new BaseOperationListResponse<T>
            {
                Data = data
            });
        }

        protected JsonResult JsonEntryResponse<T>(T data)
            where T : IEdmEntity
        {
            return Json(new BaseEntryResponse<T>
            {
                Data = new EntryObject<T>
                {
                    Results = data
                }
            });
        }

        protected JsonResult JsonFeedResponse<T>(List<T> data)
            where T : IEdmEntity
        {
            return Json(new BaseFeedResponse<T>
            {
                Data = new FeedObject<T>
                {
                    Results = data,
                    Count = data.Count
                }
            });
        }
    }
}
