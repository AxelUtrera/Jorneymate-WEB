using Newtonsoft.Json;

namespace Jorneymate_WEB.Models
{
    public class Comment
    {
        [JsonProperty("comment_creator")]
        public string CommentCreator { get; set; }

        [JsonProperty("date_creation")]
        public DateTime DateCreation { get; set; }

        [JsonProperty("comment_description")]
        public string CommentDescription { get; set; }
    }
}