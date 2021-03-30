using System;

namespace Blink_Camera_Viewer
{
    class User
    {
        private String A_ID, U_ID, CLIENT_ID, TIER, REGION, TOKEN;
        private Boolean VER;

        public User(String a_id, String u_id, String client_id, Boolean verify, String tier, String region, String token)
        {
            A_ID = a_id;
            U_ID = u_id;
            CLIENT_ID = client_id;
            TIER = tier;
            REGION = region;
            TOKEN = token;
            VER = verify;

            Properties.Settings.Default.RegionAPI = "https://rest-" + TIER + ".immedia-semi.com";//set the region based API when the user is created

        }
        public void setVerified(Boolean ver)
        {
            VER = ver;
        }
        public Boolean isVerified()
        {
            return VER;
        }
        public String getAccountID()
        {
            return A_ID;
        }
        public String getUserID()
        {
            return U_ID;
        }
        public String getClientID()
        {
            return CLIENT_ID;
        }
        public String getTier()
        {
            return TIER;
        }
        public String getRegion()
        {
            return REGION;
        }
        public String getToken()
        {
            return TOKEN;
        }       

    }
}
