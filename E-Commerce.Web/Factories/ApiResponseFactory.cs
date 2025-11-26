using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Web.Factories
{
    public static class ApiResponseFactory
    {
        public static IActionResult GenerateApiValidationResponse(ActionContext actionContext)
        {
            var errors = actionContext.ModelState.Where(x => x.Value.Errors.Count > 0)
                        .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray());
            var problem = new ProblemDetails()
            {
                Title = "Validation Errors",
                Detail = "One or more validation errors occured",
                Status = StatusCodes.Status404NotFound,
                Extensions = { { "Errors", errors } }
            };
            return new BadRequestObjectResult(problem);
        }
    }
}
