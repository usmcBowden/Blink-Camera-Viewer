using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blink_Camera_Viewer
{
    class Camera
    {
        private string ID, NAME, ENABLED, BATTERY, URL, NETWORK;
        private byte[] response;
        private string RTSP;
        Utilities util = new Utilities();
        public Camera(String id, String name, String enabled, String battery, String url, String network)
        {
            ID = id;
            NAME = name;
            URL = url;
            BATTERY = battery;
            ENABLED = enabled;
            NETWORK = network;
        }
        public async Task<byte[]> GetThumbnailAsync(String token, String tier)
        {
          
            using (var httpClient = new HttpClient())
            {

                using (var request = new HttpRequestMessage(new HttpMethod("GET"), Properties.Settings.Default.RegionAPI + URL + ".jpg"))
                {
                    try
                    {
                        request.Headers.TryAddWithoutValidation("token-auth", token);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    HttpContent content = httpClient.SendAsync(request).Result.Content;
                    response = await content.ReadAsByteArrayAsync();
                }
            }
            return response;
        }
        public async Task<string> GetLiveStreamAsync(String account, String token, String tier)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), Properties.Settings.Default.RegionAPI + "/api/v5/accounts/" + account +"/networks/"+NETWORK+"/cameras/"+ID+"/liveview"))
                {
                    try
                    {
                        request.Headers.TryAddWithoutValidation("token-auth", token);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    request.Content = new StringContent("{\"intent\":\"liveview\",\"motion_event_start_time\":\"\"}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");


                    HttpContent content = httpClient.SendAsync(request).Result.Content;
                    RTSP = await content.ReadAsStringAsync();                  
                }
            }
            return util.RTSP(RTSP);
        }
        public async Task UpdateThumnailAsync(String token, String tier)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), Properties.Settings.Default.RegionAPI + "/network/" + NETWORK+"/camera/"+ID+"/thumbnail"))
                {
                    try
                    {
                        request.Headers.TryAddWithoutValidation("token-auth", token);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    var response = await httpClient.SendAsync(request);
                }
            }
        }
        public async Task ArmOrDisarmAsync(String tier, string token)
        {
            if (isArmed() == "Armed")
                await DisableAsync(tier, token);
            else
                await EnableAsync(tier, token);

        }
        private async Task EnableAsync(String tier, String token)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), Properties.Settings.Default.RegionAPI + "/network/" + NETWORK+"/camera/"+ID+"/enable"))
                {
                    try
                    {
                        request.Headers.TryAddWithoutValidation("token-auth", token);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    var response = await httpClient.SendAsync(request);
                }
            }
        }
        private async Task DisableAsync(String tier, String token)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), Properties.Settings.Default.RegionAPI + "/network/" + NETWORK + "/camera/" + ID + "/disable"))
                {
                    try
                    {
                        request.Headers.TryAddWithoutValidation("token-auth", token);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    var response = await httpClient.SendAsync(request);
                }
            }
        }
        public String CameraName()
        {
            return NAME;
        }
        public String BatteryLevel()
        {
            return BATTERY;
        }
        public String isArmed()
        {
            if (Convert.ToBoolean(ENABLED))
                return "Armed";
            else
                return "Disarmed";
        }
    }
}
