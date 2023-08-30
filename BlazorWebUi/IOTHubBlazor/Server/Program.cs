using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;
using System.Linq.Dynamic.Core.Tokenizer;

namespace IOTHubBlazor
{
    public class Program
    {
        //TODO GetfromConfig
        static int HTTPretrySeconds = 1;
        static int HTTPretryCount = 5;

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpClient("httpClient")
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler())
                .AddPolicyHandler(
                    HttpPolicyExtensions.HandleTransientHttpError()
                        .WaitAndRetryAsync(HTTPretryCount,
                            sleepDurationProvider: retry =>
                                Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(HTTPretrySeconds), HTTPretryCount).ToList()[retry % HTTPretryCount],
                            onRetry: (timeSpan, retryCount, ctx) =>
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Retry {retryCount}, time: {timeSpan}");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            )
            );


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blazor API V1");
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}