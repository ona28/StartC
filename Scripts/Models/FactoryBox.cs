using UnityEngine;

namespace Boxes
{
    public sealed class FactoryBox : IFactoryBox
    {
        private readonly DataBox _data;

        public FactoryBox(DataBox data)
        {
            _data = data;
        }

        public IBox CreateObject(TypeBox type, Vector3 position, Quaternion qua)
        {
            var objView = _data.GetBox(type);
            return Object.Instantiate(objView, position, qua);
        }
    }
}
