using System;
using UnityEngine;

namespace Boxes
{
    internal sealed class ControllerBase : IFixUpdate, IEnable, IDisable
    {
        private Vector3 _eulerAngleVelocity = Vector3.zero;
        private readonly Rigidbody _rbBase;

        private ViewBase _viewBase;
        private IControllerInput _ctrInput;
  
        private ControllerRotate _ctrRotate = new ControllerRotate();

        public ControllerBase(ViewBase viewBase, IControllerInput inputController)
        {
            _rbBase = viewBase.GetComponent<Rigidbody>();

            _viewBase = viewBase;
            _ctrInput = inputController;
        }
      
        private void Rotate(float mouseX)
        {
            if (mouseX <= 0.3 && mouseX >= -0.3)
                _eulerAngleVelocity.Set(0, 0, 0);
            else
                _eulerAngleVelocity.Set(0, mouseX * 50, 0);
        }

        public void Enable()
        {
            _ctrInput.Rotate += Rotate;
        }

        public void Disable()
        {
            _ctrInput.Rotate -= Rotate;
        }

        public void FixUpdate(float deltaTime)
        {
            Quaternion deltaRotation = Quaternion.Euler(_eulerAngleVelocity * deltaTime);
            _ctrRotate.Rotate(_rbBase, deltaRotation);
        }
    }
}

