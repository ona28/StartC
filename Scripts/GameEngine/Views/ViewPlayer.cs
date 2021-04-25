using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameEngine3D
{
    public class ViewPlayer : MonoBehaviour
    {
        [SerializeField] private Text textHP = null;
        [SerializeField] private AudioClip clipFire = null;
        [SerializeField] private AudioClip clipStep = null;
        [SerializeField] private GameObject bullet = null;
        [SerializeField] private Transform bulletStartPosition;

        public event Action<string> OnCollisionEnterChange;

        private Animator _anim = null;
        private AudioSource _clip = null;

        private void Start()
        {
            _anim = GetComponent<Animator>();
            _clip = GetComponent<AudioSource>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            OnCollisionEnterChange?.Invoke(collision.gameObject.tag);
        }

        public void Changehealth(float health)
        {
            textHP.text = health.ToString();
        }

        public void Death()
        {
            _anim.SetTrigger("IsDie");
        }

        public void Move(bool isMove, int acceleration, bool onFloor)
        {
            if (isMove && onFloor)
            {
                _anim.SetFloat("SpeedMove", acceleration);
                _anim.SetBool("IsMove", true);
            }
            else
            {
                _anim.SetFloat("SpeedMove", 0);
                _anim.SetBool("IsMove", false);
            }
        }

        public void Fire()
        {        
            var bul = Instantiate(bullet, bulletStartPosition.position, transform.rotation).GetComponent<Bullet>();
            bul.Init(name); // временно старый код

            _clip.PlayOneShot(clipFire, 0.2f);
        }

        public void Jump()
        { 
        }

        private void PlaySoundsMove()
        {
            _clip.Stop();         
            _clip.PlayOneShot(clipStep, 1f);
        }

        private void PlaySoundIdle()
        {
            _clip.Stop();
        }
    }
}