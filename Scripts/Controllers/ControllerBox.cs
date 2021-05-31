using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boxes
{
    public sealed class ControllerBox: IFixUpdate, IEnable, IDisable
    {
        private bool _isMove = false;
        private bool _onFloor = false;

        private Rigidbody _rb;
        private Transform _tr;
        private ViewBox _viewBox;
        private readonly IControllerInput _ctrInput;

        private ControllerMove _ctrMove = new ControllerMove();

        public event Action SpawnBox;

        public ControllerBox(IControllerInput inputController)
        {
            _ctrInput = inputController;
        }

        public void InitCtrl(ViewBox viewBox)
        {
            _viewBox = viewBox;
            _rb = viewBox.GetComponent<Rigidbody>();
            _tr = viewBox.GetComponent<Transform>();

            SetRbParams(10f);
            _onFloor = false;
        }

        private void SetRbParams(float drag)
        {
            _rb.mass = 50f;
            _rb.drag = drag;
            _rb.angularDrag = drag;
        }

        private void Move(Vector3 direction, float deltaTime)
        {
            _isMove = _ctrMove.Move(direction, _tr, deltaTime);
        }

        private bool CheckOnFloor(Vector3 itemPosition)
        {
            RaycastHit hit;
            Ray ray = new Ray(itemPosition, Vector3.down);
            Physics.Raycast(ray, out hit, 0.175f);

            if (hit.collider != null)
                return true;
            else
                return false;
        }

        public void Enable()
        {
            _ctrInput.Move += Move;
        }

        public void Disable()
        {
            _ctrInput.Move -= Move;
        }


        public void FixUpdate(float deltaTime)
        {
            if (!_onFloor)
            {
                _onFloor = CheckOnFloor(_tr.position);
            }

            if (_onFloor)
            {
                SetRbParams(1f);
                _onFloor = false;                
                SpawnBox?.Invoke();
            }
        }
    }
}
