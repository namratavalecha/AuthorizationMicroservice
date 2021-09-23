using AuthorizationAPI.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AuthorizationAPI.Repository
{
    public class AuthRepo
    {
        private readonly IConfiguration _config;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthRepo));
        private readonly IInsuranceRepo repo;
        public AuthRepo(IConfiguration config, IInsuranceRepo _repo)
        {
            _config = config;
            repo = _repo;
        }
        public string GenerateJSONWebToken(AgentCredentials userInfo)
        {
            _log4net.Info("Token Is Generated!");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              issuer: _config["Jwt:Issuer"],
              audience: _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        
        public AgentCredentials AuthenticateUser(AgentCredentials login)
        {
            _log4net.Info("Validating the User!");
            //Validate the User Credentials 
            AgentCredentials usr = repo.GetAgentCred(login);
            return usr;
        }
    }
}
