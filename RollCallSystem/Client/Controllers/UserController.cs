using Newtonsoft.Json;
using RollCallSystem.Shared;
using System.Net.Http.Headers;
using System.Text;

namespace RollCallSystem.Client.Controllers
{
    public class UserController
    {
        private const string Url = "https://rollcallsystem-kea.azurewebsites.net/api/";

        public async Task<User> LogIn(string email, string password)
        {
            User user = new User();
            string token = "";

            LoginData loginData = new LoginData()
            {
                email = email,
                password = password
            };

            string jsonData = JsonConvert.SerializeObject(loginData);
            StringContent postData = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.PostAsync(Url + "JWTTokens", postData);
            response.EnsureSuccessStatusCode();
            token = await response.Content.ReadAsStringAsync();

            using (var requestMessage =
            new HttpRequestMessage(HttpMethod.Get, Url + "Users/Self"))
            {
                requestMessage.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                response = await client.SendAsync(requestMessage);
            }

            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            UserData userData = JsonConvert.DeserializeObject<UserData>(content);
            user = new User(userData.id, userData.firstName, userData.lastName, userData.email, token);

            return user;
        }

        [Serializable]
        class LoginData { public string email; public string password; }

        [Serializable]
        class UserData { public int id; public string email; public string firstName; public string lastName; public int roleId; }
    }
}
