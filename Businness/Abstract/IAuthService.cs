using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;

using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<Customer> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<Customer> Login(UserForLoginDto userForLoginDto);
        IResult UserExist(string email);
        IDataResult<AccessToken> CreateAccessToken(Customer customer);

    }
}
