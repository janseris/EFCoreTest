using System.Diagnostics;

using Data;
using Data.Models;

using GUI;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreTest
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var connectionString = File.ReadAllText("../../../connectionString.txt");

            IServiceCollection services = new ServiceCollection();
            services.AddDbContextFactory<CancellationTokenTestContext>(
                options => options.UseSqlServer(connectionString).LogTo((string s) => Trace.WriteLine(s)), ServiceLifetime.Scoped);
            services.AddSingleton<ImageDAO>();
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            DIContainer.ServiceProvider = serviceProvider;

            Application.Run(new MainWindow());
        }
    }
}