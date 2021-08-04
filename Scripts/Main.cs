using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private ParalaxView _paralaxView1;
        [SerializeField] private ParalaxView _paralaxView2;
        [SerializeField] private ParalaxView _paralaxView3;
        [SerializeField] private ParalaxView _paralaxView4;

        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        [SerializeField] private SpriteAnimatorConfig _enemyConfig;
        [SerializeField] private SpriteAnimatorConfig _bonusConfig;

        [SerializeField] private int _animationSpeed = 10;
        [SerializeField] private PlayerView _playerView;

        private List<IUpdate> _updateControllers = new List<IUpdate>();

        // надо спавнить
        [SerializeField] private EnemyView _enemyView;

        private SpriteAnimatorController _playerAnimator;
        private SpriteAnimatorController _enemyAnimator;

        private CameraController _cameraController;
        private PlayerController _playerController;

        private ParalaxController _prlxCtrl1;
        private ParalaxController _prlxCtrl2;
        private ParalaxController _prlxCtrl3;
        private ParalaxController _prlxCtrl4;

        private PortalController _ctrlEnter;
        private PortalController _ctrlExit;

        private Camera _cam;

        private void Awake()
        {
            _cam = Camera.main;                

            (float, float, float, float) _limScreen = FindMinMaxPointsScreen();

            // clouds
            GameObject sky = GameObject.FindWithTag("sky");
            _prlxCtrl1 = new ParalaxController(_paralaxView1, 0.3f, ref _cam);
            _prlxCtrl2 = new ParalaxController(_paralaxView2, 0.18f, ref _cam);
            _prlxCtrl3 = new ParalaxController(_paralaxView3, 0.25f, ref _cam);
            _prlxCtrl4 = new ParalaxController(_paralaxView4, 0.12f, ref _cam);
            _updateControllers.Add(_prlxCtrl1);
            _updateControllers.Add(_prlxCtrl2);
            _updateControllers.Add(_prlxCtrl3);
            _updateControllers.Add(_prlxCtrl4);

            // player
            _playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");
            _playerAnimator = new SpriteAnimatorController(_playerConfig);
            _playerController = new PlayerController(_playerView, _playerAnimator);                        
            _updateControllers.Add(_playerController);

            // camera
            _cameraController = new CameraController(_playerView._transform, _cam.transform, _limScreen);
            _updateControllers.Add(_cameraController);
            
            // enter-exit
            GameObject _enter = GameObject.Find("Enter");
            GameObject _exit = GameObject.Find("Exit");
            _ctrlEnter = new PortalController(_enter.GetComponent<PortalView>());
            _ctrlExit = new PortalController(_exit.GetComponent<PortalView>());            
            _updateControllers.Add(_ctrlEnter);
            _updateControllers.Add(_ctrlExit);

            // enemies
            LoadEnemies();

            // bonuses
            LoadBonuses();

            // lifts
            LoadLifts();
        }

        private void LoadEnemies()
        {
            _enemyConfig = Resources.Load<SpriteAnimatorConfig>("EnemyAnimCfg");
            _enemyAnimator = new SpriteAnimatorController(_enemyConfig);
            _enemyAnimator.StartAnimation(_enemyView._spriteRenderer, "Enemy1", AnimState.Forward, true, _animationSpeed);
            _updateControllers.Add(_enemyAnimator);
        }

        private void LoadLifts()
        {
            GameObject[] _lifts = GameObject.FindGameObjectsWithTag("Lift");

            foreach (GameObject _lift in _lifts)
            {
                _updateControllers.Add(new LiftCotroller(_lift.transform, _lift.GetComponent<LiftView>()));
            }
        }

        private void LoadBonuses()
        {
            _bonusConfig = Resources.Load<SpriteAnimatorConfig>("BonusAnimCfg");

            GameObject[] _bonuses = GameObject.FindGameObjectsWithTag("Bonus");

            foreach (GameObject _bonus in _bonuses)
            {
                _updateControllers.Add(new BonusControllers(_bonusConfig, _bonus.GetComponent<BonusView>()));
            }
        }

        private (float, float, float, float) FindMinMaxPointsScreen()
        {
            float xMin = 0f;
            float xMax = 0f;
            float yMin = 0f;
            float yMax = 0f;

            GameObject[] _obects = GameObject.FindGameObjectsWithTag("Level");

            foreach (GameObject obj in _obects)
            {
                Vector3 tr = obj.transform.position;
                Vector2 rnd = obj.GetComponent<SpriteRenderer>().size;

                if (tr.x - rnd.x/2 < xMin) xMin = tr.x - rnd.x / 2;
                if (tr.x + rnd.x / 2 > xMax) xMax = tr.x + rnd.x / 2;
                if (tr.y - rnd.y / 2 < yMin) yMin = tr.y - rnd.y / 2;
                if (tr.y + rnd.y / 2 > yMax) yMax = tr.y + rnd.y / 2;
            }
            //Debug.Log($"  {xMin}  {xMax}  {yMin}  {yMax}");

            return (xMin, xMax, yMin, yMax);
        }

        private void Update()
        {    
            for (var i = 0; i < _updateControllers.Count; i++)
            {
                _updateControllers[i].Update();
            }
        }

        private void FixedUpdate()
        {
            
        }

        private void OnEnable()
        {
            // enter-exit
            _ctrlEnter.Enable();
            _ctrlExit.Enable();
        }

        private void OnDisable()
        {
            // enter-exit
            _ctrlEnter.Disable();
            _ctrlExit.Disable();
        }

    }
}
