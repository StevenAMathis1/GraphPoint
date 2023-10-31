using Newtonsoft.Json;

namespace GraphPoint.Tools
{

    public class Fields
    {
        public string? fileName { get; set; }
        public string? author { get; set; }
        public string? fileExtension { get; set; }
        public DateTime? lastModifiedTime { get; set; }
        public string? path { get; set; }
        public object? docId { get; set; }
        public int? viewsRecent {  get; set; }
        public string? siteName { get; set; }
        public string? siteId { get; set; }
        public string? description { get; set; }
        public string? siteDescription { get; set; }
    }

    public class Hit
    {
        public string hitId { get; set; }
        public int rank { get; set; }
        public string summary { get; set; }
        public Resource resource { get; set; }
    }

    public class HitsContainer
    {
        public List<Hit> hits { get; set; }
        public int total { get; set; }
        public bool moreResultsAvailable { get; set; }
    }

    public class Resource
    {
        [JsonProperty("@odata.type")]
        public string odatatype { get; set; }
        public Fields fields { get; set; }
        public string webUrl { get; set; }
    }

    public class Root
    {
        public List<Value> value { get; set; }

        [JsonProperty("@odata.context")]
        public string odatacontext { get; set; }
    }

    public class Value
    {
        public List<string> searchTerms { get; set; }
        public List<HitsContainer> hitsContainers { get; set; }
    }

    public class JsonResponseParse
    {

        public JsonResponseParse(){}

        public Root ParseJson(string json)
        {
            
            Root response = JsonConvert.DeserializeObject<Root>(json);

            return response;
        }


    }
}
