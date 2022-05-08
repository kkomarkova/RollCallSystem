using RollCallSystem.Client.Services;
using RollCallSystem.Shared;

namespace RollCallSystem.Client.ViewModels
{
    public class LoginViewModel
    {
        public static User currentUser { get; private set; }
        

        public LoginViewModel()
        {
            LoginService.OnLoginSuccessful += (x => AssignCurrentUser(x));
        }

        public async Task LogIn(string email, string password)
        {
            LoginService loginService = new LoginService();
            bool sucess = await loginService.LoginUser(email, password);
        }

        public async Task GetCurrentLesson(User user)
        {
            LessonService lessonService = new LessonService();
            bool success = await lessonService.GetCurrentLesson(user);
        }

        public async Task StartRollCall(Lesson lesson, User user)
        {
            LessonService lessonService = new LessonService();
            bool success = await lessonService.StartRollCall(lesson, user);
        }

        private void AssignCurrentUser(User user)
        {
            currentUser = user;
        }
    }
}
