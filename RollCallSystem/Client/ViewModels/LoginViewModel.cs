using RollCallSystem.Client.Services;

namespace RollCallSystem.Client.ViewModels
{
    public class LoginViewModel
    {
        

        public LoginViewModel()
        {
            
        }

        public async Task LogIn(string email, string password)
        {
            LoginService loginService = new LoginService();
            bool sucess = await loginService.LoginUser(email, password);
        }
    }
}
