using UnityEngine;

namespace GameEngine3D
{
    internal sealed class ControllerMove
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rb"> объект Rigidbody</param>
        /// <param name="acceleration">ускорение перемещения</param>
        /// <returns></returns>
        public bool Move(Rigidbody rb, int acceleration)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 s = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;
            rb.AddRelativeForce(s * acceleration * rb.mass * 30, ForceMode.Force);


            // проверка состояния
            if (s != Vector3.zero)
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

