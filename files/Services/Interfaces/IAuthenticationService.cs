namespace WebProject.Services
{
    public interface IAuthenticationService
    {
        LoginResponse Login(AuthenticationData data);
    }
}
