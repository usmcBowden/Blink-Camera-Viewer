using Newtonsoft.Json.Linq;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Collections;

namespace Blink_Camera_Viewer
{
    class Utilities
    {
        private String response;
        public Utilities(){}
        public async Task<string> LoginAsync(string username, string password)
        {
            if (String.IsNullOrEmpty(Properties.Settings.Default.UUID))
            {//generate unique user id if one does not exist.
                Properties.Settings.Default.UUID = Guid.NewGuid().ToString();
                Properties.Settings.Default.Save();
            }

            String GUID = Properties.Settings.Default.UUID;

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), Properties.Resources.Login))
                {
                    request.Content = new StringContent("{\"unique_id\":\""+GUID+"\",\"password\":\"" + password + "\",\"email\":\"" + username + "\"}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    HttpContent content = httpClient.SendAsync(request).Result.Content;
                    response = await content.ReadAsStringAsync();
                }
            }
            return response;
        }
        public async Task<string> LogoutAsync(User user)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), Properties.Resources.APIBase + "/api/v4/account/"+user.getAccountID()+"/client/"+user.getClientID()+"/logout"))
                {
                    try
                    {
                        request.Headers.TryAddWithoutValidation("token-auth", user.getToken());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    HttpContent content = httpClient.SendAsync(request).Result.Content;
                    response = await content.ReadAsStringAsync();
                }
            }
            return response;
        }
        public async Task<string> VerifyAsync(User user, String pin)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), Properties.Settings.Default.RegionAPI + "/api/v4/account/" + user.getAccountID() + "/client/" + user.getClientID() + "/pin/verify"))
                {
                    try
                    {
                        request.Headers.TryAddWithoutValidation("token-auth", user.getToken());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    request.Content = new StringContent("{\"pin\":\""+pin+"\"}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    HttpContent content = httpClient.SendAsync(request).Result.Content;
                    response = await content.ReadAsStringAsync();
                }
            }
            return response;
        }
        public async Task<string> HomeAsync(User user)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), Properties.Settings.Default.RegionAPI + "/api/v3/accounts/" + user.getAccountID() + "/homescreen"))
                {
                    try
                    {
                        request.Headers.TryAddWithoutValidation("token-auth", user.getToken());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    HttpContent content = httpClient.SendAsync(request).Result.Content;
                    response = await content.ReadAsStringAsync();
                }
            }
            return response;
        }
        public async Task<string> GetClipsAsync(User user)
        {
            using (var httpClient = new HttpClient())
            {
                String date = DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd");
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), Properties.Settings.Default.RegionAPI + "/api/v1/accounts/" + user.getAccountID()+"/media/changed?since="+date+"T00%3A00%3A00%2B0000&page=1"))
                {
                    try
                    {
                        request.Headers.TryAddWithoutValidation("token-auth", user.getToken());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    HttpContent content = httpClient.SendAsync(request).Result.Content;
                    response = await content.ReadAsStringAsync();
                }
            }
            return response;
        }
        public async Task<byte[]> GetClipAsync(String url, String token)
        {
            byte[] response;
            using (var httpClient = new HttpClient())
            {

                using (var request = new HttpRequestMessage(new HttpMethod("GET"), Properties.Settings.Default.RegionAPI + url))
                {
                    try
                    {
                        request.Headers.TryAddWithoutValidation("token-auth", token);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    HttpContent content = httpClient.SendAsync(request).Result.Content;
                    response = await content.ReadAsByteArrayAsync();
                }
            }
            return response;
        }
        public async Task<string> GetNotificationEventsAsync(User user)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), Properties.Settings.Default.RegionAPI + "/api/v1/accounts/"+user.getAccountID()+"/notifications/configuration"))
                {
                    try
                    {
                        request.Headers.TryAddWithoutValidation("token-auth", user.getToken());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    HttpContent content = httpClient.SendAsync(request).Result.Content;
                    response = await content.ReadAsStringAsync();
                }
            }
            return response;
        }
        public async Task SetNotificationsAsync(String notification, User user)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), Properties.Settings.Default.RegionAPI + "/api/v1/accounts/" + user.getAccountID() + "/notifications/configuration"))
                {
                    try
                    {
                        request.Headers.TryAddWithoutValidation("token-auth", user.getToken());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    request.Content = new StringContent(notification);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    HttpContent content = httpClient.SendAsync(request).Result.Content;
                    _ = await content.ReadAsStringAsync();
                }
            }
        }
        public Boolean[] NotificationFlags(String JSON)
        {
            Boolean[] flags = new Boolean[12];
            JObject json = j(JSON);
            try
            {
                flags[0] = Convert.ToBoolean(json["notifications"]["low_battery"].ToString());
                flags[1] = Convert.ToBoolean(json["notifications"]["camera_offline"].ToString());
                flags[2] = Convert.ToBoolean(json["notifications"]["camera_usage"].ToString());
                flags[3] = Convert.ToBoolean(json["notifications"]["scheduling"].ToString());
                flags[4] = Convert.ToBoolean(json["notifications"]["motion"].ToString());
                flags[5] = Convert.ToBoolean(json["notifications"]["sync_module_offline"].ToString());
                flags[6] = Convert.ToBoolean(json["notifications"]["temperature"].ToString());
                flags[7] = Convert.ToBoolean(json["notifications"]["doorbell"].ToString());
                flags[8] = Convert.ToBoolean(json["notifications"]["wifi"].ToString());
                flags[9] = Convert.ToBoolean(json["notifications"]["lfr"].ToString());
                flags[10] = Convert.ToBoolean(json["notifications"]["bandwidth"].ToString());
                flags[11] = Convert.ToBoolean(json["notifications"]["battery_dead"].ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return flags;
        }
        public String[] AccountInformation(String JSON)
        {
            String[] user = new String[7];
            JObject json = j(JSON);
            try
            {
                user[0] = json["account"]["account_id"].ToString();
                user[1] = json["account"]["user_id"].ToString();
                user[2] = json["account"]["client_id"].ToString();
                user[3] = json["account"]["phone_verification_required"].ToString();
                user[4] = json["account"]["tier"].ToString();
                user[5] = json["account"]["region"].ToString();
                user[6] = json["auth"]["token"].ToString();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return user;         
        }
        public String[,] Cameras(String JSON)
        {
            JObject json = j(JSON);
            IEnumerable<JToken> jt = Enumerable.Empty<JToken>();
            try
            {
                jt = json["cameras"].Children();
            }
            catch(Exception ex)
            {
                MessageBox.Show("API Error, Please try again.");
            }
            int count = 0;
            foreach (JToken jc in jt)
                count++;

            String[,] arr = new String[count, 6]; 
            for (int i = 0; i < count; i++)
            {
                arr[i,0] = json["cameras"][i]["name"].ToString();
                arr[i,1] = json["cameras"][i]["enabled"].ToString();
                arr[i,2] = json["cameras"][i]["thumbnail"].ToString();
                arr[i,3] = json["cameras"][i]["battery"].ToString();
                arr[i,4] = json["cameras"][i]["id"].ToString();
                arr[i,5] = json["cameras"][i]["network_id"].ToString();
            }
            return arr;

        }
        public String[,] Clips(String JSON)
        {
            JObject json = j(JSON);
            IEnumerable<JToken> jt = Enumerable.Empty<JToken>();
            try
            {
                jt = json["media"].Children();
            }
            catch (Exception ex)
            {
                MessageBox.Show("API Error, Please try again.");
            }
            int count = 0;
            foreach (JToken jc in jt)
                count++;

            String[,] arr = new String[count, 6];
            for (int i = 0; i < count; i++)
            {
                arr[i, 0] = json["media"][i]["created_at"].ToString();
                arr[i, 1] = json["media"][i]["device_name"].ToString();
                arr[i, 2] = json["media"][i]["thumbnail"].ToString();
                arr[i, 3] = json["media"][i]["media"].ToString();
            }
            return arr;
        }
        public String RTSP(String JSON)
        {
            JObject jt = j(JSON);
            return jt["server"].ToString();
        }
        public JObject j(String JSON)
        {
            try
            {
                return JObject.Parse(JSON);
            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

    }
}
