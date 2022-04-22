using Newtonsoft.Json;

namespace CustomMiddleware
{
    public class IPBlockerMiddleware
    {
        private readonly RequestDelegate _next;

        public IPBlockerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            IPDetailModel model = new IPDetailModel();
            var remoteIp = (!string.IsNullOrEmpty(Convert.ToString(context.Connection.RemoteIpAddress))) ? context.Connection.RemoteIpAddress.ToString() : String.Empty;

            if (context.Session.GetString(remoteIp) == null)
            {
                model.IPAddress = remoteIp;
                model.Count = 1;
                model.DateTimeOffset = DateTimeOffset.Now;
                context.Session.SetString(remoteIp, JsonConvert.SerializeObject(model));
            }
            else
            {
                var ipRec = JsonConvert.DeserializeObject<IPDetailModel>(context.Session.GetString(remoteIp));
                if (DateTimeOffset.UtcNow.Subtract(ipRec.DateTimeOffset).TotalMinutes < 1 && ipRec.Count > 5)
                {
                    await context.Response.WriteAsJsonAsync("Permission Denied due to request count exceeded the max limit of 5 request/minute");
                }
                else
                {
                    ipRec.Count = ipRec.Count + 1;
                    context.Session.Remove(remoteIp);
                    context.Session.SetString(remoteIp, JsonConvert.SerializeObject(ipRec));
                }
            }
          
            await _next(context);
          
        }
    }

    public static class IPBlockerMiddlewareExtensions
    {
        public static IApplicationBuilder BlockRequestFromIP( this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<IPBlockerMiddleware>();
        }
    }
}

