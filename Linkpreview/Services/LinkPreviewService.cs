using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linkpreview.Core;
using Newtonsoft.Json;

namespace Linkpreview.Services
{
    public class LinkPreviewService
    {
        private readonly string apiKey = "ENTER YOUR API KEY";
        private readonly string apiUrl = "https://api.linkpreview.net/";

        public async Task<LinkPreviewResponse> GetLinkPreviewAsync(string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("X-Linkpreview-Api-Key", apiKey);

                var response = await client.GetStringAsync($"{apiUrl}?q={url}");
                if (!string.IsNullOrEmpty(response))
                {
                    var result = JsonConvert.DeserializeObject<LinkPreviewResponse>(response);
                    if (result == null)
                    {
                        throw new HttpRequestException("Deserialization returned null.");
                    }
                    return result;
                }
                throw new HttpRequestException("Unable to fetch data from LinkPreview API.");
            }
        }

    }
}
