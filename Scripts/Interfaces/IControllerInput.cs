using System;
using UnityEngine;

namespace Boxes
{
    public interface IControllerInput
    {
        public event Action<Vector3, float> Move;
        public event Action Stop;
        public event Action<int> ChangeSpeed;
        public event Action<float> Rotate;
        public event Action Fire;
        public event Action Jump;
        public event Action PauseGame;
    }
}