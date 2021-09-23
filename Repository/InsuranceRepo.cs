using AuthorizationAPI.Model;
using AuthorizationAPI.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationAPI.Repository
{
    public class InsuranceRepo : IInsuranceRepo
    {
        private IInsuranceProvider provider;

        public InsuranceRepo(IInsuranceProvider _provider)
        {
            provider = _provider;
        }
        public AgentCredentials GetAgentCred(AgentCredentials cred)
        {
            if(cred == null)
            {
                return null;
            }

            AgentCredentials agent = provider.GetAgent(cred);

            return agent;
        }
    }
}
