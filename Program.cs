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


            string accessToken = args[1];
            //string accessToken = "";

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
