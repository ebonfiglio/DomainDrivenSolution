using DomainDrivenSolution.Logic;
using Microsoft.Extensions.Configuration;
using Microsoft.Maui.Storage;
using System.Reflection;

namespace DomainDrivenSolution.BlazorMaui
{
    public partial class App : Application
    {
        public App()
        {
            string connectionString = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dds");

            Initer.Init(connectionString);
            InitializeComponent();

            MainPage = new MainPage();
        }
    }
}