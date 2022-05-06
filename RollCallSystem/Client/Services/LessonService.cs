using RollCallSystem.Shared;
using RollCallSystem.Client.Controllers;

namespace RollCallSystem.Client.Services
{
    public class LessonService
    {
        public static Action<Lesson> OnCurrentLessonUpdated;

        public async Task<bool> GetCurrentLesson(User user)
        {
            Lesson loggedInUser;

            LessonController userController = new LessonController();
            loggedInUser = await userController.GetCurrentLesson(user);

            if (loggedInUser != null)
            {
                OnCurrentLessonUpdated?.Invoke(loggedInUser);
                return true;
            }

            return false;
        }
    }
}
