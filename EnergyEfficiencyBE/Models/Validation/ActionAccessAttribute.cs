using EnergyEfficiencyBE.Models.ResultPattern;
using EnergyEfficiencyBE.Repositories.Implementations.Auth;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using EnergyEfficiencyBE.Models.Dtos;

namespace EnergyEfficiencyBE.Models.Validation
{
    public class ActionAccessAttribute : ActionFilterAttribute
    {
        public string RequiredPermission { get; }
        private IUserRepository _userRepository { get; set; }

        public ActionAccessAttribute(string requiredPermission)
        {
            RequiredPermission = requiredPermission;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value)
                    .Contains("Admin"))
            {
                _userRepository = context.HttpContext.RequestServices.GetService<IUserRepository>();

                var result = await CheckUserPermission(context, RequiredPermission);

                if (result.IsFailure)
                    context.Result = new ObjectResult(result.Message) { StatusCode = StatusCodes.Status403Forbidden };
                else await next();
            }
            else await next();
        }


        private async Task<Result> CheckUserPermission(ActionExecutingContext context, string permission)
        {
            var currentUserId = context.HttpContext.User.FindFirst("uid")?.Value;
            return permission switch
            {
                "manage-user" => await CheckUserAccess(context, currentUserId),
                _ => Result.Fail($"CustomCheckAccessAttribute: Unknown required permission: {permission}.")
            };
        }

        private async Task<Result> CheckUserAccess(ActionExecutingContext context, string? currentUserId)
        {
            if (context.RouteData.Values.TryGetValue("id", out var idValue) && Guid.TryParse(idValue.ToString(), out
                    Guid id))
                return await CheckUserAccessHelper(context, id, currentUserId);
            else if (context.ActionArguments.TryGetValue("param", out var model) &&
                     model is UserUpdateDto userUpdateDto)
                return await CheckUserAccessHelper(context, userUpdateDto.Id, currentUserId);

            return Result.Fail("CustomCheckAccessAttribute: Unable to parse user ID from the request.");
        }

        private async Task<Result> CheckUserAccessHelper(ActionExecutingContext context, Guid id, string? currentUserId)
        {
            return id.ToString() == currentUserId
                ? Result.Ok()
                : Result.Fail("User does not have permission to manage this user.");
        }
    }
}
