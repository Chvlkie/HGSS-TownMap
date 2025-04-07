public static class RomFileInfo
{
    // File Names
    public const string Arm9FileName = "arm9.bin";
    public const string OverlayTableFileName = "y9.bin";
    public const string OverlayFolderName = "overlay";

    // Overlay Numbers
    public const int TownMapOverlayNumber = 101;

    // Table Offsets and Sizes
    public static class TownOverlayTable
    {
        public const int Offset = 0x10274;
        public const int RowCount = 27;
        public const int RowSize = 0xE;
    }

    public static class TownSelectionOverlayTable
    {
        public const int Offset = 0xFC32;
        public const int RowCount = 100;
        public const int RowSize = 0x10;
    }

    public static class FlyPointTable
    {
        public const int Offset = 0xF9E80;
        public const int RowCount = 30;
        public const int RowSize = 0x12;
    }

    // Computed Paths
    public static string WorkingDirectory { get; set; } = "";

    public static string Arm9FilePath => Path.Combine(WorkingDirectory, Arm9FileName);
    public static string OverlayTableFilePath => Path.Combine(WorkingDirectory, OverlayTableFileName);

    public static string GetOverlayPath(int overlayNumber) =>
        Path.Combine(WorkingDirectory, OverlayFolderName, $"overlay_{overlayNumber:D4}.bin");

    public static string TownMapOverlayFilePath => GetOverlayPath(TownMapOverlayNumber);
}