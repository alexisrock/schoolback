using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum ParamConfig
    {
        JwtSecretKey,
        JwtIssuerToken,
        JwtAudienceToken,
        JwtExpireTime,
        KeyEncrypted,
        IVEncrypted,

    }


    public enum Rol
    {
        Profesor = 1,
        Estudiante = 2,
    }
}
