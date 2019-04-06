using CommonServiceLocator;
using Prism.Ioc;
using Prism.Logging;
using Prism.Modularity;
using Prism.Regions;
using Unity;

namespace WpfApp.Infrastructure.Base
{
    public abstract class ModuleBase : IModule
    {
        public ModuleBase()
        {
            this.UnityContainer = ServiceLocator.Current.GetInstance<IUnityContainer>();
            this.RegionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            this.logger = ServiceLocator.Current.GetInstance<ILoggerFacade>();
        }

        public abstract void OnInitialized(IContainerProvider containerProvider);

        public abstract void RegisterTypes(IContainerRegistry containerRegistry);

        public IUnityContainer UnityContainer { get; }

        public IRegionManager RegionManager { get; }

        private ILoggerFacade logger;

        public void LogInfo(string message)
        {
            logger.Log(message, Category.Info, Priority.Low);
        }

        public void LogWarn(string message)
        {
            logger.Log(message, Category.Warn, Priority.Low);
        }

        public void LogError(string message)
        {
            logger.Log(message, Category.Exception, Priority.Low);
        }

        public T Resolve<T>()
        {
            return UnityContainer.Resolve<T>();
        }
    }
}