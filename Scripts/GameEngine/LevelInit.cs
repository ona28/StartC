using UnityEngine;

namespace GameEngine3D
{
    internal sealed class LevelInit
    {
        public LevelInit(Controllers controllers)
        {
            Camera camera = Camera.main;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            var viewPlayer = player.GetComponent<ViewPlayer>();
            ModelPlayer modelPlayer = new ModelPlayer();

            controllers.Add(new ControllerCamera(player.transform, camera.transform));
            controllers.Add(new ControllerPlayer(modelPlayer, viewPlayer));
        }
    }
}