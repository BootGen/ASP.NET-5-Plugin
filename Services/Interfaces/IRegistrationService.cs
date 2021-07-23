namespace WebProject.Services
{
    public interface IRegistrationService
    {
        ProfileResponse Register(RegistrationData data);
    }
}
