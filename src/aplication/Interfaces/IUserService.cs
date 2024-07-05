using VeggieLink.Aplication.Dtos.User;

namespace VeggieLink.Aplication.Interfaces;

public interface IUserService
{
    Task<AuthDto> CreateUser(CreateUserDto dto);
}