using UnityEngine;

namespace Platformer2D
{
    public class CameraController
    {
        private float X;
        private float Y;

        float xMin;
        float xMax;
        float yMin;
        float yMax;

        private float offsetX = 0f;
        private float offsetY = 0f;

        private int camSpeed = 150;

        private Transform _playerTransform;
        private Transform _cameraTransform;

        public CameraController(Transform player, Transform cam, (float, float, float, float) limScreen)
        {
            _playerTransform = player;
            _cameraTransform = cam;

            xMin = limScreen.Item1;
            xMax = limScreen.Item2;
            yMin = limScreen.Item3;
            yMax = limScreen.Item4;
        }

        public void Update()
        {
            X = _playerTransform.position.x;
            Y = _playerTransform.position.y;

            _cameraTransform.position = Vector3.Lerp(_cameraTransform.position,
                                        new Vector3(X + offsetX, Y + offsetY,
                                        _cameraTransform.position.z),
                                        Time.deltaTime * camSpeed);
        }
    }
}
