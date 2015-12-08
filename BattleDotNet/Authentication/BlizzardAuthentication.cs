using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

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
        public string GetAuthorization(string clientID, IEnumerable<string> scope, Uri redirectUri, string state, string responseType = "code")
        {
            string baseAuthorizationUri = authorizationUri.AbsoluteUri;

            StringBuilder uri = new StringBuilder(baseAuthorizationUri);

            uri.Append("?client_id=");
            uri.Append(WebUtility.UrlEncode(clientID));

            foreach (string x in scope)
            {
                uri.Append("&scope=");
                uri.Append(WebUtility.UrlEncode(x.Replace("_", ".")));
            }

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
        public void RequestAccessTokens(string authorizationCode, string redirectUri, IEnumerable<string> scope, string grantType)
        {
            string baseAuthorizationUri = authorizationUri.AbsoluteUri;


            //string authorization = http.PostAsync(uri.ToString(),).Result;

            // return authorization;
        }
    }
}
