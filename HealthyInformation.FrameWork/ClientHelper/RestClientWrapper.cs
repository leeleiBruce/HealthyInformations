using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.FrameWork.ClientHelper
{
    public class RestClientWrapper
    {
        HttpClient client = new HttpClient();
        WindowBase windowBase;
        public RestClientWrapper()
        {
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseAdress"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public RestClientWrapper(string serviceBase, string folder, WindowBase windowBase, bool isShow = true)
            : this()
        {
            client.BaseAddress = new Uri(client.BaseAddress, serviceBase);
            client.DefaultRequestHeaders.Add("Folder", folder);
            this.windowBase = windowBase;
            AsyncProgress.GetInstance().InjectWindowBase(windowBase, isShow);
        }

        protected async Task<T> GetAsync<T>(string relativeUri)
        {
            AsyncProgress.GetInstance().ShowPopup();
            Uri uri = new Uri(string.Concat(client.BaseAddress.AbsoluteUri, "/", relativeUri));
            HttpResponseMessage response = await client.GetAsync(uri, HttpCompletionOption.ResponseContentRead);
            AsyncProgress.GetInstance().HidePopup();
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            else
            {
                return default(T);
            }
        }

        protected async Task<TOut> PostAsync<TIn, TOut>(string relativeUri, TIn param)
        {
            AsyncProgress.GetInstance().ShowPopup();
            Uri uri = new Uri(string.Concat(client.BaseAddress.AbsoluteUri, "/", relativeUri));

            var microsoftDateFormatSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };
            string microsoftJson = JsonConvert.SerializeObject(param, microsoftDateFormatSettings);

            HttpResponseMessage response = await client.PostAsync(uri, new StringContent(
                               microsoftJson,
                            Encoding.UTF8, "application/json"));
            AsyncProgress.GetInstance().HidePopup();
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<TOut>();
        }

        protected async Task<TOut> PutAsync<TIn, TOut>(string relativeUri, TIn param)
        {
            AsyncProgress.GetInstance().ShowPopup();
            Uri uri = new Uri(string.Concat(client.BaseAddress.AbsoluteUri, "/", relativeUri));
            var microsoftDateFormatSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };

            string microsoftJson = JsonConvert.SerializeObject(param, microsoftDateFormatSettings);
            HttpResponseMessage response = await client.PutAsync(uri, new StringContent(
                               microsoftJson,
                            Encoding.UTF8, "application/json"));
            AsyncProgress.GetInstance().HidePopup();
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<TOut>();
        }

        protected async Task<TOut> DeleteAsync<TOut>(string relativeUri)
        {
            AsyncProgress.GetInstance().ShowPopup();
            Uri uri = new Uri(string.Concat(client.BaseAddress.AbsoluteUri, "/", relativeUri));
            HttpResponseMessage response = await client.DeleteAsync(uri);
            AsyncProgress.GetInstance().HidePopup();
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<TOut>();
        }
    }
}

