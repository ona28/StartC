using UnityEngine;

namespace GameEngine3D
{
    internal sealed class ControllerMove
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rb"> объект Rigidbody</param>
        /// <param name="acceleration">ускорение перемещени€</param>
        /// <returns></returns>
        public bool Move(Vector3 direction, Rigidbody rb, int acceleration, float deltaTime)
        {
            // кака€ то шл€па с перемещением, с включенным аниматором скорость меньше
            // не знаю отчего это зависит. магическое число - просто тупо подбирала скорость визуально.

            //rb.AddRelativeForce(s * acceleration * rb.mass * 10, ForceMode.Impulse);
            rb.AddRelativeForce(direction.normalized * rb.mass * (1 + acceleration) * 8 * deltaTime, ForceMode.Impulse);


            // проверка состо€ни€
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

