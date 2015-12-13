using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleDotNet.Quest
{
    public class QuestEndpoint : IEndpoint
    {
        public IList<IEndpointParameter> Parameters { get; set; }

        public QuestEndpoint(string questID, Locale locale, string apiKey)
        {
            Parameters = new List<IEndpointParameter>();

            Parameters.Add(new EndpointParameter("quest", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter(questID, EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("locale", locale.ToString(), EndpointParameterType.Query));
            Parameters.Add(new EndpointParameter("apikey", apiKey, EndpointParameterType.Query));
        }


    }
}
