namespace Main
{
    partial class MainForm
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

        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            ts_Open = new ToolStripMenuItem();
            ts_Save = new ToolStripMenuItem();
            ts_SaveAs = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            ts_Import = new ToolStripMenuItem();
            ts_ImportTownOverlay = new ToolStripMenuItem();
            ts_ImportSelection = new ToolStripMenuItem();
            ts_ImportFly = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            ts_ImportAll = new ToolStripMenuItem();
            ts_Export = new ToolStripMenuItem();
            ts_ExportTownOverlay = new ToolStripMenuItem();
            ts_ExportSelection = new ToolStripMenuItem();
            ts_ExportFly = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            ts_ExportAll = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            btn_Open = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btn_Save = new ToolStripButton();
            btn_SaveAs = new ToolStripButton();
            tabs_TableSelector = new TabControl();
            tab_TownOverlay = new TabPage();
            tab_SelectionOverlay = new TabPage();
            tab_FlyPositions = new TabPage();
            menuStrip.SuspendLayout();
            toolStrip1.SuspendLayout();
            tabs_TableSelector.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 24);
            menuStrip.TabIndex = 1;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ts_Open, ts_Save, ts_SaveAs, toolStripSeparator4, ts_Import, ts_Export });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // ts_Open
            // 
            ts_Open.Image = Properties.Resources.open_ico;
            ts_Open.Name = "ts_Open";
            ts_Open.Size = new Size(180, 22);
            ts_Open.Text = "Open";
            ts_Open.Click += ts_Open_Click;
            // 
            // ts_Save
            // 
            ts_Save.Image = Properties.Resources.save_ico;
            ts_Save.Name = "ts_Save";
            ts_Save.Size = new Size(180, 22);
            ts_Save.Text = "Save";
            ts_Save.Click += ts_Save_Click;
            // 
            // ts_SaveAs
            // 
            ts_SaveAs.Image = Properties.Resources.save_as_ico;
            ts_SaveAs.Name = "ts_SaveAs";
            ts_SaveAs.Size = new Size(180, 22);
            ts_SaveAs.Text = "Save As...";
            ts_SaveAs.Click += ts_SaveAs_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(177, 6);
            // 
            // ts_Import
            // 
            ts_Import.DropDownItems.AddRange(new ToolStripItem[] { ts_ImportTownOverlay, ts_ImportSelection, ts_ImportFly, toolStripSeparator2, ts_ImportAll });
            ts_Import.Image = Properties.Resources.import_ico;
            ts_Import.Name = "ts_Import";
            ts_Import.Size = new Size(180, 22);
            ts_Import.Text = "Import";
            // 
            // ts_ImportTownOverlay
            // 
            ts_ImportTownOverlay.Name = "ts_ImportTownOverlay";
            ts_ImportTownOverlay.Size = new Size(180, 22);
            ts_ImportTownOverlay.Text = "Town Overlay";
            ts_ImportTownOverlay.Click += ts_ImportTownOverlay_Click;
            // 
            // ts_ImportSelection
            // 
            ts_ImportSelection.Name = "ts_ImportSelection";
            ts_ImportSelection.Size = new Size(180, 22);
            ts_ImportSelection.Text = "Selection Overlay";
            ts_ImportSelection.Click += ts_ImportSelection_Click;
            // 
            // ts_ImportFly
            // 
            ts_ImportFly.Name = "ts_ImportFly";
            ts_ImportFly.Size = new Size(180, 22);
            ts_ImportFly.Text = "Fly Table";
            ts_ImportFly.Click += ts_ImportFly_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(177, 6);
            // 
            // ts_ImportAll
            // 
            ts_ImportAll.Name = "ts_ImportAll";
            ts_ImportAll.Size = new Size(180, 22);
            ts_ImportAll.Text = "All Tables";
            ts_ImportAll.Click += ts_ImportAll_Click;
            // 
            // ts_Export
            // 
            ts_Export.DropDownItems.AddRange(new ToolStripItem[] { ts_ExportTownOverlay, ts_ExportSelection, ts_ExportFly, toolStripSeparator3, ts_ExportAll });
            ts_Export.Image = Properties.Resources.export_ico;
            ts_Export.Name = "ts_Export";
            ts_Export.Size = new Size(180, 22);
            ts_Export.Text = "Export";
            // 
            // ts_ExportTownOverlay
            // 
            ts_ExportTownOverlay.Name = "ts_ExportTownOverlay";
            ts_ExportTownOverlay.Size = new Size(180, 22);
            ts_ExportTownOverlay.Text = "Town Overlay";
            ts_ExportTownOverlay.Click += ts_ExportTownOverlay_Click;
            // 
            // ts_ExportSelection
            // 
            ts_ExportSelection.Name = "ts_ExportSelection";
            ts_ExportSelection.Size = new Size(180, 22);
            ts_ExportSelection.Text = "Selection Overlay";
            ts_ExportSelection.Click += ts_ExportSelection_Click;
            // 
            // ts_ExportFly
            // 
            ts_ExportFly.Name = "ts_ExportFly";
            ts_ExportFly.Size = new Size(180, 22);
            ts_ExportFly.Text = "Fly Table";
            ts_ExportFly.Click += ts_ExportFly_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(177, 6);
            // 
            // ts_ExportAll
            // 
            ts_ExportAll.Name = "ts_ExportAll";
            ts_ExportAll.Size = new Size(180, 22);
            ts_ExportAll.Text = "All Tables";
            ts_ExportAll.Click += ts_ExportAll_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { btn_Open, toolStripSeparator1, btn_Save, btn_SaveAs });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // btn_Open
            // 
            btn_Open.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_Open.Image = Properties.Resources.open_ico;
            btn_Open.ImageTransparentColor = Color.Magenta;
            btn_Open.Name = "btn_Open";
            btn_Open.Size = new Size(23, 22);
            btn_Open.Text = "Open";
            btn_Open.Click += btn_Open_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // btn_Save
            // 
            btn_Save.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_Save.Image = Properties.Resources.save_ico;
            btn_Save.ImageTransparentColor = Color.Magenta;
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(23, 22);
            btn_Save.Text = "Save";
            btn_Save.Click += btn_Save_Click;
            // 
            // btn_SaveAs
            // 
            btn_SaveAs.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_SaveAs.Image = Properties.Resources.save_as_ico;
            btn_SaveAs.ImageTransparentColor = Color.Magenta;
            btn_SaveAs.Name = "btn_SaveAs";
            btn_SaveAs.Size = new Size(23, 22);
            btn_SaveAs.Text = "Save As";
            btn_SaveAs.Click += btn_SaveAs_Click;
            // 
            // tabs_TableSelector
            // 
            tabs_TableSelector.Controls.Add(tab_TownOverlay);
            tabs_TableSelector.Controls.Add(tab_SelectionOverlay);
            tabs_TableSelector.Controls.Add(tab_FlyPositions);
            tabs_TableSelector.Dock = DockStyle.Fill;
            tabs_TableSelector.Location = new Point(0, 49);
            tabs_TableSelector.Name = "tabs_TableSelector";
            tabs_TableSelector.SelectedIndex = 0;
            tabs_TableSelector.Size = new Size(800, 401);
            tabs_TableSelector.TabIndex = 3;
            // 
            // tab_TownOverlay
            // 
            tab_TownOverlay.Location = new Point(4, 24);
            tab_TownOverlay.Name = "tab_TownOverlay";
            tab_TownOverlay.Padding = new Padding(3);
            tab_TownOverlay.Size = new Size(792, 373);
            tab_TownOverlay.TabIndex = 0;
            tab_TownOverlay.Text = "Town Overlay";
            tab_TownOverlay.UseVisualStyleBackColor = true;
            // 
            // tab_SelectionOverlay
            // 
            tab_SelectionOverlay.Location = new Point(4, 24);
            tab_SelectionOverlay.Name = "tab_SelectionOverlay";
            tab_SelectionOverlay.Padding = new Padding(3);
            tab_SelectionOverlay.Size = new Size(792, 373);
            tab_SelectionOverlay.TabIndex = 1;
            tab_SelectionOverlay.Text = "Selection Overlay";
            tab_SelectionOverlay.UseVisualStyleBackColor = true;
            // 
            // tab_FlyPositions
            // 
            tab_FlyPositions.Location = new Point(4, 24);
            tab_FlyPositions.Name = "tab_FlyPositions";
            tab_FlyPositions.Size = new Size(792, 373);
            tab_FlyPositions.TabIndex = 2;
            tab_FlyPositions.Text = "Fly Positions";
            tab_FlyPositions.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(tabs_TableSelector);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            Text = "HGSS Town Map Table Editor";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabs_TableSelector.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ts_Open;
        private System.Windows.Forms.ToolStripMenuItem ts_Save;
        private ToolStripMenuItem ts_SaveAs;
        private ToolStripMenuItem ts_Import;
        private ToolStripMenuItem ts_ImportAll;
        private ToolStripMenuItem ts_ImportTownOverlay;
        private ToolStripMenuItem ts_ImportSelection;
        private ToolStripMenuItem ts_ImportFly;
        private ToolStripMenuItem ts_Export;
        private ToolStripMenuItem ts_ExportAll;
        private ToolStripMenuItem ts_ExportTownOverlay;
        private ToolStripMenuItem ts_ExportSelection;
        private ToolStripMenuItem ts_ExportFly;
        private ToolStrip toolStrip1;
        private ToolStripButton btn_Open;
        private ToolStripButton btn_Save;
        private ToolStripButton btn_SaveAs;
        private TabControl tabs_TableSelector;
        private TabPage tab_TownOverlay;
        private TabPage tab_SelectionOverlay;
        private TabPage tab_FlyPositions;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
    }
}
