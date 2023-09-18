using KTTV.Models;
using Newtonsoft.Json;
using System.Dynamic;
using System.Text;

namespace KTTV.Services
{
    internal class TramService : BaseService
    {
        public async Task<List<Tram>> GetAll(string token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseUrl}/api/Tram/get-all";
                    dynamic context = new ExpandoObject();
                    context.Token = token;
                    var serializeContent = JsonConvert.SerializeObject(context);

                    var stringContent = new StringContent(serializeContent, Encoding.UTF8, "application/json");
                    var apiResponse = await client.PostAsync(url, stringContent);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string body = await apiResponse.Content.ReadAsStringAsync();

                        dynamic result = JsonConvert.DeserializeObject<ExpandoObject>(body);

                        List<Tram> trams = new List<Tram>();
                        foreach(var t in result.value)
                        {
                            var json = JsonConvert.SerializeObject(t);
                            var tram = JsonConvert.DeserializeObject<Tram>(json);
                            trams.Add(tram);

                            //trams.Add(new Tram
                            //{
                            //    Id = t._id,
                            //    Latitude = t.Latitude,
                            //    Longitude = t.Longitude,
                            //    Ten = t.Ten,
                            //    Type = t.Type,
                            //    IsActive = t.IsActive,
                            //    Area = t.Area
                            //});
                        }

                        return trams;
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
        public async Task<ExpandoObject> Create(string token, Tram tram)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseUrl}/api/Tram/";
                    dynamic context = new ExpandoObject();
                    context.Token = token;
                    context.value = tram;
                    var serializeContent = JsonConvert.SerializeObject(context);

                    var stringContent = new StringContent(serializeContent, Encoding.UTF8, "application/json");
                    var apiResponse = await client.PostAsync(url, stringContent);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string body = await apiResponse.Content.ReadAsStringAsync();

                        dynamic? result = JsonConvert.DeserializeObject<ExpandoObject>(body);

                        if (result != null)
                        {
                            return result;
                        }
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

        public async Task<ExpandoObject> Delete(string token, string id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseUrl}/api/Tram/delete";
                    dynamic context = new ExpandoObject();
                    context.Token = token;
                    context._id = id;
                    var serializeContent = JsonConvert.SerializeObject(context);

                    var stringContent = new StringContent(serializeContent, Encoding.UTF8, "application/json");
                    var apiResponse = await client.PostAsync(url, stringContent);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string body = await apiResponse.Content.ReadAsStringAsync();

                        dynamic? result = JsonConvert.DeserializeObject<ExpandoObject>(body);

                        if (result != null)
                        {
                            return result;
                        }
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

        public async Task<ExpandoObject> Update(string token, Tram newTram)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseUrl}/api/Tram/Update";
                    dynamic context = new ExpandoObject();
                    context.Token = token;
                    context.value = newTram;
                    var serializeContent = JsonConvert.SerializeObject(context);

                    var stringContent = new StringContent(serializeContent, Encoding.UTF8, "application/json");
                    var apiResponse = await client.PostAsync(url, stringContent);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string body = await apiResponse.Content.ReadAsStringAsync();

                        dynamic? result = JsonConvert.DeserializeObject<ExpandoObject>(body);

                        if (result != null)
                        {
                            return result;
                        }
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
