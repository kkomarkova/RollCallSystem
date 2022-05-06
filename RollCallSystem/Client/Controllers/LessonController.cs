using Newtonsoft.Json;
using RollCallSystem.Shared;
using System.Net.Http.Headers;

namespace RollCallSystem.Client.Controllers
{
    public class LessonController
    {
        private const string Url = "https://rollcallsystem-kea.azurewebsites.net/api/";
        private HttpClient client;

        public LessonController()
        {
            client = new HttpClient();
        }

        public async Task<Lesson> GetCurrentLesson(User user)
        {
            Lesson lesson = new Lesson();
            
            HttpResponseMessage response;

            using (var requestMessage =
            new HttpRequestMessage(HttpMethod.Get, Url + "Lessons/Current"))
            {
                requestMessage.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", user.Token);

                response = await client.SendAsync(requestMessage);
            }

            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            LessonData lessonData = JsonConvert.DeserializeObject<LessonData>(content);
            lesson = new Lesson(lessonData.id, lessonData.subjectName, lessonData.startTime, lessonData.code, lessonData.codeTime,
                lessonData.campusName, lessonData.teacherName);

            return lesson;
        }

        public async Task<bool> StartRollCall(Lesson lesson, User user)
        {
            bool success = false;

            HttpResponseMessage response;

            using (var requestMessage =
            new HttpRequestMessage(HttpMethod.Put, Url + $"/Lessons/StartRollCall/{lesson.id}"))
            {
                requestMessage.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", user.Token);

                response = await client.SendAsync(requestMessage);
            }

            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            if (content == "Roll call has started.")
                success = true;

            return success;
        }

        [Serializable]
        class LessonData { public int id; public string subjectId; public string subjectName; public DateTime startTime;
            public int? code; public DateTime? codeTime; public int campusId; public string campusName; public string teacherName;
        }
    }
}
