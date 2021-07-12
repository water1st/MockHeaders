# MockHeaders

### Getting started
To use the MockHeaders, first install the [NuGet package](https://www.nuget.org/packages/MockHeaders/):

```powershell
Install-Package MockHeaders
``` 

Next, register to IServiceCollection

```csharp
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMockerHeaders(options =>
            {
                options.Headers.Add("foo", "bar");
            });
        }
```
Next, Use the MockHeaders

```csharp
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseMockerHeaders();
            }

            app.UseMockerHeaders(() => env.IsDevelopment());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
```
