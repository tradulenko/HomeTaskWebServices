using Newtonsoft.Json;

namespace HomeTaskWebServices.Api_Interactions.Dto.requestDto
{
    public class UserDTO
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }

        public UserDTO(string userName, string password)
        {
            Username = userName;
            Password = password;

        }
    }
}
