using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.DomainInterfaces.Models.Entities;

namespace Sources.Scripts.Domain.Models.Settings
{
    public class Volume : IEntity
    {
        private VolumeData _data = new ();
        private int _audioVolume;
        
        public Volume(string id)
        {
            Id = id;
            _audioVolume = VolumeConst.BaseAudioValue;
        }
        
        public int AudioVolume
        {
            get => _audioVolume;
            set => _audioVolume = value;
        }

        public string Id { get; }

        public void Save()
        {
            _data.Id = Id;
            _data.AudioValue = _audioVolume;
            _data.Save(Id);
        }

        public void Load()
        {
            _data = _data.Load(Id);
            _audioVolume = _data.AudioValue;
        }
    }
}