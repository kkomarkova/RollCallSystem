using RollCallSystem.Shared;
using RollCallSystem.Client.Controllers;

namespace RollCallSystem.Client.Services
{
    public class LessonService
    {
        public static Action<Lesson> OnCurrentLessonUpdated;

        public async Task<bool> GetCurrentLesson(User user)
        {
            Lesson currentLesson;

            LessonController userController = new LessonController();
            currentLesson = await userController.GetCurrentLesson(user);

            if (currentLesson != null)
            {
                OnCurrentLessonUpdated?.Invoke(currentLesson);
                return true;
            }

            return false;
        }

        public async Task<bool> StartRollCall(Lesson lesson, User user)
        {
            Lesson currentLesson = null;

            LessonController userController = new LessonController();

            bool success = await userController.StartRollCall(lesson, user);

            if (success)
            {
                currentLesson = await userController.GetCurrentLesson(user);
            }            

            if (currentLesson != null)
            {
                OnCurrentLessonUpdated?.Invoke(currentLesson);
                return true;
            }

            return false;
        }
    }
}
