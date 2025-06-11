using AuthenticationDemo.Domain.Entities;
using DTOs;

public class AuthService : IAuthService
{
    private readonly IJwtTokenGenerator _jwtService;
    private readonly List<User> _users; // For now, hardcoded

    public AuthService(IJwtTokenGenerator jwtService)
    {
        _jwtService = jwtService;
        _users = new()
        {
            new User { Username = "admin", HashedPassword = "password", Role = "admin" },
            new User { Username = "mod", HashedPassword = "password", Role = "moderator" },
            new User { Username = "user", HashedPassword = "password", Role = "user" }
        };
    }

    public (string Token, string Role) Login(LoginRequest request)
    {
        var user = _users.FirstOrDefault(u =>
            u.Username == request.Username && u.HashedPassword == request.Password);
        if (user == null)
            throw new UnauthorizedAccessException("Invalid credentials");

        var token = _jwtService.GenerateToken(user.Username, user.Role);
        return (token, user.Role);
    }

}
