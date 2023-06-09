using Newtonsoft.Json;


namespace Jorneymate_WEB.Models
{
    public class Valoration
    {
        [JsonProperty("user")]
        public string User { set; get; }

        [JsonProperty("valoration")]
        public int valoration { get; set; }
    }
}
