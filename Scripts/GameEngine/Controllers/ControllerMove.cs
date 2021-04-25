using UnityEngine;

namespace GameEngine3D
{
    internal sealed class ControllerMove
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rb"> ������ Rigidbody</param>
        /// <param name="acceleration">��������� �����������</param>
        /// <returns></returns>
        public bool Move(Vector3 direction, Rigidbody rb, int acceleration, float deltaTime)
        {
            // ����� �� ����� � ������������, � ���������� ���������� �������� ������
            // �� ���� ������ ��� �������. ���������� ����� - ������ ���� ��������� �������� ���������.

            //rb.AddRelativeForce(s * acceleration * rb.mass * 10, ForceMode.Impulse);
            rb.AddRelativeForce(direction.normalized * rb.mass * (1 + acceleration) * 8 * deltaTime, ForceMode.Impulse);


            // �������� ���������
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

