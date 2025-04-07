using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Utilities
{
    public static class DsUtils
    {
        public static void CreateBackup(string originalPath)
        {
            string backupPath = $"{originalPath}.bak";

            // Only create backup if it doesn't exist already
            if (!File.Exists(backupPath))
            {
                File.Copy(originalPath, backupPath);
            }
        }

        public class EasyReader : BinaryReader
        {
            public EasyReader(string path, long pos = 0) : base(File.OpenRead(path))
            {
                BaseStream.Position = pos;
            }
        }

        public class EasyWriter : BinaryWriter
        {
            public EasyWriter(string path, long pos = 0, FileMode fmode = FileMode.OpenOrCreate) : base(new FileStream(path, fmode, FileAccess.Write, FileShare.None))
            {
                BaseStream.Position = pos;
            }
            public void EditSize(int increment)
            {
                BaseStream.SetLength(BaseStream.Length + increment);
            }
        }
    }
}