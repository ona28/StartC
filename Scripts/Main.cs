using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private ParalaxView _paralaxView1;
        [SerializeField] private ParalaxView _paralaxView2;

        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        [SerializeField] private SpriteAnimatorConfig _enemyConfig;

        [SerializeField] private int _animationSpeed = 10;
        [SerializeField] private PlayerView _playerView;        

        // надо спавнить
        [SerializeField] private EnemyView _enemyView;

        private SpriteAnimatorController _playerAnimator;
        private SpriteAnimatorController _enemyAnimator;

        private PlayerController _playerController;
        private ParalaxController _prlxCtrl1;
        private ParalaxController _prlxCtrl2;
        private Camera _cam;

        private void Awake()
        {
            _cam = Camera.main;

            _prlxCtrl1 = new ParalaxController(_paralaxView1, 0.3f, ref _cam);
            _prlxCtrl2 = new ParalaxController(_paralaxView2, 0.18f, ref _cam);

            _playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");
            _playerAnimator = new SpriteAnimatorController(_playerConfig);
            _playerController = new PlayerController(_playerView, _playerAnimator);

            _enemyConfig = Resources.Load<SpriteAnimatorConfig>("EnemyAnimCfg");
            _enemyAnimator = new SpriteAnimatorController(_enemyConfig);
            _enemyAnimator.StartAnimation(_enemyView._spriteRenderer, "Enemy1", AnimState.Forward, true, _animationSpeed);
        }

        private void Update()
        {
            // clouds
            _prlxCtrl1.Update();
            _prlxCtrl2.Update();

            // player
            _playerController.Update();
            _enemyAnimator.Update();
        }

        private void FixedUpdate()
        {
            
        }
    }
}
