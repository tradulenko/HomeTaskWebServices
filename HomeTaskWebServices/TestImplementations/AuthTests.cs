using HomeTaskWebServices.Api_Interactions.Api;
using HomeTaskWebServices.Api_Interactions.Dto.responseDto;
using HomeTaskWebServices.Data;
using NUnit.Allure.Core;
using NUnit.Framework;
using RestSharp;
using System.Text.RegularExpressions;


namespace HomeTaskWebServices.TestImplementations
{
    [AllureNUnit]
    [TestFixture]
    public class AuthTests
    {

        [Test]
        public void PositiveCase()
        {
            AuthApi api = new AuthApi();
            RestResponse<AuthToken> response = api.GetTokenAPI<AuthToken>(Constants.defaultUserName, Constants.defaultPassword);

            Console.WriteLine(response.Data.Token);
            string expectedPattern = @"^[0-9a-f]{15}$";
            Assert.IsTrue(Regex.IsMatch(response.Data.Token, expectedPattern));
        }

        [Test]
        public void NegativeCase()
        {
            AuthApi api = new AuthApi();
            RestResponse<ResponseWithError> response = api.GetTokenAPI<ResponseWithError>("NotValidUser", Constants.defaultPassword);

            Console.WriteLine(response.Data.Reason);
            Assert.AreEqual("Bad credentials", response.Data.Reason);
        }
    }
}
