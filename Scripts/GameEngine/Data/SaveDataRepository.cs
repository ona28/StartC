using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace GameEngine3D
{
    public sealed class SaveDataRepository: ISaveDataRepository
    {
        private readonly IData<SaveData> _data;

        private const string _nameFolder = "DataSave";
        private const string _nameFile = "data.xml";
        private readonly string _path;

        public SaveDataRepository()
        {
            _data = new XMLData<SaveData>();
            _path = Path.Combine(Application.dataPath, _nameFolder);
            //_path = Path.Combine(Application.persistentDataPath, _nameFolder);
        }

        public void Save()
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }

            // дописать что сохранить
            // ....
            var saveData = new SaveData
            {
                Name = "proba",
                Position = Vector3.zero,
                IsEnabled = true
            };

            _data.Save(saveData, Path.Combine(_path, _nameFile));
        }

        public void Load()
        {
            var file = Path.Combine(_path, _nameFile);
            if (!File.Exists(file)) return;
            var newData = _data.Load(_path);

            // загрузка из сохранения
            // ....
        }
    }
}
