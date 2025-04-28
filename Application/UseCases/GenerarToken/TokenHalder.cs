using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Application.Common;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Application.UseCases.GenerarToken
{
    public class TokenHalder : IRequestHandler<TokenCreateRequest, TokenResponse>
    {
        private readonly IConfigurationRepository configuiuracionRepository;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IValidator<TokenCreateRequest> validator;
        private readonly IProfesorRepository profesorRepository;
        private readonly IEstudianteRepository estudianteRepository;

        public TokenHalder(IConfigurationRepository configuiuracionRepository, IUsuarioRepository usuarioRepository, IValidator<TokenCreateRequest> _validator, IProfesorRepository profesorRepository, IEstudianteRepository estudianteRepository)
        {
            this.configuiuracionRepository = configuiuracionRepository;
            this.usuarioRepository = usuarioRepository;
            validator = _validator;
            this.profesorRepository = profesorRepository;
            this.estudianteRepository = estudianteRepository;
        }



        public async Task<TokenResponse> Handle(TokenCreateRequest request, CancellationToken cancellationToken)
        {
            TokenResponse UserTokenResponse;
            try
            {

                var result = await validator.ValidateAsync(request);
                if (!result.IsValid && result is null)
                {

                    throw new ApiException(result.Errors.ToString() ?? "", (int)System.Net.HttpStatusCode.Unauthorized);
                }

                var user = await ValidateUserName(request.Email);
                if (user is null)
                {
                    throw new ApiException("Usuario no encontrado", (int)System.Net.HttpStatusCode.Unauthorized);
                }

                string pass = request.Password.DecodeBase64Password();
                if (!await ValidatePassword(pass, user.Password))
                {
                    throw new ApiException("Password no valido", (int)System.Net.HttpStatusCode.Unauthorized);
                }


                UserTokenResponse = await MapperUserTokenResponse(user);
            }
            catch (Exception ex) when (ex is ApiException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApiException("Ocurrió un error inesperado", (int)System.Net.HttpStatusCode.InternalServerError);
            }
            return UserTokenResponse;
        }
        private async Task<TokenResponse> MapperUserTokenResponse(Users user)
        {
            TokenResponse UserTokenResponse = new();
            UserTokenResponse.Token = await GenerateToken(user.NameUsuario);
            UserTokenResponse.IdRol = user.IdRol;
            UserTokenResponse.IdUsuario = user.Id;
            UserTokenResponse.IdTipo = await GetIdEstudianteOrIdProfesor(user.IdRol, user.Id);

            return UserTokenResponse;
        }
        private async Task<Users?> ValidateUserName(string? correo)
        {
            var user = await usuarioRepository.GetByParam(x => x.Email.Equals(correo));
            return user;
        }
        public async Task<bool> ValidatePassword(string? password, string encryptedPassword)
        {

            var keyEncrypted = (await configuiuracionRepository.GetByParam(x => x.Id.Equals(ParamConfig.KeyEncrypted.ToString())))?.Value ?? string.Empty;
            var iVEncrypted = (await configuiuracionRepository.GetByParam(x => x.Id.Equals(ParamConfig.IVEncrypted.ToString())))?.Value ?? string.Empty;
            byte[] key = Encoding.UTF8.GetBytes(keyEncrypted);
            byte[] iv = Encoding.UTF8.GetBytes(iVEncrypted);
            using (TripleDES aes = TripleDES.Create())
            {

                ICryptoTransform decryptor = aes.CreateDecryptor(key, iv);
                byte[] encryptedPasswordBytes = Convert.FromBase64String(encryptedPassword);
                byte[] decryptedPasswordBytes = decryptor.TransformFinalBlock(encryptedPasswordBytes, 0, encryptedPasswordBytes.Length);
                string decryptedPassword = Encoding.UTF8.GetString(decryptedPasswordBytes);
                return decryptedPassword == password;
            }
        }
        private async Task<string> GenerateToken(string? userName = "")
        {
            var secretKey = (await configuiuracionRepository.GetByParam(x => x.Id.Equals(ParamConfig.JwtSecretKey.ToString())))?.Value ?? string.Empty;
            var jwtIssuerToken = (await configuiuracionRepository.GetByParam(x => x.Id.Equals(ParamConfig.JwtIssuerToken.ToString())))?.Value ?? string.Empty;
            var jwtAudienceToken = (await configuiuracionRepository.GetByParam(x => x.Id.Equals(ParamConfig.JwtIssuerToken.ToString())))?.Value ?? string.Empty;
            var jwtExpireTime = (await configuiuracionRepository.GetByParam(x => x.Id.Equals(ParamConfig.JwtExpireTime.ToString())))?.Value ?? string.Empty;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            ClaimsIdentity claimsIdentity = new(new[] { new Claim(ClaimTypes.Name, userName) });
            var currentDate = DateTime.Now;
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: jwtAudienceToken,
                issuer: jwtIssuerToken,
                subject: claimsIdentity,
                notBefore: currentDate,
                expires: currentDate.AddMinutes(Convert.ToInt32(jwtExpireTime)),
                signingCredentials: signingCredentials);
            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }
        private async Task<int> GetIdEstudianteOrIdProfesor(int idRol, int idUsuario)
        {
            int id = 0;
            if(idRol== (int)Rol.Profesor)
            {
                var profesor = await profesorRepository.GetByParam(x => x.IdUsuario == idUsuario);
                id = profesor.Id;
            }
            else
            {
                var estudiane = await estudianteRepository.GetByParam(x => x.IdUsuario == idUsuario);
                id = estudiane.Id;
            }       

            return id;
        }


    }
}
