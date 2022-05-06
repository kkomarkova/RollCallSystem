using RollCallSystem.Client.Controllers;
using RollCallSystem.Shared;

namespace RollCallSystem.Client.Services
{
    public class LoginService
    {
        public static Action<User> OnLoginSuccessful;

        public async Task<bool> LoginUser(string email, string password)
        {
            User loggedInUser = new User();

            UserController userController = new UserController();
            loggedInUser = await userController.LogIn(email, password);

            if(loggedInUser != null)
            {
                OnLoginSuccessful?.Invoke(loggedInUser);
                return true;
            }

            return false;
        }
    }
}
