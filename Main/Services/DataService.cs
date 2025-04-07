using Main.Models;
using Main.Utilities;

namespace Main.Services
{
    public class DataService : IDataService
    {


        public List<FlyRespawnPosition> ReadFlyRespawnPositions(string arm9Path)
        {
            var items = new List<FlyRespawnPosition>();
            using var reader = new DsUtils.EasyReader(arm9Path, RomFileInfo.FlyPointTable.Offset);

            for (int i = 0; i < RomFileInfo.FlyPointTable.RowCount; i++)
            {
                items.Add(new FlyRespawnPosition
                {
                    FlySpot = reader.ReadByte(),
                    Flags = reader.ReadByte(),
                    MapHeader = reader.ReadUInt16(),
                    X = reader.ReadByte(),
                    Y = reader.ReadByte(),
                    FieldId = reader.ReadUInt16(),
                    FieldCoordX = reader.ReadUInt16(),
                    FieldCoordY = reader.ReadUInt16(),
                    FieldId2 = reader.ReadUInt16(),
                    FieldCoordX2 = reader.ReadUInt16(),
                    FieldCoordY2 = reader.ReadUInt16()
                });
            }
            return items;
        }

        public List<GearMapTownOverlay> ReadTownOverlay(string overlayPath)
        {
            var items = new List<GearMapTownOverlay>();
            using var reader = new DsUtils.EasyReader(overlayPath, RomFileInfo.TownOverlayTable.Offset);

            for (int i = 0; i < RomFileInfo.TownOverlayTable.RowCount; i++)
            {
                items.Add(new GearMapTownOverlay
                {
                    MapHeader = reader.ReadUInt16(),
                    GateAppearance = reader.ReadUInt16(),
                    Entry = reader.ReadByte(),
                    Entry2 = reader.ReadByte(),
                    RedX = reader.ReadByte(),
                    RedY = reader.ReadByte(),
                    GrayX = reader.ReadByte(),
                    GrayY = reader.ReadByte(),
                    TownDim = reader.ReadByte(),
                    ReplacementDim = reader.ReadByte(),
                    Offset = reader.ReadByte(),
                    Padding = reader.ReadByte()
                });
            }
            return items;
        }

        public List<GearMapTownSelectionOverlay> ReadTownSelectionOverlay(string overlayPath)
        {
            var items = new List<GearMapTownSelectionOverlay>();
            using var reader = new DsUtils.EasyReader(overlayPath, RomFileInfo.TownSelectionOverlayTable.Offset);

            for (int i = 0; i < RomFileInfo.TownSelectionOverlayTable.RowCount; i++)
            {
                items.Add(new GearMapTownSelectionOverlay
                {
                    MapHeader = reader.ReadUInt16(),
                    BaseX = reader.ReadByte(),
                    BaseY = reader.ReadByte(),
                    Dim = reader.ReadByte(),
                    Flags = reader.ReadByte(),
                    TextEntry = reader.ReadByte(),
                    FlySpot = reader.ReadByte(),
                    Padding = reader.ReadUInt32(),
                    OrangeBaseX = reader.ReadByte(),
                    OrangeBaseY = reader.ReadByte(),
                    OrangeDimX = reader.ReadByte(),
                    OrangeDimY = reader.ReadByte()
                });
            }
            return items;
        }

        public void WriteFlyRespawnPositions(string arm9Path, IEnumerable<FlyRespawnPosition> data)
        {
            if (data.Count() != RomFileInfo.FlyPointTable.RowCount)
                throw new ArgumentException($"Expected {RomFileInfo.FlyPointTable.RowCount} entries, got {data.Count()}");
            DsUtils.CreateBackup(RomFileInfo.Arm9FilePath);

            using var writer = new DsUtils.EasyWriter(arm9Path, RomFileInfo.FlyPointTable.Offset);

            foreach (var item in data)
            {
                writer.Write(item.FlySpot);
                writer.Write(item.Flags);
                writer.Write(item.MapHeader);
                writer.Write(item.X);
                writer.Write(item.Y);
                writer.Write(item.FieldId);
                writer.Write(item.FieldCoordX);
                writer.Write(item.FieldCoordY);
                writer.Write(item.FieldId2);
                writer.Write(item.FieldCoordX2);
                writer.Write(item.FieldCoordY2);
            }
        }

        public void WriteTownOverlay(string overlayPath, IEnumerable<GearMapTownOverlay> data)
        {
            if (data.Count() != RomFileInfo.TownOverlayTable.RowCount)
                throw new ArgumentException($"Expected {RomFileInfo.TownOverlayTable.RowCount} entries, got {data.Count()}");
            DsUtils.CreateBackup(RomFileInfo.TownMapOverlayFilePath);

            using var writer = new DsUtils.EasyWriter(overlayPath, RomFileInfo.TownOverlayTable.Offset);

            foreach (var item in data)
            {
                writer.Write(item.MapHeader);
                writer.Write(item.GateAppearance);
                writer.Write(item.Entry);
                writer.Write(item.Entry2);
                writer.Write(item.RedX);
                writer.Write(item.RedY);
                writer.Write(item.GrayX);
                writer.Write(item.GrayY);
                writer.Write(item.TownDim);
                writer.Write(item.ReplacementDim);
                writer.Write(item.Offset);
                writer.Write(item.Padding);
            }
        }

        public void WriteTownSelectionOverlay(string overlayPath, IEnumerable<GearMapTownSelectionOverlay> data)
        {
            if (data.Count() != RomFileInfo.TownSelectionOverlayTable.RowCount)
                throw new ArgumentException($"Expected {RomFileInfo.TownSelectionOverlayTable.RowCount} entries, got {data.Count()}");
            DsUtils.CreateBackup(RomFileInfo.TownMapOverlayFilePath);
            using var writer = new DsUtils.EasyWriter(overlayPath, RomFileInfo.TownSelectionOverlayTable.Offset);

            foreach (var item in data)
            {
                writer.Write(item.MapHeader);
                writer.Write(item.BaseX);
                writer.Write(item.BaseY);
                writer.Write(item.Dim);
                writer.Write(item.Flags);
                writer.Write(item.TextEntry);
                writer.Write(item.FlySpot);
                writer.Write(item.Padding);
                writer.Write(item.OrangeBaseX);
                writer.Write(item.OrangeBaseY);
                writer.Write(item.OrangeDimX);
                writer.Write(item.OrangeDimY);
            }
        }
    }
}