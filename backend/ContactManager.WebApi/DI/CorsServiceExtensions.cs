namespace ContactManager.WebApi.Extensions
{
    public static class CorsServiceExtensions
    {
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services, IConfiguration configuration)
        {
            var allowedOrigins = configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    builder =>
                    {
                        builder.WithOrigins(allowedOrigins ?? new string[]{})
                               .AllowAnyHeader()
                               .AllowCredentials()
                               .AllowAnyMethod();
                    });
            });

            return services;
        }
    }
}
