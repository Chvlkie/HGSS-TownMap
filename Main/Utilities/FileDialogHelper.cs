using System;
using System.Windows.Forms;

namespace Main.Utilities
{
    public static class FileDialogHelper
    {
        // File filters
        public const string TownOverlayFilter = "Town Overlay Files (*.pgetown)|*.pgetown";
        public const string SelectionOverlayFilter = "Selection Overlay Files (*.pgesel)|*.pgesel";
        public const string FlyTableFilter = "Fly Table Files (*.pgefly)|*.pgefly";
        public const string JsonFilter = "JSON Files (*.json)|*.json";
        public const string AllTablesFilter = "Pokémon HG Editor Files (*.pgetown;*.pgesel;*.pgefly)|*.pgetown;*.pgesel;*.pgefly";

        // Default extensions
        public const string TownOverlayExtension = ".pgetown";
        public const string SelectionOverlayExtension = ".pgesel";
        public const string FlyTableExtension = ".pgefly";

        public static bool TryGetOpenPath(out string path, string filter = "All Files|*.*", string title = null)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = filter,
                Title = title ?? "Open File"
            };
            var result = dialog.ShowDialog();
            path = dialog.FileName;
            return result == DialogResult.OK;
        }

        public static bool TryGetSavePath(out string path, string filter = "All Files|*.*", string title = null, string defaultExt = null)
        {
            using var dialog = new SaveFileDialog
            {
                Filter = filter,
                Title = title ?? "Save File",
                DefaultExt = defaultExt
            };
            var result = dialog.ShowDialog();
            path = dialog.FileName;
            return result == DialogResult.OK;
        }

        public static bool TryGetFolderPath(out string path, string description = "Select folder")
        {
            using var dialog = new FolderBrowserDialog
            {
                Description = description,
                ShowNewFolderButton = true
            };
            var result = dialog.ShowDialog();
            path = dialog.SelectedPath;
            return result == DialogResult.OK;
        }

        public static string GetExportFileName(string tableName, string extension)
        {
            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            return $"{tableName.ToLower()}_{timestamp}{extension}";
        }
    }
}