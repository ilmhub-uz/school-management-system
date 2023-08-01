using SchoolManagement.AdminAPI.Options;

namespace SchoolManagement.AdminAPI.Extensions;

public static class WebApplicationExtensions
{
    public static void UseSwaggerForOcelot(this WebApplication webApplication, IConfiguration configuration)
    {
        webApplication.UseSwaggerUI(c =>
        {
            //c.SwaggerEndpoint("/swag/student", "Student api swagger");

            var endPoints = configuration.GetSection(SwaggerEndPoint.ConfigurationSectionName)
                .Get<IEnumerable<SwaggerEndPoint>>();

            if (endPoints is null)
            {
                throw new InvalidOperationException(
                    $"{SwaggerEndPoint.ConfigurationSectionName} configuration section is missing or empty."
                );
            }

            foreach (var endPoint in endPoints)
            {
				c.SwaggerEndpoint($"{endPoint.Url}", $"{endPoint.Name} - {endPoint.Version}");
				c.RoutePrefix = "swagger";
			}
        });
    }
}