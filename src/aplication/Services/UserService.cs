using aplication.Services;
using VeggieLink.Aplication.Dtos.User;
using VeggieLink.Aplication.Interfaces;
using VeggieLink.Infra.Interfaces;
using BC = BCrypt.Net.BCrypt;
using VeggieLink.Aplication.Validators.User;
using aplication.Exceptions;
using AutoMapper;
using VeggieLink.Data.Collections;

namespace VeggieLink.Aplication.Services;

public class UserService : BaseService, IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    private readonly IAuthService _authService;

    public UserService(IUserRepository repository, IMapper mapper, IAuthService authService)
    {
        _repository = repository;
        _mapper = mapper;
        _authService = authService;
    }
    public async Task<AuthDto> CreateUser(CreateUserDto dto)
    {
        Validate(new CreateUserValidator(), dto);

        dto.Email = dto.Email.Trim();
        var email = await  _repository.FindByEmail(dto.Email);

        if (email != null)
        {
            throw CustomException.ErroValidacao(new { error = "Email em uso!" });
        }

        var user = _mapper.Map<UserCollection>(dto);

        var password = BC.HashPassword(dto.Password);

        user.Name = dto.Name;
        user.Description = dto.Description;
        user.Email = dto.Email;
        user.Photo = dto.Photo;
        user.Segment = dto.Segment;
        user.Password = password;

        await _repository.Create(user);
        return _authService.GenerateJWT(user);
    }
}