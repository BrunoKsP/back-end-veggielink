using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using aplication.Exceptions;
using aplication.Services;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using VeggieLink.Aplication.Dtos.User;
using VeggieLink.Aplication.Interfaces;
using VeggieLink.Data.Collections;
using VeggieLink.Infra.Interfaces;
using BC = BCrypt.Net.BCrypt;

namespace VeggieLink.Aplication.Services;

public class AuthService : BaseService, IAuthService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _repository;
    private readonly IConfiguration _configuration;

    public AuthService(IMapper mapper, IConfiguration configuration, IUserRepository repository)
    {
        _mapper = mapper;
        _configuration = configuration;
        _repository = repository;
    }

    public async Task<AuthDto> Login(LoginDto dto)
    {
        //Validate(new LoginValidator(), dto);

        dto.Email = dto.Email.Trim();

        var clienteEmail = await _repository.FindByEmail(dto.Email) ?? throw CustomException.EntityNotFound(new { error = "Email não encontrado!" });
        var senha = BC.Verify(dto.Password, clienteEmail.Password);

        if (clienteEmail == null || senha != true)
        {
            throw CustomException.BadRequest(new { error = "Email ou senha não correspondem" });
        }
        return GenerateJWT(clienteEmail);
    }


    public AuthDto GenerateJWT(UserCollection user)
    {
        var setting = _configuration["Jwt:Settings"];

        var key = Encoding.ASCII.GetBytes(setting);
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.Name, user.Name),
                new(ClaimTypes.Sid, user.Id),
                new(ClaimTypes.Email, user.Email)
            }),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Expires = DateTime.MaxValue
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new AuthDto
        {
            Token = tokenHandler.WriteToken(token),
            Name = user.Name
        };
    }
}