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
            rb.AddRelativeForce(direction * acceleration * rb.mass * 50 * deltaTime, ForceMode.Acceleration);


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

