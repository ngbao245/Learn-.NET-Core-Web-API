using CRMCar.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CRMCar.Attribute
{
    public class ApiKeyAttribute : ServiceFilterAttribute
    {
        public ApiKeyAttribute() 
            : base(typeof(ApiKeyAuthorizationFilter))
        {

        }
    }
}
