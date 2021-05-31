using System.Collections.Generic;
using UnityEngine;

namespace Boxes
{
    public class GameStart : MonoBehaviour
    {
        [SerializeField] private Data _data;
        private Controllers _controllers;

        #region Init
        private void Awake()
        {
            _controllers = new Controllers();
            _ = new GameInit(_controllers, _data);

            _controllers.Awake();            
        }

        private void Start()
        {
            _controllers.Start();
        }
        #endregion


        #region Update
        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Update(deltaTime);
        }

        private void FixedUpdate()
        {
            var deltaTime = Time.fixedDeltaTime;
            _controllers.FixUpdate(deltaTime);
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllers.LateUpdate(deltaTime);
        }
        #endregion


        #region EnableDisable
        private void OnEnable()
        {
            _controllers.Enable();
        }

        private void OnDisable()
        {
            _controllers.Disable();
        }
        #endregion
    }
}
