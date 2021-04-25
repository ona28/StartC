using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameEngine3D
{
    public sealed class ViewEnemy : MonoBehaviour, IEnemy
    {
        [SerializeField] private Animator _anim = null;
        [SerializeField] private GameObject lineHP = null;

        private Image _imageHP = null;

        public event Action<string> OnCollisionEnterChangeEnemy;

        private void Start()
        {
            _imageHP = lineHP.GetComponent<Image>();
            _imageHP.enabled = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            OnCollisionEnterChangeEnemy?.Invoke(collision.gameObject.tag);
        }

        public void Move(bool isMove)
        {
            _anim.SetBool("IsMove", isMove);
        }

        public void ChangeHealth(int hp)
        {
            if (!_imageHP.enabled) _imageHP.enabled = true;
            float s = Convert.ToSingle(hp) / Convert.ToSingle(100);
            _imageHP.fillAmount = s;

            if (hp <= 0) Death();
        }

        public void Death()
        {
            _anim.SetTrigger("IsDie");
            //Destroy(gameObject, 1);
            gameObject.SetActive(false);
        }
    }
}