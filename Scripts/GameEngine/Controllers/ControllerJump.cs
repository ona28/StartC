using UnityEngine;

namespace GameEngine3D
{
    internal sealed class ControllerJump
    {
        public void Jump(Rigidbody _rb, float _force)
        {
            _rb.AddForce(Vector3.up * _force, ForceMode.Impulse);
        }

        public bool CheckOnFloor(Vector3 itemPosition)
        {
            if (Physics.Raycast(itemPosition, Vector3.down, 0.4f))
                return true;
            else
                return false;
        }
    }
}

