using KTTV.Models;
using Newtonsoft.Json;
using System.Dynamic;
using System.Text;

namespace KTTV.Services
{
    internal class AuthService : BaseService
    {
        public async Task<ExpandoObject> Login(LoginModel loginAccount)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseUrl}/api/Account/Login";
                    var serializeContent = JsonConvert.SerializeObject(loginAccount);

                    var stringContent = new StringContent(serializeContent, Encoding.UTF8, "application/json");
                    var apiResponse = await client.PostAsync(url, stringContent);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string body = await apiResponse.Content.ReadAsStringAsync();

                        dynamic? result = JsonConvert.DeserializeObject<ExpandoObject>(body);

                        return result;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
    }
}
