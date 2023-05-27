using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class HeroScript : MonoBehaviour
{
    [SerializeField] private bool _isGrounded;
    [SerializeField] private float _jupmForce = 6f;
    [SerializeField] private int _hitPoints;
    private Rigidbody2D _rBody;
    // private MusicControllerScript _musicControllerScript;
    private RythmScript _rythmScript;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private int _jumpActivatedBeat;

    // private bool _isAttackPressed1;
    // private bool _isAttackPressed2;
    // private bool _isAttackPressed3;
    private bool _isJump;
    private int _damageVizCount;


    void Start()
    {
        _rythmScript = GameObject.FindGameObjectWithTag("Rythm Controller").GetComponent<RythmScript>();

        _rBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _hitPoints = 3;

        // _isAttackPressed1 = false;
        // _isAttackPressed2 = false;
        // _isAttackPressed3 = false;
        _isGrounded = false;
        _isJump = false;
        _jumpActivatedBeat = 1;
    }

    void Update()
    {
        // if (_isJump && _rythmScript.rythmPoint && _jumpActivatedBeat + 2 == _rythmScript.bitNumber)
        //     EndJump();
        DamageVisualization();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DestroyEnemy(context);

            if (context.control.ToString() == "Key:/Keyboard/q")
            {
                _animator.SetTrigger("Hit_1");
            }
            if (context.control.ToString() == "Key:/Keyboard/w")
            {
                _animator.SetTrigger("Hit_2");
            }
            if (context.control.ToString() == "Key:/Keyboard/e")
            {
                _animator.SetTrigger("Hit_3");
            }
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && _isGrounded)
        {
            _animator.SetTrigger("Jump");
            _rBody.AddForce(new Vector2(0, _jupmForce), ForceMode2D.Impulse);
            _isJump = true;
            _jumpActivatedBeat = _rythmScript.bitNumber;
        }
    }
    private void DamageVisualization()
    {
        if (_damageVizCount != 0)
        {
            if (_spriteRenderer.color == Color.red)
                _damageVizCount += 1;

            if (_damageVizCount == 5)
            {
                _spriteRenderer.color = Color.white;
                _damageVizCount = 0;
            }
        }
    }

    private void EndJump()
    {
        _rBody.AddForce(new Vector2(0, _jupmForce * -1), ForceMode2D.Impulse);
        _isJump = false;
    }

    public void getDamage()
    {
        _hitPoints -= 1;
        if (_hitPoints < 0)
            SceneManager.LoadScene("DeathScreen");

        _damageVizCount = 1;
        _spriteRenderer.color = Color.red;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            _isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            _isGrounded = false;
        }
    }

    private void DestroyEnemy(InputAction.CallbackContext context)
    {
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        EnemyScript currentEnemyScrpt;
        char c;

        foreach (GameObject enemy in enemyObjects)
        {
            currentEnemyScrpt = enemy.GetComponent<EnemyScript>();
            c = currentEnemyScrpt.GetKeyToDestroy();
            if ((context.control.ToString() == "Key:/Keyboard/" + c) && currentEnemyScrpt.GetEnemyCanBeDestroy())
            {
                Destroy(enemy);
            }
        }
    }
}
