﻿using Autofac;
using Autofac.Core;
using Dashboard;
using Nav;
using Prism.Autofac;
using Prism.Events;
using Prism.Modularity;
using scaleio.Views;
using System;
using System.Windows;

namespace scaleio
{
    class Bootstrapper : AutofacBootstrapper
    {
        // 从 Container 中获取到 Shell 实例
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            Type navModule = typeof(NavModule);
            Type dashboradModule = typeof(DashboardModule);
            ModuleCatalog.AddModule(
                new ModuleInfo()
                {
                    ModuleName = navModule.Name,
                    ModuleType = navModule.AssemblyQualifiedName,
                }
            );
            ModuleCatalog.AddModule(
                new ModuleInfo()
                {
                    ModuleName = dashboradModule.Name,
                    ModuleType = dashboradModule.AssemblyQualifiedName,
                }
            );
        }
    }
}
