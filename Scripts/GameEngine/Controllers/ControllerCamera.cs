using UnityEngine;

namespace GameEngine3D
{
    internal sealed class ControllerCamera : ILateUpdate
    {
        private readonly Transform _player;
        private readonly Transform _camera;
        private readonly Vector3 _offset;
        private readonly float _rotateSpeed = 5f;

        public ControllerCamera(Transform player, Transform camera)
        {
            _player = player;
            _camera = camera;
            _offset = _player.position - _camera.position;
        }

        public void LateUpdate(float deltaTime)
        {
            float horizontal = Input.GetAxis("Mouse X") * _rotateSpeed;

            float desiredAngle = _player.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
            _camera.position = _player.position - (rotation * _offset);

            Vector3 off = new Vector3(-15, 0, 0);
            _camera.LookAt(_player.transform);
            _camera.Rotate(off);
        }
    }
}


