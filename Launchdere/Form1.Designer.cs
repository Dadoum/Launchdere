namespace Launchdere
{
    partial class LaunchForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.profileList = new System.Windows.Forms.ListView();
            this.editButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.launchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // profileList
            // 
            this.profileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profileList.Location = new System.Drawing.Point(12, 42);
            this.profileList.MultiSelect = false;
            this.profileList.Name = "profileList";
            this.profileList.Size = new System.Drawing.Size(632, 357);
            this.profileList.TabIndex = 0;
            this.profileList.UseCompatibleStateImageBehavior = false;
            this.profileList.ItemActivate += new System.EventHandler(this.launchButton_Click);
            this.profileList.SelectedIndexChanged += new System.EventHandler(this.listChanged);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(13, 13);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(80, 23);
            this.editButton.TabIndex = 1;
            this.editButton.Text = "Edit profile";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(99, 13);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(80, 23);
            this.newButton.TabIndex = 2;
            this.newButton.Text = "New profile";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newProfile_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(631, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Profiles";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // launchButton
            // 
            this.launchButton.Location = new System.Drawing.Point(554, 13);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(90, 23);
            this.launchButton.TabIndex = 4;
            this.launchButton.Text = "Launch profile";
            this.launchButton.UseVisualStyleBackColor = true;
            this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
            // 
            // LaunchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 411);
            this.Controls.Add(this.launchButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.profileList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LaunchForm";
            this.Text = "Launchdere !";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView profileList;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button launchButton;
    }
}

