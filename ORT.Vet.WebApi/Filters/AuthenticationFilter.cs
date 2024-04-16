using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ORT.Vet.BusinessLogic;
using ORT.Vet.IBusinessLogic;

namespace ORT.Vet.WebApi.Filters;

public class AuthenticationFilter : Attribute, IAuthorizationFilter
{
    // Inyeccion de dependencias adentro de filtros no funciona asi nomas
    // 1. Acceder al servicio (SessionLogic) "a mano" <- ESTA, porque hace mas facil el paso de parametros al filtro
    // 2. Registrando el filtro como un "ServiceFilter" en el Program/ServiceFactory 
    
    // Recibir parametros en un filtro
    // public string RoleNeeded { get; set; }
    
    // Checkear si el usuario esta autenticado
    // Si no esta autenticado -> corto la request y devuelvo 401
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var token = context.HttpContext.Request.Headers["Authorization"];
        
        if (String.IsNullOrEmpty(token))
        {
            // Corto la ejecución
            context.Result = new JsonResult("Empty authorization header") { StatusCode = 401 };
        } 
        else if (!Guid.TryParse(token, out Guid parsedToken))
        {
            // Corto la ejecución
            context.Result = new JsonResult("Invalid token format") { StatusCode = 400 };
        }
        else
        {
            var currentUser = GetSessionLogicService(context).GetCurrentUser(parsedToken);
            
            if (currentUser == null)
            {
                // Corto la ejecución
                context.Result = new JsonResult("Inicie sesión") { StatusCode = 401 };
            }
        }
    }

    ISessionLogic GetSessionLogicService(AuthorizationFilterContext context)
    {
        var sessionManagerObject = context.HttpContext.RequestServices.GetService(typeof(ISessionLogic));
        var sessionService = sessionManagerObject as ISessionLogic;

        return sessionService;
    }
}