using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceContracts;
using Services;

class Program
{
    static async Task Main(string[] args)
    {

        var host = CreateHostBuilder(args).Build();
        var context = host.Services.GetRequiredService<ApplicationDbContext>();

        var csvImportService = host.Services.GetRequiredService<ICsvImportService>();

        // Start processing the data
        await csvImportService.ProcessData();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)

            .ConfigureServices((hostContext, services) =>
            {

                var configuration = hostContext.Configuration;
                var connectionString = hostContext.Configuration.GetConnectionString("DefaultConnection");
                
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString));

                services.AddScoped<ICsvImportService, CsvImportService>();
                services.AddScoped<ICsvReaderService, CsvReaderService>();
                services.AddScoped<IDataSavingService, DataSavingService>();
                services.AddTransient<IDataProcessingService, DataProcessingService>();

            });
}