using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Blink_Camera_Viewer
{
    class Clip
    {
        private String NAME, DATE, URL, THUMB, TOKEN, TIER;
        private byte[] THUMB_BYTES;
        public Clip(String name, String date, String url, String thumb, String token, String tier)
        {
            NAME = name;
            DATE = date;
            URL = url;
            THUMB = thumb;
            TOKEN = token;
            TIER = tier;
            SetThumbBytes();
        }
        private async Task<byte[]> GetClipThumbnailAsync()
        {
            byte[] response;
            using (var httpClient = new HttpClient())
            {

                using (var request = new HttpRequestMessage(new HttpMethod("GET"), Properties.Settings.Default.RegionAPI + THUMB + ".jpg"))
                {
                    request.Headers.TryAddWithoutValidation("token-auth", TOKEN);
                    HttpContent content = httpClient.SendAsync(request).Result.Content;
                    response = await content.ReadAsByteArrayAsync();
                }
            }
            return response;
        }        
        private async void SetThumbBytes()
        {
            THUMB_BYTES = await GetClipThumbnailAsync(); 
        }
        public String GetName()
        {
            return NAME;
        }
        public String GetDate()
        {
            return DATE;
        }
        public byte[] GetThumbnail()
        {
            return THUMB_BYTES;
        }
        public String GetClip()
        {
            return URL;
        }
    }
}
