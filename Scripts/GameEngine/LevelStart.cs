using System.Collections.Generic;
using UnityEngine;
using GameEngine3D;

namespace GameEngine3D
{

    public class LevelStart : MonoBehaviour
    {
        [SerializeField]  private GameObject Enemy = null;
        private GameObject[] Enemes = new GameObject[0];
        private GameObject exitLevel = null;

        private Controllers _controllers;

        private void SpawnEnemy()
        {
            GameObject[] gameObjects;
            gameObjects = GameObject.FindGameObjectsWithTag("EnemyPosition");

            foreach (GameObject @object in gameObjects)
            {
                _ = Instantiate(Enemy, @object.transform, false);                
            }

            Enemes = GameObject.FindGameObjectsWithTag("Enemy");
            exitLevel = GameObject.FindGameObjectWithTag("LevelExit");
            exitLevel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

        #region Init
        private void Awake()
        {
            _controllers = new Controllers();
            _ = new LevelInit(_controllers);
            SpawnEnemy();

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


        #region Trigger
        private void OnTriggerEnter(Collider other)
        {
            
        }
              
        private void OnTriggerStay(Collider other)
        {
            
        }

        private void OnTriggerExit(Collider other)
        {

        }
        #endregion


        #region Collision
        private void OnCollisionEnter(Collision collision)
        {
            
        }

        private void OnCollisionStay(Collision collision)
        {
            
        }

        private void OnCollisionExit(Collision collision)
        {
            
        }
        #endregion
    }
}
