namespace PrintServerLauncher
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.status = new System.Windows.Forms.Label();
            this.logBox = new System.Windows.Forms.TextBox();
            this.title = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.logAppendWorker = new System.ComponentModel.BackgroundWorker();
            this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Dock = System.Windows.Forms.DockStyle.Right;
            this.status.Location = new System.Drawing.Point(405, 276);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(98, 20);
            this.status.TabIndex = 2;
            this.status.Text = "Print server running";
            // 
            // logBox
            // 
            this.logBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logBox.Location = new System.Drawing.Point(5, 55);
            this.logBox.Margin = new System.Windows.Forms.Padding(5);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logBox.Size = new System.Drawing.Size(496, 216);
            this.logBox.TabIndex = 1;
            this.logBox.WordWrap = false;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.title.Image = ((System.Drawing.Image)(resources.GetObject("title.Image")));
            this.title.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.title.Location = new System.Drawing.Point(5, 5);
            this.title.Margin = new System.Windows.Forms.Padding(5);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(439, 40);
            this.title.TabIndex = 0;
            this.title.Text = "     Print Server Launcher";
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "Print Server Launcher";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // logAppendWorker
            // 
            this.logAppendWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.logAppendWorker_RunWorkerCompleted);
            // 
            // mainPanel
            // 
            this.mainPanel.ColumnCount = 1;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.Controls.Add(this.status, 0, 2);
            this.mainPanel.Controls.Add(this.title, 0, 0);
            this.mainPanel.Controls.Add(this.logBox, 0, 1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RowCount = 3;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainPanel.Size = new System.Drawing.Size(506, 296);
            this.mainPanel.TabIndex = 1;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 296);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(320, 200);
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "Print Server Launcher";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Resize += new System.EventHandler(this.mainForm_Resize);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.ComponentModel.BackgroundWorker logAppendWorker;
        private System.Windows.Forms.TableLayoutPanel mainPanel;
    }
}