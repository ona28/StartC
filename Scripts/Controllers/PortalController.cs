using UnityEngine;

namespace Platformer2D
{
    public sealed class PortalController
    {
        private PortalView _view;
        private Vector3 _dirVector = new Vector3(0,0,1);
        private float _minScale = 0.8f;
        private float _delta = 0.001f;
        private int _k = 1;

        private float _angleRotate = -10f;

        public PortalController(PortalView view)
        {
            _view = view;
        }

        public void Update()
        {
            _view._transform.Rotate(_dirVector, Time.deltaTime * _angleRotate);
                   

            if (_view._transform.localScale.x <= _minScale)
                _k = -1;
            else if (_view._transform.localScale.x >= 1f)
                _k = 1;

            _view._transform.localScale = new Vector3(_view._transform.localScale.x - _delta * _k, _view._transform.localScale.y  - _delta *_k, 1);
        }

        private void TriggerEnterChange(Transform _object, int _direction)
        {
            Transform portal;

            if (_direction > 0)
                portal = GameObject.Find("Exit").transform;
            else
                portal = GameObject.Find("Enter").transform;

            _object.position = new Vector3(portal.position.x - 0.4f * _direction, portal.position.y + 0.2f, 0);
        }


        public void Enable()
        {
            _view.OnTriggerEnterChange += TriggerEnterChange;
        }

        public void Disable()
        {
            _view.OnTriggerEnterChange -= TriggerEnterChange;
        }
    }
}
