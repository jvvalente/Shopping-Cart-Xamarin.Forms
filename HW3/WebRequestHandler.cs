using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    public class WebRequestHandler
    {
        private HttpClient Client { get; }
        public WebRequestHandler()
        {
            Client = new HttpClient();
        }
        public async Task<string> Get(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetStringAsync(url).ConfigureAwait(false);
                    return response;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Does not even get there " + e.Message + " " + e.GetBaseException() +  " " + e.HelpLink);
               
            }


            return null;
        }

        public async Task<string> Post(string url, object obj)
        {
            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    var json = JsonConvert.SerializeObject(obj);
                    using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                    {
                        request.Content = stringContent;

                        using (var response = await client
                            .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                            .ConfigureAwait(false))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                return await response.Content.ReadAsStringAsync();
                            }
                            return "ERROR";
                        }
                    }
                }
            }
        }
    }
}
