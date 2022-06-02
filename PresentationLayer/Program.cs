
using CommonComponets;
using DomainLayer.Models.Candidate;
using DomainLayer.Models.Election;
using DomainLayer.Models.User;
using DomainLayer.Models.Voter;
using InfrastructureLayer.DataAccess.Repositories.Specific;
using PresentationLayer.Presenters;
using PresentationLayer.Presenters.UserControls;
using PresentationLayer.Presenters.UserControls.Admin;
using PresentationLayer.Presenters.UserControls.Voter;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.UserControls.Admin;
using PresentationLayer.Views.UserControls.Voter;
using ServiceLayer.CommonServices;
using ServiceLayer.Services;
using ServiceLayer.Services.AdminServices;
using ServiceLayer.Services.LoginServices;
using ServiceLayer.Services.UserServices;
using ServiceLayer.Services.VoterServices;
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
            
          //  string _connectionString = "Data Source=" +
          //@"C:\Users\TomAppleyard\Desktop\JamesMVP\MDIS.sqlite;version = 3;";

          //  returnValue = _connectionString;
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

                .RegisterType<IAdminServices, AdminServices>(new ContainerControlledLifetimeManager())
                .RegisterType<IAdminRepository, AdminRepository>(new InjectionConstructor(_connectionString))



                .RegisterType<IVoterServices, VoterServices>(new ContainerControlledLifetimeManager())
                .RegisterType<IVoterRepository, VoterRepository>(new InjectionConstructor(_connectionString))



                .RegisterType<IRegisterVoterPresenter, RegisterVoterPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IVoterRegistrationUC, VoterRegistrationUC>(new ContainerControlledLifetimeManager())
                .RegisterType<IVoterModel, VoterModel>(new ContainerControlledLifetimeManager())


                .RegisterType<ICreateElectionPresenter, CreateElectionPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<ICreateElectionViewUC, CreateElectionViewUC>(new ContainerControlledLifetimeManager())
                                .RegisterType<IElectionModel, ElectionModel>(new ContainerControlledLifetimeManager())

                .RegisterType<IElectionServices, ElectionServices>(new ContainerControlledLifetimeManager())
                .RegisterType<IElectionRepository, ElectionRepository>(new InjectionConstructor(_connectionString))

                .RegisterType<ICastVotePresenter, CastVotePresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<ICastVoteViewUC, CastVoteViewUC>(new ContainerControlledLifetimeManager())


                .RegisterType<ICandidateServices, CandidateServices>(new ContainerControlledLifetimeManager())

                .RegisterType<ICandidateRepository, CandidateRepository>(new InjectionConstructor(_connectionString))
                .RegisterType<IAddCandidatePresenter, AddCandidatePresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<ICandidateModel, CandidateModel>(new ContainerControlledLifetimeManager())
                .RegisterType<IAddCandidateViewUC, AddCandidateViewUC>(new ContainerControlledLifetimeManager())


                .RegisterType<IConfirmIdentityPresenter, ConfirmIdentityPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IConfirmIdentitiesUC, ConfirmIdentitiesUC>(new ContainerControlledLifetimeManager())


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
