using IntercomCommunication.Models.Request;
using IntercomCommunication.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IntercomCommunication.Implementation
{
    public class IntercomHandler
    {
        private string baseUrl;
        private string userName;
        private string password;
        private string Token;

        public IntercomHandler(string baseUrl, string userName, string password)
        {
            this.baseUrl = baseUrl;
            this.userName = userName;
            this.password = password;

            Login().Wait();
        }

        public async Task<string> CreateSlot(TimeSlot timeSlot)
        {
            try
            {
                string responseModel = await CreateIdentifier(timeSlot.@base);
                if (!String.IsNullOrEmpty(responseModel))
                {
                    await UpdateIdentifier(timeSlot, responseModel);
                }
                return responseModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<string> CreateIdentifier(Base baseRequest)
        {
            try
            {
                using (var http = new HttpClient())
                {
                    http.BaseAddress = new Uri(baseUrl);
                    http.Timeout = TimeSpan.FromSeconds(30);
                    var request = new HttpRequestMessage(HttpMethod.Post, $"/api/v0/access/identifiers/item");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    request.Content = new StringContent(JsonConvert.SerializeObject(baseRequest), Encoding.UTF8, "application/json");
                    var rawMessage = await request.Content.ReadAsStringAsync();
                    var response = await http.SendAsync(request);
                    var content = await response.Content.ReadAsStringAsync();
                    var responseModel = JsonConvert.DeserializeObject<DeviceResponse>(content);
                    return responseModel.uid;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async Task<bool> UpdateIdentifier(TimeSlot timeSlot, string uid)
        {
            try
            {
                using (var http = new HttpClient())
                {
                    http.BaseAddress = new Uri(baseUrl);
                    http.Timeout = TimeSpan.FromSeconds(30);
                    var request = new HttpRequestMessage(HttpMethod.Patch, $"/api/v0/access/identifiers/item/" + uid);
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    request.Content = new StringContent(JsonConvert.SerializeObject(timeSlot), Encoding.UTF8, "application/json");
                    var rawMessage = await request.Content.ReadAsStringAsync();
                    var response = await http.SendAsync(request);
                    var content = await response.Content.ReadAsStringAsync();
                    var responseModel = JsonConvert.DeserializeObject(content);
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IntercomeInformationResponse> GetInformation()
        {
            try
            {
                using (var http = new HttpClient())
                {
                    http.BaseAddress = new Uri(baseUrl);
                    http.Timeout = TimeSpan.FromSeconds(60);
                    var request = new HttpRequestMessage(HttpMethod.Get, $"/api/info");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    var response = await http.SendAsync(request);

                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IntercomeInformationResponse>(content);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<GetDeviceTime> GetDeviceTime()
        {
            try
            {
                using (var http = new HttpClient())
                {
                    http.BaseAddress = new Uri(baseUrl);
                    http.Timeout = TimeSpan.FromSeconds(60);
                    var request = new HttpRequestMessage(HttpMethod.Get, $"api/v0/device/time");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    var response = await http.SendAsync(request);

                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GetDeviceTime>(content);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<bool> Login()
        {
            try
            {
                using (var http = new HttpClient())
                {
                    http.BaseAddress = new Uri(baseUrl);
                    http.Timeout = TimeSpan.FromSeconds(60);
                    var request = new HttpRequestMessage(HttpMethod.Get, $"/api/v0/login?username={userName}&password={new Encription().MD5Hash(password)}");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    var response = await http.SendAsync(request);

                    string content = await response.Content.ReadAsStringAsync();
                    var responseModel = JsonConvert.DeserializeObject<LoginResponse>(content);
                    Token = responseModel.token.ToString();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
