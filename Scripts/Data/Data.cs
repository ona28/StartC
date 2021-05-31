using System.IO;
using UnityEngine;

namespace Boxes
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public sealed class Data : ScriptableObject
    {
        [SerializeField] private string _boxDataPath;
        private DataBox _box;

        public DataBox Box
        {
            get
            {
                if (_box == null)
                {
                    _box = Load<DataBox>("Data/" + _boxDataPath);
                }

                return _box;
            }
        }

        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}