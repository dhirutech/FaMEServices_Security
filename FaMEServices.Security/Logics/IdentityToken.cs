using FaMEServices.Security.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;

namespace FaMEServices.Security.Logics
{
    public class IdentityToken : IIdentityToken
    {
        private readonly string _idToken;
        private readonly JwtSecurityToken _tokenS;
        private Guid _userId;
        private string _role;
        public string AuthorizationHeader { get; }

        public IdentityToken(AuthenticationHeaderValue authorizationHeader)
        {
            if (authorizationHeader == null)
                throw new Exception("Error: Please provide valid authorization header.");

            _idToken = authorizationHeader.Parameter;
            AuthorizationHeader = authorizationHeader.Parameter;
            try
            {
                var handler = new JwtSecurityTokenHandler();
                _tokenS = handler.ReadToken(_idToken) as JwtSecurityToken;
            }
            catch (Exception ex)
            {
                throw new Exception("Error processing personId from Authorization header.", ex);
            }
        }

        public Guid UserId
        {
            get
            {
                if (_idToken != null && _tokenS != null)
                {
                    var accessId = _tokenS.Claims.First(claim => claim.Type == "userid").Value;
                    _userId = new Guid(accessId);
                }
                return _userId;
            }
        }
        public string Role
        {
            get
            {
                if (_idToken != null && _tokenS != null)
                {
                    var accessRole = _tokenS.Claims.First(claim => claim.Type == "Roles").Value;
                    _role = accessRole;
                }
                return _role;
            }
        }
    }
}
