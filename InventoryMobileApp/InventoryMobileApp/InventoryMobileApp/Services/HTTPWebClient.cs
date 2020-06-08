using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMobileApp.Services
{
    public class InventoryWebClient
    {
        private bool isConnected = false;
        private const int timeOut = 5;
        private string mediaType = "application/json";

        public async Task<HttpResponseMessage> GetDetails(string url)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromMinutes(timeOut);
                httpClient.BaseAddress = new Uri("http://localhost:60138/"); //new Uri(App.ServiceUrl);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

                HttpResponseMessage response = new HttpResponseMessage();
                try
                {
                    response = await httpClient.GetAsync(url).ConfigureAwait(false);
                }
                catch (Exception)
                {

                }

                return response;
            }
        }


        public async Task<HttpResponseMessage> PostDetails(string url, string JData)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromMinutes(timeOut);
                httpClient.BaseAddress = new Uri("http://localhost:60138/");//new Uri(App.ServiceUrl);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

                HttpResponseMessage response = new HttpResponseMessage();

                try
                {
                    var content = new StringContent(JData, Encoding.UTF8, "application/json");
                    response = await httpClient.PostAsync(url, content).ConfigureAwait(false);

                    if (response !=null)
                    {
                        return response;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }

                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
