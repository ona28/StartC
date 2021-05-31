using UnityEngine;

namespace Boxes
{
    internal sealed class ControllerMove
    {
        public bool Move(Vector3 direction, Transform tr, float deltaTime)
        {
            tr.Translate(direction * deltaTime, Space.World);

            // проверка состояния
            if (direction != Vector3.zero)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
