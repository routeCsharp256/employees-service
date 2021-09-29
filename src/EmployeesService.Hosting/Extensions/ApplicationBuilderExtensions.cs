namespace Microsoft.AspNetCore.Builder
{
    internal static class ApplicationBuilderExtensions
    {
        internal static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(opt => {
                opt.RoutePrefix = string.Empty;
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Employees Service");
            });

            return app;
        }
    }
}