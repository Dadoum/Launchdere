using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Launchdere
{
    public partial class ProfileConfigurator : Form
    {
        public Profile profile;

        public ProfileConfigurator(string action)
        {
            InitializeComponent();
            this.label1.Text = action + " profile configuration:";
            this.Text = action + " profile";

            checkBox1_CheckedChanged(this, new EventArgs());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YandereProfiles/" + textBox1.Text;

            if (Directory.Exists(s) && label1.Text.StartsWith("New"))
                Directory.Delete(s, true);

            if (!Directory.Exists(s) && label1.Text.StartsWith("New"))
                Directory.CreateDirectory(s);

            Process.Start(s);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Text = "New profile";

            string xmlFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/YandereProfiles/profiles.xml";

            if (!File.Exists(xmlFilePath))
            {
                File.Create(xmlFilePath).Close();
                File.WriteAllText(xmlFilePath, "<Profiles> \n</Profiles>");
            }

            XDocument doc = XDocument.Load(xmlFilePath);
            XElement xml = doc.Element("Profiles");
            if (checkBox1.Checked)
            {
                XElement loader = new XElement("Loader");

                foreach (Mod o in listBox1.Items)
                {
                    loader.Add(new XElement("Mod", o.GetPath()));
                }

                xml.Add(new XElement("Profile", new XElement("Name", textBox1.Text), loader));
            }
            else
            {
                xml.Add(new XElement("Profile", new XElement("Name", textBox1.Text)));
            }
            
            doc.Save(xmlFilePath);

            this.Close();
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                this.button2.Location = new System.Drawing.Point(278, 78);
                this.button3.Location = new System.Drawing.Point(197, 78);
                this.button4.Location = new System.Drawing.Point(12, 78);
                
                this.ClientSize = new System.Drawing.Size(365, 111);

                this.button1.Hide();
                this.button5.Hide();
                this.listBox1.Hide();
            }
            else
            {
                this.button2.Location = new System.Drawing.Point(278, 219);
                this.button3.Location = new System.Drawing.Point(197, 219);
                this.button4.Location = new System.Drawing.Point(12, 219);

                this.ClientSize = new System.Drawing.Size(365, 254);

                this.button1.Show();
                this.button5.Show();
                this.listBox1.Show();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            browser1.Filter = "Mods (*.zip)|*.zip";
            var r = browser1.ShowDialog();

            if (r == DialogResult.OK)
            {
                Mod name = new Mod(browser1.FileName);
                listBox1.Items.Add(name);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }
    }
}
