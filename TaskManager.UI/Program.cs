using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.Services.Logging.NLogIntegration;
using Castle.Windsor;
using TaskManage.Core.Interfaces;
using TaskManage.Core.Services;
using TaskManager.DataAccess.Interfaces;
using TaskManager.DataAccess.Repositories;

namespace TaskManager.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var container = new WindsorContainer();
            container.AddFacility<LoggingFacility>(f => 
                f.LogUsing<NLogFactory>().WithConfig("nlog.config"));

            container.Register(Component.For<ITaskService>().ImplementedBy<TaskService>().LifestyleSingleton());
            container.Register(Component.For<ITaskRepository>().ImplementedBy<TaskRepository>().LifestyleSingleton());
            container.Register(Component.For<MainForm>().LifestyleTransient());

            var mainForm = container.Resolve<MainForm>();
            Application.Run(mainForm);
        }
    }
}