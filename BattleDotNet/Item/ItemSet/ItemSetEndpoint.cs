using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleDotNet.Item.ItemSet
{
    public class ItemSetEndpoint : IEndpoint
    {
        public IList<IEndpointParameter> Parameters { get; set; }

        public ItemSetEndpoint(string setID, Locale locale, string apiKey)
        {
            Parameters = new List<IEndpointParameter>();

            Parameters.Add(new EndpointParameter("item", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("set", EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter(setID, EndpointParameterType.Resource));
            Parameters.Add(new EndpointParameter("locale", locale.ToString(), EndpointParameterType.Query));
            Parameters.Add(new EndpointParameter("apikey", apiKey, EndpointParameterType.Query));
        }


    }
}
