﻿
using CommonComponets;
using DomainLayer.Models.User;
using InfrastructureLayer.DataAccess.Repositories.Specific;
using PresentationLayer.Presenters;
using PresentationLayer.Presenters.UserControls;
using PresentationLayer.Presenters.UserControls.Voter;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.Voter;
using ServiceLayer.CommonServices;
using ServiceLayer.Services.LoginServices;
using ServiceLayer.Services.UserServices;
using System;
using System.Configuration;
using System.Windows.Forms;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace PresentationLayer
{
    static class Program
    {

        static string GetConnectionStringByName(string id = "Default")
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[id];

            // If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IUnityContainer UnityC;

            string _connectionString = GetConnectionStringByName();

            UnityC =
                new UnityContainer()
                .RegisterType<IMainView, MainView>(new ContainerControlledLifetimeManager())
                .RegisterType<IMainPresenter, MainPresenter>(new ContainerControlledLifetimeManager())

                //.RegisterType<IAccessTypeEventArgs, AccessTypeEventArgs>(new ContainerControlledLifetimeManager())

                .RegisterType<IUserServices, UserServices>(new ContainerControlledLifetimeManager())
                .RegisterType<IUserRepository, UserRepository>(new InjectionConstructor(_connectionString))
                .RegisterType<IUserModel, UserModel>(new ContainerControlledLifetimeManager())

                .RegisterType<ILoginPresenter, LoginPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<ILoginUC, LoginUC>(new ContainerControlledLifetimeManager())

                .RegisterType<IRegisterPresenter, RegisterPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IRegisterUC, RegisterUC>(new ContainerControlledLifetimeManager())


                .RegisterType<IRegisterVoterPresenter, RegisterVoterPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IVoterRegistrationUC, VoterRegistrationUC>(new ContainerControlledLifetimeManager())


                .RegisterType<IErrorMessageView, ErrorMessageView>(new ContainerControlledLifetimeManager())

                .RegisterType<IModelDataAnnotationCheck, ModelDataAnnotationCheck>(new ContainerControlledLifetimeManager());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IMainPresenter mainPresenter = UnityC.Resolve<MainPresenter>();

            IMainView mainView = mainPresenter.GetMainView();

            //Application.Run(UnityC.Resolve<MainView>());
            Application.Run((MainView)mainView);
        }
    }
}