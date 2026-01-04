namespace SpotifyDownloader
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exportListToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            grpUrl = new GroupBox();
            btnCheck = new Button();
            txtSpotifyUrl = new TextBox();
            lblUrl = new Label();
            grpDownloadPath = new GroupBox();
            btnBrowse = new Button();
            txtDownloadPath = new TextBox();
            lblPath = new Label();
            grpTracks = new GroupBox();
            listViewTracks = new ListView();
            colTrackName = new ColumnHeader();
            colArtist = new ColumnHeader();
            colStatus = new ColumnHeader();
            panelBottom = new Panel();
            lblOverallStatus = new Label();
            progressBarOverall = new ProgressBar();
            btnReset = new Button();
            btnDownloadAll = new Button();
            menuStrip.SuspendLayout();
            grpUrl.SuspendLayout();
            grpDownloadPath.SuspendLayout();
            grpTracks.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.BackColor = Color.Transparent;
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            menuStrip.Location = new Point(9, 9);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(5, 0, 0, 10);
            menuStrip.Size = new Size(857, 29);
            menuStrip.TabIndex = 4;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exportListToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 19);
            fileToolStripMenuItem.Text = "&File";
            // 
            // exportListToolStripMenuItem
            // 
            exportListToolStripMenuItem.Name = "exportListToolStripMenuItem";
            exportListToolStripMenuItem.Size = new Size(138, 22);
            exportListToolStripMenuItem.Text = "&Export List...";
            exportListToolStripMenuItem.Click += exportListToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(135, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(138, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 19);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(116, 22);
            aboutToolStripMenuItem.Text = "&About...";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // grpUrl
            // 
            grpUrl.Controls.Add(btnCheck);
            grpUrl.Controls.Add(txtSpotifyUrl);
            grpUrl.Controls.Add(lblUrl);
            grpUrl.Dock = DockStyle.Top;
            grpUrl.Location = new Point(9, 38);
            grpUrl.Name = "grpUrl";
            grpUrl.Padding = new Padding(9);
            grpUrl.Size = new Size(857, 66);
            grpUrl.TabIndex = 0;
            grpUrl.TabStop = false;
            grpUrl.Text = "Spotify Track URL";
            // 
            // btnCheck
            // 
            btnCheck.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCheck.Location = new Point(760, 25);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(79, 25);
            btnCheck.TabIndex = 2;
            btnCheck.Text = "Add Track";
            btnCheck.UseVisualStyleBackColor = true;
            btnCheck.Click += btnCheck_Click;
            // 
            // txtSpotifyUrl
            // 
            txtSpotifyUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSpotifyUrl.Location = new Point(61, 27);
            txtSpotifyUrl.Name = "txtSpotifyUrl";
            txtSpotifyUrl.Size = new Size(685, 23);
            txtSpotifyUrl.TabIndex = 1;
            // 
            // lblUrl
            // 
            lblUrl.AutoSize = true;
            lblUrl.Location = new Point(11, 31);
            lblUrl.Name = "lblUrl";
            lblUrl.Size = new Size(31, 15);
            lblUrl.TabIndex = 0;
            lblUrl.Text = "URL:";
            // 
            // grpDownloadPath
            // 
            grpDownloadPath.Controls.Add(btnBrowse);
            grpDownloadPath.Controls.Add(txtDownloadPath);
            grpDownloadPath.Controls.Add(lblPath);
            grpDownloadPath.Dock = DockStyle.Top;
            grpDownloadPath.Location = new Point(9, 104);
            grpDownloadPath.Name = "grpDownloadPath";
            grpDownloadPath.Padding = new Padding(9);
            grpDownloadPath.Size = new Size(857, 66);
            grpDownloadPath.TabIndex = 1;
            grpDownloadPath.TabStop = false;
            grpDownloadPath.Text = "Download Location";
            // 
            // btnBrowse
            // 
            btnBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowse.Location = new Point(760, 26);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(79, 25);
            btnBrowse.TabIndex = 2;
            btnBrowse.Text = "Browse...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // txtDownloadPath
            // 
            txtDownloadPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDownloadPath.Location = new Point(61, 28);
            txtDownloadPath.Name = "txtDownloadPath";
            txtDownloadPath.ReadOnly = true;
            txtDownloadPath.Size = new Size(685, 23);
            txtDownloadPath.TabIndex = 1;
            // 
            // lblPath
            // 
            lblPath.AutoSize = true;
            lblPath.Location = new Point(11, 31);
            lblPath.Name = "lblPath";
            lblPath.Size = new Size(34, 15);
            lblPath.TabIndex = 0;
            lblPath.Text = "Path:";
            // 
            // grpTracks
            // 
            grpTracks.Controls.Add(listViewTracks);
            grpTracks.Dock = DockStyle.Fill;
            grpTracks.Location = new Point(9, 170);
            grpTracks.Name = "grpTracks";
            grpTracks.Padding = new Padding(9);
            grpTracks.Size = new Size(857, 346);
            grpTracks.TabIndex = 2;
            grpTracks.TabStop = false;
            grpTracks.Text = "Track List (Press Delete to remove selected tracks)";
            // 
            // listViewTracks
            // 
            listViewTracks.Columns.AddRange(new ColumnHeader[] { colTrackName, colArtist, colStatus });
            listViewTracks.Dock = DockStyle.Fill;
            listViewTracks.FullRowSelect = true;
            listViewTracks.GridLines = true;
            listViewTracks.Location = new Point(9, 25);
            listViewTracks.Name = "listViewTracks";
            listViewTracks.Size = new Size(839, 312);
            listViewTracks.TabIndex = 0;
            listViewTracks.UseCompatibleStateImageBehavior = false;
            listViewTracks.View = View.Details;
            listViewTracks.KeyDown += listViewTracks_KeyDown;
            // 
            // colTrackName
            // 
            colTrackName.Text = "Track Name";
            colTrackName.Width = 400;
            // 
            // colArtist
            // 
            colArtist.Text = "Artist";
            colArtist.Width = 350;
            // 
            // colStatus
            // 
            colStatus.Text = "Status";
            colStatus.Width = 180;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(lblOverallStatus);
            panelBottom.Controls.Add(progressBarOverall);
            panelBottom.Controls.Add(btnReset);
            panelBottom.Controls.Add(btnDownloadAll);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(9, 516);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(857, 84);
            panelBottom.TabIndex = 3;
            // 
            // lblOverallStatus
            // 
            lblOverallStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblOverallStatus.Location = new Point(11, 9);
            lblOverallStatus.Name = "lblOverallStatus";
            lblOverallStatus.Size = new Size(643, 19);
            lblOverallStatus.TabIndex = 2;
            lblOverallStatus.Text = "Ready";
            // 
            // progressBarOverall
            // 
            progressBarOverall.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBarOverall.Location = new Point(11, 38);
            progressBarOverall.Name = "progressBarOverall";
            progressBarOverall.Size = new Size(643, 28);
            progressBarOverall.TabIndex = 1;
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReset.Location = new Point(760, 37);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(88, 30);
            btnReset.TabIndex = 3;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnDownloadAll
            // 
            btnDownloadAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDownloadAll.Enabled = false;
            btnDownloadAll.Location = new Point(664, 37);
            btnDownloadAll.Name = "btnDownloadAll";
            btnDownloadAll.Size = new Size(88, 30);
            btnDownloadAll.TabIndex = 0;
            btnDownloadAll.Text = "Download All";
            btnDownloadAll.UseVisualStyleBackColor = true;
            btnDownloadAll.Click += btnDownloadAll_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 609);
            Controls.Add(grpTracks);
            Controls.Add(panelBottom);
            Controls.Add(grpDownloadPath);
            Controls.Add(grpUrl);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(702, 565);
            Name = "Form1";
            Padding = new Padding(9);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Spoti2MP3 v1.0.0";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            grpUrl.ResumeLayout(false);
            grpUrl.PerformLayout();
            grpDownloadPath.ResumeLayout(false);
            grpDownloadPath.PerformLayout();
            grpTracks.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpUrl;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox txtSpotifyUrl;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.GroupBox grpDownloadPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtDownloadPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.GroupBox grpTracks;
        private System.Windows.Forms.ListView listViewTracks;
        private System.Windows.Forms.ColumnHeader colTrackName;
        private System.Windows.Forms.ColumnHeader colArtist;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblOverallStatus;
        private System.Windows.Forms.ProgressBar progressBarOverall;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnDownloadAll;
    }
}