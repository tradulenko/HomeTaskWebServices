
using HomeTaskWebServices.Api_Interactions.Dto.requestDto;
using HomeTaskWebServices.Api_Interactions.Dto.responseDto;

using HomeTaskWebServices.Data;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace HomeTaskWebServices.Api_Interactions.Api
{
    public class AuthApi : BaseApi
    {
        


        public RestResponse<T> GetTokenAPI<T>(string userName, string password)
        {
            RestRequest restRequest = new RestRequest(EndPoints.EndPoints.AUTH_API);
            restRequest.AddBody(new UserDTO(userName, password));
            RestResponse<T> response = client.ExecutePost<T>(restRequest);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            return response;

        }

        public String GetTokenForDefaultUser()
        {
            return GetTokenAPI<AuthToken>(Constants.defaultUserName, Constants.defaultPassword).Data.Token;
        }

    }
}
