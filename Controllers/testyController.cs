using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TestyMcTestfaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testyController : ControllerBase
    {


        [HttpPost("handler")]
        public async Task<SkillResponse> handler([FromBody] SkillRequest skillRequest)
        {

            var requestType = skillRequest.GetRequestType();

            SkillResponse response = null;

            if (requestType == typeof(LaunchRequest))
            {
                response = ResponseBuilder.Tell("Welcome to Testy McTestface. How can we help you?");
                response.Response.ShouldEndSession = false;
                return response;
            }
            if (requestType == typeof(SessionEndedRequest))
            {
                response = ResponseBuilder.Tell("Goodbye");
                response.Response.ShouldEndSession = true;
                return response;
            }

            if (requestType == typeof(IntentRequest) || requestType == typeof(BuiltInIntent))
            {
                var intentRequest = skillRequest.Request as IntentRequest;
                if (intentRequest.Intent.Name == "AMAZON.StopIntent")
                {
                    response = ResponseBuilder.Tell("Goodbye");
                    response.Response.ShouldEndSession = true;
                    return response;
                }
                if (intentRequest.Intent.Name == "AMAZON.CancelIntent")
                {
                    response = ResponseBuilder.Tell("Goodbye");
                    response.Response.ShouldEndSession = true;
                    return response;
                }
                if (intentRequest.Intent.Name == "AMAZON.NavigateHomeIntent")
                {
                    response = ResponseBuilder.Tell("Goodbye");
                    response.Response.ShouldEndSession = true;
                    return response;
                }
                if (intentRequest.Intent.Name == "AMAZON.HelpIntent")
                {
                    response = ResponseBuilder.Tell("You can ask me to say something. How may we help you now?");
                    response.Response.ShouldEndSession = false;
                    return response;
                }

                if (intentRequest.Intent.Name == "IntentTalkToMe")
                {
                    return ResponseBuilder.Tell("Hi, I'm Testy McTestFace");
                }


            }


            return ResponseBuilder.Tell("Hi, something has went wrong");
        }
    }
}