using Newtonsoft.Json.Linq;
using System.IO;
using System.IO.Compression;

namespace Launchdere
{
    public class Mod
    {
        JObject obj;
        string path;

        public Mod(string path)
        {
            if (File.Exists(System.IO.Path.GetTempPath() + "modinstall.json"))
                File.Delete(System.IO.Path.GetTempPath() + "modinstall.json");

            using (ZipArchive zip = ZipFile.Open(path, ZipArchiveMode.Read))
                foreach (ZipArchiveEntry entry in zip.Entries)
                    if (entry.Name == "modpkg.json")
                        entry.ExtractToFile(System.IO.Path.GetTempPath() + "modinstall.json");

            obj = JObject.Parse(File.ReadAllText(System.IO.Path.GetTempPath() + "modinstall.json"));
            this.path = path;
        }

        public JObject GetJSON()
        {
            return obj;
        }

        public override string ToString()
        {
            return obj["name"].ToString();
        }

        public string GetPath()
        {
            return path;
        }

    }
}
