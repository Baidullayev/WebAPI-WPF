using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.Models
{
    class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("lastName")]
        public string Lastname { get; set; }
            
        [JsonProperty("firstName")]
        public string Firstname { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

    }
}
