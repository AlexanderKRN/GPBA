using GPBA.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace GPBA.Api.Common
{
    /// <summary>
    /// Дополнительный базовый контроллер
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public abstract class ApplicationController : ControllerBase
    {
        /// <summary>
        /// Переопределение метода Ok
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected new IActionResult Ok(object? result = null)
        {
            var envelope = Envelope.Ok(result);

            return base.Ok(envelope);
        }

        /// <summary>
        /// Переопределение метода BadRequest
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        protected IActionResult BadRequest(Error? error)
        {
            var errorInfo = new ErrorInfo(error);
            var envelope = Envelope.Error(errorInfo);

            return base.BadRequest(envelope);
        }
    }
}
