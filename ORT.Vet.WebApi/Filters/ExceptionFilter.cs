using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ORT.Vet.IBusinessLogic.CustomExceptions;

namespace ORT.Vet.WebApi.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        try
        {
            throw context.Exception;
        }
        catch (NotFoundException e)
        {
            // Cortar la ejecucion de la request
            context.Result = new JsonResult(e.Message) { StatusCode = 404 };
        }
        catch (ArgumentException e)
        {
            context.Result = new JsonResult(e.Message) { StatusCode = 400 };
        }
        catch (InvalidOperationException e)
        {
            // 409 - Conflict
            context.Result = new JsonResult(e.Message) { StatusCode = 409 };
        }
        catch (Exception)
        {
            // TODO: Si estoy en development -> throw again
      
            // No se que paso -> 500
            // Aca tendriamos que loggear el error (no es necesario en el obli)
            context.Result = new JsonResult("We encountered some issues, try again later") { StatusCode = 500 };
        }
    }
}