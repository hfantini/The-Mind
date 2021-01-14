namespace The_Mind
{
    partial class ViewMain
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewMain));
            this.barMain = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mItemMain = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemSimpleDustSweeper = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tbarMain = new System.Windows.Forms.ToolStrip();
            this.tBtnShowConsole = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tBtnPlaySimulation = new System.Windows.Forms.ToolStripButton();
            this.tBtnPauseSimulation = new System.Windows.Forms.ToolStripButton();
            this.tBtnStopSimulation = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.barMain.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.tbarMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barMain
            // 
            this.barMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.barMain.Location = new System.Drawing.Point(0, 358);
            this.barMain.Name = "barMain";
            this.barMain.Size = new System.Drawing.Size(645, 22);
            this.barMain.TabIndex = 0;
            this.barMain.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(76, 17);
            this.lblStatus.Text = "STATUS: IDLE";
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemMain,
            this.mItemAbout,
            this.mItemExit});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(645, 24);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mItemMain
            // 
            this.mItemMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemSimpleDustSweeper});
            this.mItemMain.Name = "mItemMain";
            this.mItemMain.Size = new System.Drawing.Size(50, 20);
            this.mItemMain.Text = "MAIN";
            // 
            // mItemSimpleDustSweeper
            // 
            this.mItemSimpleDustSweeper.Name = "mItemSimpleDustSweeper";
            this.mItemSimpleDustSweeper.Size = new System.Drawing.Size(241, 22);
            this.mItemSimpleDustSweeper.Text = "SIMPLE AGENT: DUST SWEEPER";
            this.mItemSimpleDustSweeper.Click += new System.EventHandler(this.nEURALNETWORKHANDWRITTINGIDENTIFICATIONToolStripMenuItem_Click);
            // 
            // mItemAbout
            // 
            this.mItemAbout.Name = "mItemAbout";
            this.mItemAbout.Size = new System.Drawing.Size(58, 20);
            this.mItemAbout.Text = "ABOUT";
            // 
            // mItemExit
            // 
            this.mItemExit.Name = "mItemExit";
            this.mItemExit.Size = new System.Drawing.Size(42, 20);
            this.mItemExit.Text = "EXIT";
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlMain.Location = new System.Drawing.Point(0, 56);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(645, 299);
            this.pnlMain.TabIndex = 2;
            // 
            // tbarMain
            // 
            this.tbarMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbarMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tBtnShowConsole,
            this.toolStripSeparator1,
            this.tBtnPlaySimulation,
            this.tBtnPauseSimulation,
            this.tBtnStopSimulation});
            this.tbarMain.Location = new System.Drawing.Point(0, 0);
            this.tbarMain.Name = "tbarMain";
            this.tbarMain.Size = new System.Drawing.Size(645, 29);
            this.tbarMain.TabIndex = 0;
            this.tbarMain.Text = "toolStrip1";
            // 
            // tBtnShowConsole
            // 
            this.tBtnShowConsole.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tBtnShowConsole.Image = ((System.Drawing.Image)(resources.GetObject("tBtnShowConsole.Image")));
            this.tBtnShowConsole.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tBtnShowConsole.Name = "tBtnShowConsole";
            this.tBtnShowConsole.Size = new System.Drawing.Size(23, 26);
            this.tBtnShowConsole.Text = "Show Console";
            this.tBtnShowConsole.Click += new System.EventHandler(this.tBtnShowConsole_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // tBtnPlaySimulation
            // 
            this.tBtnPlaySimulation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tBtnPlaySimulation.Image = ((System.Drawing.Image)(resources.GetObject("tBtnPlaySimulation.Image")));
            this.tBtnPlaySimulation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tBtnPlaySimulation.Name = "tBtnPlaySimulation";
            this.tBtnPlaySimulation.Size = new System.Drawing.Size(23, 26);
            this.tBtnPlaySimulation.Text = "Play current simulation";
            this.tBtnPlaySimulation.Click += new System.EventHandler(this.tBtnPlaySimulation_Click);
            // 
            // tBtnPauseSimulation
            // 
            this.tBtnPauseSimulation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tBtnPauseSimulation.Image = ((System.Drawing.Image)(resources.GetObject("tBtnPauseSimulation.Image")));
            this.tBtnPauseSimulation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tBtnPauseSimulation.Name = "tBtnPauseSimulation";
            this.tBtnPauseSimulation.Size = new System.Drawing.Size(23, 26);
            this.tBtnPauseSimulation.Text = "Pause current simulation";
            this.tBtnPauseSimulation.Click += new System.EventHandler(this.tBtnPauseSimulation_Click);
            // 
            // tBtnStopSimulation
            // 
            this.tBtnStopSimulation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tBtnStopSimulation.Image = ((System.Drawing.Image)(resources.GetObject("tBtnStopSimulation.Image")));
            this.tBtnStopSimulation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tBtnStopSimulation.Name = "tBtnStopSimulation";
            this.tBtnStopSimulation.Size = new System.Drawing.Size(23, 26);
            this.tBtnStopSimulation.Text = "Stop current simulation";
            this.tBtnStopSimulation.ToolTipText = "Stop current simulation";
            this.tBtnStopSimulation.Click += new System.EventHandler(this.tBtnStopSimulation_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbarMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 29);
            this.panel1.TabIndex = 3;
            // 
            // ViewMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 380);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.barMain);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(75, 30);
            this.MainMenuStrip = this.mnuMain;
            this.Name = "ViewMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "The Mind - Artificial Intelligence 0.1b / By Henrique Fantini";
            this.barMain.ResumeLayout(false);
            this.barMain.PerformLayout();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.tbarMain.ResumeLayout(false);
            this.tbarMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip barMain;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mItemMain;
        private System.Windows.Forms.ToolStripMenuItem mItemExit;
        private System.Windows.Forms.ToolStripMenuItem mItemAbout;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripMenuItem mItemSimpleDustSweeper;
        private System.Windows.Forms.ToolStrip tbarMain;
        private System.Windows.Forms.ToolStripButton tBtnShowConsole;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tBtnPlaySimulation;
        private System.Windows.Forms.ToolStripButton tBtnPauseSimulation;
        private System.Windows.Forms.ToolStripButton tBtnStopSimulation;
    }
}

