using System;
using System.ComponentModel;

namespace Main.Models
{
    public class GearMapTownSelectionOverlay : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ushort _mapHeader;
        private byte _baseX;
        private byte _baseY;
        private byte _dim; // Combined DimY (bits 4-7) and DimX (bits 0-3)
        private byte _flags;
        private byte _textEntry;
        private byte _flySpot;
        private uint _padding;
        private byte _orangeBaseX;
        private byte _orangeBaseY;
        private byte _orangeDimX;
        private byte _orangeDimY;

        [DisplayName("Map Header")]
        public ushort MapHeader
        {
            get => _mapHeader;
            set
            {
                _mapHeader = value;
                OnPropertyChanged(nameof(MapHeader));
            }
        }

        [DisplayName("Base X")]
        public byte BaseX
        {
            get => _baseX;
            set
            {
                _baseX = value;
                OnPropertyChanged(nameof(BaseX));
            }
        }

        [DisplayName("Base Y")]
        public byte BaseY
        {
            get => _baseY;
            set
            {
                _baseY = value;
                OnPropertyChanged(nameof(BaseY));
            }
        }

        [DisplayName("Dim Y")]
        public byte DimY
        {
            get => (byte)(_dim >> 4);
            set
            {
                _dim = (byte)((value << 4) | DimX);
                OnPropertyChanged(nameof(DimY));
                OnPropertyChanged(nameof(Dim));
                OnPropertyChanged(nameof(DimDisplay));
            }
        }

        [DisplayName("Dim X")]
        public byte DimX
        {
            get => (byte)(_dim & 0x0F);
            set
            {
                _dim = (byte)((DimY << 4) | value);
                OnPropertyChanged(nameof(DimX));
                OnPropertyChanged(nameof(Dim));
                OnPropertyChanged(nameof(DimDisplay));
            }
        }

        [Browsable(false)]
        public byte Dim
        {
            get => _dim;
            set
            {
                _dim = value;
                OnPropertyChanged(nameof(Dim));
                OnPropertyChanged(nameof(DimY));
                OnPropertyChanged(nameof(DimX));
                OnPropertyChanged(nameof(DimDisplay));
            }
        }

        [DisplayName("Flags")]
        public byte Flags
        {
            get => _flags;
            set
            {
                _flags = value;
                OnPropertyChanged(nameof(Flags));
            }
        }

        [DisplayName("Text Entry")]
        public byte TextEntry
        {
            get => _textEntry;
            set
            {
                _textEntry = value;
                OnPropertyChanged(nameof(TextEntry));
            }
        }

        [DisplayName("Fly Spot")]
        public byte FlySpot
        {
            get => _flySpot;
            set
            {
                _flySpot = value;
                OnPropertyChanged(nameof(FlySpot));
            }
        }

        [Browsable(false)]
        public uint Padding
        {
            get => _padding;
            set
            {
                _padding = value;
                OnPropertyChanged(nameof(Padding));
            }
        }

        [DisplayName("Orange Base X")]
        public byte OrangeBaseX
        {
            get => _orangeBaseX;
            set
            {
                _orangeBaseX = value;
                OnPropertyChanged(nameof(OrangeBaseX));
            }
        }

        [DisplayName("Orange Base Y")]
        public byte OrangeBaseY
        {
            get => _orangeBaseY;
            set
            {
                _orangeBaseY = value;
                OnPropertyChanged(nameof(OrangeBaseY));
            }
        }

        [DisplayName("Orange Dim X")]
        public byte OrangeDimX
        {
            get => _orangeDimX;
            set
            {
                _orangeDimX = value;
                OnPropertyChanged(nameof(OrangeDimX));
            }
        }

        [DisplayName("Orange Dim Y")]
        public byte OrangeDimY
        {
            get => _orangeDimY;
            set
            {
                _orangeDimY = value;
                OnPropertyChanged(nameof(OrangeDimY));
            }
        }

        [Browsable(false)]
        public string DimDisplay => $"{DimY}:{DimX}";

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}