using System;
using System.ComponentModel;

namespace Main.Models
{
    public class FlyRespawnPosition : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private byte _flySpot;
        private byte _flags;
        private ushort _mapHeader;
        private byte _x;
        private byte _y;
        private ushort _fieldId;
        private ushort _fieldCoordX;
        private ushort _fieldCoordY;
        private ushort _fieldId2;
        private ushort _fieldCoordX2;
        private ushort _fieldCoordY2;

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

        [DisplayName("X")]
        public byte X
        {
            get => _x;
            set
            {
                _x = value;
                OnPropertyChanged(nameof(X));
            }
        }

        [DisplayName("Y")]
        public byte Y
        {
            get => _y;
            set
            {
                _y = value;
                OnPropertyChanged(nameof(Y));
            }
        }

        [DisplayName("Field ID")]
        public ushort FieldId
        {
            get => _fieldId;
            set
            {
                _fieldId = value;
                OnPropertyChanged(nameof(FieldId));
            }
        }

        [DisplayName("Field X")]
        public ushort FieldCoordX
        {
            get => _fieldCoordX;
            set
            {
                _fieldCoordX = value;
                OnPropertyChanged(nameof(FieldCoordX));
            }
        }

        [DisplayName("Field Y")]
        public ushort FieldCoordY
        {
            get => _fieldCoordY;
            set
            {
                _fieldCoordY = value;
                OnPropertyChanged(nameof(FieldCoordY));
            }
        }

        [DisplayName("Field ID 2")]
        public ushort FieldId2
        {
            get => _fieldId2;
            set
            {
                _fieldId2 = value;
                OnPropertyChanged(nameof(FieldId2));
            }
        }

        [DisplayName("Field X 2")]
        public ushort FieldCoordX2
        {
            get => _fieldCoordX2;
            set
            {
                _fieldCoordX2 = value;
                OnPropertyChanged(nameof(FieldCoordX2));
            }
        }

        [DisplayName("Field Y 2")]
        public ushort FieldCoordY2
        {
            get => _fieldCoordY2;
            set
            {
                _fieldCoordY2 = value;
                OnPropertyChanged(nameof(FieldCoordY2));
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}