using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnytimeSecure.Common;
using AnytimeSecure.DataViewModels.Common;
using AnytimeSecure.DataViewModels.Enum.Admin.v1;
using AnytimeSecure.Services.Interface.v1.Admin;

namespace AnytimeSecure.Apis.Models.Authorizations
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AdminAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private List<Guid> rightIds = new List<Guid>();
        public AdminAuthorizeAttribute(string[] rightIds)
        {
            foreach (var rightid in rightIds)
            {
                this.rightIds.Add(Guid.Parse(rightid));
            }
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            AdminAuthToken tokenData = null;
            string token = string.Empty;

            token = (context.HttpContext.Request.Headers.Any(x => x.Key == "Authorization")) ? context.HttpContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";
            if (token == string.Empty)
            {
                context.HttpContext.Response.StatusCode = 401;
                context.Result = new JsonResult(new Response<bool> { IsError = true, Message = Error.MissingAuthorization, Data = false });
                return;
            }

            if (!string.IsNullOrEmpty(token))
            {
                try
                {
                    var configuration = (IConfiguration)context.HttpContext.RequestServices.GetService(typeof(IConfiguration));
                    var keyByteArray = Encoding.ASCII.GetBytes(configuration.GetValue<String>("Tokens:Key"));
                    var signinKey = new SymmetricSecurityKey(keyByteArray);

                    SecurityToken validatedToken;
                    var handeler = new JwtSecurityTokenHandler();
                    var we = handeler.ValidateToken(token, new TokenValidationParameters
                    {
                        IssuerSigningKey = signinKey,
                        ValidAudience = "Audience",
                        ValidIssuer = "Issuer",
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(0)
                    }, out validatedToken);

                    var temp = handeler.ReadJwtToken(token);
                    tokenData = JsonConvert.DeserializeObject<AdminAuthToken>(temp.Claims.FirstOrDefault(x => x.Type.Equals("token"))?.Value);
                    context.RouteData.Values.Add("userId", tokenData.UserId);
                    context.RouteData.Values.Add("roleIdd", tokenData.RoleId);
                }
                catch (Exception ex)
                {
                    context.HttpContext.Response.StatusCode = 401;
                    context.Result = new JsonResult(new Response<bool> { IsError = true, Message = Error.AccessDenied, Data = false });
                    return;
                }

                if (!tokenData.RoleId.ToString().ToLower().Equals("DE77E06C-8F80-4FD1-879B-C3A2ABBC67A6".ToLower()))
                {
                    var accountService = (IAccountService)context.HttpContext.RequestServices.GetService(typeof(IAccountService));

                    var isAuthenticated = accountService.IsAdminUserAllowed(tokenData.UserId, tokenData.RoleId, rightIds);

                    if (!isAuthenticated)
                    {
                        context.HttpContext.Response.StatusCode = 401;
                        context.Result = new JsonResult(new Response<bool> { IsError = true, Message = Error.AccessDenied, Data = false });
                        return;
                    }
                }

            }
        }
    }
}
