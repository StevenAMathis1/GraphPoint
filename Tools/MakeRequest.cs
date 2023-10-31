using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace GraphPoint.Tools
{
    public class MakeRequest
    {

        //FetchDataAsync makes multiple POST requests in parallel to the Microsoft Graph API, and returns
        //a string list that contains the json bodies of the responses from all of the requests made
        public static async Task<List<string>> FetchDataAsync(string accessToken, string[] queries)
        {
            string apiUrl = "https://graph.microsoft.com/v1.0/search/query";
            var responseBodies = new List<string>();

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var tasks = queries.Select(async query =>
                {
                    var requestBody = new
                    {
                        requests = new[]
                        {
                            new
                            {
                                entityTypes = new[] { "listItem" },
                                query = new
                                {
                                    queryString = query
                                },
                                fields = new[]
                                {
                                    "FileName",
                                    "author",
                                    "FileExtension",
                                    "LastModifiedTime",
                                    "path",
                                    "DocId",
                                    "Description",
                                    "ViewsRecent",
                                    "SiteName",
                                    "SiteId",
                                    "SiteDescription"
                                }
                            }
                        }
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(requestBody), System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        responseBodies.Add(responseBody);
                    }
                    else
                    {
                        Console.WriteLine("Error: " + response.StatusCode);
                        string responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Response Content: " + responseContent);
                    }
                });

                await Task.WhenAll(tasks);
            }

            return responseBodies;
        }
    }
}
