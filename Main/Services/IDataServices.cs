using Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Services
{
    public interface IDataService
    {
        List<FlyRespawnPosition> ReadFlyRespawnPositions(string arm9FilePath);
        List<GearMapTownOverlay> ReadTownOverlay(string filePath);
        List<GearMapTownSelectionOverlay> ReadTownSelectionOverlay(string filePath);
        void WriteFlyRespawnPositions(string arm9FilePath, IEnumerable<FlyRespawnPosition> data);
        void WriteTownOverlay(string filePath, IEnumerable<GearMapTownOverlay> data);
        void WriteTownSelectionOverlay(string filePath, IEnumerable<GearMapTownSelectionOverlay> data);
    }
}
