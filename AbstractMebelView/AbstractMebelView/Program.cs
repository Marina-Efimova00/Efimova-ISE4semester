﻿using AbstractMebelBusinessLogic.Interfaces;
using AbstractShopListImplement.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace AbstractMebelView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IZagotovkaLogic, ZagotovkaLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMebelLogic, MebelLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainLogic, MainLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStorageLogic, StorageLogic>(new
           HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
