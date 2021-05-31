using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boxes
{
    public sealed class InitBoxes
    {
        private readonly IFactoryBox _factoryBox;
        private ControllerBox _ctrlBox;
        private TypeBox _typeBox = TypeBox.None;
        private DataBox _dataBox;

        public InitBoxes(in Controllers controllers, IFactoryBox factoryBox, DataBox dataBox)
        {
            _factoryBox = factoryBox;
            _dataBox = dataBox;
        }

        public ViewBox SpawnBox(in Controllers controllers, IControllerInput inputPC)
        {
            GameObject gameObject = GameObject.Find("StartBoxPosition");
            int ind = Random.Range(1, 5);

            _typeBox = (TypeBox)ind;

            return _factoryBox.CreateObject(_typeBox, gameObject.transform.position, Quaternion.identity) as ViewBox;
        }
    }
}
