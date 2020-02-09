using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MessagerApi.Services.Providers
{
    public class NetworkProvider
    {
        private static readonly HttpClient _Client = new HttpClient();
        public async Task RequestPost(string pUrl, string jsonBody, Dictionary<string, string> headers = null)
        {
            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Post;
            httpRequestMessage.RequestUri = new Uri(pUrl);

            if (headers != null)
            {
                foreach (var head in headers)
                {
                    httpRequestMessage.Headers.Add(head.Key, head.Value);
                }
            }

            HttpContent httpContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            httpRequestMessage.Content = httpContent;

            await _Client.SendAsync(httpRequestMessage);
        }
    }
}