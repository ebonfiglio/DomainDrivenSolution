using DomainDrivenSolution.Logic;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace DomainDrivenSolution.BlazorMaui
{
    public partial class App : Application
    {
        public App()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            Initer.Init(connectionString);
            InitializeComponent();

            MainPage = new MainPage();
        }
    }
}