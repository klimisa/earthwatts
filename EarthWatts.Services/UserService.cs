using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EarthWatts.Domain;
using EarthWatts.Infrastructure.Security;
using EarthWatts.Repository;

namespace EarthWatts.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService() : this(new UserRepository())
        {

        }

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Response> RegisterUser(string firstName, string lastName, string emailAddress, string password)
        {
            var response = new Response();

            try
            {
                var user = await _userRepository.GetByEmailAddressAsync(emailAddress);
                if (user != null)
                {
                    throw new Exception("User already registered.");
                }

                var salt = SecurityHelper.GetSalt();
                var saltedPassword = salt + password;
                var hash = PasswordStorage.CreateHash(saltedPassword);
                var newUser = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    EmailAddress = emailAddress,
                    Password = hash,
                    Salt = salt
                };

                await _userRepository.AddAsync(newUser);
                response.Success = true;
                return response;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Errors.Add(e.Message);
                return response;
            }
        }
        public async Task<Response> LoginUser(string emailAddress, string password)
        {
            var response = new Response();

            try
            {
                var user = await _userRepository.GetByEmailAddressAsync(emailAddress);
                if (user == null)
                {
                    throw new Exception("User not found.");
                }

                var saltedPassword = user.Salt + password;
                if (PasswordStorage.VerifyPassword(saltedPassword, user.Password))
                {
                    response.Success = true;
                    return response;
                }

                response.Success = false;
                response.Errors.Add("Invalid password.");
                return response;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Errors.Add(e.Message);
                return response;
            }
        }
    }
}
