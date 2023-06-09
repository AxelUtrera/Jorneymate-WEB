using Newtonsoft.Json;

namespace Jorneymate_WEB.Models
{
    public partial class Task
    {
        [JsonProperty("_id")]
        public string _Id {  get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("task_description")]
        public string TaskDescription { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("budget")]
        public int Budget { get; set; }

        [JsonProperty("isCompleted")]
        public bool IsCompleted { get; set; }

        [JsonProperty("schedule")]
        public string Schedule { get; set; }

        [JsonProperty("valorations")]
        public List<Valoration> Valorations { get; set; }

        [JsonProperty("comments")]
        public List<Comment> TaskComments { get; set; }

    }


    public partial class TaskItem
    {
        [JsonProperty("task")]
        public string TaskId { get; set; }
    }
}