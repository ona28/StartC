using System;
using UnityEngine;

namespace GameEngine3D
{
    internal sealed class ControllerPlayer : IAwake, IUpdate, IFixUpdate, IEnable, IDisable
    {
        private int _acceleration = 1;   // ускорение бег

        private bool _fire = false;
        private bool _jump = false;
        private bool _boom = false;
        private bool _isMove = false;
        private bool _onFloor = true;
        private bool _isAlive = true;

        private readonly Rigidbody _rb;
        private readonly Transform _player;

        private ViewPlayer _playerView;
        private ModelPlayer _playerModel;

        private ControllerMove _ctrMove = new ControllerMove();
        private ControllerRotate _ctrRotate = new ControllerRotate();


        public ControllerPlayer(ModelPlayer modelPlayer, ViewPlayer viewPlayer)
        {
            _player = viewPlayer.GetComponent<Transform>() ?? null; ;
            _rb = viewPlayer.GetComponent<Rigidbody>() ?? null;

            _playerView = viewPlayer;
            _playerModel = modelPlayer;
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

        public void Enable()
        {
            
        }

        public void Disable()
        {
            _playerModel.Death -= Death;
            _playerModel.ChangedHealth -= ChangeHealth;
        }

        public void Awake()
        {
            _playerModel.Death += Death;
            _playerModel.ChangedHealth += ChangeHealth;
        }

        public void Update(float deltaTime)
        {
            if (!_isAlive) return;

            if (Input.GetMouseButtonDown(0)) _fire = true;
            if (Input.GetKeyDown(KeyCode.Space)) _jump = true;
            if (Input.GetKeyDown(KeyCode.F)) _boom = true;

            if (!Input.GetKey(KeyCode.LeftShift)) _acceleration = 3;  // всегда бежит, с Shift - ходит
            else _acceleration = 1;

            // вращение
            float MouseX = Input.GetAxis("Mouse X");
            if (MouseX != 0)
            {
                _ctrRotate.Rotate(_player, MouseX, 4f);
            }
        }

        public void FixUpdate(float deltaTime)
        {
            if (!_isAlive) return;

            // проверка на полу игрок или нет
            if (Physics.Raycast(_player.position, Vector3.down, 0.4f))
            {
                _onFloor = true;
            }
            else
            {
                _onFloor = false;
            }

            _isMove = _ctrMove.Move(_rb, _acceleration);
            //if (_jump && _onFloor) Jump();
            //if (_fire) Fire();            
            //if (_boom) Boom();
        }

    }
}

