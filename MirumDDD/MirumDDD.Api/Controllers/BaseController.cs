using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MirumDDD.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        [Route("v1/response")]
        public async Task<IActionResult> Response(object result)
        {
            //if (notifications == null || !notifications.Any())
            //{
            //    try
            //    {
                    return Ok(new
                    {
                        success = true,
                        data = result
                    });
            //    }
            //    catch
            //    {
            //        return BadRequest(new
            //        {
            //            success = false,
            //            errors = new[] { "Ocorreu uma falha interna no servidor." }
            //        });
            //    }
            //}
            //else
            //{
            //    return BadRequest(new
            //    {
            //        success = false,
            //        errors = notifications
            //    });
            //}
        }
    }
}