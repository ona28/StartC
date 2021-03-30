using UnityEngine;

namespace GameEngine3D
{
    public class ViewPlayer : MonoBehaviour
    {
        public void Changehealth(float health)
        {
            //вывод в ui
        }

        public void Death()
        {
            //анимация смерти
            Debug.Log("Игрок умер (:");
        }
    }
}