using Core.Entites.Concrete;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Security.JWT;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(RegisterDto userRegisterDto);
        IDataResult<User> Login(LoginDto userLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);

    }
}
