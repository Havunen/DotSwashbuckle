using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace DotSwashbuckle.AspNetCore.SwaggerGen
{
    public class SwaggerApplicationConvention : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            application.ApiExplorer.IsVisible = true;
        }
    }
}