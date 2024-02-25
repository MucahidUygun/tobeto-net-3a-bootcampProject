using DataAccess.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        public IActionResult HandleDataResult<T>(IDataResult<T> dataResult)
        {
            return dataResult.Success ? Ok(dataResult) : BadRequest(dataResult);
        }


        //Burası Çalışan Kod Fakat Swagger ile alakalı bir durumdan çalışmıyor Postman ile yapılan bir istek ile istenilen işlem yapılabiliyor!!!
        //public IActionResult HandleResult(IResult result)
        //{
        //    return result.Success ? Ok(result) : BadRequest(result) ;
        //}
    }
}
