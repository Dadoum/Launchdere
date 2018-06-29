using CG.Web.MegaApiClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Launchdere
{
    public partial class LaunchForm : Form
    {
        List<Profile> profiles;

        public LaunchForm()
        {
            InitializeComponent();
            listChanged(this, new EventArgs());

            ParseXML();
        }

        private void editProfile_Click(object sender, EventArgs e)
        {

        }

        private void newProfile_Click(object sender, EventArgs e)
        {
            ProfileConfigurator config = new ProfileConfigurator("New");
            this.Enabled = false;
            config.Show(this);
            this.Enabled = true;

            InitializeComponent();
            ParseXML();
        }

        private void ParseXML()
        {
            profileList.Items.Clear();

            profiles = new List<Profile>();
            Profile buffer = new Profile(null, null);

            string s = "";

            XmlReader xReader = XmlReader.Create(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YandereProfiles/profiles.xml");
            while (xReader.Read())
            {
                switch (xReader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (xReader.Name != "Profiles")
                        {
                            switch (xReader.Name)
                            {
                                case "Profile":
                                    buffer = new Profile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YandereProfiles/", null);
                                    break;
                                case "Name":
                                    break;
                                case "Loader":
                                    buffer.LoaderActive = true;
                                    break;
                                case "Mod":
                                    break;
                            }
                        }
                        break;

                    case XmlNodeType.Text:
                        s = xReader.Value;
                        break;

                    case XmlNodeType.EndElement:
                        try
                        {
                            if (xReader.Name != "Profiles")
                            {
                                switch (xReader.Name)
                                {
                                    case "Profile":
                                        profileList.Items.Add(buffer.item);
                                        profiles.Add(buffer);
                                        break;
                                    case "Name":
                                        buffer.item.Name = s;
                                        buffer.item.Text = s;
                                        buffer.name = s;
                                        buffer.path += s;
                                        break;
                                    case "Loader":
                                        break;
                                    case "Mod":
                                        buffer.mods.Add(new Mod(s));
                                        break;
                                }
                            }
                        }
                        catch (Exception e) {
                            Console.Out.WriteLine(e.ToString());
                        }
                        break;
                }
            }
        }

        void DynamicProgress()
        {
            while (true)
            {
                try
                {
                    dialog.progressBar1.Maximum = profile.b;
                    dialog.progressBar1.Value = (int)(new FileInfo(profile.path + "/" + profile.url.Name).Length / 1000000) + 1;
                }
                catch { }
            }
        }

        Profile profile;
        DialogBox dialog;

        private void launchButton_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            profile = profiles[profileList.Items.IndexOf(profileList.SelectedItems[0])];

            if (!Directory.Exists(profile.path))
            {
                Directory.CreateDirectory(profile.path);

                dialog = new DialogBox();
                dialog.SetText("It may take several minutes.");
                dialog.SetTitle("Downloading Yandere Simulator...");
                dialog.Show();
                
                Thread t = new Thread(DynamicProgress);
                t.Start();

                profile.DownloadGame();

                if (profile.LoaderActive)
                {
                    dialog.SetTitle("Downloading Loader...");
                    profile.DownloadLoader();

                    if (!Directory.Exists(profile.path + "/mods"))
                        Directory.CreateDirectory(profile.path + "/mods");

                    foreach (Mod mod in profile.mods)
                    {
                        File.Copy(mod.GetPath(), profile.path + "/mods/" + mod.GetJSON()["id"] + ".zip");
                    }
                }
            }

            if (profile.LoaderActive)
                Process.Start(profile.path + "/Loader.exe");
            else
                Process.Start(profile.path + "/YandereSimulator.exe");
        }

        private void listChanged(object sender, EventArgs e)
        {
            if (profileList.SelectedItems.Count == 0)
            {
                editButton.Enabled = false;
            }
            else
            {
                editButton.Enabled = true;
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
           MessageBox.Show("It's actually impossible to modify profile with graphical interface. You can however modify the XML file.", "Sorry");

        }
    }
}
