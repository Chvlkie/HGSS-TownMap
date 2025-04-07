using Main.Models;
using Main.Services;
using Main.Utilities;
using System.ComponentModel;
using System.Text.Json;

namespace Main
{
    public partial class MainForm : Form
    {
        private readonly IDataService _dataService;
        private BindingList<FlyRespawnPosition>? _flyRespawnData;
        private BindingList<GearMapTownSelectionOverlay>? _selectionOverlayData;
        private BindingList<GearMapTownOverlay>? _townOverlayData;

        public MainForm(IDataService dataService)
        {
            _dataService = dataService;
            InitializeComponent();
            ConfigureTownMapOverlayTable();
            ConfigureSelectionOverlayTable();
            ConfigureFlyRespawnTable();
            EnableDisableControls(false);
        }

        private static void AddColumnToGrid(DataGridView dgv, string propertyName, string headerText, int minValue, int maxValue)
        {
            var col = new DataGridViewTextBoxColumn
            {
                DataPropertyName = propertyName,
                HeaderText = headerText,
                ValueType = GetColumnType(minValue, maxValue),
                ReadOnly = false,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0"
                },
                Tag = new { Min = minValue, Max = maxValue }
            };
            dgv.Columns.Add(col);
        }

        private static Type GetColumnType(int minValue, int maxValue)
        {
            switch (minValue)
            {
                case >= 0:
                    if (maxValue <= byte.MaxValue) return typeof(byte);
                    if (maxValue <= ushort.MaxValue) return typeof(ushort);
                    if (maxValue <= uint.MaxValue) return typeof(uint);
                    return typeof(long);

                case >= sbyte.MinValue when maxValue <= sbyte.MaxValue:
                    return typeof(sbyte);

                case >= short.MinValue when maxValue <= short.MaxValue:
                    return typeof(short);

                case >= int.MinValue when maxValue <= int.MaxValue:
                    return typeof(int);

                default:
                    return typeof(long);
            }
        }

        private static DataGridView GetDataGridViewForTab(TabPage tabPage)
        {
            // If there's no DataGridView in the tab yet, create one
            if (tabPage.Controls.Count == 0)
            {
                var dgv = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    Name = "dgv_" + tabPage.Name.Replace("tab_", "")
                };
                tabPage.Controls.Add(dgv);
                return dgv;
            }

