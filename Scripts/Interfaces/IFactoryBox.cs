using UnityEngine;

namespace Boxes
{
    public interface IFactoryBox
    {
        public IBox CreateObject(TypeBox type, Vector3 position, Quaternion qua);
    }
}