using UnityEngine;
using UnityEngine.UI;

public class MyPlayer : MonoBehaviour, ITakeDamage, IAlive, ITakeBulls
{
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private GameObject bomb = null;
    [SerializeField] private Transform bulletStartPosition;
    [SerializeField] private Text textHP = null;
    [SerializeField] private Text textBulls = null;
    [SerializeField] private Text textBomb = null;
    [SerializeField] private AudioClip clipFire = null;
    [SerializeField] private AudioClip clipStep = null;
    [SerializeField] private AudioClip clipRun = null;

    private int hp = 100;
    private int bulls = 20; // кол-во патронов
    private int bombs = 3; // кол-во бомб
    private int acceleration = 1;
    private Rigidbody _rb = null;
    private bool _fire = false;
    private bool _jump = false;
    private bool _boom = false;
    private bool _isMove = false;
    private bool _onFloor = true;
    private Animator _anim = null;
    private AudioSource _clip = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _clip = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!IsAlive()) return;

        if (Input.GetMouseButtonDown(0)) _fire = true;
        if (Input.GetKeyDown(KeyCode.Space)) _jump = true;
        if (Input.GetKeyDown(KeyCode.F)) _boom = true;

        if (!Input.GetKey(KeyCode.LeftShift)) acceleration = 5;  // всегда бежит, с Shift - ходит
        else acceleration = 1;

        // rotation
        float MouseX = Input.GetAxis("Mouse X");
        if (MouseX != 0)
        {
            transform.Rotate(new Vector3(0, MouseX * 4, 0));
        }
    }

    private void FixedUpdate()
    {
        if (!IsAlive()) return;

        // проверка на полу игрок или нет
        if (Physics.Raycast(transform.position, Vector3.down, 0.4f))
        {
            _onFloor = true;
        }
        else
        {
            _onFloor = false;
        }

        Move();
        if (_fire) Fire();
        if (_jump && _onFloor) Jump();
        if (_boom) Boom();
    }

    private void Move()
    {
        // move
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 s = new Vector3(moveHorizontal, 0.0f, moveVertical);
        _rb.AddRelativeForce(s * acceleration * _rb.mass, ForceMode.Impulse);


        // animation move
        if (s != Vector3.zero)
        {
            _anim.SetFloat("SpeedMove", acceleration);
            _anim.SetBool("IsMove", true);
            _isMove = true;
        }
        else
        {
            _anim.SetFloat("SpeedMove", 0);
            _anim.SetBool("IsMove", false);
            _isMove = false;
        }
    }

    private void Jump()
    {
        _jump = false;
        _onFloor = false;
        _rb.AddForce(Vector3.up * 350, ForceMode.Impulse);
    }

    private void Fire()
    {
        _fire = false;

        if (bulls == 0) return;
        var bul = Instantiate(bullet, bulletStartPosition.position, transform.rotation).GetComponent<Bullet>();
        bul.Init(name);
        TakeBulls(-1);

        _clip.PlayOneShot(clipFire, 0.2f);
    }

    private void Boom()
    {
        _boom = false;

        if (bombs == 0) return;
        var b = Instantiate(bomb, bulletStartPosition.position, transform.rotation).GetComponent<Bomb>();
        b.Init();
        bombs--;
        ShowBomb(bombs);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp > 100) hp = 100;
        if (hp < 0) hp = 0;
        ShowHP(hp);
        if (!IsAlive()) Death();
    }
    public void TakeBulls(int bullCount)
    {
        bulls += bullCount;
        ShowBulls(bulls);
    }

    private void Death()
    {
        _anim.SetTrigger("IsDie");
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ближний бой
        var obj = collision.gameObject;
        if (obj.CompareTag("Enemy"))
        {
            obj.GetComponent<ITakeDamage>().TakeDamage(5 * acceleration);
            TakeDamage(10);
        }
    }

    public bool IsAlive()
    {
        if (hp <= 0)
            return false;
        else
            return true;
    }

    private void ShowHP(int _hp)
    {
        textHP.text = _hp.ToString();
    }

    private void ShowBulls(int _bul)
    {
        textBulls.text = _bul.ToString();
    }

    private void ShowBomb(int _bomb)
    {
        textBomb.text = _bomb.ToString();
    }

    private void PlaySoundsMove()
    {
        _clip.Stop();
        if (!_isMove) return;

        if (acceleration > 1)
        {
            _clip.PlayOneShot(clipRun, 0.3f);
        }
        else
        {
            _clip.PlayOneShot(clipStep, 0.2f);
        }
    }

    private void PlaySoundIdle()
    {
        _clip.Stop();
    }
}