            return (DataGridView)tabPage.Controls[0];
        }
        private void btn_Open_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btn_SaveAs_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void ConfigureFlyRespawnTable()
        {
            var dgv = GetDataGridViewForTab(tab_FlyPositions);

            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv.Columns.Clear();

            AddColumnToGrid(dgv, "FlySpot", "Fly Spot", 0, byte.MaxValue);
            AddColumnToGrid(dgv, "Flags", "Flags", 0, byte.MaxValue);
            AddColumnToGrid(dgv, "MapHeader", "Map Header", 0, ushort.MaxValue);
            AddColumnToGrid(dgv, "X", "X", 0, byte.MaxValue);
            AddColumnToGrid(dgv, "Y", "Y", 0, byte.MaxValue);
            AddColumnToGrid(dgv, "FieldId", "Field ID", 0, ushort.MaxValue);
            AddColumnToGrid(dgv, "FieldCoordX", "Field X", 0, ushort.MaxValue);
            AddColumnToGrid(dgv, "FieldCoordY", "Field Y", 0, ushort.MaxValue);
            AddColumnToGrid(dgv, "FieldId2", "Field ID 2", 0, ushort.MaxValue);
            AddColumnToGrid(dgv, "FieldCoordX2", "Field X 2", 0, ushort.MaxValue);
            AddColumnToGrid(dgv, "FieldCoordY2", "Field Y 2", 0, ushort.MaxValue);
        }

        private void ConfigureSelectionOverlayTable()
        {
            var dgv = GetDataGridViewForTab(tab_SelectionOverlay);

            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv.Columns.Clear();

            AddColumnToGrid(dgv, "MapHeader", "Map Header", 0, ushort.MaxValue);
            AddColumnToGrid(dgv, "BaseX", "Base X", 0, byte.MaxValue);
            AddColumnToGrid(dgv, "BaseY", "Base Y", 0, byte.MaxValue);
            AddColumnToGrid(dgv, "DimX", "Dim X", 0, 15);
            AddColumnToGrid(dgv, "DimY", "Dim Y", 0, 15);
            AddColumnToGrid(dgv, "Flags", "Flags", 0, byte.MaxValue);
            AddColumnToGrid(dgv, "TextEntry", "Text Entry", 0, byte.MaxValue);
            AddColumnToGrid(dgv, "FlySpot", "Fly Spot", 0, byte.MaxValue);
            AddColumnToGrid(dgv, "OrangeBaseX", "Orange Base X", 0, byte.MaxValue);
            AddColumnToGrid(dgv, "OrangeBaseY", "Orange Base Y", 0, byte.MaxValue);
            AddColumnToGrid(dgv, "OrangeDimX", "Orange Dim X", 0, byte.MaxValue);
            AddColumnToGrid(dgv, "OrangeDimY", "Orange Dim Y", 0, byte.MaxValue);
        }

        private void ConfigureTownMapOverlayTable()
        {
            var dgv = GetDataGridViewForTab(tab_TownOverlay);

            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv.Columns.Clear();

            AddColumnToGrid(dgv, "MapHeaderDec", "Map ID", 0, ushort.MaxValue);
            AddColumnToGrid(dgv, "GateAppearanceDec", "Gate Appear", 0, ushort.MaxValue);
            AddColumnToGrid(dgv, "EntryDec", "Entry", 0, byte.MaxValue);
            AddColumnToGrid(dgv, "Entry2Dec", "Alt Entry", 0, byte.MaxValue);
            AddColumnToGrid(dgv, "RedXDec", "Red X", 0, byte.MaxValue);
            AddColumnToGrid(dgv, "RedYDec", "Red Y", 0, byte.MaxValue);
            AddColumnToGrid(dgv, "GrayXDec", "Gray X", 0, byte.MaxValue);
            AddColumnToGrid(dgv, "GrayYDec", "Gray Y", 0, byte.MaxValue);
            AddColumnToGrid(dgv, "TownDimX", "Town X", 0, 15);
            AddColumnToGrid(dgv, "TownDimY", "Town Y", 0, 15);
            AddColumnToGrid(dgv, "ReplacementDimX", "Repl X", 0, 15);
            AddColumnToGrid(dgv, "ReplacementDimY", "Repl Y", 0, 15);
            AddColumnToGrid(dgv, "OffsetX", "Offset X", 0, 15);
            AddColumnToGrid(dgv, "OffsetY", "Offset Y", 0, 15);
        }

        private void EnableDisableControls(bool enable)
        {
            ts_Save.Enabled = enable;
            ts_SaveAs.Enabled = enable;
            ts_Import.Enabled = enable;
            ts_Export.Enabled = enable;
            btn_Save.Enabled = enable;
            btn_SaveAs.Enabled = enable;
        }

        private void ExportAll()
        {
            if (FileDialogHelper.TryGetFolderPath(out string folderPath, "Select folder to save all tables"))
            {
                try
                {
                    string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                    ExportTownOverlay(Path.Combine(folderPath,
                        FileDialogHelper.GetExportFileName("town_overlay", FileDialogHelper.TownOverlayExtension)));
                    ExportSelectionOverlay(Path.Combine(folderPath,
                        FileDialogHelper.GetExportFileName("selection_overlay", FileDialogHelper.SelectionOverlayExtension)));
                    ExportFlyTable(Path.Combine(folderPath,
                        FileDialogHelper.GetExportFileName("fly_table", FileDialogHelper.FlyTableExtension)));

                    MessageBox.Show("All tables exported successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting tables: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExportFlyTable(string filePath)
        {
            if (_flyRespawnData == null)
            {
                MessageBox.Show("No fly table data loaded", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string json = JsonSerializer.Serialize(_flyRespawnData.ToList(), new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(filePath, json);

                MessageBox.Show($"Fly table data exported to {filePath}", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting fly table: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportSelectionOverlay(string filePath)
        {
            if (_selectionOverlayData == null)
            {
                MessageBox.Show("No selection overlay data loaded", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string json = JsonSerializer.Serialize(_selectionOverlayData.ToList(), new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(filePath, json);

                MessageBox.Show($"Selection overlay data exported to {filePath}", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting selection overlay: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportTownOverlay(string filePath)
        {
            if (_townOverlayData == null)
            {
                MessageBox.Show("No town overlay data loaded", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string json = JsonSerializer.Serialize(_townOverlayData.ToList(), new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(filePath, json);

                MessageBox.Show($"Town overlay data exported to {filePath}", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting town overlay: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImportAll()
        {
            if (FileDialogHelper.TryGetFolderPath(out string folderPath, "Select folder containing import files"))
            {
                try
                {
                    var townFiles = Directory.GetFiles(folderPath, $"*{FileDialogHelper.TownOverlayExtension}");
                    var selectionFiles = Directory.GetFiles(folderPath, $"*{FileDialogHelper.SelectionOverlayExtension}");
                    var flyFiles = Directory.GetFiles(folderPath, $"*{FileDialogHelper.FlyTableExtension}");

                    if (townFiles.Length > 0) ImportTownOverlay(townFiles[0]);
                    if (selectionFiles.Length > 0) ImportSelectionOverlay(selectionFiles[0]);
                    if (flyFiles.Length > 0) ImportFlyTable(flyFiles[0]);

                    MessageBox.Show("Import completed", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error during import: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ImportFlyTable(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                var data = JsonSerializer.Deserialize<List<FlyRespawnPosition>>(json);

                if (data == null || data.Count == 0)
                    throw new InvalidDataException("File contains no valid data");

                _flyRespawnData = new BindingList<FlyRespawnPosition>(data);
                GetDataGridViewForTab(tab_FlyPositions).DataSource = _flyRespawnData;

                MessageBox.Show($"Successfully imported {data.Count} fly table entries", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error importing fly table: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImportSelectionOverlay(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                var data = JsonSerializer.Deserialize<List<GearMapTownSelectionOverlay>>(json);

                if (data == null || data.Count == 0)
                    throw new InvalidDataException("File contains no valid data");

                _selectionOverlayData = new BindingList<GearMapTownSelectionOverlay>(data);
                GetDataGridViewForTab(tab_SelectionOverlay).DataSource = _selectionOverlayData;

                MessageBox.Show($"Successfully imported {data.Count} selection overlay entries", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error importing selection overlay: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImportTownOverlay(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                var data = JsonSerializer.Deserialize<List<GearMapTownOverlay>>(json);

                if (data == null || data.Count == 0)
                    throw new InvalidDataException("File contains no valid data");

                _townOverlayData = [.. data];
                GetDataGridViewForTab(tab_TownOverlay).DataSource = _townOverlayData;

                MessageBox.Show($"Successfully imported {data.Count} town overlay entries", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error importing town overlay: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Open()
        {
            if (FileDialogHelper.TryGetFolderPath(out string folderPath, "Select DSPRE Folder"))
            {
                try
                {
                    RomFileInfo.WorkingDirectory = folderPath;

                    if (!File.Exists(RomFileInfo.Arm9FilePath) || !File.Exists(RomFileInfo.OverlayTableFilePath) || !File.Exists(RomFileInfo.TownMapOverlayFilePath))
                    {
                        string missingFile = !File.Exists(RomFileInfo.Arm9FilePath) ? RomFileInfo.Arm9FilePath :
                            !File.Exists(RomFileInfo.OverlayTableFilePath) ? RomFileInfo.OverlayTableFilePath :
                            !File.Exists(RomFileInfo.TownMapOverlayFilePath) ? RomFileInfo.TownMapOverlayFilePath : "";

                        MessageBox.Show($"Required file not found: {missingFile}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        RomFileInfo.WorkingDirectory = "";
                        EnableDisableControls(false);
                        return;
                    }

                    if (Overlay.IsCompressed(RomFileInfo.TownMapOverlayNumber))
                    {
                        MessageBox.Show($"Overlay 101 is marked as compressed.\nThis table must be decompressed first.\n\nYou can do this using DSPRE > Other Editors > Overlay Editor",
                       "Overlay 101 is Compressed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        RomFileInfo.WorkingDirectory = "";
                        EnableDisableControls(false);
                        return;
                    }

                    _townOverlayData = [.. _dataService.ReadTownOverlay(RomFileInfo.TownMapOverlayFilePath)];
                    _selectionOverlayData = [.. _dataService.ReadTownSelectionOverlay(RomFileInfo.TownMapOverlayFilePath)];
                    _flyRespawnData = [.. _dataService.ReadFlyRespawnPositions(RomFileInfo.Arm9FilePath)];

                    GetDataGridViewForTab(tab_TownOverlay).DataSource = _townOverlayData;
                    GetDataGridViewForTab(tab_SelectionOverlay).DataSource = _selectionOverlayData;
                    GetDataGridViewForTab(tab_FlyPositions).DataSource = _flyRespawnData;

                    Text = $"HGSS Town Map Table Editor - {Path.GetFileName(folderPath)}";
                    EnableDisableControls(true);
                }
                catch (Exception ex)
                {
                    RomFileInfo.WorkingDirectory = "";
                    Text = "HGSS Town Map Table Editor";
                    EnableDisableControls(false);
                    MessageBox.Show($"Error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Save()
        {
            if (string.IsNullOrEmpty(RomFileInfo.WorkingDirectory))
            {
                MessageBox.Show("No ROM folder loaded", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show(
        "Save changes to ROM files?\n\n" +
        "ARM9.bin\n" +
        "overlay_0101.bin\n\n" +
        "Backups will be created automatically.",
        "Confirm Save",
        MessageBoxButtons.YesNoCancel,
        MessageBoxIcon.Question,
        MessageBoxDefaultButton.Button3); // Default to Cancel

            switch (result)
            {
                case DialogResult.Yes:
                    try
                    {
                        _dataService.WriteTownOverlay(RomFileInfo.TownMapOverlayFilePath, _townOverlayData);
                        _dataService.WriteTownSelectionOverlay(RomFileInfo.TownMapOverlayFilePath, _selectionOverlayData);
                        _dataService.WriteFlyRespawnPositions(RomFileInfo.Arm9FilePath, _flyRespawnData);

                        MessageBox.Show("All tables saved successfully", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving files: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                default:
                    return;
            }
        }

        private void SaveAs()
        {
            using var folderDialog = new FolderBrowserDialog
            {
                Description = "Select folder to save modified ROM files",
                ShowNewFolderButton = true,
                UseDescriptionForTitle = true
            };

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                string saveFolder = folderDialog.SelectedPath;

                string newArm9Path = Path.Combine(saveFolder, RomFileInfo.Arm9FileName);
                string newOverlayPath = Path.Combine(saveFolder, RomFileInfo.OverlayFolderName, Path.GetFileName(RomFileInfo.TownMapOverlayFilePath));

                if (File.Exists(newArm9Path) || File.Exists(newOverlayPath))
                {
                    var overwriteResult = MessageBox.Show(
                        "Target folder contains existing ROM files.\nOverwrite them?\n\n" +
                        $"{Path.GetFileName(newArm9Path)}\n" +
                        $"{Path.GetFileName(newOverlayPath)}",
                        "Overwrite Files?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2);

                    if (overwriteResult != DialogResult.Yes)
                    {
                        return;
                    }
                }

                try
                {
                    string overlayFolder = Path.Combine(saveFolder, RomFileInfo.OverlayFolderName);
                    Directory.CreateDirectory(overlayFolder);

                    _dataService.WriteTownOverlay(newOverlayPath, _townOverlayData);
                    _dataService.WriteTownSelectionOverlay(newOverlayPath, _selectionOverlayData);
                    _dataService.WriteFlyRespawnPositions(newArm9Path, _flyRespawnData);

                    RomFileInfo.WorkingDirectory = saveFolder;
                    Text = $"HGSS Town Map Table Editor - {Path.GetFileName(saveFolder)}";

                    MessageBox.Show($"Files saved successfully to:\n{saveFolder}",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving files: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void ts_ExportAll_Click(object sender, EventArgs e) => ExportAll();

        private void ts_ExportFly_Click(object sender, EventArgs e)
        {
            if (FileDialogHelper.TryGetSavePath(out string path,
                filter: $"{FileDialogHelper.FlyTableFilter}|{FileDialogHelper.JsonFilter}",
                title: "Export Fly Table",
                defaultExt: FileDialogHelper.FlyTableExtension))
            {
                ExportFlyTable(path);
            }
        }

        private void ts_ExportSelection_Click(object sender, EventArgs e)
        {
            if (FileDialogHelper.TryGetSavePath(out string path,
                filter: $"{FileDialogHelper.SelectionOverlayFilter}|{FileDialogHelper.JsonFilter}",
                title: "Export Selection Overlay",
                defaultExt: FileDialogHelper.SelectionOverlayExtension))
            {
                ExportSelectionOverlay(path);
            }
        }

        private void ts_ExportTownOverlay_Click(object sender, EventArgs e)
        {
            if (FileDialogHelper.TryGetSavePath(out string path,
                filter: $"{FileDialogHelper.TownOverlayFilter}|{FileDialogHelper.JsonFilter}",
                title: "Export Town Overlay",
                defaultExt: FileDialogHelper.TownOverlayExtension))
            {
                ExportTownOverlay(path);
            }
        }

        private void ts_ImportAll_Click(object sender, EventArgs e) => ImportAll();

        private void ts_ImportFly_Click(object sender, EventArgs e)
        {
            if (FileDialogHelper.TryGetOpenPath(out string path,
                filter: $"{FileDialogHelper.FlyTableFilter}|{FileDialogHelper.JsonFilter}",
                title: "Import Fly Table"))
            {
                ImportFlyTable(path);
            }
        }

        private void ts_ImportSelection_Click(object sender, EventArgs e)
        {
            if (FileDialogHelper.TryGetOpenPath(out string path,
                filter: $"{FileDialogHelper.SelectionOverlayFilter}|{FileDialogHelper.JsonFilter}",
                title: "Import Selection Overlay"))
            {
                ImportSelectionOverlay(path);
            }
        }

        private void ts_ImportTownOverlay_Click(object sender, EventArgs e)
        {
            if (FileDialogHelper.TryGetOpenPath(out string path,
                filter: $"{FileDialogHelper.TownOverlayFilter}|{FileDialogHelper.JsonFilter}",
                title: "Import Town Overlay"))
            {
                ImportTownOverlay(path);
            }
        }

        private void ts_Open_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void ts_Save_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void ts_SaveAs_Click(object sender, EventArgs e)
        {
            SaveAs();
        }
    }
}