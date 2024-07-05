using VeggieLink.Aplication.Dtos.User;
using VeggieLink.Data.Collections;

namespace VeggieLink.Aplication.Interfaces;

public interface IAuthService
{
    AuthDto GenerateJWT(UserCollection user);
    Task<AuthDto> Login(LoginDto dto);
}