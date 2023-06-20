using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

using Popsy.Attributes;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace Popsy.Filters
{
    /// <summary>
    /// Filtro para controladores que no serán mostrados en el swagger.
    /// </summary>
    public class DisableSwaggerDocumentFilter : IDocumentFilter
    {
        /// <summary><see cref="IWebHostEnvironment"/> instancia.</summary>
        private readonly IWebHostEnvironment _environment;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="environment"><see cref="IWebHostEnvironment"/> instancia.</param>
        public DisableSwaggerDocumentFilter(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        /// <summary>
        /// Función que aplica el filtro.
        /// </summary>
        /// <param name="swaggerDoc"><see cref="OpenApiDocument"/> objeto.</param>
        /// <param name="context"><see cref="DocumentFilterContext"/> objeto.</param>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            IEnumerable<ApiDescription> hiddenEndpoints = context.ApiDescriptions
            .Where(desc => desc.ActionDescriptor.EndpointMetadata.Any(em => em.GetType() == typeof(DisableSwaggerAttribute)) && !_environment.IsDevelopment())
            .ToList();

            foreach (ApiDescription hiddenEndpoint in hiddenEndpoints)
            {
                if (hiddenEndpoint.RelativePath is not null)
                {
                    String key = $"/{hiddenEndpoint.RelativePath.TrimEnd('/')}";
                    if (swaggerDoc.Paths.ContainsKey(key))
                        swaggerDoc.Paths.Remove(key);
                }
            }
        }
    }
}
