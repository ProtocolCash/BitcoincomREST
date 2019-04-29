using System.Net.Http;
using System.Threading.Tasks;
using BitcoincomREST.v2.Model;
using Newtonsoft.Json;

namespace BitcoincomREST.v2
{
    public class Control
    {
        public static ControlInfo GetInfo(int timeout)
        {
            var task = GetInfoAsync();
            task.Wait(timeout);
            return task.Result;
        }

        public static async Task<ControlInfo> GetInfoAsync()
        {
            var request = new BitcoincomRequestHandler();
            var ret = await request.MakeRequest("control/getInfo", RequestMethod.GET);
            if (!ret.IsSuccessful())
                throw new HttpRequestException("HTTP Request Error: Received Status " + (int) ret.httpCode + " - " +
                                               ret.httpCode);

            return JsonConvert.DeserializeObject<ControlInfo>(ret.body);
        }
    }
}