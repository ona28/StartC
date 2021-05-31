using UnityEngine;

namespace Boxes
{
    internal sealed class ControllerRotate
    {
        public void Rotate(Rigidbody obj, Quaternion deltaRotation)
        { 
            obj.MoveRotation(obj.rotation * deltaRotation);
        }
    }
}
