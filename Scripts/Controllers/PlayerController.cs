using UnityEngine;

namespace Platformer2D
{
    public class PlayerController : IUpdate
    {
        private float _xAxisInput;
        
        private float _walkSpeed = 70f;
        private float _animationSpeed = 10f;
        private float _movingTreshold = 0.1f;
       
        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);
       
        private bool isMoving;
        private bool _isJump;

        private float _jumpForce = 12f;
        private float _jumpTreshold = 1f;

        //private float _yVelocity = 0f;
        private float _xVelocity = 0f;

        private PlayerView _view;
        private SpriteAnimatorController _spriteAnimator;
        private readonly ContactPoller _contactPoller;


        public PlayerController(PlayerView player, SpriteAnimatorController animator)
        {
            _view = player;
            _spriteAnimator = animator;
            _spriteAnimator.StartAnimation(_view._spriteRenderer, "Player", AnimState.Idle, true, _animationSpeed);
            _contactPoller = new ContactPoller(_view._collider);
        }

        private void MoveTowards()
        {
            _xVelocity = _walkSpeed * Time.fixedDeltaTime * (_xAxisInput < 0 ? -1 : 1);
            _view._rigidbody.velocity = _view._rigidbody.velocity.Change(x: _xVelocity);
            _view._transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);
        }

        public void Update()
        {
            _spriteAnimator.Update();
            _contactPoller.Update();

            _xAxisInput = Input.GetAxis("Horizontal");
            _isJump = Input.GetAxis("Vertical") > 0;
            isMoving = Mathf.Abs(_xAxisInput) > _movingTreshold;


            if (isMoving)
            {
                MoveTowards();
            }

            if (_contactPoller.IsBottomContact)
            {
                _spriteAnimator.StartAnimation(_view._spriteRenderer, "Player", isMoving ? AnimState.Run : AnimState.Idle, true, _animationSpeed);


                if (_isJump && Mathf.Abs(_view._rigidbody.velocity.y) <= _jumpTreshold)
                {
                    _view._rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                }
            }
            else
            {
                if (Mathf.Abs(_view._rigidbody.velocity.y) > _jumpTreshold)
                {
                    _spriteAnimator.StartAnimation(_view._spriteRenderer, "Player", AnimState.Jump, true, _animationSpeed);
                }
            }
        }
    }
}
