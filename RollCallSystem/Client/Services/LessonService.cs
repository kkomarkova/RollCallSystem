using RollCallSystem.Shared;
using RollCallSystem.Client.Controllers;

namespace RollCallSystem.Client.Services
{
    public class LessonService
    {
        public static Action<Lesson> OnCurrentLessonUpdated;
        public static Action<List<Lesson>> OnLessonsByMonthUpdated;

        private LessonController lessonController = new LessonController();
        private UserController userController = new UserController();

        public async Task<bool> GetCurrentLesson(User user)
        {
            Lesson currentLesson;

            LessonController userController = new LessonController();
            currentLesson = await userController.GetCurrentLesson(user);

            if (currentLesson != null)
            {
                OnCurrentLessonUpdated?.Invoke(currentLesson);

                currentLesson.checkedInStudents = await GetCheckedInStudents(currentLesson, user);
                OnCurrentLessonUpdated?.Invoke(currentLesson);
                return true;
            }

            return false;
        }

        public async Task<bool> StartRollCall(Lesson lesson, User user)
        {
            Lesson currentLesson = null;

            bool success = await lessonController.StartRollCall(lesson, user);

            if (success)
            {
                currentLesson = await lessonController.GetCurrentLesson(user);
            }            

            if (currentLesson != null)
            {
                OnCurrentLessonUpdated?.Invoke(currentLesson);
                return true;
            }

            return false;
        }

        public async Task<bool> GetLessonsByMonth(User user, int monthNo)
        {
            List<Lesson> lessons = await lessonController.GetLessonsByMonth(user, monthNo);
            Console.WriteLine("succ");
            if (lessons != default)
            {
                OnLessonsByMonthUpdated?.Invoke(lessons);
                return true;
            }

            return false;
        }

        public async Task<List<User>> GetCheckedInStudents(Lesson lesson, User user)
        {
            List<User> checkedInStudents = new List<User>();

            checkedInStudents = await userController.GetCheckedInStudents(lesson, user);

            return checkedInStudents;
        }
    }
}
