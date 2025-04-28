using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Application.Common;
using Application.Mapper;
 
using Application.UseCases.RegistrarUsuarioEstudiante;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCases.RegistrarUsuarioProfesor
{
    public class UsuarioProfesorHandler : IRequestHandler<UsuarioProfesorRequest, BaseResponse>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IProfesorRepository profesorRepository;
        private readonly IConfigurationRepository configuiuracionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioProfesorHandler(IUsuarioRepository usuarioRepository, IProfesorRepository profesorRepository, IConfigurationRepository configuiuracionRepository, IUnitOfWork unitOfWork)
        {
            _usuarioRepository = usuarioRepository;
            this.profesorRepository = profesorRepository;
            this.configuiuracionRepository = configuiuracionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> Handle(UsuarioProfesorRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            try
            {

                await _unitOfWork.ExecuteAsync(async () =>
                {
                    var validateUser = await ValidateUserName(request.NameUsuario);
                    if (validateUser is null)
                    {
                        var usuario = new Users(request.NameUsuario, request.Email, request.Password, request.IdRol);
                        string pass = request.Password.DecodeBase64Password();
                        usuario.Password = await EncryptedPassword(pass);
                        await InsertUser(usuario);
                        var profesor = new Profesor(usuario.Id, request.Profesion);
                        await InsertProfesor(profesor);
                        response.SetDataResponse(HttpStatusCode.OK, $"Profesor {usuario.NameUsuario} creado con exito");

                        return response;


                    }
                    throw new ApiException($"the user already exists with name {request.NameUsuario}", (int)System.Net.HttpStatusCode.Conflict);


                });
                return response;
            }
            catch (Exception ex) when (ex is ApiException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApiException("Ocurrió un error inesperado", (int)System.Net.HttpStatusCode.InternalServerError);
            }
        }


        private async Task<string> EncryptedPassword(string password)
        {
            var keyEncrypted = (await configuiuracionRepository.GetByParam(x => x.Id.Equals(ParamConfig.KeyEncrypted.ToString())))?.Value ?? string.Empty;
            var iVEncrypted = (await configuiuracionRepository.GetByParam(x => x.Id.Equals(ParamConfig.IVEncrypted.ToString())))?.Value ?? string.Empty;


            byte[] key = Encoding.UTF8.GetBytes(keyEncrypted);
            byte[] iv = Encoding.UTF8.GetBytes(iVEncrypted);

            using (TripleDES aes = TripleDES.Create())
            {


                ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);

                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] encryptedPasswordBytes = encryptor.TransformFinalBlock(passwordBytes, 0, passwordBytes.Length);

                string encryptedPassword = Convert.ToBase64String(encryptedPasswordBytes);
                return encryptedPassword;
            }
        }
        private async Task<Users?> ValidateUserName(string? userName)
        {
            var user = await _usuarioRepository.GetByParam(x => x.NameUsuario.Equals(userName));
            return user;
        }
        private async Task InsertUser(Users usuario)
        {
            await _usuarioRepository.Insert(usuario);
        }
        private async Task InsertProfesor(Profesor profesor)
        {
            await profesorRepository.Insert(profesor);
        }
    }
}
