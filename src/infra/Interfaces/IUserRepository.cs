using VeggieLink.Data.Collections;

namespace VeggieLink.Infra.Interfaces;

public interface IUserRepository
{
    Task Create(UserCollection collection);
    Task UpdateUser(UserCollection dto, string id);
    Task<UserCollection> FindByEmail(string email);
}