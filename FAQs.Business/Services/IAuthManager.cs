using FAQs.Data.DTOs;

namespace FAQs.Business.Services;

public interface IAuthManager
{
    Task<bool> ValidateUser(LoginUserDto userDto);

    Task<string> CreateToken();
}