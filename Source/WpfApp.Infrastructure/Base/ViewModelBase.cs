﻿using CommonServiceLocator;
using Prism.Events;
using Prism.Ioc;
using Prism.Logging;
using Prism.Mvvm;
using Prism.Regions;
using Unity;

namespace WpfApp.Infrastructure.Base
{
    public class ViewModelBase : BindableBase
    {
        public ViewModelBase()
        {
            this.UnityContainer = ServiceLocator.Current.GetInstance<IUnityContainer>();
            this.RegionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            this.EventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            this.logger = ServiceLocator.Current.GetInstance<ILoggerFacade>();
        }

        public IUnityContainer UnityContainer { get; }

        public IRegionManager RegionManager { get; }

        public IEventAggregator EventAggregator { get; }

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