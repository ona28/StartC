using System;
using UnityEngine;

namespace GameEngine3D
{
    internal sealed class ControllerInputPC : IUpdate
    {
        private Vector3 _direction = Vector3.zero;
        private int _acceleration = 4;

        public event Action<Vector3, float> Move;
        public event Action Stop;
        public event Action<int> ChangeSpeed;
        public event Action<float> Rotate;
        public event Action Fire;
        public event Action Jump;

        public void Update(float deltaTime)
        {
            // move
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            _direction.Set(moveHorizontal, 0.0f, moveVertical);
            if (_direction != Vector3.zero)
                Move?.Invoke(_direction, Time.deltaTime);
            else
                Stop?.Invoke();

            // change speed
            if (Input.GetKey(KeyCode.LeftShift))
                _acceleration = 1;
            else
                _acceleration = 4;
            ChangeSpeed?.Invoke(_acceleration);

            // rotate
            float mouseX = Input.GetAxis("Mouse X");
            if (mouseX != 0) Rotate?.Invoke(mouseX);

            // fire
            if (Input.GetMouseButtonDown(0))
                Fire?.Invoke();

            // jump
            if (Input.GetAxis("Jump") != 0)
                Jump?.Invoke();
        }        
    }

}