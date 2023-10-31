using GraphPoint.Tools;

namespace GraphPoint
{

    class Program
    {

        public static string OutPath = "..\\..\\..\\output";


        //creates the file name like 'DDMMYYYY_SnaffOut.csv' with the current date
        private static string FileName()
        {
            string fileName;
            string currDate = DateTime.Now.ToString("ddMMyyyy");
            fileName = currDate + "_SnaffOut.csv";


            return fileName;
        }


        //writes column headers to the csv file
        public static void WriteHeadersToCsv()
        {
            string headers = "Preset Name|Title|Author|DocId|Path|FileExtension|Description|ViewsRecent|LastModifiedTime|SiteName|SiteId|SiteDescription\n";
            File.WriteAllText(Path.Combine(OutPath, FileName()), headers);
        }


        static async Task Main(string[] args)
        {

            
            JsonResponseParse _JsonResponseParse = new();

            WriteHeadersToCsv();

            ConfigureResults _ConfigureResults = new(OutPath + "\\" + FileName());


            //string accessToken = args[1];
            string accessToken = "eyJ0eXAiOiJKV1QiLCJub25jZSI6IlJlbUVfazhWc2lhQjFGRTZEalkydHdOYVo4anNXOW5HQ3lFUXpuLTRaRHciLCJhbGciOiJSUzI1NiIsIng1dCI6IjlHbW55RlBraGMzaE91UjIybXZTdmduTG83WSIsImtpZCI6IjlHbW55RlBraGMzaE91UjIybXZTdmduTG83WSJ9.eyJhdWQiOiIwMDAwMDAwMy0wMDAwLTAwMDAtYzAwMC0wMDAwMDAwMDAwMDAiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC9jMjNhYmQ0Zi1mMTM3LTQxOTAtOGFjNC1hOThlMjJhMjU1ZDUvIiwiaWF0IjoxNjk4Nzc2NjQ2LCJuYmYiOjE2OTg3NzY2NDYsImV4cCI6MTY5ODg2MzM0NiwiYWNjdCI6MCwiYWNyIjoiMSIsImFpbyI6IkFUUUF5LzhVQUFBQStLVXY5K1MrTFVrWmVjS3dRUTZZNE1LalJOMG42WU5IS1duUDlCei9mUUNiRnBSbUVZLyt0RFNKSjVTNFM2ZGYiLCJhbXIiOlsicHdkIl0sImFwcF9kaXNwbGF5bmFtZSI6IkdyYXBoIEV4cGxvcmVyIiwiYXBwaWQiOiJkZThiYzhiNS1kOWY5LTQ4YjEtYThhZC1iNzQ4ZGE3MjUwNjQiLCJhcHBpZGFjciI6IjAiLCJpZHR5cCI6InVzZXIiLCJpcGFkZHIiOiI0LjIzNi4xODkuMTIyIiwibmFtZSI6ImRtc3ZjYWNjdHRlc3QiLCJvaWQiOiI1MjdmNTJlMS03YTA5LTRhMTYtYjg4OS1lNzBkNzE4ZGEwN2QiLCJwbGF0ZiI6IjMiLCJwdWlkIjoiMTAwMzIwMDJFQjlDOTE3QiIsInJoIjoiMC5BVVVBVDcwNndqZnhrRUdLeEttT0lxSlYxUU1BQUFBQUFBQUF3QUFBQUFBQUFBQkZBRUUuIiwic2NwIjoiQ2FsZW5kYXJzLlJlYWRXcml0ZSBDb250YWN0cy5SZWFkV3JpdGUgRmlsZXMuUmVhZFdyaXRlLkFsbCBHcm91cC5SZWFkLkFsbCBJbmZvcm1hdGlvblByb3RlY3Rpb25Qb2xpY3kuUmVhZCBNYWlsLlJlYWRXcml0ZSBOb3Rlcy5SZWFkV3JpdGUuQWxsIG9wZW5pZCBQZW9wbGUuUmVhZCBQb2xpY3kuUmVhZC5BbGwgcHJvZmlsZSBSZXBvcnRzLlJlYWQuQWxsIFNlY3VyaXR5RXZlbnRzLlJlYWQuQWxsIFNpdGVzLkZ1bGxDb250cm9sLkFsbCBTaXRlcy5SZWFkV3JpdGUuQWxsIFRhc2tzLlJlYWRXcml0ZSBVc2VyLlJlYWQgVXNlci5SZWFkQmFzaWMuQWxsIFVzZXIuUmVhZFdyaXRlIGVtYWlsIiwic2lnbmluX3N0YXRlIjpbImttc2kiXSwic3ViIjoiUVI1V1hxUnVVYjN0emZJVFdacVd2X05vdnVWVFFSSlV6MmFvVkxWOGwzZyIsInRlbmFudF9yZWdpb25fc2NvcGUiOiJOQSIsInRpZCI6ImMyM2FiZDRmLWYxMzctNDE5MC04YWM0LWE5OGUyMmEyNTVkNSIsInVuaXF1ZV9uYW1lIjoiZG1zdmNhY2N0dGVzdEBmdHNjdGVzdC5vbm1pY3Jvc29mdC5jb20iLCJ1cG4iOiJkbXN2Y2FjY3R0ZXN0QGZ0c2N0ZXN0Lm9ubWljcm9zb2Z0LmNvbSIsInV0aSI6Imsydm9EUERQVDBHNlVNQVlabXlpQUEiLCJ2ZXIiOiIxLjAiLCJ3aWRzIjpbImI3OWZiZjRkLTNlZjktNDY4OS04MTQzLTc2YjE5NGU4NTUwOSJdLCJ4bXNfY2MiOlsiQ1AxIl0sInhtc19zc20iOiIxIiwieG1zX3N0Ijp7InN1YiI6InUtT2ZRRUxBTTFpTExTWUFZZDlab1dTR1ppbkoxTlh6MmdMNnhHNGdnUWsifSwieG1zX3RjZHQiOjE1ODAyMzE1NzN9.wrut_jU15PPDq5PCu2z1y7WrZfvuVSmJVQGkG9PLDtFqWldg7QpdSEbyA_UzJlBz8g88MwcYkW5mHlt-XkosY4MKSWc2Q8CBXGJn2eDjpVC_wtQUKGjmcxhx3XQ8I9s-IBdyLbps2aZHo8A36l-8tjgKtjA1rfus9DQxUd-7t77Zx7EhAoa9hwlCpmYpbiQtZ3BeUXJiXdbkk7VFR8MAXML7VoacstldaooEdj7obvZTgDi0sfY7XZRGLXgkGep7ArzxAT1WGb8XKIQLWdK7CGPkYoZ8bTB9hKL3ohcaT4P9H1CKpjHLYage3eTxt-s4VrqElT4JYwzMj-CcEMOLgw";

            if (!string.IsNullOrEmpty(accessToken))
            {
                string[] queries = new[]
                {
                "username NEAR(n=7) password"
                };


            try
                {
                    //calls FetchDataAsync from MakeRequest with the accessToken and list of queries
                    List<string> responseBodies = await MakeRequest.FetchDataAsync(accessToken, queries);


                    foreach (string responseBody in responseBodies)
                    {
                        //calls CSVMaker from ConfigureResults with the name of current preset and
                        //Root object returned from ParseJson from JsonResponseParse
                        _ConfigureResults.CSVMaker("preset", _JsonResponseParse.ParseJson(responseBody));
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"An error has occured: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Please give an access token\n");
            }
        }
    }
}
