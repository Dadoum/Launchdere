using CG.Web.MegaApiClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Launchdere
{
    public class Profile
    {
        public string path;
        public string name;
        public string version;

        public ListViewItem item = new ListViewItem();

        public INodeInfo url;

        private Uri uri;

        private MegaApiClient mega = new MegaApiClient();

        public bool LoaderActive = false;
        public List<Mod> mods = new List<Mod>();

        public Profile(string path, string name)
        {
            this.mega.Login();
            this.uri = new Uri("https://mega.nz/#!AhhDXKzI!kEWFdkaOTTyq2NiStlHtq98OooF4C1Xmr-8_YPq1tVI");
            this.url = mega.GetNodeFromLink(uri);

            this.path = path;
            this.name = name;

            item.Name = name;
            item.Text = name;

            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            this.version = url.ModificationDate.Value.ToString("d", culture);
        }

        public int b = 0;

        public void DownloadGame()
        {
            System.Net.WebClient client = new System.Net.WebClient();
            client.OpenRead("https://dl.yanderesimulator.com/latest.zip");
            Int64 bytes_total = Convert.ToInt64(client.ResponseHeaders["Content-Length"]);
            b = (int) (bytes_total / 1000000) + 1;
            client.DownloadFile("https://dl.yanderesimulator.com/latest.zip", path + "/" + url.Name);
            ZipFile.ExtractToDirectory(path + "/" + url.Name, path);
        }

        public void DownloadLoader()
        {
            new System.Net.WebClient().DownloadFile("http://dadoum.ml/dl/YanModLoader.zip", path + "/YLM.zip");
            ZipFile.ExtractToDirectory(path + "/YLM.zip", path);
        }
        
    }
}
