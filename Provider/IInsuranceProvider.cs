using AuthorizationAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationAPI.Provider
{
    public interface IInsuranceProvider
    {
        public List<AgentCredentials> GetList();

        public AgentCredentials GetAgent(AgentCredentials cred);
    }
}
