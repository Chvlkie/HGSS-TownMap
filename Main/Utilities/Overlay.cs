using Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Utilities
{
   public static class Overlay
    {
        public static bool IsCompressed(int overlayNumber)
        {
            return new FileInfo(RomFileInfo.GetOverlayPath(overlayNumber)).Length < GetUncompressedSize(overlayNumber);
        }

        public static uint GetUncompressedSize(int overlayNumber)
        {
            using DsUtils.EasyReader f = new(RomFileInfo.OverlayTableFilePath, (overlayNumber * 32) + 8);
            return f.ReadUInt32();
        }
    }
}
