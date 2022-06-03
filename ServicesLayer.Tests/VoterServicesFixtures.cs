using DomainLayer.Models.User;
using DomainLayer.Models.Voter;
using ServiceLayer.CommonServices;
using ServiceLayer.Services.LoginServices;
using ServiceLayer.Services.VoterServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Tests
{

        public class VoterServicesFixture
        {
            private IVoterServices _voterServices;
            private IVoterModel _voterModel;

            public VoterServicesFixture()
            {
                _voterModel = new VoterModel();
                _voterServices = new VoterServices(null, new ModelDataAnnotationCheck());
            }

            public VoterModel VoterModel
            {
                get { return (VoterModel)_voterModel; }
                set { _voterModel = value; }
            }
            public VoterServices VoterServices
            {
                get { return (VoterServices)_voterServices; }
                set { _voterServices = value; }
            }
        }
    }

