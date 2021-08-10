using Business.Abstract;
using Business.Constants;

using Businness.Abstract;

using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;

using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        
        private ICustomerService _customerService;
        private ITokenHelper _tokenHelper;

        public AuthManager(ICustomerService customerService, ITokenHelper tokenHelper)
        {
            _customerService = customerService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(Customer customer)
        {
            var claims = _customerService.GetClaims(customer);
            var accessToken = _tokenHelper.CreateToken(customer, claims);
            return new SuccessDataResult<AccessToken>(accessToken,"Access Token Created");
        }

        public IDataResult<Customer> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _customerService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<Customer>(Messages.UserNotFound);
            }
            if (HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<Customer>(Messages.PasswordError);
            }

            return new SuccessDataResult<Customer>(userToCheck,Messages.LoginSuccessfull);

        }

        public IDataResult<Customer> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new Customer
            {
                Email = userForRegisterDto.Email,
                Name =  userForRegisterDto.FirstName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
               
            };
            _customerService.Add(user);
            return new SuccessDataResult<Customer>(user, Messages.UserRegisterSuccess);
        }

        public IResult UserExist(string email)
        {
            if (_customerService.GetByMail(email)!=null)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }
            return new SuccessResult("Not Exist!");
        }
    }
}
