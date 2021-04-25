using UnityEngine;

namespace GameEngine3D
{
    internal sealed class LevelInit
    {
        public LevelInit(Controllers controllers, Data data)
        {
            Camera camera = Camera.main;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            ViewPlayer viewPlayer = player.GetComponent<ViewPlayer>();
            ModelPlayer modelPlayer = new ModelPlayer();
            ControllerInputPC inputController = new ControllerInputPC();
            var factoryEnemy = new FactoryEnemy(data.Enemy);

            controllers.Add(inputController);
            controllers.Add(new ControllerGame(inputController));
            controllers.Add(new ControllerCamera(player.transform, camera.transform));
            controllers.Add(new ControllerPlayer(modelPlayer, viewPlayer, inputController));

            _ = new InitEnemy(in controllers, player, factoryEnemy, data.Enemy);
        }
    }
}