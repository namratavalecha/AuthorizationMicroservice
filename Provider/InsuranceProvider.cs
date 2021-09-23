using AuthorizationAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationAPI.Provider
{
    public class InsuranceProvider : IInsuranceProvider
    {
        private static List<AgentCredentials> List = new List<AgentCredentials>()
        {
            new AgentCredentials{ Username = "Admin", Password = "Admin@123"},
            new AgentCredentials{ Username = "Namrata", Password = "Namrata@123"},
            new AgentCredentials{ Username = "Harsh", Password = "Harsh@123"},
            new AgentCredentials{ Username = "Nitish", Password = "Nitish@123"},
            new AgentCredentials{ Username = "Abc", Password = "Abc@123"}
        };
        public List<AgentCredentials> GetList()
        {
            return List;
        }

        public AgentCredentials GetAgent(AgentCredentials agentCredentials)
        {
            List<AgentCredentials> agentList = GetList();
            AgentCredentials agentCred = agentList.FirstOrDefault(user => user.Username == agentCredentials.Username && user.Password == agentCredentials.Password);

            return agentCred;
        }
    }
}
