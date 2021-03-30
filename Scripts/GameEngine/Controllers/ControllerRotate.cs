using UnityEngine;

namespace GameEngine3D
{
    internal sealed class ControllerRotate
    {
        public void Rotate(Transform obj, float angle, float speed)
        {
            obj.Rotate(new Vector3(0, angle * speed, 0));
        }
    }
}
