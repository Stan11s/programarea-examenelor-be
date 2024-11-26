namespace API.Services
{
    public class ConfigureServices
    {
        public void AddCustomServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin()  // Permite accesul din orice domeniu
                           .AllowAnyMethod()  // Permite orice metodă HTTP (GET, POST, PUT, DELETE etc.)
                           .AllowAnyHeader(); // Permite orice header
                });
            });

            // Alte servicii
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Aplică politica CORS
            app.UseCors("AllowAllOrigins");

            // Alte middleware-uri
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
