using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using VeggieLink.Aplication.Interfaces;

namespace VeggieLink.Api.Extensions;


public class ValidationSessionUserFilter(IAuthService service) : IAsyncAuthorizationFilter
{
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        bool hasAllowAnonymous = context.ActionDescriptor.EndpointMetadata
                            .Any(em => em.GetType() == typeof(AllowAnonymousAttribute));

        bool hasAuthorize = context.ActionDescriptor.EndpointMetadata
                            .Any(em => em.GetType() == typeof(AuthorizeAttribute));

        if (hasAllowAnonymous || !hasAuthorize) return;

        AuthenticationHeaderValue authorization = AuthenticationHeaderValue.Parse(context.HttpContext.Request.Headers.Authorization);

        return;
    }
}
