using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HealthyInformation.Utility
{
    public class SerializeHelper
    {
        public static async Task<string> JsonSerialize<T>(T TEntity) where T : class
        {
            return await Task.Factory.StartNew(() => { return JsonConvert.SerializeObject(TEntity); });
        }

        public static async Task<T> JsonDeserialize<T>(string content) where T : class
        {
            return await Task.Factory.StartNew(() => { return JsonConvert.DeserializeObject<T>(content); });
        }
    }
}
