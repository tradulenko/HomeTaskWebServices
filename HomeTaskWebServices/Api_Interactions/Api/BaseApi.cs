using RestSharp;

namespace HomeTaskWebServices.Api_Interactions.Api
{
    public class BaseApi
    {
        protected RestClient client = new RestClient(new Uri("https://restful-booker.herokuapp.com"));

        protected RestRequest AddHeaders(RestRequest restRequest)
        {
            restRequest.AddHeader("Content-Type", "application/json");  
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        protected RestRequest AddAuthorisation(RestRequest restRequest)
        {

            var token = new AuthApi().GetTokenForDefaultUser();
            var headerValue = $"token={token}";
            restRequest.AddHeader("Cookie", headerValue);
            return restRequest;
        }

    }
}
