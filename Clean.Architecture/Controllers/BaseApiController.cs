using Clean.Architecture.Domain.Validation.ErrorBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Clean.Architecture.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected IActionResult Problem(Error error)
        {

            if (error.Type == ErrorType.Validation)
            {
                return ValidationProblem(error);
            }


            return ProblemResponse(error);
        }

        private IActionResult ProblemResponse(Error error)
        {
            var statusCode = error.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            return Problem(statusCode: statusCode, title: error.Description);
        }

        private IActionResult ValidationProblem(Error error)
        {
            var modelStateDictionary = new ModelStateDictionary();

            modelStateDictionary.AddModelError(
                error.Code,
                error.Description
            );

            return ValidationProblem(modelStateDictionary);
        }
    }
}
