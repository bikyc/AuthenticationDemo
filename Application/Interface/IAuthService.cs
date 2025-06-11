using DTOs;


public interface IAuthService
{
    (string Token, string Role) Login(LoginRequest request);
}

