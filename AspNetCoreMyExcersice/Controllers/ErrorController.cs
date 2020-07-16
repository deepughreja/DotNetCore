using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMyExcersice.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }


        [Route("Error/{statuscode}")]
        public IActionResult HttpStatusCodeHandler(int statuscode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();     
            switch (statuscode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry resourse not found";
                    logger.LogInformation("Resource Not Found");
                    break;
            }
            
            return View("NotFound");
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult HandleError()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ExceptionPath = exceptionDetails.Error.Message;
            ViewBag.ExceptionMessage = exceptionDetails.Error.Message;
            ViewBag.StackStrace = exceptionDetails.Error.StackTrace;

            logger.LogInformation($"Message :{exceptionDetails.Error.Message} , ExceptionMessage : {exceptionDetails.Error.Message}");

            return View("Error");
        }

    }
}
