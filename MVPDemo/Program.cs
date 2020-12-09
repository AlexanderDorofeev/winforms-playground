using System;

using System.Windows.Forms;

using Microsoft.Extensions.DependencyInjection;
using MVPDemo.DataAccess;
using MVPDemo.LoadingForm;
using MVPDemo.Model;
using MVPDemo.Presenters;
using MVPDemo.Services;

namespace MVPDemo
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var services=new ServiceCollection();
            services.AddDbContext<AppDbContext>();
            services.AddSingleton<IToDoItemRepository, ToDoItemRepository>();
            services.Configure<ActionExecutorOptions>(o => o.NotifyLoadingAfterMilliseconds = 500);
            services.AddScoped<ILoadingView, LoadingView>();
            services.AddScoped<IActionExecutor, ActionExecutor>();
            services.AddSingleton<ITodoView, ToDoView>();
            services.AddScoped<IMessageBoxPresenter, MessageBoxPresenter>();
            services.AddScoped<IToDoViewPresenter, ToDoViewPresenter>();
            
            
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var provider= services.BuildServiceProvider();
            var mainPresenter=provider.GetRequiredService<IToDoViewPresenter>();
            mainPresenter.Show();
            Application.Run((Form)provider.GetRequiredService<ITodoView>());
        }
    }
}