namespace CRMCar.Extensions
{
    public class ApiKeyAuthenExtension
    {
        private readonly RequestDelegate _requestDelegate;

        private readonly string KeyName = "x-api-key";

        private readonly string KeyValue = "j209jf02jf9023jf902fj2ejjwefeklwfkla";

        public ApiKeyAuthenExtension(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            var apiToken = context.Request.Headers[KeyName].FirstOrDefault();
            if (apiToken == null)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("ApiKey Name is not authorizaton");
                return;
            }
            if(apiToken != KeyValue)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("ApiKey Value is not authorizaton");
                return;
            }
            await _requestDelegate.Invoke(context);
        }

    }
}
