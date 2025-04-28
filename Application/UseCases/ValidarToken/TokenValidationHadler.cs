using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using Application.Common;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Application.UseCases.ValidarToken
{
    public class TokenValidationHadler : IRequestHandler<TokenRequest, bool>
    {
        private readonly IConfigurationRepository configuiuracionRepository;
        private readonly IUsuarioRepository usuarioRepository;

        public TokenValidationHadler(IConfigurationRepository configuiuracionRepository, IUsuarioRepository usuarioRepository)
        {
            this.configuiuracionRepository = configuiuracionRepository;
            this.usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Handle(TokenRequest request, CancellationToken cancellationToken)
        {
            return await ValidateToken(request.Token);
        }
        public async Task<bool> ValidateToken(string token)
        {

            try
            {
                var tokenHeader = new JwtSecurityTokenHandler();
                var secreKey = (await configuiuracionRepository.GetByParam(x => x.Id.Equals(ParamConfig.JwtSecretKey.ToString())))?.Value ?? string.Empty;
                var jwtIssuerToken = (await configuiuracionRepository.GetByParam(x => x.Id.Equals(ParamConfig.JwtIssuerToken.ToString())))?.Value;
                var jwtAudienceToken = (await configuiuracionRepository.GetByParam(x => x.Id.Equals(ParamConfig.JwtIssuerToken.ToString())))?.Value;
                var key = Encoding.ASCII.GetBytes(secreKey);
                var tokenParameter = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = jwtIssuerToken,
                    ValidateAudience = true,
                    ValidAudience = jwtAudienceToken,
                    ClockSkew = TimeSpan.Zero
                };

                tokenHeader.ValidateToken(token, tokenParameter, out SecurityToken securutyToken);
                var jwtToken = (JwtSecurityToken)securutyToken;
                var isOk = await SearchUser(jwtToken.Claims.First(t => t.Type == "unique_name").Value);
                return isOk;
            }
            catch (Exception ex)
            {

                throw new ApiException("Ocurrió un error inesperado", (int)System.Net.HttpStatusCode.InternalServerError);
            }
        }
        private async Task<bool> SearchUser(string username)
        {
            var user = await usuarioRepository.GetByParam(x => x.NameUsuario.Equals(username));
            return user != null;
        }
    }
}
