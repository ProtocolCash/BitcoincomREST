using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BitcoincomREST
{
    public class RestResponse
    {
        public string body;
        public HttpStatusCode httpCode;
        public HttpResponseHeaders httpHeaders;

        public bool IsSuccessful()
        {
            return httpCode == HttpStatusCode.OK;
        }
    }

    public enum RequestMethod
    {
        POST,
        GET
    }

    public class BitcoincomRequestHandler : SimpleRequestHandler
    {
        public BitcoincomRequestHandler() : base("https://rest.bitcoin.com/v2/")
        {
        }
        public BitcoincomRequestHandler(string acceptType) : base("https://rest.bitcoin.com/v2/", acceptType)
        {
        }

        public async Task<RestResponse> MakeRequest(string path, RequestMethod method)
        {
            if (method == RequestMethod.POST)
                throw new ArgumentException("POST Requests must contain a body.");

            return await GetAsync(path);
        }

        public async Task<RestResponse> MakeRequest(string path, RequestMethod method, JObject jsonObjectBody)
        {
            if (method != RequestMethod.POST)
                throw new ArgumentException("Requests with jsonBody must use POST method.");

            return await PostAsync(path, jsonObjectBody.ToString(Formatting.None));
        }
    }

    public class SimpleRequestHandler
    {
        private readonly HttpClient _client;

        public SimpleRequestHandler(string urlBase, string acceptType = "*/*")
        {
            _client = new HttpClient {BaseAddress = new Uri(urlBase)};
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(acceptType));
        }

        protected async Task<RestResponse> GetAsync(string path)
        {
            var response = await _client.GetAsync(path);

            if (!response.IsSuccessStatusCode)
                return new RestResponse {body = "", httpCode = response.StatusCode, httpHeaders = response.Headers };

            var answer = await response.Content.ReadAsStringAsync();

            return new RestResponse {body = answer, httpCode = response.StatusCode, httpHeaders = response.Headers };
        }

        protected async Task<RestResponse> PostAsync(string path, string content)
        {
            var strContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(path, strContent);
            if (!response.IsSuccessStatusCode)
                return new RestResponse {body = "", httpCode = response.StatusCode, httpHeaders = response.Headers };

            var answer = await response.Content.ReadAsStringAsync();

            return new RestResponse {body = answer, httpCode = response.StatusCode, httpHeaders = response.Headers};
        }
    }
}