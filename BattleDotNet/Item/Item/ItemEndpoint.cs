using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleDotNet.Item.Item
{
    public class ItemEndpoint : IEndpoint
    {
        public IList<IEndpointParameter> Parameters { get; set; }

        public ItemEndpoint(string itemID, Locale locale, string apiKey)
        {
            Parameters = new List<IEndpointParameter>();

            Parameters.Add(new EndpointParameter("item", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter(itemID, EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("locale", locale.ToString(), EndpointParameterType.Query));
            Parameters.Add(new EndpointParameter("apikey", apiKey, EndpointParameterType.Query));
        }


    }
}
