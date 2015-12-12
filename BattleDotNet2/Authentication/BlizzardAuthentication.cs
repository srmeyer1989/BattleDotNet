using System;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BattleDotNet.Authentication
{
    public class BlizzardAuthentication
    {
        private HttpClient http;
        private Uri authorizationUri;
        private Uri tokenUri;
        private Uri checkTokenUri;

        public BlizzardAuthentication(BattleDotNet.Region region)
        {
            this.http = new HttpClient();
            this.authorizationUri = GetAuthorizationUri(region);
            this.tokenUri = GetTokenUri(region);
            this.checkTokenUri = GetCheckTokenUri(region);
        }

        private Uri GetAuthorizationUri(BattleDotNet.Region region)
        {
            switch (region)
            {
                case BattleDotNet.Region.us:
                case BattleDotNet.Region.eu:
                case BattleDotNet.Region.kr:
                case BattleDotNet.Region.tw:
                    return new Uri("https://" + region.ToString() + ".battle.net/oauth/authorize");
                case BattleDotNet.Region.cn:
                    return new Uri("https://www.battlenet.com.cn/oauth/authorize");
                default:
                    throw new NotSupportedException("This region is not supported yet.");
            }
        }

        private Uri GetTokenUri(BattleDotNet.Region region)
        {
            switch (region)
            {
                case BattleDotNet.Region.us:
                case BattleDotNet.Region.eu:
                case BattleDotNet.Region.kr:
                case BattleDotNet.Region.tw:
                    return new Uri("https://" + region.ToString() + ".battle.net/oauth/token");
                case BattleDotNet.Region.cn:
                    return new Uri("https://www.battlenet.com.cn/oauth/token");
                default:
                    throw new NotSupportedException("This region is not supported yet.");
            }
        }
        private Uri GetCheckTokenUri(BattleDotNet.Region region)
        {
            switch (region)
            {
                case BattleDotNet.Region.us:
                case BattleDotNet.Region.eu:
                case BattleDotNet.Region.kr:
                case BattleDotNet.Region.tw:
                case BattleDotNet.Region.cn:
                    return new Uri("https://" + region.ToString() + ".battle.net/oauth/check_token");
                default:
                    throw new NotSupportedException("This region is not supported yet.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="scope"></param>
        /// <param name="redirectUri"></param>
        /// <param name="state"></param>
        /// <param name="responseType"></param>
        /// <returns></returns>
        public string GetAuthorization(string clientID, Scope scope, Uri redirectUri, string state, string responseType = "code")
        {
            string baseAuthorizationUri = authorizationUri.AbsoluteUri;

            StringBuilder uri = new StringBuilder(baseAuthorizationUri);

            uri.Append("?client_id=");
            uri.Append(WebUtility.UrlEncode(clientID));

            //foreach (string x in scope)
            //{
            uri.Append("&scope=");
            uri.Append(WebUtility.UrlEncode(scope.ToString().Replace("_", ".")));
            //}

            uri.Append("&state=");
            uri.Append(WebUtility.UrlEncode(state));
            uri.Append("&redirect_uri=");
            uri.Append(WebUtility.UrlEncode(redirectUri.OriginalString));
            uri.Append("&response_type=");
            uri.Append(WebUtility.UrlEncode(responseType));

            string authorization = http.GetStringAsync(uri.ToString()).Result;

            return authorization;
        }

        public bool CheckToken(string token)
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authorizationCode"></param>
        /// <param name="redirectUri"></param>
        /// <param name="scope"></param>
        /// <param name="grantType"></param>
        public string RequestAccessTokens(string authorizationCode, string redirectUri, Scope scope, string grantType)
        {

            //var data = new List<KeyValuePair<string, string>>();

            //data.Add(new KeyValuePair<string, string>("redirect_uri", "https://localhost"));
            //data.Add(new KeyValuePair<string, string>("scope", "wow.profile"));
            //data.Add(new KeyValuePair<string, string>("grant_type", "authorization_code"));
            //data.Add(new KeyValuePair<string, string>("code", authorizationCode));


            var data = new
            {
                redirect_uri = "https://localhost",
                scope = "wow.profile",
                grant_type = "authorization_code",
                code = authorizationCode,
            };

            //var param = "?redirect_uri=" + redirectUri + 
            //    "&grant_type=" + grantType + 
            //    "&code=" + authorizationCode + 
            //    "&scope=" + scope.ToString().Replace("_", ".");

            var byteArray = Encoding.UTF8.GetBytes("heuemgj94eyv484cekut2a82d6crnskm:Cw5V9sdXnxdvHj5gexXvJQbQ4g9MTcds");
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            string postBody = JsonConvert.SerializeObject(data);
            var content = new StringContent(postBody, Encoding.UTF8, "application/json");
            //  var content = new FormUrlEncodedContent(data);
            //  http.DefaultRequestHeaders.
            HttpResponseMessage response = http.PostAsync(tokenUri, content).Result;
            //         response.EnsureSuccessStatusCode();
            string stuff = response.Content.ReadAsStringAsync().Result;
            return stuff;
        }
    }
}
