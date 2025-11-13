using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductAPI.Data;

namespace EAIntegrationTest.Library;

public class CustomWebApplicationFactory<TStartup>
    : WebApplicationFactory<TStartup> where TStartup : class
{

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);

        builder.UseEnvironment("Testing");

        builder.ConfigureServices(services =>
        {
            // Remove the app's ProductDbContext registration.
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                    typeof(DbContextOptions<ProductDbContext>));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            // Add ProductDbContext using an in-memory database for testing.
            services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryProductAPI");
            });

            // Build the service provider.
            var sp = services.BuildServiceProvider();

            // Create a scope to obtain a reference to the database contexts
            using var scope = sp.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
            db.Database.EnsureCreated();
        });
    }
}
