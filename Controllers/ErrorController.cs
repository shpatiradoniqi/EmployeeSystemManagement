﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeManagment.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;
        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;

        }
        [Route("Error/statusCode")]
        public IActionResult HttpStatisCodeHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case 404:
                    return ViewBag.ErrorMessage = "sorry the request you write it is wrong";
                    logger.LogWarning($"404 Error Occured.Path={statusCodeResult.OriginalPath}");

                    break;

                    
            }
            return View("NotFound");

        }
        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            logger.LogError($" The path {exceptionDetails.Path} threw an exception {exceptionDetails.Error}");



            return View("Error");



        }
    }
}
