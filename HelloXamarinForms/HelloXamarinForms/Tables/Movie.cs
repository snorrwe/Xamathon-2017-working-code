using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloXamarinForms.Tables
{
    public class Movie
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty(PropertyName = "updatedAt")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }
        [JsonProperty(PropertyName = "deleted")]
        public bool Deleted { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "posterurl")]
        public string PosterUrl { get; set; }
        [JsonProperty(PropertyName = "releaseyear")]
        public DateTime ReleaseYeasr { get; set; }
        [JsonProperty(PropertyName = "imdburl")]
        public string ImdbUrl { get; set; }
    }
}
