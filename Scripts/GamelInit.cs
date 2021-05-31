using UnityEngine;

namespace Boxes
{
    internal sealed class GameInit
    {
        public GameInit(Controllers controllers, Data data)
        {
            Camera camera = Camera.main;
            IControllerInput inputController = new ControllerInputPC();

            GameObject _base = GameObject.FindGameObjectWithTag("Base");
            ViewBase viewBase = _base.GetComponent<ViewBase>();

            controllers.Add((IController) inputController);
            controllers.Add(new ControllerBase(viewBase, inputController));
            controllers.Add(new ControllerGame(in controllers, inputController, data));                       
        }
    }
}