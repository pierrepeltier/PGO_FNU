using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonGo.RocketAPI.Extensions;
using POGOProtos.Networking.Envelopes;

namespace PGO_BOT
{
    public class MyApiFailureStrategy : IApiFailureStrategy
    {
        public Task<ApiOperation> HandleApiFailure(RequestEnvelope request, ResponseEnvelope response)
        {
            Console.WriteLine("ERROR on " + request);
            return null;
        }

        public void HandleApiSuccess(RequestEnvelope request, ResponseEnvelope response)
        {
            
        }
    }
}