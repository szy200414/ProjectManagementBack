using ProjectManagementBack.WebApi.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ProjectManagementBack.WebApi.Filters
{
    public class MyAuthAttribute: Attribute, IAuthorizationFilter
    {
        public bool AllowMultiple { get; }

        public async Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true).Count > 0)
            {
                return await continuation();
            }

            IEnumerable<string> headers;
            if (actionContext.Request.Headers.TryGetValues("token", out headers))
            {
                var loginName = JwtTools.Decode(headers.First())["username"].ToString();
                var userId = Guid.Parse(JwtTools.Decode(headers.First())["userid"].ToString());
                (actionContext.ControllerContext.Controller as ApiController).User = new ApplicationUser(loginName, userId);
                return await continuation();
            }

            return new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }
    }
}