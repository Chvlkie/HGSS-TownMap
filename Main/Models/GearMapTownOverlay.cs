using System;
using System.ComponentModel;

namespace Main.Models
{
    public class GearMapTownOverlay : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ushort _mapHeader;
        private ushort _gateAppearance;
        private byte _entry;
        private byte _entry2;
        private byte _redX;
        private byte _redY;
        private byte _grayX;
        private byte _grayY;
        private byte _townDim;
        private byte _replacementDim;
        private byte _offset;
        private byte _padding;

        [DisplayName("Map ID")]
        public int MapHeaderDec
        {
            get => MapHeader;
            set
            {
                MapHeader = (ushort)value;
                OnPropertyChanged(nameof(MapHeaderDec));
            }
        }

        [DisplayName("Gate Appearance")]
        public int GateAppearanceDec
        {
            get => GateAppearance;
            set
            {
                GateAppearance = (ushort)value;
                OnPropertyChanged(nameof(GateAppearanceDec));
            }
        }

        [DisplayName("Entry")]
        public int EntryDec
        {
            get => Entry;
            set
            {
                Entry = (byte)value;
                OnPropertyChanged(nameof(EntryDec));
            }
        }

        [DisplayName("Alt Entry")]
        public int Entry2Dec
        {
            get => Entry2;
            set
            {
                Entry2 = (byte)value;
                OnPropertyChanged(nameof(Entry2Dec));
            }
        }

        [DisplayName("Red X")]
        public int RedXDec
        {
            get => RedX;
            set
            {
                RedX = (byte)value;
                OnPropertyChanged(nameof(RedXDec));
            }
        }

        [DisplayName("Red Y")]
        public int RedYDec
        {
            get => RedY;
            set
            {
                RedY = (byte)value;
                OnPropertyChanged(nameof(RedYDec));
            }
        }

        [DisplayName("Gray X")]
        public int GrayXDec
        {
            get => GrayX;
            set
            {
                GrayX = (byte)value;
                OnPropertyChanged(nameof(GrayXDec));
            }
        }

        [DisplayName("Gray Y")]
        public int GrayYDec
        {
            get => GrayY;
            set
            {
                GrayY = (byte)value;
                OnPropertyChanged(nameof(GrayYDec));
            }
        }

        [DisplayName("Town Dim Y")]
        public int TownDimY
        {
            get => TownDim >> 4;
            set
            {
                TownDim = (byte)((value << 4) | TownDimX);
                OnPropertyChanged(nameof(TownDimY));
                OnPropertyChanged(nameof(TownDim));
            }
        }

        [DisplayName("Town Dim X")]
        public int TownDimX
        {
            get => TownDim & 0x0F;
            set
            {
                TownDim = (byte)((TownDimY << 4) | value);
                OnPropertyChanged(nameof(TownDimX));
                OnPropertyChanged(nameof(TownDim));
            }
        }

        [DisplayName("Repl Dim Y")]
        public int ReplacementDimY
        {
            get => ReplacementDim >> 4;
            set
            {
                ReplacementDim = (byte)((value << 4) | ReplacementDimX);
                OnPropertyChanged(nameof(ReplacementDimY));
                OnPropertyChanged(nameof(ReplacementDim));
            }
        }

        [DisplayName("Repl Dim X")]
        public int ReplacementDimX
        {
            get => ReplacementDim & 0x0F;
            set
            {
                ReplacementDim = (byte)((ReplacementDimY << 4) | value);
                OnPropertyChanged(nameof(ReplacementDimX));
                OnPropertyChanged(nameof(ReplacementDim));
            }
        }

        [DisplayName("Offset Y")]
        public int OffsetY
        {
            get => Offset >> 4;
            set
            {
                Offset = (byte)((value << 4) | OffsetX);
                OnPropertyChanged(nameof(OffsetY));
                OnPropertyChanged(nameof(Offset));
            }
        }

        [DisplayName("Offset X")]
        public int OffsetX
        {
            get => Offset & 0x0F;
            set
            {
                Offset = (byte)((OffsetY << 4) | value);
                OnPropertyChanged(nameof(OffsetX));
                OnPropertyChanged(nameof(Offset));
            }
        }

        [Browsable(false)]
        public ushort MapHeader
        {
            get => _mapHeader;
            set
            {
                _mapHeader = value;
                OnPropertyChanged(nameof(MapHeader));
                OnPropertyChanged(nameof(MapHeaderDec));
            }
        }

        [Browsable(false)]
        public ushort GateAppearance
        {
            get => _gateAppearance;
            set
            {
                _gateAppearance = value;
                OnPropertyChanged(nameof(GateAppearance));
                OnPropertyChanged(nameof(GateAppearanceDec));
            }
        }

        [Browsable(false)]
        public byte Entry
        {
            get => _entry;
            set
            {
                _entry = value;
                OnPropertyChanged(nameof(Entry));
                OnPropertyChanged(nameof(EntryDec));
            }
        }

        [Browsable(false)]
        public byte Entry2
        {
            get => _entry2;
            set
            {
                _entry2 = value;
                OnPropertyChanged(nameof(Entry2));
                OnPropertyChanged(nameof(Entry2Dec));
            }
        }

        [Browsable(false)]
        public byte RedX
        {
            get => _redX;
            set
            {
                _redX = value;
                OnPropertyChanged(nameof(RedX));
                OnPropertyChanged(nameof(RedXDec));
            }
        }

        [Browsable(false)]
        public byte RedY
        {
            get => _redY;
            set
            {
                _redY = value;
                OnPropertyChanged(nameof(RedY));
                OnPropertyChanged(nameof(RedYDec));
            }
        }

        [Browsable(false)]
        public byte GrayX
        {
            get => _grayX;
            set
            {
                _grayX = value;
                OnPropertyChanged(nameof(GrayX));
                OnPropertyChanged(nameof(GrayXDec));
            }
        }

        [Browsable(false)]
        public byte GrayY
        {
            get => _grayY;
            set
            {
                _grayY = value;
                OnPropertyChanged(nameof(GrayY));
                OnPropertyChanged(nameof(GrayYDec));
            }
        }

        [Browsable(false)]
        public byte TownDim
        {
            get => _townDim;
            set
            {
                _townDim = value;
                OnPropertyChanged(nameof(TownDim));
                OnPropertyChanged(nameof(TownDimY));
                OnPropertyChanged(nameof(TownDimX));
            }
        }

        [Browsable(false)]
        public byte ReplacementDim
        {
            get => _replacementDim;
            set
            {
                _replacementDim = value;
                OnPropertyChanged(nameof(ReplacementDim));
                OnPropertyChanged(nameof(ReplacementDimY));
                OnPropertyChanged(nameof(ReplacementDimX));
            }
        }

        [Browsable(false)]
        public byte Offset
        {
            get => _offset;
            set
            {
                _offset = value;
                OnPropertyChanged(nameof(Offset));
                OnPropertyChanged(nameof(OffsetY));
                OnPropertyChanged(nameof(OffsetX));
            }
        }

        [Browsable(false)]
        public byte Padding
        {
            get => _padding;
            set
            {
                _padding = value;
                OnPropertyChanged(nameof(Padding));
            }
        }

        [Browsable(false)]
        public string TownDimDisplay => $"{TownDimY}:{TownDimX}";

        [Browsable(false)]
        public string ReplacementDimDisplay => $"{ReplacementDimY}:{ReplacementDimX}";

        [Browsable(false)]
        public string OffsetDisplay => $"{OffsetY}:{OffsetX}";

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}