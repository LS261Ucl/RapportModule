using RestSharp;
using System.Net.Http.Headers;
using System.Text;

namespace Rapport.BusinessLogig.Extensions
{
    public class PdfExtension
    {
        private static readonly HttpClient client = new HttpClient();

        private static readonly string urlToFlow = "https://prod-255.westeurope.logic.azure.com:443/workflows/bbffe4124f3245c4add335889da12bd9/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=OAIiKdY0bFWhYbpDRX70lxCliu6q6OPj5uVBSQCCsmo";
        private static readonly string htmlContent = "<html><body><H1>Hello World</H1></body></html>";


        /// <summary>
        /// https://powerusers.microsoft.com/t5/Using-Flows/trigger-a-flow-using-c/td-p/616386
        /// </summary>
        /// <returns></returns>
        public async Task ComeOnII()
        {
            var client = new HttpClient();
            //var body = "{\"html\": \" < html >\n < body >\n<H1> Hello World </ H1 >\n </ body >\n </ html > \",\"email\": \"lenesvit @gmail.com\",\"filename\": \"Report004\"}";
            // HttpContent httpContent = new StringContent(htmlContent);    
            var response = await client.PostAsync(urlToFlow, null);
            string result = response.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// https://elbruno.com/2017/02/06/flow-remote-calling-a-flow-from-a-csharp-consoleapp/
        /// </summary>
        public async Task<RestResponse> comeOn()
        {
            var body = "{\"html\": \"test\",\"email\": \"lenesvit @gmail.com\",\"filename\": \"Report004\"}";
            var client = new RestClient(urlToFlow);
            var request = new RestRequest(Method.Post.ToString());
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var responce = client.ExecuteAsync(request);
            return responce.Result;
        }


        public async Task testAPIAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(urlToFlow);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
                var body = "{\"html\": \" < html >\n < body >\n<H1> Hello World </ H1 >\n </ body >\n </ html > \",\"email\": \"lenesvit @gmail.com\",\"filename\": \"Report004\"}";
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                request.Content = content;



                try
                {
                    var response = await client.SendAsync(request).ConfigureAwait(false);
                    var responseString = string.Empty;
                    response.EnsureSuccessStatusCode();
                    responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Console.WriteLine(response);
                }
                catch (HttpRequestException hre)
                {
                    Console.WriteLine(hre.Message);
                }



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception();
            }
        }
    }
}
