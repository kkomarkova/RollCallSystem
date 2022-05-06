using Newtonsoft.Json;
using RollCallSystem.Shared;
using System.Net.Http.Headers;

namespace RollCallSystem.Client.Controllers
{
    public class LessonController
    {
        private const string Url = "https://rollcallsystem-kea.azurewebsites.net/api/";

        public async Task<Lesson> GetCurrentLesson(User user)
        {
            Lesson lesson = new Lesson();

            HttpClient client = new HttpClient();
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

        [Serializable]
        class LessonData { public int id; public string subjectId; public string subjectName; public DateTime startTime;
            public int? code; public DateTime? codeTime; public int campusId; public string campusName; public string teacherName;
        }
    }
}
