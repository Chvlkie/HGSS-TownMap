using Main.Services;  // Using your Main.Services namespace
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace Main
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection()
                .AddSingleton<IDataService, DataService>()  // From Main.Services
                .AddTransient<MainForm>()  // From Main.Forms
                .BuildServiceProvider();

            Application.Run(services.GetRequiredService<MainForm>());
        }
    }
}