using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Data.Ids;
using Sources.Scripts.DomainInterfaces.Models.Entities;

namespace Sources.Scripts.Domain.Models.Settings
{
    public class Volume : IEntity
    {
        private int _audioVolume;
        
        public Volume(int audioVolume, string id)
        {
            _audioVolume = audioVolume;
            Id = id;
        }
        
        public event Action AudioVolumeChanged;
        
        public int AudioVolume
        {
            get => _audioVolume;
            set
            {
                _audioVolume = value;
                AudioVolumeChanged?.Invoke();
            }
        }

        public string Id { get; }
        public Type Type => GetType();
    }
}