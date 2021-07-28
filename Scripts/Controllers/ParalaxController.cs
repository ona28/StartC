using UnityEngine;

namespace Platformer2D
{
    public class ParalaxController
    {
        private ParalaxView _paralaxView;
        private Vector3 _dist = Vector3.left;
        private Vector3 _point;
        private float _speed = 0;
        private Camera _cam;
        float _widthSprite;

        public ParalaxController(ParalaxView paralaxView, float speedAnimation, ref Camera cam)
        {
            _paralaxView = paralaxView;
            _speed = speedAnimation;

            _cam = cam;
            _widthSprite = _paralaxView._renderer.size.x;
        }
              
        public void Update()
        {           
            _point = _cam.WorldToViewportPoint(_paralaxView.transform.position + _dist * _widthSprite / 2);

            if (_point.y > 1f || _point.x > 1f)
            {
                _paralaxView._transform.position = new Vector3(_cam.ViewportToWorldPoint(Vector3.zero).x, 
                                                                _cam.transform.position.y + Random.Range(-3.0f, 3.0f),
                                                                0) + _dist * _widthSprite / 2;

                _paralaxView._renderer.flipX = !_paralaxView._renderer.flipX;
            }
            else
            {
                _paralaxView._transform.position -= _dist * Time.deltaTime * _speed;
            }
        }
    }
}
