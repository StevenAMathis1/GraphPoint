
namespace GraphPoint.Tools
{
    internal class ConfigureResults
    {
        private readonly string _fileAndPathName;
        public ConfigureResults(string fileAndPathName) 
        { 
            _fileAndPathName = fileAndPathName;
        }
        public int CSVMaker(string preset, Root response)
        {
            foreach(var hit in response.value[0].hitsContainers[0].hits)
            {
                string entry = preset + "|" + hit.resource.fields.fileName + "|" + hit.resource.fields.author + "|" + hit.resource.fields.docId + "|" + hit.resource.fields.path + "|" + hit.resource.fields.fileExtension + "|" + hit.resource.fields.description + "|" + hit.resource.fields.viewsRecent + "|" + hit.resource.fields.lastModifiedTime + "|" + hit.resource.fields.siteName + "|" + hit.resource.fields.siteId + "|" + hit.resource.fields.siteDescription + "\n";

                File.AppendAllText(_fileAndPathName, entry);
            }

            return 0;
        }
    }

}
