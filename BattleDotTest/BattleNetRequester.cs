//using System;
//using System.Threading;
//using System.Diagnostics;
//using System.Configuration;
//using BattleDotNet;
//using Microsoft.AspNet.SignalR.Client;

using System;

namespace BattleDotTest
{
    public class BattleNetRequester
    {
        //  private static LeaderboardIntegrationService battleNetLeaderboardService;

        public static void Main(string[] args)
        {
            var x = new BattleDotNet.Authentication.BlizzardAuthentication(BattleDotNet.Region.us);
            var code = x.GetAuthorization("client", BattleDotNet.Authentication.Scope.wow_profile, new Uri("https://localhost:443"), "");
            var y = x.RequestAccessTokens(code, "https://localhost:443", BattleDotNet.Authentication.Scope.wow_profile, "");

            Console.ReadLine();

            //            battleNetLeaderboardService = new LeaderboardIntegrationService(new QueueDodgeDB(), "heuemgj94eyv484cekut2a82d6crnskm");

            //                string bracket = args[0];
            //                Region region = (Region)Enum.Parse(typeof(Region), args[1], true);
            //                Locale locale;
            //                Console.WriteLine(bracket);
            //                Console.WriteLine(region);

            //                switch (region.ToString())
            //                {
            //                    case "us":
            //                        locale = Locale.en_us;
            //                        break;
            //                    case "eu":
            //                        locale = Locale.en_gb;
            //                        break;

            //                    default:
            //                        locale = Locale.en_us;
            //                        throw new Exception("Region or locale not supported.");
            //                }


            //            do
            //            {


            //                var hub = ConfigurationManager.AppSettings["HubAddress"];

            //                // var connection = new HubConnection("http://localhost:51906/");
            //                var connection = new HubConnection(hub);
            //                IHubProxy myHub = connection.CreateHubProxy("LeaderboardHub");

            //                connection.Start().Wait(); // not sure if you need this if you are simply posting to the hub

            //                myHub.Invoke("LeaderboardRequestStarted", bracket, (int)region, DateTime.Now);

            //                var request = battleNetLeaderboardService.GetLeaderboard(bracket, ".api.battle.net/", region, Game.wow, locale);

            //                Console.WriteLine(bracket + " Leaderboard time: {0} at " + DateTime.Now, request.Duration);

            //                myHub.Invoke("LeaderboardRequestComplete", bracket, (int)region, DateTime.Now);

            //                   Thread.Sleep(30000);
            //                GC.Collect();
            //                GC.WaitForPendingFinalizers();
            //                GC.Collect();
            //            } while (1 == 1);
        }
    }
}
