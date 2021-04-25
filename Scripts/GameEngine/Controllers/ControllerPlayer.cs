using System;
using UnityEngine;

namespace GameEngine3D
{
    internal sealed class ControllerPlayer : IFixUpdate, IEnable, IDisable
    {
        private int _acceleration = 1;
        private float _forceJump = 30f;

        private bool _onFloor = true;
        private bool _isAlive = true;
        private bool _isMove = false;
        private bool _fire = false;

        private readonly Rigidbody _rb;
        private readonly Transform _player;

        private ViewPlayer _playerView;
        private ModelPlayer _playerModel;
        private ControllerInputPC _ctrInput;

        private ControllerMove _ctrMove = new ControllerMove();
        private ControllerRotate _ctrRotate = new ControllerRotate();
        private ControllerJump _ctrJump = new ControllerJump();


        public ControllerPlayer(ModelPlayer modelPlayer, ViewPlayer viewPlayer, ControllerInputPC inputController)
        {
            _player = viewPlayer.GetComponent<Transform>();
            _rb = viewPlayer.GetComponent<Rigidbody>();

            _playerView = viewPlayer;
            _playerModel = modelPlayer;
            _ctrInput = inputController;
        }

        private void ChangeHealth(int health)
        {
            _playerView.Changehealth(health);
        }

        private void Death()
        {
            _isAlive = false;
            _playerView.Death();
            Disable();
        }

        private void CollisionEnterChange(string tag)
        {
            if (tag == "Enemy")
                _playerModel.SetNewHealth(10);
        }

        #region PlayerAction
        private void Move(Vector3 direction, float deltaTime)
        {
            _isMove = _ctrMove.Move(direction, _rb, _acceleration, deltaTime);
        }

        private void Stop()
        {
            _isMove = false;
        }

        private void ChangeSpeed(int acceleration)
        {
            _acceleration = acceleration;
        }

        private void Rotate(float mouseX)
        {
            _ctrRotate.Rotate(_player, mouseX, 4f);
        }

        private void Jump()
        {
            if (_onFloor) _ctrJump.Jump(_rb, _forceJump);
            _playerView.Jump();
        }

        private void Fire()
        {
            _fire = true;           
        }
        #endregion

        public void Enable()
        {
            _playerModel.Death += Death;
            _playerModel.ChangedHealth += ChangeHealth;
            _playerView.OnCollisionEnterChange += CollisionEnterChange;
            _ctrInput.Move += Move;
            _ctrInput.Stop += Stop;
            _ctrInput.ChangeSpeed += ChangeSpeed;
            _ctrInput.Rotate += Rotate;
            _ctrInput.Fire += Fire;
            _ctrInput.Jump += Jump;
        }

        public void Disable()
        {
            _playerModel.Death -= Death;
            _playerModel.ChangedHealth -= ChangeHealth;
            _playerView.OnCollisionEnterChange -= CollisionEnterChange;
            _ctrInput.Move -= Move;
            _ctrInput.Stop -= Stop;
            _ctrInput.ChangeSpeed -= ChangeSpeed;
            _ctrInput.Rotate -= Rotate;
            _ctrInput.Fire -= Fire;
            _ctrInput.Jump -= Jump;
        }
         
        public void FixUpdate(float deltaTime)
        {
            if (!_isAlive) return;

            _onFloor = _ctrJump.CheckOnFloor(_player.position);
            _playerView.Move(_isMove, _acceleration, _onFloor);
            
            
            int bulls = 1;
            if (bulls == 0) return;

            if (_fire)
            {
                _fire = false;
                _playerView.Fire();                
            }
        }
    }
}

