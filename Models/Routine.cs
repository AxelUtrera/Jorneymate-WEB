using Newtonsoft.Json;

namespace Jorneymate_WEB.Models
{
    public partial class Routine
    {
        [JsonProperty("_id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("city")]
        public string? City { get; set; }

        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("routine_description")]
        public string? RoutineDescription { get; set; }

        [JsonProperty("visibility")]
        public string? Visibility { get; set; }

        [JsonProperty("label_category")]
        public string? LabelCategory { get; set; }

        [JsonProperty("state_country")]
        public string? StateCountry { get; set; }

        [JsonProperty("town")]
        public string? Town { get; set; }

        [JsonProperty("routine_creator")]
        public string? RoutineCreator { get; set; }

        [JsonProperty("budget")]
        public string? Budget { get; set; }

        [JsonProperty("followers")]
        public int Followers { get; set; }

        [JsonProperty("valoration")]
        public List<Valoration>? Valorations { get; set; }

        [JsonProperty("tasks")]
        public List<TaskItem>? Tasks { get; set; }

        [JsonProperty("routine_comments")]
        public List<Comment>? RoutineComments { get; set; }

        [JsonProperty("__v")]
        public int Version { get; set; }

    }


    public partial class RoutineItem
    {
        [JsonProperty("routine")]
        public string? RoutineString { get; set; }
    }
}