using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssassinVR.DataModels
{
    public class assassinInformation
    {
        [JsonProperty(PropertyName = "Id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "Username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "Score")]
        public int Score { get; set; }

        [JsonProperty(PropertyName = "Contracts")]
        public int Contracts { get; set; }
    }
}
