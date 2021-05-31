using UnityEngine;

namespace Boxes
{
    public sealed class ControllerGame : IEnable, IDisable
    {
        private readonly FactoryBox _factoryBox;
        private readonly Data _data;
        private readonly IControllerInput _ctrlinput;        
        private readonly Controllers _controllers;
        private readonly ControllerBox _ctrlBox;

        public ControllerGame(in Controllers controllers, IControllerInput inputController, Data data)
        {
            _data = data;
            _ctrlinput = inputController;
            _factoryBox = new FactoryBox(data.Box);
            _controllers = controllers;

            _ctrlBox = new ControllerBox(inputController);

            controllers.Add(_ctrlBox);
            SpawnBox();
        }

        private void SpawnBox()
        {
            var obj = new InitBoxes(in _controllers, _factoryBox, _data.Box);
            ViewBox _vb = obj.SpawnBox(in _controllers, _ctrlinput);
            _ctrlBox.InitCtrl(_vb);
        }

        public void Enable()
        {
            _ctrlBox.SpawnBox += SpawnBox;
        }

        public void Disable()
        {
            _ctrlBox.SpawnBox -= SpawnBox;
        }
    }
}
