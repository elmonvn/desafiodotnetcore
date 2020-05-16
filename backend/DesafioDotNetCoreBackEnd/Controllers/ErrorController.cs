using System;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DesafioDotNetCoreBackEnd.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        [Route("/error-local-development")]
        public IActionResult ErrorLocalDevelopment(
            [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.EnvironmentName != "Development")
            {
                throw new InvalidOperationException(
                    "Esta exceção não deveria ser lançada fora do ambiente de desenvolvimento.");
            }

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            return Problem(title: context.Error.Message);
        }

        [Route("/error")]
        public IActionResult Error() => Problem();
    }
}